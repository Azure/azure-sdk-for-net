// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents the arguments used when asking the caller to validate an attestation token.
    /// </summary>
    public class AttestationTokenValidationEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationTokenValidationEventArgs"/> class.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="signer"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        internal AttestationTokenValidationEventArgs(AttestationToken token, AttestationSigner signer, bool isRunningSynchronously, CancellationToken cancellationToken) : base(isRunningSynchronously, cancellationToken)
        {
            Token = token;
            Signer = signer;
            IsValid = true;
        }

        /// <summary>
        /// Returns the token which has been validated.
        /// </summary>
        public AttestationToken Token { get; private set; }
        /// <summary>
        /// Returns the signer of the token.
        /// </summary>
        public AttestationSigner Signer { get; private set; }

        /// <summary>
        /// Set by the event callback to "true" to indicate that the callback has validated the token, false otherwise.
        /// </summary>
        /// <remarks>The default value of IsValid is 'true'.</remarks>
        public bool IsValid{get; set;}
    }
}
