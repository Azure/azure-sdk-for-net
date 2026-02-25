// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.CertificateRegistration.Tests
{
    public class CertificateRegistrationManagementTestEnvironment : TestEnvironment
    {
        // Variables retrieved using GetRecordedVariable will be recorded in recorded tests
        // Argument is the output name in the test-resources.json
        public new string SubscriptionId => GetRecordedVariable("CERTIFICATEREGISTRATION_SUBSCRIPTIONID");
        // Variables retrieved using GetVariable will not be recorded but the method will throw if the variable is not set
        public string ResourceGroupName => GetVariable("CERTIFICATEREGISTRATION_RESOURCEGROUPNAME");
        // Account details
        public string AccountName => GetRecordedVariable("CERTIFICATEREGISTRATION_ACCOUNTNAME");
        public string CertificateProfile => GetRecordedVariable("CERTIFICATEREGISTRATION_CERTIFICATEPROFILE");
    }
}
