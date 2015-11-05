﻿namespace ErisSystem.Data
{
    using System;
    using System.Data.Entity;

    using ErisSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ErisSystemContext : DbContext, IErisSystemContext
    {
        public ErisSystemContext()
            :base("name=ErisSystemContext")
        {

        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Hitman> Hitmen { get; set; }

        public IDbSet<Contract> Contracts { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<HitmanRating> HitmanRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
