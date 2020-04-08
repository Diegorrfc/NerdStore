using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> DebitarEstoque(Guid id, int quantidade)
        {
            Produto produto = await _produtoRepository.ObterPorId(id);
            if (produto == null) return false;
            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            return await _produtoRepository.UnitOfWork.Commit();
        }      

        public async Task<bool> ReporEstoque(Guid id, int quantidade)
        {
            Produto produto = await _produtoRepository.ObterPorId(id);
            if(produto== null) return false;

            produto.ReporEstoque(quantidade);           

            return await _produtoRepository.UnitOfWork.Commit();
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
