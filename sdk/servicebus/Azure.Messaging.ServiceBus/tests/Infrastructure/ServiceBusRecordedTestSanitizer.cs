// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;

namespace Azure.Messaging.ServiceBus.Tests.Infrastructure
{
    public class ServiceBusRecordedTestSanitizer : RecordedTestSanitizer
    {

        public ServiceBusRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("ServiceBusDlqSupplementaryAuthorization");
            SanitizedHeaders.Add("ServiceBusSupplementaryAuthorization");
        }

        // The authorization key needs to be exactly 44 ASCII encoded bytes.
        private const string SanitizedKeyValue = "SanitizedSanitizedSanitizedSanitizedSanitize";
        public override string SanitizeTextBody(string contentType, string body)
        {
            var replaced = Regex.Replace(body, "\\u003CPrimaryKey\\u003E.*\\u003C/PrimaryKey\\u003E", $"\u003CPrimaryKey\u003E{SanitizedKeyValue}\u003C/PrimaryKey\u003E");
            replaced = Regex.Replace(replaced, "\\u003CSecondaryKey\\u003E.*\\u003C/SecondaryKey\\u003E", $"\u003CSecondaryKey\u003E{SanitizedKeyValue}\u003C/SecondaryKey\u003E");
            return replaced;
        }
        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            if (variableName == ServiceBusTestEnvironment.NamespaceConnectionStringVariableName)
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
