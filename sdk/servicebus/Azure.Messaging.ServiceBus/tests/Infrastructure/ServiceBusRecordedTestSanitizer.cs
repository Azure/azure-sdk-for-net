// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Messaging.ServiceBus.Tests.Infrastructure
{
    public class ServiceBusRecordedTestSanitizer : RecordedTestSanitizer
    {
        // The authorization key needs to be exactly 44 ASCII encoded bytes.
        private const string SanitizedKeyValue = "SanitizedSanitizedSanitizedSanitizedSanitize";

        public ServiceBusRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("ServiceBusDlqSupplementaryAuthorization");
            SanitizedHeaders.Add("ServiceBusSupplementaryAuthorization");
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "\\u003CPrimaryKey\\u003E.*\\u003C/PrimaryKey\\u003E",
                    $"\u003CPrimaryKey\u003E{SanitizedKeyValue}\u003C/PrimaryKey\u003E"));
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "\\u003CSecondaryKey\\u003E.*\\u003C/SecondaryKey\\u003E",
                    $"\u003CSecondaryKey\u003E{SanitizedKeyValue}\u003C/SecondaryKey\u003E"));
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "[^\\r](?<break>\\n)",
                    "\r\n")
                {
                    GroupForReplace = "break"
                });
        }
    }
}
