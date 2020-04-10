using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NerdStore.Catalogo.Application.ViewModel;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _repository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMapper mapper)
        {
            _repository = produtoRepository;
            _estoqueService = estoqueService;
            _mapper = mapper;
        }
        public async Task Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _repository.Adicionar(produto);
           await _repository.UnitOfWork.Commit();
        }

        public Task Adicionar(CategoriaViewModel categoriaViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new DomainException("N foi possivel debitar o estoque");
            }
            return _mapper.Map<ProdutoViewModel>(await _repository.ObterPorId(id));
        }

        public Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}
