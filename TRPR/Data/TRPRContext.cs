﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRPR.Models;

namespace TRPR.Data
{
    public class TRPRContext : DbContext
    {
        public TRPRContext (DbContextOptions<TRPRContext> options)
            : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<PaperInfo> PaperInfos { get; set; }
        public DbSet<Recommend> Recommends { get; set; }
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<ReviewAgain> ReviewAgains { get; set; }
        public DbSet<ReviewAssign> ReviewAssigns { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ReviewFile> ReviewFiles { get; set; }
        public DbSet<ResearchInstitute> ResearchInstitutes { get; set; }
        public DbSet<PaperFile> PaperFiles { get; set; }
        public DbSet<ResearchExpertise> ResearchExpertises { get; set; }
        public DbSet<AuthoredPaper> AuthoredPapers { get; set; }
        public DbSet<PaperKeyword> PaperKeywords { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRPR");


            //Add a unique index to the researchers email
            modelBuilder.Entity<Researcher>()
            .HasIndex(p => p.ResEmail)
            .IsUnique();

            //Many to Many Authored - Paper
            modelBuilder.Entity<AuthoredPaper>()
            .HasKey(t => new { t.ResID, t.PaperID });

            //Many to Many Researcher - Expertise
            modelBuilder.Entity<ResearchExpertise>()
            .HasKey(t => new { t.ResID, t.ExpID });

            //Many to Many Researcher - Institute
            modelBuilder.Entity<ResearchInstitute>()
            .HasKey(t => new { t.ResID, t.InstID });

            //Many to Many Review - File
            modelBuilder.Entity<ReviewFile>()
            .HasKey(t => new { t.RevID, t.FileID });

            //Many to Many Paper - File
            modelBuilder.Entity<PaperFile>()
            .HasKey(t => new { t.PaperID, t.FileID });

            //Many to Many Paper - Keyword
            modelBuilder.Entity<PaperKeyword>()
            .HasKey(t => new { t.PaperID, t.KeyID });
        }
    }
}
