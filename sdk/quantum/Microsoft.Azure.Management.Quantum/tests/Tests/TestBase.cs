using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.Quantum.Tests
{
    public class QuantumManagementTestBase : TestBase, IDisposable
    {
        internal static bool IsRecordMode => QuantumManagementTestUtilities.IsRecordMode();

        internal QuantumMockContext Context { get; set; }

        internal CommonTestFixture CommonData { get; set; }

        internal QuantumManagementClient QuantumClient { get; set; }

        internal QuantumManagementHelper QuantumManagementHelper { get; private set; }

        internal virtual void TestInitialize([System.Runtime.CompilerServices.CallerMemberName] string methodName = "testframework_failed")
        {
            Context = QuantumMockContext.Start(this.GetType(), methodName);

            UseAccessTokenIfNeeded();

            CommonData = new CommonTestFixture();
            QuantumClient = Context.GetServiceClient<QuantumManagementClient>();
            QuantumManagementHelper = new QuantumManagementHelper(CommonData, Context);

            if (IsRecordMode)
            {
                //set mode to none to skip recoding during setup
                HttpMockServer.Mode = HttpRecorderMode.None;
                QuantumManagementHelper.RegisterSubscriptionForResource("Microsoft.Quantum");
                QuantumManagementHelper.RegisterSubscriptionForResource("Microsoft.Storage");
                this.CreateResources();

                //set mode back to record
                HttpMockServer.Mode = HttpRecorderMode.Record;
                string mockedSubscriptionId = TestUtilities.GenerateGuid().ToString();
                CommonData.SubscriptionId = QuantumManagementTestUtilities.GetSubscriptionId();
                this.Context.AddTextReplacementRule(CommonData.SubscriptionId, mockedSubscriptionId);
            }
        }

        private static void UseAccessTokenIfNeeded()
        {
            var testConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            if (!testConnectionString.Contains("ServicePrincipal=") && IsRecordMode)
            {
                var azProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo("cmd.exe", "/c az account get-access-token")
                    {
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true
                    }
                };
                azProcess.Start();
                azProcess.WaitForExit();
                var output = azProcess.StandardOutput.ReadToEnd();
                var accessToken = JObject.Parse(output)["accessToken"].Value<string>();
                Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $"{testConnectionString}RawToken={accessToken};");
            }
        }

        protected virtual void CreateResources()
        {
            //create resource group
            QuantumManagementHelper.CreateResourceGroup(CommonData.ResourceGroupName, CommonData.Location);

            //create storage account
            CommonData.StorageAccountKey = QuantumManagementHelper.CreateStorageAccount(
                CommonData.ResourceGroupName,
                CommonData.StorageAccountName,
                CommonData.Location,
                out string storageAccountSuffix,
                out string storageAccountId);
            CommonData.StorageAccountId = storageAccountId;
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
                if (QuantumClient != null)
                {
                    QuantumClient.Dispose();
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