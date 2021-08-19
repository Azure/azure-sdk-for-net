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

                #region Snippet:UploadMessage
                byte[] body = GetRandomBuffer(1000000);
                var blobName = Guid.NewGuid().ToString();
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
                var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                if (receivedMessage.ApplicationProperties.TryGetValue("blob-name", out object blobNameReceived))
                {
                    var blobClient = new BlobClient(TestEnvironment.StorageClaimCheckConnectionString, "claim-checks", (string) blobNameReceived);
                    BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                    BinaryData messageBody = downloadResult.Content;
#if !SNIPPET
                    Assert.AreEqual(body, messageBody.ToArray());
#endif
                }
                #endregion
            }
        }
    }
}