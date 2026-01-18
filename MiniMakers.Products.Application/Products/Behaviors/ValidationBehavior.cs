using FluentValidation;
using MediatR;
using MiniMakers.Products.Application.Products.Queries;

namespace MiniMakers.Products.Application.Products.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        // Apply defaults for GetProductsQuery if not provided
        if (request is GetProductsQuery query)
        {
            request = (TRequest)(object)new GetProductsQuery
            {
                Category = query.Category,
                MinPrice = query.MinPrice,
                MaxPrice = query.MaxPrice,
                IsActive = query.IsActive,
                PageNumber = query.PageNumber == 0 ? 1 : query.PageNumber,
                PageSize = query.PageSize == 0 ? 10 : query.PageSize
            };
        }

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
