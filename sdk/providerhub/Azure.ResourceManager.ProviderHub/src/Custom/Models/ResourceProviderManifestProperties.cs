// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: re-exposes convenience properties that are now nested under generated wrapper models.
    // These setters need custom initialization of RequestHeaderOptions, ProviderAuthentication, and FeaturesRule.
    /// <summary> The ResourceProviderManifestProperties. </summary>
    public partial class ResourceProviderManifestProperties
    {
        /// <summary> Gets or sets the opt in headers. </summary>
        public OptInHeaderType? OptInHeaders
        {
            get => RequestHeaderOptions is null ? default : RequestHeaderOptions.OptInHeaders;
            set
            {
                if (RequestHeaderOptions is null)
                    RequestHeaderOptions = new ProviderRequestHeaderOptions();
                RequestHeaderOptions.OptInHeaders = value;
            }
        }

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

        /// <summary> Gets or sets the required features policy. </summary>
        public FeaturesPolicy? RequiredFeaturesPolicy
        {
            get => FeaturesRule is null ? default(FeaturesPolicy?) : FeaturesRule.RequiredFeaturesPolicy;
            set => FeaturesRule = value.HasValue ? new ProviderFeaturesRule(value.Value) : default;
        }
    }
}
