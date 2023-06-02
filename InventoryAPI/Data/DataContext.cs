using InventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure Products table
			modelBuilder.Entity<Product>()
				.HasKey(p => p.ProductID);

			// Configure Customers table
			modelBuilder.Entity<Customer>()
				.HasKey(c => c.CustomerID);

			// Configure Quotations table
			modelBuilder.Entity<Quotation>()
				.HasKey(q => q.QuotationID);

			modelBuilder.Entity<Quotation>()
				.HasOne(q => q.Customer)
				.WithMany()
				.HasForeignKey(q => q.CustomerID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Quotation>()
				.HasOne(q => q.Product)
				.WithMany()
				.HasForeignKey(q => q.ProductID)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure Invoices table
			modelBuilder.Entity<Invoice>()
				.HasKey(i => i.InvoiceID);

			modelBuilder.Entity<Invoice>()
				.HasOne(i => i.Customer)
				.WithMany()
				.HasForeignKey(i => i.CustomerID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Invoice>()
				.HasOne(i => i.Product)
				.WithMany()
				.HasForeignKey(i => i.ProductID)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure CreditNotes table
			modelBuilder.Entity<CreditNote>()
				.HasKey(cn => cn.CreditNoteID);

			modelBuilder.Entity<CreditNote>()
				.HasOne(cn => cn.Customer)
				.WithMany()
				.HasForeignKey(cn => cn.CustomerID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<CreditNote>()
				.HasOne(cn => cn.Invoice)
				.WithMany()
				.HasForeignKey(cn => cn.InvoiceID)
				.OnDelete(DeleteBehavior.Restrict);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Quotation> Quotations { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<CreditNote> CreditNotes { get; set; }
	}
}
