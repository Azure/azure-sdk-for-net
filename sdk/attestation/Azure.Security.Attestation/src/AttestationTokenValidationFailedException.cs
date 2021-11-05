// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Exception thrown when a call to <see cref="AttestationToken.ValidateToken(AttestationTokenValidationOptions, IReadOnlyList{AttestationSigner}, System.Threading.CancellationToken)"/> fails.
    ///
    /// Normally, the only way that this exception will be thrown is if the customer's
    /// <see cref="AttestationTokenValidationOptions.TokenValidated"/> event delegate
    /// indicates a validation failure.
    /// </summary>
    public class AttestationTokenValidationFailedException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationTokenValidationFailedException"/> class.
        /// </summary>
        /// <param name="message">Message helping explain the source of the exception.</param>
        public AttestationTokenValidationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Represents a set of signing certificates which may have signed the attestation token, or null if there are no official signers.
        /// </summary>
        public IReadOnlyList<AttestationSigner> Signers { get; internal set; }

        /// <summary>
        /// Represents the attestation token which was being validated.
        /// </summary>
        public AttestationToken Token { get; internal set; }

        internal static void ThrowFailure(IReadOnlyList<AttestationSigner> signers, AttestationToken token)
        {
            throw new AttestationTokenValidationFailedException($"An Attestation Token was rejected by an {nameof(AttestationTokenValidationOptions)}.{nameof(AttestationTokenValidationOptions.TokenValidated)} event handler.")
            {
                Signers = signers,
                Token = token,
            };
        }
    }
}
