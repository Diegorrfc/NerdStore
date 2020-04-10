using System;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModel;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomaindToViewModelMappingProfile : Profile
    {
        public DomaindToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.Altura, o => o.MapFrom(p => p.Dimensoes.Altura))
                .ForMember(d => d.Largura, o => o.MapFrom(p => p.Dimensoes.Largura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(p => p.Dimensoes.Profundidade));
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
