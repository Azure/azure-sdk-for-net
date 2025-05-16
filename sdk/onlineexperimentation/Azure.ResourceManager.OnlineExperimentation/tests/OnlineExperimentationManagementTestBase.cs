// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

using NUnit.Framework;

namespace Azure.ResourceManager.OnlineExperimentation.Tests
{
    public class OnlineExperimentationManagementTestBase : ManagementRecordedTestBase<OnlineExperimentationManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public OnlineExperimentationWorkspaceResource TestWorkspaceResource { get; private set; }

        protected OnlineExperimentationManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected OnlineExperimentationManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();

            var workspaceResourceId = ResourceIdentifier.Parse(TestEnvironment.OnlineExperimentationWorkspaceResourceId);
            TestWorkspaceResource = Client.GetOnlineExperimentationWorkspaceResource(workspaceResourceId);
        }
    }
}
