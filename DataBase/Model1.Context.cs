﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectEducationalPracticeEntities : DbContext
    {
        public ProjectEducationalPracticeEntities()
            : base("name=ProjectEducationalPracticeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Fault> Fault { get; set; }
        public virtual DbSet<Performer> Performer { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Repair_request> Repair_request { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
