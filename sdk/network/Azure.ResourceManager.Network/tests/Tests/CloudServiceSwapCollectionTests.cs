// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class CloudServiceSwapCollectionTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ParentPath = "/subscriptions/" + SubscriptionId + "/resourceGroups/selectedGroup/providers/microsoft.Compute/cloudServices/selectedCloudService";
        private const string ListPath = ParentPath + "/providers/Microsoft.Network/cloudServiceSlots";
        private const string Payload = "{\"value\":[{\"id\":\"" + ListPath + "/staging\",\"name\":\"staging\",\"type\":\"Microsoft.Network/cloudServiceSlots\",\"properties\":{\"slotType\":\"Staging\"}},{\"id\":\"" + ListPath + "/production\",\"name\":\"production\",\"type\":\"Microsoft.Network/cloudServiceSlots\",\"properties\":{\"slotType\":\"Production\"}}]}";

        [Test]
        public void GetAllRetainsReleasedOptionalCancellationContract()
        {
            foreach (string name in new[] { "GetAll", "GetAllAsync" })
            {
                var method = typeof(CloudServiceSwapCollection).GetMethod(name);
                Assert.That(method.IsVirtual, Is.True);
                Assert.That(method.DeclaringType, Is.EqualTo(typeof(CloudServiceSwapCollection)));
                Assert.That(method.ReturnType, Is.EqualTo(name == "GetAll"
                    ? typeof(Pageable<CloudServiceSwapResource>)
                    : typeof(AsyncPageable<CloudServiceSwapResource>)));
                var parameter = method.GetParameters().Single();
                Assert.That(parameter.Name, Is.EqualTo("cancellationToken"));
                Assert.That(parameter.ParameterType, Is.EqualTo(typeof(CancellationToken)));
                Assert.That(parameter.IsOptional, Is.True);
                Assert.That(parameter.HasDefaultValue, Is.True);
                Assert.That(parameter.DefaultValue, Is.Null);
                Assert.That(Attribute.IsDefined(method, typeof(ObsoleteAttribute)), Is.False);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetAllReturnsWrappedResourcesFromOnePage(bool asynchronous)
        {
            using var cancellation = new CancellationTokenSource();
            CancellationToken observedToken = default;
            var response = new MockResponse(200).SetContent(Payload);
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observedToken = message.CancellationToken;
                return response;
            });
            var collection = CreateCollection(transport);
            using var diagnostics = new ClientDiagnosticListener("Azure.ResourceManager.Network", asyncLocal: true);
            var pages = new List<Page<CloudServiceSwapResource>>();

            if (asynchronous)
            {
                await foreach (var page in collection.GetAllAsync(cancellation.Token).AsPages())
                {
                    pages.Add(page);
                }
            }
            else
            {
                pages.AddRange(collection.GetAll(cancellation.Token).AsPages());
            }

            Assert.That(pages, Has.Count.EqualTo(1));
            Assert.That(pages[0].ContinuationToken, Is.Null);
            Assert.That(pages[0].GetRawResponse(), Is.SameAs(response));
            AssertResources(pages[0].Values);
            Assert.That(observedToken.CanBeCanceled, Is.True);
            AssertRequest(transport);
            var scope = diagnostics.Scopes.Single(item => item.Name.EndsWith("CloudServiceSwapCollection.GetAll", StringComparison.Ordinal));
            Assert.That(scope.IsCompleted, Is.True);
            Assert.That(scope.Exception, Is.Null);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public async Task CollectionEnumeratorsFetchResourcesInsteadOfReturningEmpty(int contract)
        {
            using var cancellation = new CancellationTokenSource();
            CancellationToken observedToken = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observedToken = message.CancellationToken;
                return new MockResponse(200).SetContent(Payload);
            });
            var collection = CreateCollection(transport);
            var resources = new List<CloudServiceSwapResource>();
            if (contract == 2)
            {
                await foreach (var resource in ((IAsyncEnumerable<CloudServiceSwapResource>)collection).WithCancellation(cancellation.Token))
                {
                    resources.Add(resource);
                }
                Assert.That(observedToken.CanBeCanceled, Is.True);
            }
            else if (contract == 1)
            {
                foreach (CloudServiceSwapResource resource in (IEnumerable)collection)
                {
                    resources.Add(resource);
                }
            }
            else
            {
                resources.AddRange((IEnumerable<CloudServiceSwapResource>)collection);
            }
            AssertResources(resources);
            AssertRequest(transport);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetAllPropagatesCancellation(int contract)
        {
            using var cancellation = new CancellationTokenSource();
            CancellationToken observedToken = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                observedToken = message.CancellationToken;
                cancellation.Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200).SetContent(Payload);
            });
            var collection = CreateCollection(transport);
            using var diagnostics = new ClientDiagnosticListener("Azure.ResourceManager.Network", asyncLocal: true);
            if (contract == 2)
            {
                Assert.CatchAsync<OperationCanceledException>(async () =>
                {
                    await foreach (var resource in ((IAsyncEnumerable<CloudServiceSwapResource>)collection).WithCancellation(cancellation.Token))
                    {
                    }
                });
            }
            else if (contract == 1)
            {
                Assert.CatchAsync<OperationCanceledException>(async () =>
                {
                    await foreach (var resource in collection.GetAllAsync(cancellation.Token))
                    {
                    }
                });
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => collection.GetAll(cancellation.Token).ToList());
            }
            Assert.That(observedToken.IsCancellationRequested, Is.True);
            AssertRequest(transport);
            var scope = diagnostics.Scopes.Single(item => item.Name.EndsWith("CloudServiceSwapCollection.GetAll", StringComparison.Ordinal));
            Assert.That(scope.IsCompleted, Is.True);
            Assert.That(scope.Exception, Is.InstanceOf<OperationCanceledException>());
        }

        private static CloudServiceSwapCollection CreateCollection(MockTransport transport)
        {
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            return client.GetCloudServiceSwaps(new ResourceIdentifier(ParentPath));
        }

        private static void AssertResources(IReadOnlyList<CloudServiceSwapResource> resources)
        {
            Assert.That(resources, Has.Count.EqualTo(2));
            for (int i = 0; i < resources.Count; i++)
            {
                string name = i == 0 ? "staging" : "production";
                Assert.That(resources[i].HasData, Is.True);
                Assert.That(resources[i].Id.ToString(), Is.EqualTo(ListPath + "/" + name));
                Assert.That(resources[i].Data.Id, Is.EqualTo(resources[i].Id));
                Assert.That(resources[i].Data.Name, Is.EqualTo(name));
                Assert.That(resources[i].Data.CloudServiceSwapSlotType, Is.EqualTo(i == 0 ? SwapSlotType.Staging : SwapSlotType.Production));
            }
        }

        private static void AssertRequest(MockTransport transport)
        {
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.SingleRequest.Uri.ToUri().AbsolutePath, Is.EqualTo(ListPath));
            Assert.That(transport.SingleRequest.Uri.ToUri().Query, Is.EqualTo("?api-version=2026-01-01"));
        }
    }
}
