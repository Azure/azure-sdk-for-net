// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample10_ClaimCheck : ServiceBusLiveTestBase
    {
        [Test]
        public async Task ClaimCheck()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                Uri accountUri = new($"https://{TestEnvironment.StorageClaimCheckAccountName}.blob.core.windows.net/claim-checks");
                #region Snippet:CreateBlobContainer
#if SNIPPET
                DefaultAzureCredential credential = new();
#else
                var credential = TestEnvironment.Credential;
#endif
                var containerClient = new BlobContainerClient(accountUri, credential);
                await containerClient.CreateIfNotExistsAsync();
#endregion

                try
                {
                    #region Snippet:UploadMessage

                    byte[] body = ServiceBusTestUtilities.GetRandomBuffer(1000000);
                    string blobName = Guid.NewGuid().ToString();
                    await containerClient.UploadBlobAsync(blobName, new BinaryData(body));
                    var message = new ServiceBusMessage
                    {
                        ApplicationProperties =
                        {
                            ["blob-name"] = blobName
                        }
                    };

                    #endregion

                    #region Snippet:ClaimCheckSendMessage

#if SNIPPET
                    ServiceBusClient client = new("<service bus fully qualified namespace>", credential);
#else
                    ServiceBusClient client = new(TestEnvironment.FullyQualifiedNamespace, credential);
#endif
                    ServiceBusSender sender = client.CreateSender(scope.QueueName);
                    await sender.SendMessageAsync(message);

                    #endregion

                    #region Snippet:ReceiveClaimCheck

                    ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);
                    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                    if (receivedMessage.ApplicationProperties.TryGetValue("blob-name", out object blobNameReceived))
                    {
#if SNIPPET
                        Uri blobUri = new($"https://<storage account name>.blob.core.windows.net/claim-checks/{(string)blobNameReceived}");
#else
                        Uri blobUri = new($"https://{TestEnvironment.StorageClaimCheckAccountName}.blob.core.windows.net/claim-checks/{(string)blobNameReceived}");
#endif
                        var blobClient = new BlobClient(blobUri, credential);

                        BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                        BinaryData messageBody = downloadResult.Content;

                        // Once we determine that we are done with the message, we complete it and delete the corresponding blob.
                        await receiver.CompleteMessageAsync(receivedMessage);
                        await blobClient.DeleteAsync();
#if !SNIPPET
                        Assert.AreEqual(body, messageBody.ToArray());
#endif
                    }
                    #endregion
                }
                finally
                {
                    await containerClient.DeleteAsync();
                }
            }
        }
    }
}
