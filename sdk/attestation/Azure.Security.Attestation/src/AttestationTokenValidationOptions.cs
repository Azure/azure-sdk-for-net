// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Declares the options used for validating an attestation token.
    ///
    /// When validating a JSON Web Token, there are a number of options that can be configured. For instance if the returned token
    /// is going to be validated by a relying party, there is no need for the client to validate the token.
    ///
    /// Similarly, because the expiration time of the token is relative to the clock on the server, it may be necessary to introduce a level of "leeway"
    /// when determining if a token is expired or not.
    /// </summary>
    public class AttestationTokenValidationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationTokenValidationOptions"/> class.
        /// </summary>
        public AttestationTokenValidationOptions()
        {
            ValidateExpirationTime = true;
            ValidateNotBeforeTime = true;
            ValidateToken = true;
        }

        internal async Task<bool> RaiseValidationCallbackAsync(AttestationToken token, AttestationSigner signer, ClientDiagnostics diagnostics, bool isRunningSynchronously, CancellationToken cancellationToken)
        {
            if (diagnostics != null)
            {
                var eventArgs = new AttestationTokenValidationEventArgs(token: token,
                        signer: signer,
                        isRunningSynchronously: isRunningSynchronously,
                        cancellationToken);

                await TokenValidated.RaiseAsync(eventArgs,
                    nameof(AttestationTokenValidationOptions),
                    nameof(TokenValidated),
                    diagnostics).ConfigureAwait(false);
                return eventArgs.IsValid;
            }
            else
            {
                // If anyone has subscribed to the invocation event, let them know that this didn't work :(.
                if (TokenValidated?.GetInvocationList() != null)
                {
                    throw new Exception("Unable to call validation callback outside of an attestation client operation.");
                }
            }
            return true;
        }

        /// <summary>
        /// Raised when an attestation token should be validated.
        /// </summary>
        public event SyncAsyncEventHandler<AttestationTokenValidationEventArgs> TokenValidated;

        /// <summary>
        /// Returns whether or not to validate the attestation token.
        /// </summary>
        public bool ValidateToken { get; set; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token expiration times, if present.
        /// </summary>
        public bool ValidateExpirationTime { get; set; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token NotBefore time, if present.
        /// </summary>
        public bool ValidateNotBeforeTime { get; set; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate the Issuer of the token, if present.
        /// </summary>
        public bool ValidateIssuer { get; set; }

        /// <summary>
        /// Expected Issuer for the token, if present.
        /// </summary>
        public string ExpectedIssuer { get; set; }

        /// <summary>
        /// Allowable slack in time validations - used to account for differences between the clock on the client
        /// and the clock on the server.
        /// </summary>
        public long TimeValidationSlack { get; set; }

        /// <summary>
        /// Create a deep copy of the current attestation token.
        /// </summary>
        /// <returns></returns>
        public AttestationTokenValidationOptions Clone()
        {
            var returnedToken = new AttestationTokenValidationOptions()
            {
                ValidateExpirationTime = this.ValidateExpirationTime,
                ValidateIssuer = this.ValidateIssuer,
                ExpectedIssuer = this.ExpectedIssuer,
                TimeValidationSlack = this.TimeValidationSlack,
                ValidateNotBeforeTime = this.ValidateNotBeforeTime,
                ValidateToken = this.ValidateToken,
            };
            returnedToken.TokenValidated = this.TokenValidated;
            return returnedToken;
        }
    }
}
