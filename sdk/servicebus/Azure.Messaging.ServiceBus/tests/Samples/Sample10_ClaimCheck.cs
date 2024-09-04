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
                Uri accountUri = TestEnvironment.StorageClaimCheckAccountUri;
                #region Snippet:CreateBlobContainer
                var containerClient = new BlobContainerClient(accountUri, new DefaultAzureCredential());
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
                    ServiceBusClient client = new("<service bus fully qualified namespace>", new DefaultAzureCredential());
#else
                    ServiceBusClient client = new(TestEnvironment.FullyQualifiedNamespace, new DefaultAzureCredential());
#endif
                    ServiceBusSender sender = client.CreateSender(scope.QueueName);
                    await sender.SendMessageAsync(message);

                    #endregion

                    #region Snippet:ReceiveClaimCheck

                    ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);
                    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                    if (receivedMessage.ApplicationProperties.TryGetValue("blob-name", out object blobNameReceived))
                    {
                        var blobClient = new BlobClient(accountUri, new DefaultAzureCredential());

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
