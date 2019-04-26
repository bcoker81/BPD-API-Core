using BPD01_WebApi_Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BPD01_WebApi_Core.Entities
{
    public class BpdDbContext : DbContext
    {
        public BpdDbContext(DbContextOptions<BpdDbContext> options)
         : base(options){
        }

         public DbSet<GrantModel> Grants { get; set; }
        public DbSet<GrantExtensionModel> GrantExtensions { get; set; }
        public DbSet<ReportDateModel> GrantReportDates { get; set; }
        public DbSet<CommentModel> GrantComments { get; set; }
        public DbSet<AttachmentModel> Attachments { get; set; }
        public DbSet<DocumentModel> AttachmentDocuments { get; set; }
        public DbSet<PickListModel> PickLists { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ExpenditureModel> Expenditures { get; set; }
        public DbSet<GANModel> Gans { get; set; }
    }
}