using System;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Produto(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaID, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaID = categoriaID;
            Dimensoes = dimensoes;
            Validar();
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Guid CategoriaID { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Validacoes.ValidarSeNulo(categoria, "A categoria não pode ser nula");
            Categoria = categoria;
            CategoriaID = categoria.Id;
        }
        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "Desciricao não pode ser vazia");
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (PossuiEstoque(quantidade)) throw new DomainException(); 
            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            if(quantidade < 0) quantidade *= -1;
            QuantidadeEstoque += quantidade;
        }
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, $"o camo {nameof(Nome)} está vazio");
            Validacoes.ValidarSeVazio(Descricao, $"o camo {nameof(Descricao)} está vazio");
            Validacoes.ValidarSeDiferente(CategoriaID, Guid.Empty, $"O campo  {nameof(CategoriaID)} não pode ser vazio");
            Validacoes.ValidarSeVazio(Imagem, $"o camo {nameof(Imagem)} está vazio");
            Validacoes.ValidarSeMenorIgualMinimo(Valor, 0, $"O campo  {nameof(Valor)} não pode ser menor ou igual a 0");
        }

    }
   
}
