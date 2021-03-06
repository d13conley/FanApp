﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hello.Data;
using Hello.Data.Models;

namespace Hello.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			builder.Entity<ApplicationArtist>()
			.Property(p => p.Id)
			.HasColumnName("ArtistId");

			builder.Entity<ApplicationUser>()
			.Property(p => p.Id)
			.HasColumnName("UserId");



        //    builder.Entity<Like>()
        //.Property(p => p.LikeId)
        //.HasColumnName("LikeId");
         
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

		public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<ApplicationArtist> ApplicationArtist { get; set; }
		public DbSet<Post> Post { get; set; }
		public DbSet<Follow> Follow { get; set; }
		public DbSet<UserFollow> UserFollow { get; set; }
        public DbSet<InboxUserVm> Inbox { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
