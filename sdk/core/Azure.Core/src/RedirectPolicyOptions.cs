// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Configures behaviors for the redirect policy.
    /// </summary>
    public class RedirectPolicyOptions
    {
        /// <summary>
        /// Gets or sets a value that indicates whether the redirect policy should follow redirection responses.
        /// </summary>
        /// <value>
        /// <c>true</c> if the redirect policy should follow redirection responses; otherwise <c>false</c>. The default value is <c>false</c>
        /// </value>
        public bool IsAutoRedirectEnabled { get; set; }
    }
}
