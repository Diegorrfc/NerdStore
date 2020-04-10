using System;
namespace NerdStore.Catalogo.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
        public Guid CategoriaID { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Profundidade { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
