// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Security.Attestation.Models;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// An <see cref="AttestationToken{T}"/> represents a JSON Web Token object either passed into or received from the Microsoft Azure Attestation service.
    /// </summary>
    /// <typeparam name="T">Type representing the Body field in the JSON Web Token.</typeparam>
    public class AttestationToken<T> : AttestationToken
        where T : class
    {
        private T _parsedBody;

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
        public T Value
        {
            get
            {
                lock (this) {
                    if (_parsedBody != null)
                    {
                        return _parsedBody;
                    }
                    _parsedBody = JsonSerializer.Deserialize<T>(TokenBodyBytes);
                    return _parsedBody;
                }
            }
        }

        /// <summary>
        /// Returns the raw JSON value of the body as a string.
        /// </summary>
        public virtual string RawValue { get; }
    }
}
