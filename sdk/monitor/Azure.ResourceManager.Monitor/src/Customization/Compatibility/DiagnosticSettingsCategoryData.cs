// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Monitor
{
    public partial class DiagnosticSettingsCategoryData
    {
        // The generated backing property is get-only; this setter lets generated
        // CategoryType and CategoryGroups accessors initialize missing properties.
        internal Models.DiagnosticSettingsCategoryProperties Properties { get; private set; } = new Models.DiagnosticSettingsCategoryProperties();
    }
}
