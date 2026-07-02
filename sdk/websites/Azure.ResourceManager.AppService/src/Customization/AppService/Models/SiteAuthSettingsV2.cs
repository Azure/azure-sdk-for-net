// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    // The SiteAuthSettingsV2 class is a GA-compatibility shim for the original SiteAuthSettingsV2 model, which was a plain payload returned by WebSiteResource.GetAuthSettingsV2* / UpdateAuthSettingsV2* (and slot variants).
    // After the TypeSpec migration, the underlying API surfaced as a singleton sub-resource (WebSiteAuthSettingsV2Resource) with a *Data model (SiteAuthSettingsV2Data).
    // To preserve the GA API surface, this class is retained.
    /// <summary>
    /// Configuration settings for the Azure App Service Authentication / Authorization V2 feature.
    /// Serialized Name: SiteAuthSettingsV2
    /// </summary>
    public partial class SiteAuthSettingsV2 : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="SiteAuthSettingsV2"/>. </summary>
        public SiteAuthSettingsV2()
        {
        }

        internal SiteAuthSettingsV2(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string kind,
            AuthPlatform platform,
            GlobalValidation globalValidation,
            AppServiceIdentityProviders identityProviders,
            WebAppLoginInfo login,
            AppServiceHttpSettings httpSettings,
            IDictionary<string, BinaryData> rawData)
            : base(id, name, resourceType, systemData)
        {
            Kind = kind;
            Platform = platform;
            GlobalValidation = globalValidation;
            IdentityProviders = identityProviders;
            Login = login;
            HttpSettings = httpSettings;
            _serializedAdditionalRawData = rawData;
        }

        /// <summary> Kind of resource. </summary>
        [WirePath("kind")]
        public string Kind { get; set; }

        /// <summary> Platform settings. </summary>
        [WirePath("properties.platform")]
        public AuthPlatform Platform { get; set; }

        /// <summary> Global validation. </summary>
        [WirePath("properties.globalValidation")]
        public GlobalValidation GlobalValidation { get; set; }

        /// <summary> Identity providers. </summary>
        [WirePath("properties.identityProviders")]
        public AppServiceIdentityProviders IdentityProviders { get; set; }

        /// <summary> Login configuration. </summary>
        [WirePath("properties.login")]
        public WebAppLoginInfo Login { get; set; }

        /// <summary> HTTP settings. </summary>
        [WirePath("properties.httpSettings")]
        public AppServiceHttpSettings HttpSettings { get; set; }

        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;
    }
}
