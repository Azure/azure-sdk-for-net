// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.FunctionalTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Azure.Core.TestFramework;

    public class AzureMonitorTestEnvironment : TestEnvironment
    {
        public AzureMonitorTestEnvironment() : base()// base("monitor")
        {
        }

        //public string Endpoint => GetRecordedVariable("API-LEARN_ENDPOINT");
        //public string SettingKey => GetVariable("API-LEARN_SETTING_COLOR_KEY");
        //public string SettingValue => GetVariable("API-LEARN_SETTING_COLOR_VALUE");

        /// <summary>
        /// </summary>
        /// <example>"InstrumentationKey=00000000-0000-0000-0000-000000000000".</example>
        public string ConnectionString => GetRecordedVariable(EnvironmentVariableName.ConnectionString);

        public string InstrumentationKey => GetRecordedVariable(EnvironmentVariableName.InstrumentationKey);

        internal static class EnvironmentVariableName
        {
            public const string ConnectionString = "";
            public const string InstrumentationKey = "INSTRUMENTATION_KEY";
        }
    }
}
