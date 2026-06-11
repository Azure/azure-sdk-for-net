// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecuritySettingData
    {
        // Setting is a discriminated TypeSpec resource, so MPG generates a public constructor that
        // requires the discriminator kind. The GA SDK also exposed a parameterless constructor.
        /// <summary> Initializes a new instance of <see cref="SecuritySettingData"/>. </summary>
        public SecuritySettingData()
        {
        }
    }
}
