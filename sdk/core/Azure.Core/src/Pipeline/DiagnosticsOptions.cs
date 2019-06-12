// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    public class DiagnosticsOptions
    {
        public DiagnosticsOptions()
        {
            DisableTelemetry = EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TELEMETRY_DISABLED")) ?? false;;
            ApplicationId = DefaultApplicationId;
        }

        public bool DisableLogging { get; set; }

        public bool DisableTelemetry { get; set; }

        public string ApplicationId { get; set; }

        public static string DefaultApplicationId { get; set; }

        private static bool? EnvironmentVariableToBool(string value)
        {
            if (string.Equals("true", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("1", value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals("false", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("0", value, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return null;
        }
    }
}
