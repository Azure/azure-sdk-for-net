// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ServiceGroups.Tests
{
    public class ServiceGroupsManagementTestBase : ManagementRecordedTestBase<ServiceGroupsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ServiceGroupsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ServiceGroupsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected string GetTenantId()
        {
            // Use recorded variable to ensure consistency between Record and Playback modes
            return TestEnvironment.TenantId;
        }
    }
}
