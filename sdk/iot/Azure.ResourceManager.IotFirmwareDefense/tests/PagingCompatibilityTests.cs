// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class PagingCompatibilityTests
    {
        private const string SubscriptionId = "83aa47df-e3e9-49ff-877b-94304bf3d3ad";

        [TestCase(false)]
        [TestCase(true)]
        public async Task SubscriptionListingRespectsApiVersion(bool isAsync)
        {
            Uri requestUri = null;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    requestUri = request.Uri.ToUri();
                    return new MockResponse(200).SetContent("{\"value\":[]}");
                })
            };
            options.SetApiVersion(FirmwareAnalysisWorkspaceResource.ResourceType, "2025-08-02");
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            SubscriptionResource subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            if (isAsync)
            {
                await foreach (FirmwareAnalysisWorkspaceResource workspace in subscription.GetFirmwareAnalysisWorkspacesAsync())
                {
                    Assert.Fail("The mocked collection is empty.");
                }
            }
            else
            {
                foreach (FirmwareAnalysisWorkspaceResource workspace in subscription.GetFirmwareAnalysisWorkspaces())
                {
                    Assert.Fail("The mocked collection is empty.");
                }
            }

            Assert.IsNotNull(requestUri);
            Assert.That(requestUri.Query, Does.Contain("api-version=2025-08-02"));
        }

        [Test]
        public void AsyncListingRespectsCancellation(
            [Values] bool resourceListing,
            [Values] bool enumerationToken,
            [Values] bool asPages,
            [Values] bool duringRequest)
        {
            using var methodCancellation = new CancellationTokenSource();
            using var enumerationCancellation = new CancellationTokenSource();
            CancellationTokenSource cancellation = enumerationToken ? enumerationCancellation : methodCancellation;
            if (!duringRequest)
            {
                cancellation.Cancel();
            }

            var options = new ArmClientOptions
            {
                Transport = MockTransport.FromMessageCallback(message =>
                {
                    if (duringRequest)
                    {
                        cancellation.Cancel();
                    }
                    message.CancellationToken.ThrowIfCancellationRequested();
                    return new MockResponse(200).SetContent("{\"value\":[]}");
                })
            };
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);

            if (resourceListing)
            {
                SubscriptionResource subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
                AssertEnumerationCanceled(subscription.GetFirmwareAnalysisWorkspacesAsync(methodCancellation.Token), enumerationCancellation.Token, asPages);
            }
            else
            {
                var id = IotFirmwareResource.CreateResourceIdentifier(SubscriptionId, "rg", "workspace", "firmware");
                IotFirmwareResource firmware = client.GetIotFirmwareResource(id);
                AssertEnumerationCanceled(firmware.GetCvesAsync(methodCancellation.Token), enumerationCancellation.Token, asPages);
            }
        }

        private static void AssertEnumerationCanceled<T>(AsyncPageable<T> pageable, CancellationToken cancellationToken, bool asPages)
        {
            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                if (asPages)
                {
                    await foreach (Page<T> page in pageable.AsPages().WithCancellation(cancellationToken))
                    {
                        Assert.Fail("The mocked collection is empty.");
                    }
                }
                else
                {
                    await foreach (T item in pageable.WithCancellation(cancellationToken))
                    {
                        Assert.Fail("The mocked collection is empty.");
                    }
                }
            });
        }
    }
}
