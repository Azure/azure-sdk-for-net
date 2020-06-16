using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.HDInsight.Job.Tests
{
    public class SparkJobTestsFixture : CommonTestsFixture, IDisposable
    {
        /// <summary>
        /// Gets or sets the mock context.
        /// </summary>
        private MockContext context;

        /// <summary>
        /// Initializes common data properties.
        /// </summary>
        public override void Initialize(MockContext contextToUse)
        {
            try
            {
                context = contextToUse;
                Location = "East US";
                HDInsightClusterType = "Spark";
                WorkNodeSize = "Large";
                HDInsightClusterVersion = "3.6";
                HDInsightClusterSuffix = "azurehdinsight.net";
                JobPollInterval = HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record ? TimeSpan.FromSeconds(30) : TimeSpan.FromTicks(1);
                JobWaitInterval = TimeSpan.FromMinutes(30);
                ResourceGroupName = TestUtilities.GenerateName("hdisdkrg1");
                HDInsightClusterName = TestUtilities.GenerateName("testcluster1");
                StorageAccountName = TestUtilities.GenerateName("testazureblob1");
                HttpUserName = TestUtilities.GenerateName("testuser1");
                HttpUserPassword = TestUtilities.GenerateName("Password!1");
                SshUserName = TestUtilities.GenerateName("testuser1");
                SshUserPassword = TestUtilities.GenerateName("Password!2");
                ContainerName = TestUtilities.GenerateName("testcontainer1");
                SQLServerName = TestUtilities.GenerateName("testsqlserver1");
                SQLServerDatabaseName = TestUtilities.GenerateName("testdatabase1");
                SQLServerAdminLogin = TestUtilities.GenerateName("testlogin");
                SQLServerAdminLoginPassword = TestUtilities.GenerateName("Password!3");
                SQLServerTableName = TestUtilities.GenerateName("testtable1");

                HDInsightManagementHelper = new HDInsightManagementHelper(this, context);
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.HDInsight");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.Storage");
                HDInsightManagementHelper.RegisterSubscriptionForResource("Microsoft.Sql");

                HDInsightManagementHelper.CreateResourceGroup(ResourceGroupName, Location);
                StorageAccountAccessKey = HDInsightManagementHelper.CreateStorageAccount(this.ResourceGroupName,
                     this.StorageAccountName,
                     "HDInsightTestStorage",
                     "HDInsightTestStorageDescription",
                     this.Location,
                     this.ContainerName,
                     out string storageAccountSuffix);

                HDInsightManagementHelper.CreateSqlServer(
                     this.ResourceGroupName,
                     this.Location,
                     this.SQLServerAdminLogin,
                     this.SQLServerAdminLoginPassword,
                     this.SQLServerName,
                     this.SQLServerDatabaseName,
                     this.SQLServerTableName);

                var createParams = this.HDInsightManagementHelper.GetClusterCreateParameters(this);
                this.HDInsightManagementHelper.CreateHDInsightCluster(
                    this.ResourceGroupName,
                    this.Location,
                    this.HDInsightClusterName,
                    createParams
                );

                // Wait another 5 minutes for the cluster setup
                TestUtilities.Wait(300000);
            }
            catch
            {
                Cleanup();
                throw;
            }
            finally
            {
                HttpMockServer.Flush();
            }
        }

        #region Dispose

        private void Cleanup()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Initialize(this.GetType(), ".cleanup");
            }
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
        #endregion
    }
}
