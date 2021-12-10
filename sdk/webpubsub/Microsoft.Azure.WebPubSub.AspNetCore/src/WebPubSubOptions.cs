// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Options when using Web PubSub service.
    /// </summary>
    public class WebPubSubOptions
    {
        /// <summary>
        /// Validation options for Abuse Protection and Signature checks.
        /// </summary>
        public WebPubSubValidationOptions ValidationOptions { get; set; } = new WebPubSubValidationOptions();

        /// <summary>
        /// Authentication options for request checks.
        /// </summary>
        public IWebPubSubAuthenticationOptions AuthenticationOptions { get; set; }
    }
}
