using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class RsaKeyCreateOptions : KeyCreateOptions
    {
        public int KeySize { get; set; }
        
        public RsaKeyCreateOptions(int size, string name, List<string> keyOps, DateTime? notBefore, DateTime? expires, Dictionary<string, string> tags)
            :base(name)
        {
            KeySize = size;
            KeyOps = keyOps;
            KeyType = JsonWebKeyType.Rsa;
            NotBefore = notBefore;
            Expires = expires;
            Tags = new Dictionary<string, string>(tags);
        }
    }
}
