// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Interface of Web PubSub Auth
    /// </summary>
    public interface IWebPubSubAuthOptions
    {
        /// <summary>
        /// Configure authentication options.
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="options"></param>
        public AuthenticationBuilder Configure(string scheme, AuthenticationBuilder options);

        /// <summary>
        /// Configure authorization policies.
        /// </summary>
        /// <param name="policyBuilder"></param>
        public AuthorizationPolicyBuilder Configure(AuthorizationPolicyBuilder policyBuilder);
    }
}
