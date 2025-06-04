// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.Tables
{
    internal class TablesCompatSwitches
    {
        public static bool DisableEscapeSingleQuotesOnGetEntity
            => AppContextSwitchHelper.GetConfigValue(
                TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnGetEntitySwitchName,
                TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnGetEntityEnvVar);

        public static bool DisableEscapeSingleQuotesOnDeleteEntity
            => AppContextSwitchHelper.GetConfigValue(
                TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnDeleteEntitySwitchName,
                TableConstants.CompatSwitches.DisableEscapeSingleQuotesOnDeleteEntityEnvVar);

        public static bool DisableThrowOnStringComparisonFilter
            => AppContextSwitchHelper.GetConfigValue(
                TableConstants.CompatSwitches.DisableThrowOnStringComparisonFilterSwitchName,
                TableConstants.CompatSwitches.DisableThrowOnStringComparisonFilterEnvVar);
    }
}
