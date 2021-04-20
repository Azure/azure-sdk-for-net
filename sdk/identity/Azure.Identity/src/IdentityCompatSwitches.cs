// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class IdentityCompatSwitches
    {
        internal const string DisableInteractiveThreadpoolExecutionSwitchName = "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution";
        internal const string DisableInteractiveThreadpoolExecutionEnvVar = "AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION";
        internal const string DisableCP1ExecutionSwitchName = "AZURE.IDENTITY.DISABLECP1";
        internal const string DisableCP1ExecutionEnvVar = "AZURE_IDENTITY_DISABLE_CP1";

        public static bool DisableInteractiveBrowserThreadpoolExecution
            => GetConfigValue(DisableInteractiveThreadpoolExecutionSwitchName, DisableInteractiveThreadpoolExecutionEnvVar);

        public static bool DisableCAE
            => GetConfigValue(DisableCP1ExecutionSwitchName, DisableCP1ExecutionEnvVar);

        /// <summary>
        /// Determines if either an AppContext switch or its corresponding Environment Variable is set
        /// </summary>
        /// <param name="switchName">Name of the AppContext switch.</param>
        /// <param name="envName">Name of the Environment variable.</param>
        /// <returns>true if either the switch or the environment variable is set to true. False if both are set to false or unset.</returns>
        private static bool GetConfigValue(string switchName, string envName)
        {
            if (!AppContext.TryGetSwitch(switchName, out bool ret) || ret == false)
            {
                string switchValue = Environment.GetEnvironmentVariable(envName);

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
