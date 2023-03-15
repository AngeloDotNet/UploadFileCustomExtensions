namespace UploadFileCustomExtensions.DataAccessLayer;

public class UploadFilesDbContext : DbContext
{
    public UploadFilesDbContext(DbContextOptions<UploadFilesDbContext> options) : base(options)
    {
    }

    public virtual DbSet<ImageEntity> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}