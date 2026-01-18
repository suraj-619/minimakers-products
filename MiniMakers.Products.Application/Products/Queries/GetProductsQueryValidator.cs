using FluentValidation;

namespace MiniMakers.Products.Application.Products.Queries;

public class GetProductsQueryValidator  : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(x=>x.PageNumber).GreaterThanOrEqualTo(0).WithMessage("PageNumber must be greater than or equal to 0.");
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage("PageSize must be greater than or equal to 0.");
        RuleFor(x=>x.MaxPrice)
            .GreaterThanOrEqualTo(x=>x.MinPrice)
            .When(x=>x.MinPrice.HasValue && x.MaxPrice.HasValue)
            .WithMessage("MaxPrice must be greater than or equal to MinPrice.");
    }
    
}
