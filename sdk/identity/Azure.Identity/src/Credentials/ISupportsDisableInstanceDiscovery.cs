// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    internal interface ISupportsDisableInstanceDiscovery
    {
        /// <summary>
        /// Determines whether or not instance discovery is performed when attempting to authenticate.
        /// Setting this to true will completely disable instance discovery and authority validation.
        /// </summary>
        bool DisableInstanceDiscovery { get; set; }
    }
}
