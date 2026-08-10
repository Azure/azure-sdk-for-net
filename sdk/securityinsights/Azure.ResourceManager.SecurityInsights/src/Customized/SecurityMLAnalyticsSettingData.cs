// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityInsights
{
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation does not emit the base constructors needed for deserialization and derived discriminator types.
    public partial class SecurityMLAnalyticsSettingData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityMLAnalyticsSettingData"/>. </summary>
        public SecurityMLAnalyticsSettingData()
        {
        }
    }
}
