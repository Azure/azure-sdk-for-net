// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing diagnostic settings category data. </summary>
    [Obsolete("This API is no longer supported.", false)]
    public partial class DiagnosticSettingsCategoryData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="DiagnosticSettingsCategoryData"/>. </summary>
        public DiagnosticSettingsCategoryData()
        {
        }
    }
}
