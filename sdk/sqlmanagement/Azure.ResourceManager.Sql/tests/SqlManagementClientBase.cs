// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    [ClientTestFixture]
    [NonParallelizable]
    public abstract class SqlManagementClientBase : ManagementRecordedTestBase<SqlManagementTestEnvironment>
    {
        protected string DefaultLocation = "westus2";

        protected SqlManagementClientBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public virtual void TestSetup()
        {
        }

        [TearDown]
        public virtual Task TestCleanup()
        {
            return Task.CompletedTask;
        }

        protected SqlManagementClient GetSqlManagementClient()
        {
            return CreateClient<SqlManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new SqlManagementClientOptions()));
        }
    }
}
