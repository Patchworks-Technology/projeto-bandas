﻿using Microsoft.EntityFrameworkCore;
using ProjetoBandas.Entidades;
using System.Collections.Generic;

namespace ProjetoBandas
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BandasContext(serviceProvider.GetRequiredService<DbContextOptions<BandasContext>>()))
            {
                if (context.Bandas.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bandas.AddRange(

                    new Banda { Id = 1, Nome = "Metallica", AnoFormacao = DateTime.Now.AddYears(-20) },
                    new Banda { Id = 2, Nome = "Iron Maiden", AnoFormacao = DateTime.Now.AddYears(-22) },
                    new Banda { Id = 3, Nome = "Deep Purple", AnoFormacao = DateTime.Now.AddYears(-25) }
                );

                context.SaveChanges();
            }
        }
    }
}