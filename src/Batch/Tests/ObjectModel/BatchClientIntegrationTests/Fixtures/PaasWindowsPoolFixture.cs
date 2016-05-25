namespace BatchClientIntegrationTests.Fixtures
{
    using System.Collections.Generic;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class PaasWindowsPoolFixture : PoolFixture
    {
        public PaasWindowsPoolFixture()
            : base(TestUtilities.GetMyName() + "-pooltest")
        {
            this.Pool = this.CreatePool();
        }

        protected CloudPool CreatePool()
        {
            CloudPool currentPool = this.FindPoolIfExists();

            if (currentPool == null)
            {
                // gotta create a new pool
                CloudServiceConfiguration passConfiguration = new CloudServiceConfiguration(OSFamily);

                currentPool = this.client.PoolOperations.CreatePool(
                    this.PoolId,
                    VMSize,
                    passConfiguration,
                    targetDedicated: 1);

                StartTask st = new StartTask();

                // used for tests of StartTask(info)
                st.CommandLine = "cmd /c hostname";
                st.EnvironmentSettings = new List<EnvironmentSetting>
                    {
                        new EnvironmentSetting("key", "value")
                    };
                currentPool.StartTask = st;

                currentPool.Commit();
            }

            return WaitForPoolAllocation(this.client, this.PoolId);
        }
    }

    /// <summary>
    /// This class is used by XUnit
    /// </summary>
    [CollectionDefinition("SharedPoolCollection")]
    public class SharedPoolCollection : ICollectionFixture<PaasWindowsPoolFixture>
    {

    }
}
