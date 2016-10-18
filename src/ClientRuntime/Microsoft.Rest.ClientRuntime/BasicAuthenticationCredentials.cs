// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest
{
    /// <summary>
    /// Basic Auth credentials for use with a REST Service Client.
    /// </summary>
    public class BasicAuthenticationCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// Basic auth UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Basic auth password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Add the Basic Authentication Header to each outgoing request
        /// </summary>
        /// <param name="request">The outgoing request</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns></returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            // Add username and password to "Basic" header of each request.
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}:{1}",
                    UserName,
                    Password).ToCharArray())));
            return Task.FromResult<object>(null);
        }
    }
}