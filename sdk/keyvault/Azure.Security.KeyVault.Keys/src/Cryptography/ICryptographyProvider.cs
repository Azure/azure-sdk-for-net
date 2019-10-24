// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal interface ICryptographyProvider
    {
        bool ShouldRemote { get; }

        bool SupportsOperation(KeyOperation operation);

        Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default);

        EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default);

        Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default);

        DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default);

        Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default);

        WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default);

        Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default);

        UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default);

        Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default);

        SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default);

        Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default);

        VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default);
    }
}
