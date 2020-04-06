using System;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Profundidade { get; set; }
       
        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
            Validar();
        }
        void Validar()
        {
            Validacoes.ValidarSeMenorIgualMinimo(Altura, 1, "A altura precisa se maior ou igual a 1");
            Validacoes.ValidarSeMenorIgualMinimo(Largura, 1, "A largura precisa se maior ou igual a 1");
            Validacoes.ValidarSeMenorIgualMinimo(Profundidade, 1, "A profundidade precisa se maior ou igual a 1");
        }
        public string DescricaoFormatada()
        {
            return $"LxAxP {Altura} x {Largura} x {Profundidade}";
        }
    }
}
