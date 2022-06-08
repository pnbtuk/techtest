using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Commands.ProductCommands.Update
{
    public record UpdateProductCommand : IRequest
    {
        public int Id { get; init; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new Exception($"{nameof(Product)}\" ({request.Id}) was not found.");                
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
