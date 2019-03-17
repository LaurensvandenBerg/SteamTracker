using Microsoft.EntityFrameworkCore;
using SteamTracker.Data.Models;

namespace SteamTracker.Data
{
	public class SteamContext : DbContext
	{
		public SteamContext(DbContextOptions<SteamContext> options) : base(options) { }

		public DbSet<Game> Games { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<OwnerShip> OwnerShips { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OwnerShip>()
				.HasOne(p => p.Player)
				.WithMany(o => o.Owns)
				.HasForeignKey(p => p.PlayerId)
				.HasConstraintName("ForeignKey_Ownership_Player");

			builder.Entity<OwnerShip>()
				.HasOne(g => g.Game)
				.WithMany(o => o.Players)
				.HasForeignKey(p => p.GameId)
				.HasConstraintName("ForeignKey_Ownership_Game");

			builder.Entity<OwnerShip>()
				.HasKey(o => new { o.GameId, o.PlayerId });
		}
	}
}
