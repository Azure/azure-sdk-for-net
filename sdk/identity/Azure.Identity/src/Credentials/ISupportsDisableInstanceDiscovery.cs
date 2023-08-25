// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    internal interface ISupportsDisableInstanceDiscovery
    {
        /// <summary>
        /// Gets or sets the setting which determines whether or not instance discovery is performed when attempting to authenticate.
        /// Setting this to true will completely disable both instance discovery and authority validation.
        /// This functionality is intended for use in scenarios where the metadata endpoint cannot be reached, such as in private clouds or Azure Stack.
        /// The process of instance discovery entails retrieving authority metadata from https://login.microsoft.com/ to validate the authority.
        /// By setting this to <c>true</c>, the validation of the authority is disabled.
        /// As a result, it is crucial to ensure that the configured authority host is valid and trustworthy."
        /// </summary>
        bool DisableInstanceDiscovery { get; set; }
    }
}
