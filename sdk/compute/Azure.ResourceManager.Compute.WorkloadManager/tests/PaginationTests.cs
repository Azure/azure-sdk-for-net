// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.WorkloadManager.Tests
{
    public class PaginationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        private static IEnumerable<TestCaseData> CancellationCases()
        {
            foreach (string list in new[] { "Bindings", "Links", "Capabilities", "ResourceGroup", "Subscription" })
            foreach (bool pages in new[] { false, true })
            foreach (string mode in new[] { "Method", "Enumeration", "BothMethod", "BothEnumeration" })
                yield return new TestCaseData(list, pages, mode);
        }

        [TestCaseSource(nameof(CancellationCases))]
        public void AsyncListingHonorsCancellation(string list, bool pages, string mode)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            if (mode == "Method" || mode == "BothMethod")
                methodSource.Cancel();
            else
                enumerationSource.Cancel();

            var transport = MockTransport.FromMessageCallback(message =>
            {
                // MockTransport does not enforce cancellation itself.
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200).SetContent("{\"value\":[]}");
            });
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            CancellationToken methodToken = mode == "Enumeration" ? default : methodSource.Token;
            CancellationToken enumerationToken = mode == "Method" ? default : enumerationSource.Token;

            Assert.CatchAsync<System.OperationCanceledException>(() => EnumerateList(client, list, pages, methodToken, enumerationToken));
        }

        [TestCase(false, null)]
        [TestCase(true, null)]
        [TestCase(false, "2099-01-01")]
        [TestCase(true, "2099-01-01")]
        public async Task SubscriptionListingHonorsApiVersion(bool isAsync, string apiVersion)
        {
            int requests = 0;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                requests++;
                string content = requests == 1
                    ? "{\"value\":[],\"nextLink\":\"https://management.azure.com/subscriptions/" + SubscriptionId + "/providers/Microsoft.Compute/workloadSpaces?$skiptoken=next\"}"
                    : "{\"value\":[]}";
                return new MockResponse(200).SetContent(content);
            });
            var options = new ArmClientOptions { Transport = transport };
            if (apiVersion != null)
                options.SetApiVersion(WorkloadSpaceResource.ResourceType, apiVersion);
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            if (isAsync)
            {
                await foreach (var item in subscription.GetWorkloadSpacesAsync()) { }
            }
            else
            {
                foreach (var item in subscription.GetWorkloadSpaces()) { }
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            foreach (var request in transport.Requests)
                Assert.That(request.Uri.ToUri().Query, Does.Contain("api-version=" + (apiVersion ?? "2026-11-01-preview")));
        }

        internal static Task EnumerateList(ArmClient client, string list, bool pages, CancellationToken methodToken, CancellationToken enumerationToken)
        {
            var space = client.GetWorkloadSpaceResource(WorkloadSpaceResource.CreateResourceIdentifier(SubscriptionId, "rg", "space"));
            return list switch
            {
                "Bindings" => Enumerate(space.GetRuntimeBindings().GetAllAsync(methodToken), pages, enumerationToken),
                "Links" => Enumerate(space.GetRuntimeLinks().GetAllAsync(methodToken), pages, enumerationToken),
                "Capabilities" => Enumerate(space.GetWorkloadCapabilities().GetAllAsync(methodToken), pages, enumerationToken),
                "ResourceGroup" => Enumerate(client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "rg")).GetWorkloadSpaces().GetAllAsync(methodToken), pages, enumerationToken),
                "Subscription" => Enumerate(client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId)).GetWorkloadSpacesAsync(methodToken), pages, enumerationToken),
                _ => throw new System.ArgumentException("Unknown list", nameof(list))
            };
        }

        private static async Task Enumerate<T>(AsyncPageable<T> source, bool pages, CancellationToken token)
        {
            if (pages)
            {
                await foreach (var page in source.AsPages().WithCancellation(token)) { }
            }
            else
            {
                await foreach (var item in source.WithCancellation(token)) { }
            }
        }
    }
}
