// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hyak.Common
{
    public class BasicAuthenticationCloudCredentials
        : CloudCredentials
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}",
                    Username,
                    Password).ToCharArray())));

            return Task.FromResult<object>(null);
        }
    }
}
