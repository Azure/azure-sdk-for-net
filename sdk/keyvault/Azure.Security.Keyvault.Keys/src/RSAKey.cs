using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class RSAKey
    {
        public int KeySize { get; set; }
        public string Name { get; set; }
        public JsonWebKey KeyMaterial { get; set; }
        public DateTime? NotBefore { get; set; }
        public DateTime? Expires { get; set; }
        public IDictionary<string, string> Tags { get; set; }
    }
}
