// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests.Unit
{
    public class CollectionExistsCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ServiceId = "/subscriptions/" + SubscriptionId + "/resourceGroups/rg/providers/Microsoft.ApiManagement/service/service";

        private static IEnumerable<TestCaseData> Collections()
        {
            var cases = new (Type Type, string Parent, object Name, object Selector, string Suffix, string Query)[]
            {
                (typeof(ApiIssueCollection), ServiceId + "/apis/api", "issue", true, "/issues/issue", "expandCommentsAttachments=true"),
                (typeof(ApiManagementPolicyCollection), ServiceId, PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ApiManagementProductPolicyCollection), ServiceId + "/products/product", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ApiOperationPolicyCollection), ServiceId + "/apis/api/operations/operation", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ApiPolicyCollection), ServiceId + "/apis/api", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(PolicyFragmentContractCollection), ServiceId, "fragment", PolicyFragmentContentFormat.Rawxml, "/policyFragments/fragment", "format=rawxml"),
                (typeof(ServiceApiResolverPolicyCollection), ServiceId + "/apis/api/resolvers/resolver", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ServiceWorkspaceApiOperationPolicyCollection), ServiceId + "/workspaces/workspace/apis/api/operations/operation", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ServiceWorkspaceApiPolicyCollection), ServiceId + "/workspaces/workspace/apis/api", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ServiceWorkspacePolicyCollection), ServiceId + "/workspaces/workspace", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml"),
                (typeof(ServiceWorkspacePolicyFragmentCollection), ServiceId + "/workspaces/workspace", "fragment", PolicyFragmentContentFormat.Rawxml, "/policyFragments/fragment", "format=rawxml"),
                (typeof(ServiceWorkspaceProductPolicyCollection), ServiceId + "/workspaces/workspace/products/product", PolicyName.Policy, PolicyExportFormat.RawXml, "/policies/policy", "format=rawxml")
            };
            foreach (var item in cases)
            {
                foreach (var isAsync in new[] { false, true })
                {
                    yield return new TestCaseData(item.Type, item.Parent, item.Name, item.Selector, item.Suffix, item.Query, isAsync);
                }
            }
        }

        [TestCaseSource(nameof(Collections))]
        public async Task LegacySignatureUsesHeadOrGet(Type collectionType, string parent, object name, object selector, string suffix, string expectedQuery, bool isAsync)
        {
            var selectorType = selector is bool ? typeof(bool?) : selector is PolicyExportFormat ? typeof(PolicyExportFormat?) : typeof(PolicyFragmentContentFormat?);
            var nameType = name is string ? typeof(string) : typeof(PolicyName);
            var method = collectionType.GetMethod(isAsync ? "ExistsAsync" : "Exists", [nameType, selectorType, typeof(CancellationToken)]);
            Assert.That(method, Is.Not.Null);
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.GetParameters()[1].IsOptional, Is.True);
            Assert.That(method.GetParameters()[2].IsOptional, Is.True);
            Assert.That(collectionType.GetMethod(isAsync ? "ExistsAsync" : "Exists", [nameType, typeof(CancellationToken)]), Is.Null);

            using var cancellation = new CancellationTokenSource();
            MockResponse[] responses = [
                new MockResponse(204),
                new MockResponse(201),
                new MockResponse(200).SetContent("{}").AddHeader("Content-Type", "application/json"),
                new MockResponse(200).SetContent("null").AddHeader("Content-Type", "application/json"),
                new MockResponse(404),
                new MockResponse(404),
                new MockResponse(403),
                new MockResponse(500)
            ];
            var transport = new TrackingTransport(responses);
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var collection = Activator.CreateInstance(collectionType, BindingFlags.NonPublic | BindingFlags.Instance, null,
                [client, new ResourceIdentifier(parent)], null);

            async Task<Response<bool>> Invoke(object value)
            {
                try
                {
                    var result = method.Invoke(collection, [name, value, cancellation.Token]);
                    return isAsync ? await (Task<Response<bool>>)result : (Response<bool>)result;
                }
                catch (TargetInvocationException ex) when (ex.InnerException != null)
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    throw;
                }
            }

            var head = await Invoke(null);
            Assert.That(head.Value, Is.True);
            Assert.That(head.GetRawResponse(), Is.SameAs(responses[0]));
            Assert.That(head.GetRawResponse().Status, Is.EqualTo(204));
            Assert.That((await Invoke(null)).Value, Is.True);
            var get = await Invoke(selector);
            Assert.That(get.Value, Is.True);
            Assert.That(get.GetRawResponse(), Is.SameAs(responses[2]));
            Assert.That(get.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That((await Invoke(selector)).Value, Is.False);
            Assert.That((await Invoke(null)).Value, Is.False);
            Assert.That((await Invoke(selector)).Value, Is.False);
            var headFailure = Assert.ThrowsAsync<RequestFailedException>(async () => await Invoke(null));
            Assert.That(headFailure.Status, Is.EqualTo(403));
            var getFailure = Assert.ThrowsAsync<RequestFailedException>(async () => await Invoke(selector));
            Assert.That(getFailure.Status, Is.EqualTo(500));

            Assert.That(transport.Requests, Has.Count.EqualTo(8));
            Assert.That(transport.AsyncCalls, Has.All.EqualTo(isAsync));
            Assert.That(transport.CancellationTokens, Has.Count.EqualTo(8));
            for (var i = 0; i < transport.Requests.Count; i++)
            {
                var isGet = i is 2 or 3 or 5 or 7;
                var request = transport.Requests[i];
                Assert.That(request.Method, Is.EqualTo(isGet ? RequestMethod.Get : RequestMethod.Head));
                Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(parent + suffix));
                Assert.That(request.Uri.ToUri().Query, Does.Contain("api-version="));
                if (isGet)
                {
                    Assert.That(request.Uri.ToUri().Query, Does.Contain(expectedQuery));
                }
                else
                {
                    Assert.That(request.Uri.ToUri().Query, Does.Not.Contain(expectedQuery.Split('=')[0]));
                }
            }
        }

        [TestCaseSource(nameof(Collections))]
        public async Task ResourceEntityTagUsesHead(Type collectionType, string parent, object name, object selector, string suffix, string expectedQuery, bool isAsync)
        {
            var resourceType = collectionType.Assembly.GetType(collectionType.FullName.Replace("Collection", "Resource"), true);
            var method = resourceType.GetMethod(isAsync ? "GetEntityTagAsync" : "GetEntityTag", [typeof(CancellationToken)]);
            Assert.That(method, Is.Not.Null);
            var raw = new MockResponse(204).AddHeader("ETag", "\"test-etag\"");
            var transport = new TrackingTransport(raw);
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var resource = Activator.CreateInstance(resourceType, BindingFlags.NonPublic | BindingFlags.Instance, null,
                [client, new ResourceIdentifier(parent + suffix)], null);
            using var cancellation = new CancellationTokenSource();
            var result = method.Invoke(resource, [cancellation.Token]);
            var response = isAsync ? await (Task<Response<bool>>)result : (Response<bool>)result;

            Assert.That(response.Value, Is.True);
            Assert.That(response.GetRawResponse(), Is.SameAs(raw));
            Assert.That(response.GetRawResponse().Headers.TryGetValue("ETag", out var etag), Is.True);
            Assert.That(etag, Is.EqualTo("\"test-etag\""));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Head));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(parent + suffix));
            Assert.That(transport.AsyncCalls, Has.All.EqualTo(isAsync));
        }

        [TestCaseSource(nameof(Collections))]
        public async Task CancellationReachesBothRequests(Type collectionType, string parent, object name, object selector, string suffix, string expectedQuery, bool isAsync)
        {
            var selectorType = selector is bool ? typeof(bool?) : selector is PolicyExportFormat ? typeof(PolicyExportFormat?) : typeof(PolicyFragmentContentFormat?);
            var nameType = name is string ? typeof(string) : typeof(PolicyName);
            var method = collectionType.GetMethod(isAsync ? "ExistsAsync" : "Exists", [nameType, selectorType, typeof(CancellationToken)]);
            Assert.That(method, Is.Not.Null);
            foreach (var value in new[] { null, selector })
            {
                using var cancellation = new CancellationTokenSource();
                var transport = new CancellationProbeTransport(cancellation);
                var options = new ArmClientOptions { Transport = transport };
                options.Retry.MaxRetries = 0;
                var client = new ArmClient(new MockCredential(), SubscriptionId, options);
                var collection = Activator.CreateInstance(collectionType, BindingFlags.NonPublic | BindingFlags.Instance, null,
                    [client, new ResourceIdentifier(parent)], null);
                if (isAsync)
                {
                    Assert.CatchAsync<OperationCanceledException>(async () => await (Task<Response<bool>>)method.Invoke(collection, [name, value, cancellation.Token]));
                }
                else
                {
                    var exception = Assert.Throws<TargetInvocationException>(() => method.Invoke(collection, [name, value, cancellation.Token]));
                    Assert.That(exception.InnerException, Is.InstanceOf<OperationCanceledException>());
                }
                Assert.That(transport.ObservedCancellation, Is.True);
            }
        }

        private sealed class CancellationProbeTransport(CancellationTokenSource cancellation) : MockTransport
        {
            public bool ObservedCancellation { get; private set; }

            public override void Process(HttpMessage message)
            {
                cancellation.Cancel();
                ObservedCancellation = message.CancellationToken.IsCancellationRequested;
                throw new OperationCanceledException(message.CancellationToken);
            }

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                Process(message);
                return default;
            }
        }

        private sealed class TrackingTransport(params MockResponse[] responses) : MockTransport(responses)
        {
            public List<bool> AsyncCalls { get; } = new();
            public List<CancellationToken> CancellationTokens { get; } = new();

            public override void Process(HttpMessage message)
            {
                AsyncCalls.Add(false);
                CancellationTokens.Add(message.CancellationToken);
                base.Process(message);
            }

            public override async ValueTask ProcessAsync(HttpMessage message)
            {
                AsyncCalls.Add(true);
                CancellationTokens.Add(message.CancellationToken);
                await base.ProcessAsync(message).ConfigureAwait(false);
            }
        }

        private sealed class OverridingPolicyCollection(ArmClient client, ResourceIdentifier id) : ApiManagementPolicyCollection(client, id)
        {
            public override NullableResponse<ApiManagementPolicyResource> GetIfExists(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
                => throw new InvalidOperationException("The compatibility method must not call GetIfExists.");

            public override Task<NullableResponse<ApiManagementPolicyResource>> GetIfExistsAsync(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
                => throw new InvalidOperationException("The compatibility method must not call GetIfExistsAsync.");
        }

        [Test]
        public async Task SelectorGetDoesNotCallVirtualGetIfExists()
        {
            var transport = new TrackingTransport(new MockResponse(200).SetContent("{}"), new MockResponse(200).SetContent("{}"));
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var collection = new OverridingPolicyCollection(client, new ResourceIdentifier(ServiceId));

            Assert.That(collection.Exists(PolicyName.Policy, PolicyExportFormat.RawXml).Value, Is.True);
            Assert.That((await collection.ExistsAsync(PolicyName.Policy, PolicyExportFormat.RawXml)).Value, Is.True);
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Get));
        }

        private sealed class OverridingExistsCollection : ApiManagementPolicyCollection
        {
            public override Response<bool> Exists(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
                => Response.FromValue(false, new MockResponse(200));

            public override Task<Response<bool>> ExistsAsync(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
                => Task.FromResult(Response.FromValue(false, new MockResponse(200)));
        }

        [Test]
        public async Task OptionalCallsDispatchToPublishedVirtualMethods()
        {
            ApiManagementPolicyCollection collection = new OverridingExistsCollection();
            Assert.That(collection.Exists(PolicyName.Policy).Value, Is.False);
            Assert.That((await collection.ExistsAsync(PolicyName.Policy, cancellationToken: default)).Value, Is.False);
        }

        [Test]
        public void StringIdentifiersAreValidatedBeforeSending()
        {
            var transport = new TrackingTransport(new MockResponse(204));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var issue = new ApiIssueCollection(client, new ResourceIdentifier(ServiceId + "/apis/api"));
            var fragment = new PolicyFragmentContractCollection(client, new ResourceIdentifier(ServiceId));
            var workspaceFragment = new ServiceWorkspacePolicyFragmentCollection(client, new ResourceIdentifier(ServiceId + "/workspaces/workspace"));

            Assert.Throws<ArgumentNullException>(() => issue.Exists(null));
            Assert.Throws<ArgumentException>(() => issue.Exists(string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await issue.ExistsAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await issue.ExistsAsync(string.Empty));
            Assert.Throws<ArgumentNullException>(() => fragment.Exists(null));
            Assert.Throws<ArgumentException>(() => fragment.Exists(string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await fragment.ExistsAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await fragment.ExistsAsync(string.Empty));
            Assert.Throws<ArgumentNullException>(() => workspaceFragment.Exists(null));
            Assert.Throws<ArgumentException>(() => workspaceFragment.Exists(string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await workspaceFragment.ExistsAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await workspaceFragment.ExistsAsync(string.Empty));
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public async Task OptionalAndNamedCallsRemainUnambiguous()
        {
            var transport = new MockTransport(
                new MockResponse(204), new MockResponse(204),
                new MockResponse(200).SetContent("{}"), new MockResponse(200).SetContent("{}"),
                new MockResponse(204), new MockResponse(200).SetContent("{}"),
                new MockResponse(204), new MockResponse(200).SetContent("{}"));
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var service = new ResourceIdentifier(ServiceId);
            var policies = new ApiManagementPolicyCollection(client, service);
            var issues = new ApiIssueCollection(client, new ResourceIdentifier(ServiceId + "/apis/api"));
            var fragments = new PolicyFragmentContractCollection(client, service);

            Assert.That(policies.Exists(PolicyName.Policy).Value, Is.True);
            Assert.That((await policies.ExistsAsync(PolicyName.Policy, cancellationToken: default)).Value, Is.True);
            Assert.That(policies.Exists(PolicyName.Policy, PolicyExportFormat.RawXml).Value, Is.True);
            Assert.That((await policies.ExistsAsync(PolicyName.Policy, format: PolicyExportFormat.RawXml)).Value, Is.True);
            Assert.That(issues.Exists("issue", default).Value, Is.True);
            Assert.That((await issues.ExistsAsync("issue", expandCommentsAttachments: false)).Value, Is.True);
            Assert.That(fragments.Exists("fragment", format: null).Value, Is.True);
            Assert.That((await fragments.ExistsAsync("fragment", format: PolicyFragmentContentFormat.Rawxml)).Value, Is.True);
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Head));
            Assert.That(transport.Requests[2].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[5].Uri.ToUri().Query, Does.Contain("expandCommentsAttachments=false"));
        }
    }
}
