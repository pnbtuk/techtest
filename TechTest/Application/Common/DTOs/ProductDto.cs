using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class ProductDto : IMapFrom<Product>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
                //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                //.ForMember(d => d.Description, opt => opt.MapFrom(d => d.Description))
                //.ForMember (d => d.Price, opt => opt.MapFrom(d => d.Price));
        }
    }
}
