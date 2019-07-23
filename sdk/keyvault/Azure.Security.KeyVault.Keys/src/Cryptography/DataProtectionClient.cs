using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public class DataProtectionClient
    {
        protected DataProtectionClient()
        {

        }

        public DataProtectionClient(TokenCredential credential)
        {

        }

        public DataProtectionClient(TokenCredential credential, CryptographyClientOptions options)
        {

        }

        public DataProtectionClient(TokenCredential credential)
        {

        }

        public DataProtectionClient(TokenCredential credential, CryptographyClientOptions options)
        {

        }

        public async Task<JsonWebEncryption> ProtectAsync(string keyId, byte[] data, CancellationToken cancellationToken = default)
        {

        }

        public JsonWebEncryption Protect(string keyId, byte[] data, CancellationToken cancellationToken = default)
        {

        }

        public async Task<JsonWebEncryption> ProtectAsync(Key key, CancellationToken cancellationToken = default)
        {

        }

        public JsonWebEncryption Protect(Key key, CancellationToken cancellationToken = default)
        {

        }
        public async Task<byte[]> UnprotectAsync(JsonWebEncryption jwe, CancellationToken cancellationToken = default)
        {

        }

        public byte[] Unprotect(JsonWebEncryption jwe, CancellationToken cancellationToken = default)
        {

        }
    }
}
