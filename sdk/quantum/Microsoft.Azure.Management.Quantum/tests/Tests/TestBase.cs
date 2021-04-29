using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

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

            UseAzLoginCredentialsIfNeeded();

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

        private static void UseAzLoginCredentialsIfNeeded()
        {
            if (IsRecordMode)
            {
                var testConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
                AzLoginAccessTokenInfo accessTokenInfo = null;
                if (string.IsNullOrEmpty(testConnectionString))
                {
                    accessTokenInfo = GetAzLoginAccessTokenInfo();
                    if (accessTokenInfo == null) return;
                    testConnectionString = $"SubscriptionId={accessTokenInfo.SubscriptionId};AADTenant={accessTokenInfo.TenantId};Environment=Prod;HttpRecorderMode=Record;";
                    Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", testConnectionString);
                }
                if (!testConnectionString.Contains("ServicePrincipal="))
                    accessTokenInfo = accessTokenInfo ?? GetAzLoginAccessTokenInfo();                {
                    if (accessTokenInfo == null) return;
                    Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $"{testConnectionString};RawToken={accessTokenInfo.AccessToken};");
                }
            }
        }

        private class AzLoginAccessTokenInfo
        {
            [JsonProperty("subscription")]
            public string SubscriptionId { get; set; }

            [JsonProperty("tenant")]
            public string TenantId { get; set; }

            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }
        }

        private static AzLoginAccessTokenInfo GetAzLoginAccessTokenInfo()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (!isWindows)
            {
                return null;
            }

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
            var azProcessOutput = azProcess.StandardOutput.ReadToEnd();
            var accessTokenInfo = JsonConvert.DeserializeObject<AzLoginAccessTokenInfo>(azProcessOutput);
            return accessTokenInfo;
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