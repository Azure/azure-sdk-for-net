// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ProviderHubMetadata. </summary>
    [CodeGenSuppress("ProviderAuthenticationAllowedAudiences")]
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
