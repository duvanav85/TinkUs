using Admin.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Admin.Data
{
    public class TinkContext : ModelContext
    {
        private string ConnString { get; set; }
        public TinkContext(DbContextOptions<TinkContext> options)
            : base(options)
        {
            ConnString = ConnectionString();
        }
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        public virtual void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public virtual void SetDetached(object entity)
        {
            Entry(entity).State = EntityState.Detached;
        }
        public virtual void SetCurrentValues(object existing, object newValues)
        {
            Entry(existing).CurrentValues.SetValues(newValues);
        }

        public virtual void SetCommandTimeout(int? time)
        {
            Database.SetCommandTimeout(time);
        }

        public virtual void ExecuteScript(string script)
        {
            Database.ExecuteSqlRaw(script);
        }
        public static string ConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            return configuration.ToString() ?? "";
        }
    }
}
