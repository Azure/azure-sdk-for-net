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
        protected const string TestPackagesEnabledDefaultValue = "all";
        private const string TestPackagesEnabledEnvironmentVariableName = "TEST_PACKAGES_ENABLED";
        private const string SkipSmsTestEnvironmentVariableName = "SKIP_INT_SMS_TEST";
        private const string SkipPhoneNumbersTestEnvironmentVariableName = "SKIP_INT_PHONENUMBERS_TEST";

        public string LiveTestDynamicConnectionString => GetRecordedVariable(LiveTestDynamicConnectionStringEnvironmentVariableName);

        public Uri LiveTestDynamicEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("endpoint"));

        public string LiveTestDynamicAccessKey => Core.ConnectionString.Parse(LiveTestDynamicConnectionString).GetRequired("accesskey");

        public string LiveTestStaticConnectionString => GetRecordedVariable(LiveTestStaticConnectionStringEnvironmentVariableName);

        public Uri LiveTestStaticEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("endpoint"));

        public string LiveTestStaticAccessKey => Core.ConnectionString.Parse(LiveTestStaticConnectionString).GetRequired("accesskey");

        public string CommunicationTestPhoneNumber => GetVariable(AzurePhoneNumber);

        public string SkipSmsTest => GetOptionalVariable(SkipSmsTestEnvironmentVariableName) ?? "False";

        public string SkipPhoneNumbersTest => GetOptionalVariable(SkipPhoneNumbersTestEnvironmentVariableName) ?? "False";

        public virtual string ExpectedTestPackagesEnabled { get { return TestPackagesEnabledDefaultValue; } }

        public bool ShouldIgnoreTests => TestPackagesEnabled != TestPackagesEnabledDefaultValue
            && TestPackagesEnabled != ExpectedTestPackagesEnabled;

        public bool ShouldIgnoreSMSTests => TestPackagesEnabled != TestPackagesEnabledDefaultValue
            && TestPackagesEnabled != ExpectedTestPackagesEnabled
            || bool.Parse(SkipSmsTest);

        public bool ShouldIgnorePhoneNumbersTests => bool.Parse(SkipPhoneNumbersTest);

        public string TestPackagesEnabled => GetTestPackageEnabled();

        private string GetTestPackageEnabled()
        {
            string? package = Environment.GetEnvironmentVariable(TestPackagesEnabledEnvironmentVariableName);
            return package ?? TestPackagesEnabledDefaultValue;
        }
    }
}
