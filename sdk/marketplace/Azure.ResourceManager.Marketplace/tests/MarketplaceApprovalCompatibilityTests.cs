// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Marketplace.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Marketplace.Tests
{
    public class MarketplaceApprovalCompatibilityTests
    {
        private static readonly Guid StoreId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        private const string RequestId = "request1";
        private const string Publisher = "publisher1";

        private static ArmClient CreateClient(MockTransport transport)
            => new ArmClient(new MockCredential(), StoreId.ToString(), new ArmClientOptions { Transport = transport });

        private static string ResourcePath(bool admin)
            => $"/providers/Microsoft.Marketplace/privateStores/{StoreId}/{(admin ? "adminRequestApprovals" : "requestApprovals")}/{RequestId}";

        private static string ResourceJson(bool admin)
            => $"{{\"id\":\"{ResourcePath(admin)}\",\"name\":\"{RequestId}\",\"type\":\"Microsoft.Marketplace/privateStores/{(admin ? "adminRequestApprovals" : "requestApprovals")}\",\"properties\":{{\"offerId\":\"offer1\",\"publisherId\":\"{Publisher}\",\"displayName\":\"Display\",\"offerDisplayName\":\"Display\",\"approvedPlans\":[\"plan1\"],\"messageCode\":42}}}}";

        [Test]
        public void LegacyModelsAndFactoriesRoundTrip()
        {
            var regular = ArmMarketplaceModelFactory.MarketplaceApprovalRequestData(
                offerId: "offer1", publisherId: Publisher, offerDisplayName: "Display", isClosed: true, messageCode: 42);
            var admin = ArmMarketplaceModelFactory.MarketplaceAdminApprovalRequestData(
                offerId: "offer2", publisherId: Publisher, displayName: "Admin display", approvedPlans: new[] { "plan1" });

            var regularCopy = ModelReaderWriter.Read<MarketplaceApprovalRequestData>(
                ModelReaderWriter.Write(regular, ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default),
                ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default);
            var adminCopy = ModelReaderWriter.Read<MarketplaceAdminApprovalRequestData>(
                ModelReaderWriter.Write(admin, ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default),
                ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default);

            Assert.That(regularCopy.OfferId, Is.EqualTo("offer1"));
            Assert.That(regularCopy.OfferDisplayName, Is.EqualTo("Display"));
            Assert.That(regularCopy.IsClosed, Is.True);
            Assert.That(regularCopy.MessageCode, Is.EqualTo(42));
            Assert.That(adminCopy.OfferId, Is.EqualTo("offer2"));
            Assert.That(adminCopy.DisplayName, Is.EqualTo("Admin display"));
            Assert.That(adminCopy.ApprovedPlans, Is.EqualTo(new[] { "plan1" }));

            const string unknownJson = "{\"properties\":{\"offerId\":\"offer1\",\"futureProperty\":\"kept\"},\"futureRoot\":true}";
            var withUnknown = ModelReaderWriter.Read<MarketplaceApprovalRequestData>(
                BinaryData.FromString(unknownJson), ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default);
            string roundTrip = ModelReaderWriter.Write(withUnknown, ModelReaderWriterOptions.Json, AzureResourceManagerMarketplaceContext.Default).ToString();
            using var document = JsonDocument.Parse(roundTrip);
            Assert.That(document.RootElement.GetProperty("futureRoot").GetBoolean(), Is.True);
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("futureProperty").GetString(), Is.EqualTo("kept"));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task LegacyCollectionListsReturnLegacyData(bool admin, bool async)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent($"{{\"value\":[{ResourceJson(admin)}]}}"));
            var client = CreateClient(transport);
            var store = client.GetPrivateStoreResource(PrivateStoreResource.CreateResourceIdentifier(StoreId));
            var values = new List<string>();

            if (admin)
            {
                var collection = store.GetMarketplaceAdminApprovalRequests();
                Assert.That(store.GetMarketplaceAdminRequestApprovals(), Is.Not.Null);
                if (async)
                {
                    await foreach (var resource in collection.GetAllAsync())
                    {
                        Assert.That(resource.HasData, Is.True);
                        Assert.That(resource.Data.ApprovedPlans, Is.EqualTo(new[] { "plan1" }));
                        values.Add(resource.Data.OfferId);
                    }
                }
                else
                {
                    foreach (var resource in collection.GetAll())
                    {
                        Assert.That(resource.HasData, Is.True);
                        Assert.That(resource.Data.ApprovedPlans, Is.EqualTo(new[] { "plan1" }));
                        values.Add(resource.Data.OfferId);
                    }
                }
            }
            else
            {
                var collection = store.GetMarketplaceApprovalRequests();
                Assert.That(store.GetMarketplaceRequestApprovals(), Is.Not.Null);
                if (async)
                {
                    await foreach (var resource in collection.GetAllAsync())
                    {
                        Assert.That(resource.HasData, Is.True);
                        Assert.That(resource.Data.MessageCode, Is.EqualTo(42));
                        values.Add(resource.Data.OfferId);
                    }
                }
                else
                {
                    foreach (var resource in collection.GetAll())
                    {
                        Assert.That(resource.HasData, Is.True);
                        Assert.That(resource.Data.MessageCode, Is.EqualTo(42));
                        values.Add(resource.Data.OfferId);
                    }
                }
            }

            Assert.That(values, Is.EqualTo(new[] { "offer1" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(ResourcePath(admin).Substring(0, ResourcePath(admin).LastIndexOf('/'))));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task LegacyResourceEntryPointsGetServiceData(bool admin, bool async)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent(ResourceJson(admin)));
            var client = CreateClient(transport);
            var store = client.GetPrivateStoreResource(PrivateStoreResource.CreateResourceIdentifier(StoreId));

            if (admin)
            {
                var withoutData = client.GetMarketplaceAdminApprovalRequestResource(MarketplaceAdminApprovalRequestResource.CreateResourceIdentifier(StoreId, RequestId));
                Assert.That(withoutData.HasData, Is.False);
                var result = async
                    ? (await store.GetMarketplaceAdminApprovalRequestAsync(RequestId, Publisher)).Value
                    : store.GetMarketplaceAdminApprovalRequest(RequestId, Publisher).Value;
                Assert.That(result.Id, Is.EqualTo(withoutData.Id));
                Assert.That(result.Data.OfferId, Is.EqualTo("offer1"));
                Assert.That(result.Data.ApprovedPlans, Is.EqualTo(new[] { "plan1" }));
                string persisted = ((IPersistableModel<MarketplaceAdminApprovalRequestData>)result).Write(ModelReaderWriterOptions.Json).ToString();
                Assert.That(persisted, Does.Contain("\"offerId\":\"offer1\""));
            }
            else
            {
                var withoutData = client.GetMarketplaceApprovalRequestResource(MarketplaceApprovalRequestResource.CreateResourceIdentifier(StoreId, RequestId));
                Assert.That(withoutData.HasData, Is.False);
                var result = async
                    ? (await store.GetMarketplaceApprovalRequestAsync(RequestId)).Value
                    : store.GetMarketplaceApprovalRequest(RequestId).Value;
                Assert.That(result.Id, Is.EqualTo(withoutData.Id));
                Assert.That(result.Data.OfferId, Is.EqualTo("offer1"));
                Assert.That(result.Data.MessageCode, Is.EqualTo(42));
                string persisted = ((IPersistableModel<MarketplaceApprovalRequestData>)result).Write(ModelReaderWriterOptions.Json).ToString();
                Assert.That(persisted, Does.Contain("\"offerId\":\"offer1\""));
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(ResourcePath(admin)));
            if (admin)
            {
                Assert.That(transport.Requests[0].Uri.ToUri().Query, Does.Contain($"publisherId={Publisher}"));
            }
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task LegacyGetIfExistsHandlesNotFound(bool admin, bool async)
        {
            var transport = new MockTransport(new MockResponse(404));
            var client = CreateClient(transport);
            var store = client.GetPrivateStoreResource(PrivateStoreResource.CreateResourceIdentifier(StoreId));
            bool hasValue;
            if (admin)
            {
                var collection = store.GetMarketplaceAdminApprovalRequests();
                hasValue = async
                    ? (await collection.GetIfExistsAsync(RequestId, Publisher)).HasValue
                    : collection.GetIfExists(RequestId, Publisher).HasValue;
            }
            else
            {
                var collection = store.GetMarketplaceApprovalRequests();
                hasValue = async
                    ? (await collection.GetIfExistsAsync(RequestId)).HasValue
                    : collection.GetIfExists(RequestId).HasValue;
            }

            Assert.That(hasValue, Is.False);
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(ResourcePath(admin)));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task LegacyCreateSendsWritableProperties(bool admin, bool async)
        {
            string requestBody = null;
            var transport = new MockTransport(request =>
            {
                using var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                requestBody = Encoding.UTF8.GetString(stream.ToArray());
                return new MockResponse(200).SetContent(ResourceJson(admin));
            });
            var client = CreateClient(transport);
            var store = client.GetPrivateStoreResource(PrivateStoreResource.CreateResourceIdentifier(StoreId));

            if (admin)
            {
                var data = new MarketplaceAdminApprovalRequestData { OfferId = "submitted", PublisherId = Publisher };
                data.ApprovedPlans.Add("plan1");
                var collection = store.GetMarketplaceAdminApprovalRequests();
                var operation = async
                    ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, RequestId, data)
                    : collection.CreateOrUpdate(WaitUntil.Completed, RequestId, data);
                Assert.That(operation.Value.Data.OfferId, Is.EqualTo("offer1"));
            }
            else
            {
                var data = new MarketplaceApprovalRequestData { OfferId = "submitted", PublisherId = Publisher, MessageCode = 42 };
                var collection = store.GetMarketplaceApprovalRequests();
                var operation = async
                    ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, RequestId, data)
                    : collection.CreateOrUpdate(WaitUntil.Completed, RequestId, data);
                Assert.That(operation.Value.Data.OfferId, Is.EqualTo("offer1"));
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(ResourcePath(admin)));
            using var document = JsonDocument.Parse(requestBody);
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("offerId").GetString(), Is.EqualTo("submitted"));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("publisherId").GetString(), Is.EqualTo(Publisher));
            if (admin)
            {
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("approvedPlans")[0].GetString(), Is.EqualTo("plan1"));
            }
            else
            {
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("messageCode").GetInt64(), Is.EqualTo(42));
            }
        }
    }
}
