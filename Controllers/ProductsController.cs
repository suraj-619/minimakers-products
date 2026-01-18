using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMakers.Products.Application.Products.Queries;


namespace MiniMakers.Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
