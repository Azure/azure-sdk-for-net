using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    public class CryptographyClient
    {
        private object _initLock;
        private JsonWebKey _key;
        private Uri _keyId;

        /// <summary>
        /// Protected cosntructor for mocking
        /// </summary>
        protected CryptographyClient()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            _keyId = keyId ?? throw new ArgumentNullException(nameof(keyId));
        }

        public CryptographyClient(JsonWebKey key, TokenCredential credential)
        {

        }

        public CryptographyClient(JsonWebKey key, TokenCredential credential, CryptographyClientOptions options)
        {

        }

        public string KeyId { get; }


        public virtual async ValueTask<Key> GetKeyAsync(CancellationToken cancellationToken = default)
        {

        }

        public virtual JsonWebKey GetKey(CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<byte[]> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, Stream plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, Stream ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {

        }

        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {

        }











        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
        }

        public virtual EncryptResult Encrypt(byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual byte[] Decrypt(byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual WrapResult WrapKey(byte[] key, KeyWrapAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual byte[] UnwrapKey(byte[] encryptedKey, KeyWrapAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual SignResult Sign(byte[] digest, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual bool Verify(byte[] digest, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual SignResult SignData(byte[] data, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual bool VerifyData(byte[] data, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual SignResult SignData(Stream data, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual bool VerifyData(Stream data, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }
    }
}
