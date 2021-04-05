// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Options used for validating an attestation token.
    /// </summary>
    public class AttestationTokenOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationTokenOptions"/> class.
        /// </summary>
        public AttestationTokenOptions()
        {
            ValidateExpirationTime = true;
            ValidateNotBeforeTime = true;
        }
        /// <summary>
        /// Callback provided by the customer to perform additional validations of the specified attestation token.
        /// </summary>
        public Func<AttestationToken, AttestationSigner, bool> ValidationCallback { get; set; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token expiration times.
        /// </summary>
        public bool ValidateExpirationTime { get; set; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token NotBefore time.
        /// </summary>
        public bool ValidateNotBeforeTime { get; set; }

        /// <summary>
        /// Allowable slack in time validations - used to account for differences between the clock on the client
        /// and the clock on the server.
        /// </summary>
        public long TimeValidationSlack { get; set; }
    }
}
