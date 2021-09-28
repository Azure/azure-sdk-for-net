// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal class IdentityCompatSwitches
    {
        internal const string EnableLegacyTenantSelectionEnvVar = "AZURE_IDENTITY_ENABLE_LEGACY_TENANT_SELECTION";
        internal const string EnableLegacyTenantSelectionSwitchName = "Azure.Identity.EnableLegacyTenantSelection";
        internal const string DisableInteractiveThreadpoolExecutionSwitchName = "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution";
        internal const string DisableInteractiveThreadpoolExecutionEnvVar = "AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION";
        internal const string DisableCP1ExecutionSwitchName = "Azure.Identity.DisableCP1";
        internal const string DisableCP1ExecutionEnvVar = "AZURE_IDENTITY_DISABLE_CP1";
        internal const string DisableTenantDiscoverySwitchName = "Azure.Identity.DisableTenantDiscovery";
        internal const string DisableTenantDiscoveryEnvVar = "AZURE_IDENTITY_DISABLE_TENANTDISCOVERY";

        public static bool DisableInteractiveBrowserThreadpoolExecution
            => AppContextSwitchHelper.GetConfigValue(DisableInteractiveThreadpoolExecutionSwitchName, DisableInteractiveThreadpoolExecutionEnvVar);

        public static bool DisableCP1
            => AppContextSwitchHelper.GetConfigValue(DisableCP1ExecutionSwitchName, DisableCP1ExecutionEnvVar);

        public static bool DisableTenantDiscovery
            => AppContextSwitchHelper.GetConfigValue(DisableTenantDiscoverySwitchName, DisableTenantDiscoveryEnvVar);
    }
}
