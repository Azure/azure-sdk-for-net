//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.HDInsight.Job.Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;

    public class CommonTestsFixture : TestBase, IDisposable
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public string Location  { get; set; }

        /// <summary>
        /// HDInsight cluster name
        /// </summary>
        public string HDInsightClusterName { get; set; }

        /// <summary>
        /// Gets or sets HDInsight cluster suffix.
        /// By default: azurehdinsight.net
        /// </summary>
        public string HDInsightClusterSuffix { get; set; }

        /// <summary>
        /// Gets or sets HDInsight cluster type.
        /// </summary>
        public string HDInsightClusterType { get; set; }

        /// <summary>
        /// Gets or sets the version of the HDInsight cluster.
        /// </summary>
        public string HDInsightClusterVersion { get; set; }

        /// <summary>
        /// Gets or sets the login for the cluster's user.
        /// </summary>
        public string HttpUserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the cluster's user.
        /// </summary>
        public string HttpUserPassword { get; set; }

        /// <summary>
        /// Gets or sets SSH user name.
        /// </summary>
        public string SshUserName { get; set; }

        /// <summary>
        /// Gets or sets SSH password.
        /// </summary>
        public string SshUserPassword { get; set; }

        /// <summary>
        /// Gets or sets storage account name.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets storage account access key.
        /// </summary>
        public string StorageAccountAccessKey { get; set; }

        /// <summary>
        /// Gets or sets storage account container name.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets worker node size.
        /// </summary>
        public string WorkNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the interval to poll for job status.
        /// </summary>
        public TimeSpan JobPollInterval { get; set; }

        /// <summary>
        /// Gets or sets the maximum duration to wait for completion of job before returning to client.
        /// </summary>
        public TimeSpan JobWaitInterval { get; set; }

        /// <summary>
        /// Gets or sets the name of the SQL Server.
        /// </summary>
        public string SQLServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string SQLServerDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the login for the database's user.
        /// </summary>
        public string SQLServerAdminLogin { get; set; }

        /// <summary>
        /// Gets or sets the password for the database's user.
        /// </summary>
        public string SQLServerAdminLoginPassword { get; set; }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        public string SQLServerTableName { get; set; }

        /// <summary>
        /// Gets the JDSC connection string to access SQL server.
        /// </summary>
        public string SQLServerJdbcConnectionString
        {
            get
            {
                return $"jdbc:sqlserver://{SQLServerName}.database.windows.net:1433;database={SQLServerDatabaseName};user={SQLServerAdminLogin};password={SQLServerAdminLoginPassword};";
            }
        }

        /// <summary>
        /// Gets the full qualified HDInsight cluster URL.
        /// </summary>
        public string HDInsightClusterUrl
        {
            get
            {
                return $"{HDInsightClusterName}.{HDInsightClusterSuffix}";
            }
        }

        /// <summary>
        /// Gets or sets the helper for managing resources used during test process.
        /// </summary>
        public HDInsightManagementHelper HDInsightManagementHelper { get; set; }

        /// <summary>
        /// Gets or sets the mock context.
        /// </summary>
        private MockContext context;

        /// <summary>
        /// Ctor.
        /// </summary>
        public CommonTestsFixture()
        {
            var context = MockContext.Start(this.GetType(), ".ctor");
            this.Initialize(context);
        }

        /// <summary>
        /// Initializes common data properties.
        /// </summary>
        public virtual void Initialize(MockContext contextToUse)
        {
            try 
            {
                context = contextToUse;
                Location = "North Central US";
                HDInsightClusterType = "Hadoop";
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

        public void Dispose()
        {
            Cleanup();
        }

        #endregion
    }
}
