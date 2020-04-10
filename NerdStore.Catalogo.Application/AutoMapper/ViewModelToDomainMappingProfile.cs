using System;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModel;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(c => new Produto(c.Nome, c.Descricao, c.Ativo,
                c.Valor, c.DataCadastro, c.Imagem,c.CategoriaID,
                new Dimensoes(c.Altura, c.Largura, c.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c=> new Categoria(c.Nome,c.Codigo));
        }
    }
}
