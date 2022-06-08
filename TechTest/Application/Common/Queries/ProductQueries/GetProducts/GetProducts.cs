using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Queries.ProductQueries.GetProducts
{
    public record GetProductsQuery : IRequest<List<Product>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery,List<Product>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .ProjectTo<Product>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
