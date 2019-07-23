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
        protected CryptographyClient()
        {

        }

        public CryptographyClient(Uri keyId, TokenCredential credential)
        {

        }

        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {

        }

        public CryptographyClient(Key key, TokenCredential credential)
        {

        }

        public CryptographyClient(Key key, TokenCredential credential, CryptographyClientOptions options)
        {

        }

        public string KeyId { get; }


        public virtual async ValueTask<Key> GetKeyAsync(CancellationToken cancellationToken = default)
        {
            // if the key hasn't already been fetched and cached locally this method fetches and caches the key
            // this method is ultimately what other methods which require local key data will call
        }

        public virtual async Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // plaintext is required
            // iv is required for some algorithms, for instance AESCBC
            // authenticationData is never required but it only makes sense in the case of authenticated encryption algorithms, for instance AES-GCM AESCBC-HMAC
            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required

            // this method **could** be performed locally in the case that the public portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric
        }

        public virtual async Task<byte[]> DecryptAsync(byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // ciphertext is required
            // iv is required for some algorithms, for instance AES
            // authenticationData is never required but it only makes sense in the case of authenticated encryption algorithms, for instance AES-GCM AES-HMAC
            // if authenticationData is specified authenticationTag must also be specified
            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required

            // this method **could** be performed locally only is private portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric
        }

        public virtual async Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv = default, byte[] authenticationData = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required

            // this method would need local crypto support as it might require multi-block encryption
            // in the case that someone specified a stream which is within the service limited size for value we **could** read the entire stream and send the request to the service
        }

        public virtual async Task<byte[]> DecryptAsync(Stream ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method would need local crypto support as it might require multi-block encryption
            // in the case that someone specified a stream which is within the service limited size for value we **could** read the entire stream and send the request to the service

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<WrapKeyResult> WrapKeyAsync(byte[] key, KeyWrapAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method **could** be performed locally in the case that the public portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<byte[]> UnwrapKeyAsync(byte[] encryptedKey, KeyWrapAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method **could** be performed locally only if the private portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<SignResult> SignAsync(byte[] digest, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method **could** be performed locally only is private portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<bool> VerifyAsync(byte[] digest, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method **could** be performed locally in the case that the public portion of the key is available locally for asymmetric keys, or all the key data in the case of symmetric

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<SignResult> SignDataAsync(byte[] data, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method would need local crypto support as requires hashing the supplied data with the appropriate hash algorithm

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<bool> VerifyDataAsync(byte[] data, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method would need local crypto support as requires hashing the supplied data with the appropriate hash algorithm

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<SignResult> SignDataAsync(Stream data, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method would need local crypto support as requires hashing the supplied data with the appropriate hash algorithm

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual async Task<bool> VerifyDataAsync(Stream data, byte[] signature, SignatureAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {
            // this method would need local crypto support as requires hashing the supplied data with the appropriate hash algorithm

            // algorithm is not required in the case that we have the key locally and know the keytype (in which case we can use the best available algorithm for the keytype), otherwise it would be required
        }

        public virtual Key GetKey(CancellationToken cancellationToken = default)
        {

        }

        public virtual EncryptResult Encrypt(byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual byte[] Decrypt(byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, EncryptionAlgorithm algorithm = default, CancellationToken cancellationToken = default)
        {

        }

        public virtual WrapKeyResult WrapKey(byte[] key, KeyWrapAlgorithm algorithm = default, CancellationToken cancellationToken = default)
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
