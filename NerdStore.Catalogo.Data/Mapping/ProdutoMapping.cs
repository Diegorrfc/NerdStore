﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Descricao)
              .IsRequired()
              .HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
              .IsRequired()
              .HasColumnType("varchar(250)");

            builder.OwnsOne(p => p.Dimensoes, dm =>
            {
                dm.Property(d => d.Altura)
                .HasColumnName("Altura")
                .HasColumnType("int");

                dm.Property(d => d.Largura)
               .HasColumnName("Largura")
               .HasColumnType("int");

                dm.Property(d => d.Profundidade)
               .HasColumnName("Profundidade")
               .HasColumnType("int");

            });

            builder.ToTable("Produtos");

        }
    }
}
