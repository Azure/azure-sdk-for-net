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
    public class TokenValidationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenValidationOptions"/> class.
        /// </summary>
        /// <param name="validateToken">If true, specifies that the attestation token should be validated.</param>
        /// <param name="validateExpirationTime">If true, specifies that the expiration time in the token should be checked.</param>
        /// <param name="validateNotBeforeTime">If true, specifies that the "not valid before" time in the token should be checked.</param>
        /// <param name="validateIssuer">Validate the issuer in the token.</param>
        /// <param name="expectedIssuer">Expected issuer for the attestation token. Only used if the <paramref name="validateIssuer"/> parameter is true.</param>
        /// <param name="timeValidationSlack">"Slack" time in seconds for time based checks. Allows the caller to specify the allowable amount of clock drift between local and remote clocks.</param>
        /// <param name="validationCallback">Callback to enable customer specific additional token validation checks.</param>
        public TokenValidationOptions(
            bool validateToken = true,
            bool validateExpirationTime = true,
            bool validateNotBeforeTime = true,
            bool validateIssuer = false,
            string expectedIssuer = default,
            int timeValidationSlack = default(int),
            Func<AttestationToken, AttestationSigner, bool> validationCallback = default
            )
        {
            ValidateExpirationTime = validateExpirationTime;
            ValidateNotBeforeTime = validateNotBeforeTime;
            ValidateIssuer = validateIssuer;
            ValidationCallback = validationCallback;
            ExpectedIssuer = expectedIssuer;
            TimeValidationSlack = timeValidationSlack;
            ValidateToken = validateToken;
        }

        /// <summary>
        /// Callback provided by the customer to perform additional validations of the specified attestation token.
        /// </summary>
        public Func<AttestationToken, AttestationSigner, bool> ValidationCallback { get; }

        /// <summary>
        /// Returns whether or not to validate the attestation token.
        /// </summary>
        public bool ValidateToken { get; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token expiration times, if present.
        /// </summary>
        public bool ValidateExpirationTime { get; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate token NotBefore time, if present.
        /// </summary>
        public bool ValidateNotBeforeTime { get; }

        /// <summary>
        /// Specifies whether or not the validation logic should validate the Issuer of the token, if present.
        /// </summary>
        public bool ValidateIssuer { get; }

        /// <summary>
        /// Expected Issuer for the token, if present.
        /// </summary>
        public string ExpectedIssuer { get; }

        /// <summary>
        /// Allowable slack in time validations - used to account for differences between the clock on the client
        /// and the clock on the server.
        /// </summary>
        public long TimeValidationSlack { get; }
    }
}
