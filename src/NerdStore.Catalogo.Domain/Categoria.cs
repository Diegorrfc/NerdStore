using System;
using System.Collections.Generic;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Validar();
        }
        protected Categoria() { }
       
        public string Nome
        {
            get;
            private set;
        }
        public int Codigo
        {
            get;
            private set;
        }
        public ICollection<Produto> Produtos { get; set; }

        public DateTime DataCadastro { get; private set; }

        void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, $"A propriedade {Nome} não pode ser vazia");
            Validacoes.ValidarSeMenorIgualMinimo(Codigo, 0, $"A propriedade {Codigo} não pode ser menor do que zero");
        }

    }
}
