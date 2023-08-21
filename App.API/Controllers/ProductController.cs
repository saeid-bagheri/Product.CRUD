using App.Core.Application.DTOs.Product;
using App.Core.Application.Features.Products.Requests.Commands;
using App.Core.Application.Features.Products.Requests.Queries;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Endpoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet("AllProducts")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost("CreateProduct")]
        public async Task<ActionResult> Post([FromBody] CreateProductDto product)
        {
            var command = new CreateProductCommand() { CreateProductDto = product };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<ProductController>
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> Put([FromBody] UpdateProductDto product)
        {
            var command = new UpdateProductCommand() { UpdateProductDto = product };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
