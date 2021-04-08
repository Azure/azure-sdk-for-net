// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class IdentityCompatSwitches
    {
        private const string DisableInteractiveThreadpoolExecutionSwitchName = "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution";
        private const string DisableInteractiveThreadpoolExecutionEnvVar = "AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION";

        public static bool DisableInteractiveBrowserThreadpoolExecution
        {
            get
            {
                if (!AppContext.TryGetSwitch(DisableInteractiveThreadpoolExecutionSwitchName, out bool ret))
                {
                    string switchValue = Environment.GetEnvironmentVariable(DisableInteractiveThreadpoolExecutionEnvVar);

                    if (switchValue != null)
                    {
                        ret = string.Equals("true", switchValue, StringComparison.InvariantCultureIgnoreCase) ||
                              switchValue.Equals("1", StringComparison.InvariantCultureIgnoreCase);
                    }
                }

                return ret;
            }
        }
    }
}
