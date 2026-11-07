// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class DiagnosticSettingsCategoryData
    {
        internal Models.DiagnosticSettingsCategoryProperties Properties { get; private set; } = new Models.DiagnosticSettingsCategoryProperties();

        /// <summary> The type of the diagnostic settings category. </summary>
        public MonitorCategoryType? CategoryType
        {
            get => Properties?.CategoryType;
            set
            {
                Properties ??= new Models.DiagnosticSettingsCategoryProperties();
                Properties.CategoryType = value;
            }
        }

        /// <summary> The collection of supported category groups. </summary>
        public IList<string> CategoryGroups => (Properties ??= new Models.DiagnosticSettingsCategoryProperties()).CategoryGroups;
    }
}
