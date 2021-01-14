// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class LogAnalyticsTests : VMTestBase
    {
        [Fact]
        public void TestExportingThrottlingLogs()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string rg1Name = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);

                try
                {
                    EnsureClientsInitialized(context);

                    string sasUri = GetBlobContainerSasUri(rg1Name, storageAccountName);

                    RequestRateByIntervalInput requestRateByIntervalInput = new RequestRateByIntervalInput()
                    {
                        BlobContainerSasUri = sasUri,
                        FromTime = DateTime.UtcNow.AddDays(-10),
                        ToTime = DateTime.UtcNow.AddDays(-8),
                        IntervalLength = IntervalInMins.FiveMins,
                    };

                    var result = m_CrpClient.LogAnalytics.ExportRequestRateByInterval(requestRateByIntervalInput, "westcentralus");

                    //BUG: LogAnalytics API does not return correct result.
                    //Assert.EndsWith(".csv", result.Properties.Output);

                    ThrottledRequestsInput throttledRequestsInput = new ThrottledRequestsInput()
                    {
                        BlobContainerSasUri = sasUri,
                        FromTime = DateTime.UtcNow.AddDays(-10),
                        ToTime = DateTime.UtcNow.AddDays(-8),
                        GroupByOperationName = true,
                    };

                    result = m_CrpClient.LogAnalytics.ExportThrottledRequests(throttledRequestsInput, "westcentralus");

                    //BUG: LogAnalytics API does not return correct result.
                    //Assert.EndsWith(".csv", result.Properties.Output);

                    ThrottledRequestsInput throttledRequestsInput2 = new ThrottledRequestsInput()
                    {
                        BlobContainerSasUri = sasUri,
                        FromTime = DateTime.UtcNow.AddDays(-10),
                        ToTime = DateTime.UtcNow.AddDays(-8),
                        GroupByOperationName = false,
                        GroupByClientApplicationId = true,
                        GroupByUserAgent = false,
                    };

                    result = m_CrpClient.LogAnalytics.ExportThrottledRequests(throttledRequestsInput2, "eastus2");
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rg1Name);
                }
            }
        }

        private string GetBlobContainerSasUri(string rg1Name, string storageAccountName)
        {
            string sasUri = "foobar";

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                StorageAccount storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);
                var accountKeyResult = m_SrpClient.StorageAccounts.ListKeysWithHttpMessagesAsync(rg1Name, storageAccountName).Result;
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, accountKeyResult.Body.Key1), useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("sascontainer");
                container.CreateIfNotExistsAsync();
                sasUri = GetContainerSasUri(container);
            }

            return sasUri;
        }

        private string GetContainerSasUri(CloudBlobContainer container)
        {
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddDays(-1);
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddDays(2);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            //Generate the shared access signature on the blob, setting the constraints directly on the signature.
            string sasContainerToken = container.GetSharedAccessSignature(sasConstraints);

            //Return the URI string for the container, including the SAS token.
            return container.Uri + sasContainerToken;
        }
    }
}
