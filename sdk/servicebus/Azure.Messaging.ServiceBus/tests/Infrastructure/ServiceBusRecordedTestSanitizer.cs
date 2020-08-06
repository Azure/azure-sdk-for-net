// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;

namespace Azure.Messaging.ServiceBus.Tests.Infrastructure
{
    public class ServiceBusRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static bool s_IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public ServiceBusRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("ServiceBusDlqSupplementaryAuthorization");
            SanitizedHeaders.Add("ServiceBusSupplementaryAuthorization");
        }

        // The authorization key needs to be exactly 44 ASCII encoded bytes.
        private const string SanitizedKeyValue = "SanitizedSanitizedSanitizedSanitizedSanitize";
        public override string SanitizeTextBody(string contentType, string body)
        {
            var sanitized = Regex.Replace(body, "\\u003CPrimaryKey\\u003E.*\\u003C/PrimaryKey\\u003E", $"\u003CPrimaryKey\u003E{SanitizedKeyValue}\u003C/PrimaryKey\u003E");
            sanitized = Regex.Replace(sanitized, "\\u003CSecondaryKey\\u003E.*\\u003C/SecondaryKey\\u003E", $"\u003CSecondaryKey\u003E{SanitizedKeyValue}\u003C/SecondaryKey\u003E");
            if (!s_IsWindows)
            {
                sanitized = sanitized.Replace("\n", "\r\n");
            }
            return sanitized;
        }
        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            if (variableName == ServiceBusTestEnvironment.ServiceBusConnectionStringEnvironmentVariable)
            {
                return Regex.Replace(environmentVariableValue, "SharedAccessKey=.*", "SharedAccessKey=Kg==");
            }
            else
            {
                return base.SanitizeVariable(variableName, environmentVariableValue);
            }
        }
    }
}
