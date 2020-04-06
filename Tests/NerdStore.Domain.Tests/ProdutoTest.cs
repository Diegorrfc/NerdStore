using System;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObject;
using Xunit;

namespace NerdStore.Domain.Tests
{
    public class ProdutoTest
    {       
        [Fact]
        public void Produto_validar_ValidacoesDevemRetornarExceptionsComMensagens()
        {
            // Arrange

            Dimensoes dimensoes = new  Dimensoes(2, 2, 2);

            // Act
            var ex = Assert.Throws<DomainException>(() => new Produto(string.Empty, "Descricao", true, 10, DateTime.UtcNow, "imagem", Guid.NewGuid(), dimensoes)
            );

            //Assert
            Assert.Equal($"o camo {nameof(Produto.Nome)} está vazio", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto("produto 1", string.Empty, true, 10, DateTime.UtcNow, "imagem", Guid.NewGuid(), dimensoes)
           );
            //Assert
            Assert.Equal($"o camo {nameof(Produto.Descricao)} está vazio", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto("produto 1", "Descricao", true, 10, DateTime.UtcNow, "imagem", Guid.Empty, dimensoes)
        );
            //Assert
            Assert.Equal($"O campo  {nameof(Produto.CategoriaID)} não pode ser vazio", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto("produto", "Descricao", true, 10, DateTime.UtcNow, string.Empty, Guid.NewGuid(), dimensoes)
          );
            //Assert
            Assert.Equal($"o camo {nameof(Produto.Imagem)} está vazio", ex.Message);

            // Act
            ex = Assert.Throws<DomainException>(() => new Produto("produto", "Descricao", true, 0, DateTime.UtcNow, "imagem", Guid.NewGuid(), dimensoes)
          );
            //Assert
            Assert.Equal($"O campo  {nameof(Produto.Valor)} não pode ser menor ou igual a 0",ex.Message);

         
        }
    }
}
