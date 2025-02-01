using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExampleApp.Models
{
    public static class SnakeCaseDatabaseNames
    {
        public static void UseSnakeCaseDatabaseNames(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.GetTableName() is string tableName)
                {
                    entity.SetTableName(tableName.ToSnakeCase());
                }

                foreach (IMutableProperty property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
                }

                foreach (IMutableKey key in entity.GetKeys())
                {
                    if (key.GetName() is string keyName)
                    {
                        key.SetName(keyName.ToSnakeCase());
                    }
                }

                foreach (IMutableForeignKey key in entity.GetForeignKeys())
                {
                    if (key.GetConstraintName() is string constraintName)
                    {
                        key.SetConstraintName(constraintName.ToSnakeCase());
                    }
                }

                foreach (IMutableIndex index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }
    }
}