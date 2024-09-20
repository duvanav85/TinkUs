using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Commons.Settings
{
    public class AppSettings
    {
        public AzureB2C AzureB2C { get; set; }
    }

    public class AzureB2C
    {
        public string Tenant { get; set; }
        public string ClientId { get; set; }
        public string Policy { get; set; }
        public string Instance { get; set; }
    }
}
