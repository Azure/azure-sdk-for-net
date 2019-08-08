using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal interface ICryptographyProvider
    {
        Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken);

        EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken);

        Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken);

        DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken);

        Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken);

        WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken);

        Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken);

        UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken);

        Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken);

        SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken);

        Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken);

        VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken);
    }
}
