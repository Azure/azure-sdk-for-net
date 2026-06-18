// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    // Backward compatibility: preserve the public constructor used by tests and mocking code.
    public partial class SecuritySettingData
    {
        /// <summary> Initializes a new instance of <see cref="SecuritySettingData"/>. </summary>
        public SecuritySettingData()
        {
        }
    }
}
