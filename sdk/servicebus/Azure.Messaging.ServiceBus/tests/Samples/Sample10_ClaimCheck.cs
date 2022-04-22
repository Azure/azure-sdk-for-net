// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
                #region Snippet:CreateBlobContainer
#if SNIPPET
                var containerClient = new BlobContainerClient("<storage connection string>", "claim-checks");
#else
                var containerClient = new BlobContainerClient(TestEnvironment.StorageClaimCheckConnectionString, "claim-checks");
#endif
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
                    var client = new ServiceBusClient("<service bus connection string>");
#else
                    var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
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
                        var blobClient = new BlobClient("<storage connection string>", "claim-checks", (string) blobNameReceived);
#else
                        var blobClient = new BlobClient(
                            TestEnvironment.StorageClaimCheckConnectionString,
                            "claim-checks",
                            (string)blobNameReceived);
#endif
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