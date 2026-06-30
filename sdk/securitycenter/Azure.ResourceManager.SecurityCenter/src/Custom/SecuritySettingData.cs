// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    // The current TypeSpec-generated data model only exposes serialization constructors, while GA exposed a public parameterless constructor used by tests and mocking code; keep that constructor here.
    public partial class SecuritySettingData
    {
        /// <summary> Initializes a new instance of <see cref="SecuritySettingData"/>. </summary>
        public SecuritySettingData()
        {
        }
    }
}
