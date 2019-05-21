using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.Keyvault.Keys
{
    public class Key : KeyBase
    {
        public JsonWebKey KeyMaterial { get; set; }
    }
}
