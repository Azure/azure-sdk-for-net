// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Service request builder.
    /// </summary>
    public class ServiceRequestBuilder
    {
        private WebPubSubValidationOptions _options;
        private ServiceHub _serviceHub;
        private string _path;

        /// <summary>
        /// Maps incoming requests with the specified path to the specified <see cref="ServiceHub"/> type.
        /// </summary>
        /// <param name="path">Target request path.</param>
        /// <param name="hub">Use implementd <see cref="ServiceHub"/></param>
        public void MapHub(PathString path, ServiceHub hub)
        {
            _path = path;
            _serviceHub = hub;
        }

        internal void AddValidationOptions(WebPubSubValidationOptions options)
        {
            _options = options;
        }

        internal ServiceRequestHandlerAdapter Build()
        {
            return new ServiceRequestHandlerAdapter(_options, _serviceHub, _path);
        }
    }
}
