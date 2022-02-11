// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Communication.Tests
{
    public class CommunicationTestEnvironment : TestEnvironment
    {
        public const string LiveTestDynamicConnectionStringEnvironmentVariableName = "COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING";
        public const string LiveTestStaticConnectionStringEnvironmentVariableName = "COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING";
        public const string AzurePhoneNumber = "AZURE_PHONE_NUMBER";
        private const string SkipIntSmsTestEnvironmentVariableName = "SKIP_INT_SMS_TEST";
        private const string SkipIntPhoneNumbersTestEnvironmentVariableName = "SKIP_INT_PHONENUMBERS_TEST";

        public string LiveTestDynamicConnectionString => GetRecordedVariable(
            LiveTestDynamicConnectionStringEnvironmentVariableName,
            options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public Uri LiveTestDynamicEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("endpoint"));

        public string LiveTestDynamicAccessKey => Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("accesskey");

        public string LiveTestStaticConnectionString => GetRecordedVariable(
                LiveTestStaticConnectionStringEnvironmentVariableName,
                options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public Uri LiveTestStaticEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("endpoint"));

        public string LiveTestStaticAccessKey => Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("accesskey");

        public string CommunicationTestPhoneNumber => GetRecordedVariable(AzurePhoneNumber, options => options.IsSecret("+14255550123"));

        public string SkipSmsTest => GetOptionalVariable(SkipIntSmsTestEnvironmentVariableName) ?? "False";

        public string SkipPhoneNumbersTest => GetOptionalVariable(SkipIntPhoneNumbersTestEnvironmentVariableName) ?? "False";

        public bool ShouldIgnoreSMSTests => bool.Parse(SkipSmsTest);

        public bool ShouldIgnorePhoneNumbersTests => bool.Parse(SkipPhoneNumbersTest);
    }
}
