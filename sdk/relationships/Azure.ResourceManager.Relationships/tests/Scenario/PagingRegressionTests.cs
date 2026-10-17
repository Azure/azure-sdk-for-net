// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests.Scenario
{
    public class PagingRegressionTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string GroupId = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg-paging";
        private const string ServiceGroupId = "/providers/Microsoft.Management/serviceGroups/sg-paging";
        private static readonly string[] Families = { "GroupContains", "SubscriptionContains", "Dependency", "Member", "ServiceGroupDependency" };

        public static IEnumerable<TestCaseData> CancellationCases()
        {
            foreach (string family in Families)
            {
                foreach (bool pages in new[] { false, true })
                {
                    foreach (string tokens in new[] { "Method", "Enumerator", "BothMethodCanceled", "BothEnumeratorCanceled" })
                    {
                        yield return new TestCaseData(family, pages, tokens);
                    }
                }
            }
        }

        public static IEnumerable<TestCaseData> ContinuationCases()
        {
            foreach (string family in Families)
            {
                foreach (bool async in new[] { false, true })
                {
                    foreach (string linkKind in new[] { "RootRelative", "PathRelative", "Absolute" })
                    {
                        yield return new TestCaseData(family, async, linkKind);
                    }
                }
            }
        }

        [TestCaseSource(nameof(CancellationCases))]
        public void EnumerationPropagatesCancellation(string family, bool pages, string tokens)
        {
            CancellationToken receivedToken = default;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                receivedToken = message.CancellationToken;
                receivedToken.ThrowIfCancellationRequested();
                return EmptyPage();
            });
            ArmClient client = CreateClient(transport);
            using var methodSource = new CancellationTokenSource();
            using var enumeratorSource = new CancellationTokenSource();
            if (tokens == "Method" || tokens == "BothMethodCanceled")
            {
                methodSource.Cancel();
            }
            else
            {
                enumeratorSource.Cancel();
            }
            CancellationToken methodToken = tokens == "Enumerator" ? default : methodSource.Token;
            CancellationToken enumeratorToken = tokens == "Method" ? default : enumeratorSource.Token;

            Assert.CatchAsync<OperationCanceledException>(() => EnumerateAsync(client, family, methodToken, enumeratorToken, pages));
            Assert.IsTrue(receivedToken.IsCancellationRequested);
        }

        [TestCaseSource(nameof(ContinuationCases))]
        public async Task ReturnedContinuationCanResume(string family, bool async, string linkKind)
        {
            string path = GetListPath(family);
            string nextLink = (linkKind == "Absolute" ? "https://management.azure.com" : "") +
                (linkKind == "PathRelative" ? path.TrimStart('/') : path) + "?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                new MockResponse(200).SetContent("{\"value\":[],\"nextLink\":\"" + nextLink + "\"}"),
                EmptyPage(), EmptyPage());
            ArmClient client = CreateClient(transport);

            string returnedToken = await EnumeratePagesAsync(client, family, async, null);
            Assert.AreEqual(nextLink, returnedToken);
            Assert.AreEqual(2, transport.Requests.Count, "Normal nextLink traversal must work before resuming");
            Assert.AreEqual(new Uri(new Uri("https://management.azure.com"), nextLink).PathAndQuery, transport.Requests[1].Uri.PathAndQuery);

            await EnumeratePagesAsync(client, family, async, returnedToken);
            Assert.AreEqual(3, transport.Requests.Count);
            Assert.AreEqual("https", transport.Requests[2].Uri.Scheme);
            Assert.AreEqual(transport.Requests[1].Uri.PathAndQuery, transport.Requests[2].Uri.PathAndQuery);
        }

        [Test]
        public void CancellationDuringRequest(
            [Values("GroupContains", "SubscriptionContains", "Dependency", "Member", "ServiceGroupDependency")] string family,
            [Values(false, true)] bool cancelMethod)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumeratorSource = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                // Cancel after the pipeline has started processing with the initially active token.
                Assert.IsFalse(message.CancellationToken.IsCancellationRequested);
                (cancelMethod ? methodSource : enumeratorSource).Cancel();
                message.CancellationToken.ThrowIfCancellationRequested();
                return EmptyPage();
            });
            Assert.CatchAsync<OperationCanceledException>(() =>
                EnumerateAsync(CreateClient(transport), family, methodSource.Token, enumeratorSource.Token, false));
        }

        [Test]
        public void CancellationBetweenPages(
            [Values("GroupContains", "SubscriptionContains", "Dependency", "Member", "ServiceGroupDependency")] string family,
            [Values(false, true)] bool cancelMethod)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumeratorSource = new CancellationTokenSource();
            int requests = 0;
            var transport = MockTransport.FromMessageCallback(message =>
            {
                if (++requests == 1)
                {
                    (cancelMethod ? methodSource : enumeratorSource).Cancel();
                    return new MockResponse(200).SetContent("{\"value\":[],\"nextLink\":\"https://management.azure.com" + GetListPath(family) + "?api-version=2026-08-01&$skiptoken=page2\"}");
                }
                message.CancellationToken.ThrowIfCancellationRequested();
                return EmptyPage();
            });
            Assert.CatchAsync<OperationCanceledException>(() =>
                EnumerateAsync(CreateClient(transport), family, methodSource.Token, enumeratorSource.Token, true));
            Assert.AreEqual(2, requests);
        }

        [Test]
        public async Task EnumerationsHaveIndependentEffectiveTokens()
        {
            var tokens = new List<CancellationToken>();
            using var methodSource = new CancellationTokenSource();
            using var firstSource = new CancellationTokenSource();
            using var secondSource = new CancellationTokenSource();
            var pageable = new RelationshipsAsyncPageable<int>(token =>
            {
                tokens.Add(token);
                return AsyncPageable<int>.FromPages(new[] { Page<int>.FromValues(new[] { 1 }, null, new MockResponse(200)) });
            }, new Uri("https://management.azure.com"), methodSource.Token);

            await using (IAsyncEnumerator<int> first = pageable.GetAsyncEnumerator(firstSource.Token))
            await using (IAsyncEnumerator<int> second = pageable.GetAsyncEnumerator(secondSource.Token))
            {
                Assert.IsTrue(await first.MoveNextAsync());
                Assert.IsTrue(await second.MoveNextAsync());
                firstSource.Cancel();
                Assert.IsTrue(tokens[0].IsCancellationRequested);
                Assert.IsFalse(tokens[1].IsCancellationRequested);
                Assert.IsFalse(methodSource.IsCancellationRequested);
                Assert.IsFalse(secondSource.IsCancellationRequested);
            }

            await foreach (int item in pageable.WithCancellation(secondSource.Token)) { }
            Assert.AreEqual(3, tokens.Count, "Re-enumeration must construct a fresh source");
            Assert.IsFalse(tokens[2].IsCancellationRequested);
        }

        [Test]
        public async Task DisposingEnumerationDisconnectsItsLinkedToken()
        {
            CancellationToken effectiveToken = default;
            using var methodSource = new CancellationTokenSource();
            using var enumeratorSource = new CancellationTokenSource();
            var pageable = new RelationshipsAsyncPageable<int>(token =>
            {
                effectiveToken = token;
                return AsyncPageable<int>.FromPages(new[] { Page<int>.FromValues(new[] { 1 }, null, new MockResponse(200)) });
            }, new Uri("https://management.azure.com"), methodSource.Token);

            await using (IAsyncEnumerator<int> enumerator = pageable.GetAsyncEnumerator(enumeratorSource.Token))
            {
                Assert.IsTrue(await enumerator.MoveNextAsync());
            }
            methodSource.Cancel();
            enumeratorSource.Cancel();
            Assert.IsFalse(effectiveToken.IsCancellationRequested, "The compiler-created linked token source must be disposed");
        }

        private static ArmClient CreateClient(MockTransport transport) =>
            new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });

        private static MockResponse EmptyPage() => new MockResponse(200).SetContent("{\"value\":[]}");

        private static string GetListPath(string family) => family switch
        {
            "GroupContains" => GroupId + "/providers/Microsoft.Relationships/contains",
            "SubscriptionContains" => "/subscriptions/" + SubscriptionId + "/providers/Microsoft.Relationships/contains",
            "Dependency" => GroupId + "/providers/Microsoft.Relationships/dependencyOf",
            "Member" => GroupId + "/providers/Microsoft.Relationships/serviceGroupMember",
            _ => ServiceGroupId + "/providers/Microsoft.Relationships/dependencyOf"
        };

        private static Task EnumerateAsync(ArmClient client, string family, CancellationToken methodToken, CancellationToken enumeratorToken, bool pages) => family switch
        {
            "GroupContains" => EnumerateAsync(client.GetResourceGroupResource(new ResourceIdentifier(GroupId)).GetByResourceGroupContainsRelationshipsAsync(cancellationToken: methodToken), enumeratorToken, pages),
            "SubscriptionContains" => EnumerateAsync(client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId)).GetBySubscriptionContainsRelationshipsAsync(cancellationToken: methodToken), enumeratorToken, pages),
            "Dependency" => EnumerateAsync(client.GetDependencyOfRelationships(new ResourceIdentifier(GroupId)).GetAllAsync(methodToken), enumeratorToken, pages),
            "Member" => EnumerateAsync(client.GetServiceGroupMemberRelationships(new ResourceIdentifier(GroupId)).GetAllAsync(methodToken), enumeratorToken, pages),
            _ => EnumerateAsync(client.GetServiceGroupDependencyOfRelationships(new ResourceIdentifier(ServiceGroupId)).GetAllAsync(methodToken), enumeratorToken, pages)
        };

        private static async Task EnumerateAsync<T>(AsyncPageable<T> pageable, CancellationToken token, bool pages) where T : notnull
        {
            if (pages)
            {
                await foreach (Page<T> page in pageable.AsPages().WithCancellation(token)) { }
            }
            else
            {
                await foreach (T item in pageable.WithCancellation(token)) { }
            }
        }

        private static Task<string> EnumeratePagesAsync(ArmClient client, string family, bool async, string token) => family switch
        {
            "GroupContains" => async
                ? ReadPagesAsync(client.GetResourceGroupResource(new ResourceIdentifier(GroupId)).GetByResourceGroupContainsRelationshipsAsync(), token)
                : Task.FromResult(ReadPages(client.GetResourceGroupResource(new ResourceIdentifier(GroupId)).GetByResourceGroupContainsRelationships(), token)),
            "SubscriptionContains" => async
                ? ReadPagesAsync(client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId)).GetBySubscriptionContainsRelationshipsAsync(), token)
                : Task.FromResult(ReadPages(client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + SubscriptionId)).GetBySubscriptionContainsRelationships(), token)),
            "Dependency" => async
                ? ReadPagesAsync(client.GetDependencyOfRelationships(new ResourceIdentifier(GroupId)).GetAllAsync(), token)
                : Task.FromResult(ReadPages(client.GetDependencyOfRelationships(new ResourceIdentifier(GroupId)).GetAll(), token)),
            "Member" => async
                ? ReadPagesAsync(client.GetServiceGroupMemberRelationships(new ResourceIdentifier(GroupId)).GetAllAsync(), token)
                : Task.FromResult(ReadPages(client.GetServiceGroupMemberRelationships(new ResourceIdentifier(GroupId)).GetAll(), token)),
            _ => async
                ? ReadPagesAsync(client.GetServiceGroupDependencyOfRelationships(new ResourceIdentifier(ServiceGroupId)).GetAllAsync(), token)
                : Task.FromResult(ReadPages(client.GetServiceGroupDependencyOfRelationships(new ResourceIdentifier(ServiceGroupId)).GetAll(), token))
        };

        private static string ReadPages<T>(Pageable<T> pageable, string token) where T : notnull =>
            pageable.AsPages(token).ToList()[0].ContinuationToken;

        private static async Task<string> ReadPagesAsync<T>(AsyncPageable<T> pageable, string token) where T : notnull
        {
            string firstToken = null;
            await foreach (Page<T> page in pageable.AsPages(token))
            {
                firstToken ??= page.ContinuationToken;
            }
            return firstToken;
        }
    }
}
