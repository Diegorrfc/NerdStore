using System;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObject;
using Xunit;

namespace NerdStore.Domain.Tests
{
    public class DimensoesTest
    {
        [Fact]
        public void Dimensoes_validar_ValidacoesDevemRetornarExceptionsComMensagens()
        {
            //arrage
            string nome = "Produto";
            string descricao = "Descricao";
            bool ativo = true;
            int quantidade = 10;
            DateTime dateTime = DateTime.UtcNow;
            string imagem = "imagem";
            Guid guid = Guid.NewGuid();
          
            // Act
            var ex = Assert.Throws<DomainException>(() => new Produto(nome, descricao, ativo, quantidade, dateTime, imagem, guid, new Dimensoes(0,1,3))
            );
            Assert.Equal("A altura precisa se maior ou igual a 1", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto(nome, descricao, ativo, quantidade, dateTime, imagem, guid, new Dimensoes(2, 0, 3))
            );
            Assert.Equal("A largura precisa se maior ou igual a 1", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto(nome, descricao, ativo, quantidade, dateTime, imagem, guid, new Dimensoes(2, 2, 0))
            );
            Assert.Equal("A profundidade precisa se maior ou igual a 1", ex.Message);
        }
    }
}
