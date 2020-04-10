using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Catalogo.Application.ViewModel;

namespace NerdStore.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {       
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);
        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();
        Task Adicionar(ProdutoViewModel produtoViewModel);
        Task Adicionar(CategoriaViewModel categoriaViewModel);
        Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}
