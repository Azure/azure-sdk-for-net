// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Azure.Security.KeyVault.Keys.Tests
{
    internal class ThrowingCryptographyProvider : ICryptographyProvider
    {
        internal const int CRYPT_E_NO_PROVIDER = unchecked((int)0x80092006);

        public bool CanRemote => true;

        public bool SupportsOperation(KeyOperation operation) => true;

        public DecryptResult Decrypt(DecryptParameters options, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<DecryptResult> DecryptAsync(DecryptParameters options, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public EncryptResult Encrypt(EncryptParameters options, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<EncryptResult> EncryptAsync(EncryptParameters options, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);

        public Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default) => throw new CryptographicException(CRYPT_E_NO_PROVIDER);
    }
}
