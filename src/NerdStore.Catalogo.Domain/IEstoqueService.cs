using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid id, int quantidade);
        Task<bool> ReporEstoque(Guid id, int quantidade);
    }
}
