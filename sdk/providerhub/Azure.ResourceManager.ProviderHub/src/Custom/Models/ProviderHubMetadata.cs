// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: re-exposes ProviderAuthenticationAllowedAudiences as a top-level settable property.
    // This shim must initialize the nested generated model on demand, which cannot be expressed with a spec-side rename.
    /// <summary> The ProviderHubMetadata. </summary>
    public partial class ProviderHubMetadata
    {
        /// <summary> Gets or sets the provider authentication allowed audiences. </summary>
        public IList<string> ProviderAuthenticationAllowedAudiences
        {
            get
            {
                if (ProviderAuthentication is null)
                    ProviderAuthentication = new ResourceProviderAuthentication();
                return ProviderAuthentication.ProviderAuthenticationAllowedAudiences;
            }
            set
            {
                if (ProviderAuthentication is null)
                    ProviderAuthentication = new ResourceProviderAuthentication();
                ProviderAuthentication.ProviderAuthenticationAllowedAudiences.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                        ProviderAuthentication.ProviderAuthenticationAllowedAudiences.Add(item);
                }
            }
        }
    }
}
