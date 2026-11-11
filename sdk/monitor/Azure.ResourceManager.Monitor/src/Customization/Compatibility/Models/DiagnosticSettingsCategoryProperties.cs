// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Monitor.Models
{
    internal partial class DiagnosticSettingsCategoryProperties
    {
        // Preserve the writable CategoryType property shipped in the GA SDK.
        // The generated response model is read-only, but DiagnosticSettingsCategoryData's compatibility setter assigns this property.
        public MonitorCategoryType? CategoryType { get; set; }
    }
}
