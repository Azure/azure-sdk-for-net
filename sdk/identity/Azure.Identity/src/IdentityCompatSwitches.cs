// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal class IdentityCompatSwitches
    {
        internal const string DisableInteractiveThreadpoolExecutionSwitchName = "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution";
        internal const string DisableInteractiveThreadpoolExecutionEnvVar = "AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION";
        internal const string DisableCP1ExecutionSwitchName = "Azure.Identity.DisableCP1";
        internal const string DisableCP1ExecutionEnvVar = "AZURE_IDENTITY_DISABLE_CP1";
        internal const string DisableMultiTenantAuthSwitchName = "Azure.Identity.DisableMultiTenantAuth";
        internal const string DisableMultiTenantAuthEnvVar = "AZURE_IDENTITY_DISABLE_MULTITENANTAUTH";

        public static bool DisableInteractiveBrowserThreadpoolExecution
            => AppContextSwitchHelper.GetConfigValue(DisableInteractiveThreadpoolExecutionSwitchName, DisableInteractiveThreadpoolExecutionEnvVar);

        public static bool DisableCP1
            => AppContextSwitchHelper.GetConfigValue(DisableCP1ExecutionSwitchName, DisableCP1ExecutionEnvVar);

        public static bool DisableTenantDiscovery
            => AppContextSwitchHelper.GetConfigValue(DisableMultiTenantAuthSwitchName, DisableMultiTenantAuthEnvVar);
    }
}
