// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Education.Tests
{
    public class EducationManagementTestBase : ManagementRecordedTestBase<EducationManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected EducationManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected EducationManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        // Education resources are tenant-scoped, so scenarios operate against the tenant.
        protected async Task<TenantResource> GetTenantAsync()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            return tenants.FirstOrDefault();
        }
    }
}
