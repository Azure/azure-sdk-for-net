using System;
using System.Collections.Generic;

namespace Azure.Security.Keyvault.Keys
{
    public class KeyBase
    {
        private KeyAttributes _attributes;
        
        public string Version { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string VaultId { get; set; }
        public string VaultUrl { get; set; }
        public bool Managed { get; private set; }
         public IDictionary<string, string> Tags { get; set; }

        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        public DateTime? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        public DateTime? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }

        public DateTime? Created => _attributes.Created;

        public DateTime? Updated => _attributes.Updated;

        public string RecoveryLevel => _attributes.RecoveryLevel;

    }
}
