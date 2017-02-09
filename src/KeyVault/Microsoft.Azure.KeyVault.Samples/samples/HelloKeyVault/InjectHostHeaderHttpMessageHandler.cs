﻿//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Configuration;

namespace Sample.Microsoft.HelloKeyVault
{
    public class InjectHostHeaderHttpMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// Adds the Host header to every request if the "KmsNetworkUrl" configuration setting is specified.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var requestUri = request.RequestUri;
            var authority = string.Empty;
            var targetUri = requestUri;

            // NOTE: The KmsNetworkUrl setting is purely for development testing on the
            //       Microsoft Azure Development Fabric and should not be used outside that environment.
            string networkUrl = ConfigurationManager.AppSettings["KmsNetworkUrl"];

            if (!string.IsNullOrEmpty(networkUrl))
            {
                authority = targetUri.Authority;
                targetUri = new Uri(new Uri(networkUrl), targetUri.PathAndQuery);

                request.Headers.Add("Host", authority);
                request.RequestUri = targetUri;
            }

            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(response =>
            {
                return response.Result;
            });
        }
    }
}

