// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents authentication information in Authorization, ProxyAuthorization,
    /// WWW-Authenticate, and Proxy-Authenticate header values.
    /// </summary>
    public class HttpAuthorization
    {
        /// <summary>
        /// Gets the scheme to use for authorization.
        /// </summary>
        public string Scheme { get; }

        /// <summary>
        /// Gets the credentials containing the authentication information of the
        /// user agent for the resource being requested.
        /// </summary>
        public string Parameter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpAuthorization"/> class.
        /// </summary>
        /// <param name="scheme">
        /// The scheme to use for authorization.
        /// </param>
        /// <param name="parameter">
        /// The credentials containing the authentication information of the
        /// user agent for the resource being requested.
        /// </param>
        public HttpAuthorization(
            string scheme,
            string parameter)
        {
            Argument.AssertNotNullOrWhiteSpace(scheme, nameof(scheme));
            Argument.AssertNotNullOrWhiteSpace(parameter, nameof(parameter));

            Scheme = scheme;
            Parameter = parameter;
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="HttpAuthorization"/> object.
        /// </summary>
        public override string ToString()
            => $"{Scheme} {Parameter}";
    }
}
