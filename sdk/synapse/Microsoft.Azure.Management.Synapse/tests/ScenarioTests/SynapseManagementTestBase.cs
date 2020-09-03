// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class SynapseManagementTestBase : TestBase, IDisposable
    {
        internal static bool IsRecordMode => SynapseManagementTestUtilities.IsRecordMode();

        internal SynapseMockContext Context { get; set; }

        internal CommonTestFixture CommonData { get; set; }

        internal SynapseManagementClient SynapseClient { get; set; }

        internal SynapseManagementHelper SynapseManagementHelper { get; private set; }

        internal virtual void TestInitialize([System.Runtime.CompilerServices.CallerMemberName] string methodName = "testframework_failed")
        {
            Context = SynapseMockContext.Start(this.GetType(), methodName);
            CommonData = new CommonTestFixture();
            SynapseClient = Context.GetServiceClient<SynapseManagementClient>();
            SynapseManagementHelper = new SynapseManagementHelper(CommonData, Context);

            if (IsRecordMode)
            {
                //set mode to none to skip recoding during setup
                HttpMockServer.Mode = HttpRecorderMode.None;
                SynapseManagementHelper.RegisterSubscriptionForResource("Microsoft.Synapse");
                SynapseManagementHelper.RegisterSubscriptionForResource("Microsoft.Storage");
                this.CreateResources();

                //set mode back to record
                HttpMockServer.Mode = HttpRecorderMode.Record;
                string mockedSubscriptionId = TestUtilities.GenerateGuid().ToString();
                CommonData.SubscriptionId = SynapseManagementTestUtilities.GetSubscriptionId();
                this.Context.AddTextReplacementRule(CommonData.SubscriptionId, mockedSubscriptionId);
            }
        }

        protected virtual void CreateResources()
        {
            //create resource group
            SynapseManagementHelper.CreateResourceGroup(CommonData.ResourceGroupName, CommonData.Location);
            
            //create data lake storage
            CommonData.StorageAccountKey = SynapseManagementHelper.CreateStorageAccount(
                CommonData.ResourceGroupName,
                CommonData.StorageAccountName,
                CommonData.Location,
                out string storageAccountSuffix);
            CommonData.DefaultDataLakeStorageAccountUrl = string.Format("https://{0}.dfs.{1}", CommonData.StorageAccountName, storageAccountSuffix);
        }

        #region Dispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                if (SynapseClient != null)
                {
                    SynapseClient.Dispose();
                }

                if (Context != null)
                {
                    Context.Dispose();
                }
            }

            disposed = true;
        }

        #endregion
    }
}
