// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// The result of an Azure guest attestation: a token sealed to the attested virtual machine.
    /// </summary>
    /// <remarks>
    /// The service encrypts the token to a key held in the virtual machine's TPM, so only that virtual machine can decrypt it,
    /// for example with the <see href="https://github.com/Azure/confidential-computing-cvm-guest-attestation">guest attestation library</see>.
    /// The decrypted token is an attestation token: read it with <see cref="AttestationToken.Deserialize(string)"/>, validate it with
    /// <see cref="AttestationToken.ValidateToken(AttestationTokenValidationOptions, System.Collections.Generic.IReadOnlyList{AttestationSigner}, System.Threading.CancellationToken)"/>,
    /// and get its claims with <see cref="AttestationToken.GetBody{T}"/> and <see cref="AttestationResult"/>.
    /// </remarks>
    [CodeGenType("SealedAttestationResult")]
    public partial class SealedAttestationResult
    {
    }
}
