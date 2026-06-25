// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation does not emit the base constructors needed for deserialization and derived discriminator types.
    public partial class SecurityMLAnalyticsSettingData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityMLAnalyticsSettingData"/>. </summary>
        public SecurityMLAnalyticsSettingData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityMLAnalyticsSettingData"/>. </summary>
        /// <param name="kind"> Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value. </param>
        private protected SecurityMLAnalyticsSettingData(SecurityMLAnalyticsSettingsKind kind)
        {
            Kind = kind;
        }
    }
}