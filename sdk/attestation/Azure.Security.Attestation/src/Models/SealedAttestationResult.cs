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
    /// <see cref="AttestationToken.ValidateToken(AttestationTokenValidationOptions, System.Collections.Generic.IReadOnlyList{AttestationSigner}, System.Threading.CancellationToken)"/>
    /// against the signing certificates returned by <see cref="AttestationClient.GetSigningCertificates(System.Threading.CancellationToken)"/>,
    /// and get its claims with <see cref="AttestationToken.GetBody{T}"/> and <see cref="AttestationResult"/>.
    /// </remarks>
    // Makes the generated model public, for AttestAzureGuest; the generator emits the accessibility declared here.
    [CodeGenType("SealedAttestationResult")]
    public partial class SealedAttestationResult
    {
        /// <summary>
        /// Gets the sealed token: the Base64Url-encoded JSON envelope that holds the attestation token, encrypted to the
        /// virtual machine's TPM key, together with its encryption parameters. It is not itself a JSON Web Token; decrypt it
        /// inside the virtual machine, then read the result with <see cref="AttestationToken.Deserialize(string)"/>.
        /// </summary>
        // Replaces the generated doc, which describes the value as a JSON Web Token.
        public string Token { get; }
    }
}
