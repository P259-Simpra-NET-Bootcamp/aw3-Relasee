using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimApi.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimApi.Data;

[Table("Category", Schema = "dbo")]
public class Category : BaseModel
{
    public string Name { get; set; }
    public int Order { get; set; }

    public ICollection<Product> Products { get; set; } // 1-M ilişki için Products koleksiyonu eklendi
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Order).IsRequired(true);

        builder.HasIndex(x => x.Name).IsUnique(true);
    }
}
