using Application.Common.Commands.ProductCommands.Create;
using Application.Common.Commands.ProductCommands.Delete;
using Application.Common.Commands.ProductCommands.Update;
using Application.Common.DTOs;
using Application.Common.Models;
using Application.Common.Queries.ProductQueries.GetProductWithPagination;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetProductsWithPaginationQuery([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }        

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id));

            return NoContent();
        }
    }
}
