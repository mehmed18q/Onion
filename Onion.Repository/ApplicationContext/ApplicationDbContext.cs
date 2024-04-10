﻿using Microsoft.EntityFrameworkCore;
using Onion.Data.Access;
using Onion.Data.Account;
using Onion.Data.Music;
using Onion.Data.Site;

namespace Onion.Repository.ApplicationContext
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Singer> Singers { get; set; }
		public DbSet<Song> Songs { get; set; }
		public DbSet<SongAttractiveness> SongAttractiveness { get; set; }
	}
}
