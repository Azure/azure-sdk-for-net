// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppComplianceAutomation.Tests
{
    public class AppComplianceAutomationManagementTestBase : ManagementRecordedTestBase<AppComplianceAutomationManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected ReportResourceCollection ReportResources { get; private set; }

        protected AppComplianceAutomationManagementTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            SanitizedHeaders.Add(UserTokenPolicy.UserTokenHeader);
        }

        public AppComplianceAutomationManagementTestBase(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
            SanitizedHeaders.Add(UserTokenPolicy.UserTokenHeader);
        }

        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        // The App Compliance Automation provider need user token in a separated header in the following scenarios.
        protected void InitializeUserTokenClients()
        {
            UserTokenPolicy userTokenPolicy = new UserTokenPolicy(TestEnvironment.Credential, TestEnvironment.ResourceManagerUrl + "/.default");
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(userTokenPolicy, HttpPipelinePosition.PerRetry);
            Client = GetArmClient(options);
        }
    }
}
