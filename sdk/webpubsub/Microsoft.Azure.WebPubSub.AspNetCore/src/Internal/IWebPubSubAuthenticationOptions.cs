// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Interface of Web PubSub Authentication
    /// </summary>
    public interface IWebPubSubAuthenticationOptions
    {
        /// <summary>
        /// Configure auth scheme and policies.
        /// </summary>
        /// <param name="services"></param>
        public IServiceCollection Configure(IServiceCollection services);
    }
}
