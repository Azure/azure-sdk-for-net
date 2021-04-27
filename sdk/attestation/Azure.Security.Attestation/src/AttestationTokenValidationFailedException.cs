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
        /// <param name="message"></param>
        public AttestationTokenValidationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Represents the entity which had signed the attestation token, or null if the token was unsecured.
        /// </summary>
        public IReadOnlyList<AttestationSigner> Signers { get; internal set; }

        /// <summary>
        /// Represents the attestation token which was being validated.
        /// </summary>
        public AttestationToken Token { get; internal set; }
    }
}
