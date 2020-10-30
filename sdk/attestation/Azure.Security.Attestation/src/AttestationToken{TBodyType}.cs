// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Security.Attestation.Models;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// An <see cref="AttestationToken{TBodyType}"/> represents a JSON Web Token object either passed into or received from the Microsoft Azure Attestation service.
    /// </summary>
    /// <typeparam name="TBodyType">Type representing the Body field in the JSON Web Token.</typeparam>
    public class AttestationToken<TBodyType> : AttestationToken
        where TBodyType : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken{TBodyType}"/> class.
        /// </summary>
        /// <param name="token">string JWT to initialize.</param>
        internal AttestationToken(string token) : base(token)
        {
        }

        /// <summary>
        /// Token constructor for mocking.
        /// </summary>
        protected AttestationToken() : base()
        {
        }

        /// <summary>
        /// Returns the type representing the "Body" of the JSON WebToken.
        /// </summary>
        public TBodyType Value { get; }

        /// <summary>
        /// Returns the raw JSON value of the body as a string.
        /// </summary>
        public virtual string RawValue { get; }
    }
}
