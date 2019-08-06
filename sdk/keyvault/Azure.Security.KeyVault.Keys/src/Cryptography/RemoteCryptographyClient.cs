using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public class RemoteCryptographyClient
    {
        protected CryptographyClient()
        {

        }

        public CryptographyClient(TokenCredential credential)
        {

        }

        public CryptographyClient(TokenCredential credential, CryptographyClientOptions options)
        {
        }


        public virtual async Task<Response<EncryptResult>> EncryptAsync(string keyId, EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual Response<EncryptResult> Encrypt(string keyId, EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<Response<DecryptResult>> DecryptAsync(string keyId, EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
        }

        public virtual Response<DecryptResult> Decrypt(string keyId, EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<Response<WrapResult>> WrapKeyAsync(string keyId, KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {

        }

        public virtual Response<WrapResult> WrapKey(string keyId, KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<Response<UnwrapResult>> UnwrapKeyAsync(string keyId, KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {

        }


        public virtual Response<UnwrapResult> UnwrapKey(string keyId, KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<Response<SignResult>> SignAsync(string keyId, SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {

        }

        public virtual Response<SignResult> Sign(string keyId, SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<Response<VerifyResult>> VerifyAsync(string keyId, SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {

        }

        public virtual Response<VerifyResult> Verify(string keyId, SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {

        }

    }
}
