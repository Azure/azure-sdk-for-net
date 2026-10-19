// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionLocalSetupTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string TenantId = "00000000-0000-0000-0000-000000000002";
        private const string Account = """{"id":"00000000-0000-0000-0000-000000000001","tenantId":"00000000-0000-0000-0000-000000000002"}""";

        [TestCase(RecordedTestMode.Record, "true", false, null, null, true)]
        [TestCase(RecordedTestMode.Live, "TRUE", false, null, null, true)]
        [TestCase(RecordedTestMode.Playback, "true", false, null, null, false)]
        [TestCase(null, "true", false, null, null, false)]
        [TestCase(RecordedTestMode.Record, null, false, null, null, false)]
        [TestCase(RecordedTestMode.Record, "false", false, null, null, false)]
        [TestCase(RecordedTestMode.Record, "true", true, null, null, false)]
        [TestCase(RecordedTestMode.Record, "true", false, "test-secret", null, false)]
        [TestCase(RecordedTestMode.Record, "true", false, null, "test-pipeline-token", false)]
        public void CliSetupIsLimitedToOptedInLocalServiceTests(RecordedTestMode? mode, string enabled, bool isCI,
            string clientSecret, string pipelineToken, bool expected)
        {
            Assert.That(EdgeActionsManagementTestEnvironment.ShouldUseAzureCli(mode, enabled, isCI, clientSecret, pipelineToken), Is.EqualTo(expected));
        }

        [TestCase(null, null)]
        [TestCase(SubscriptionId, null)]
        [TestCase(null, TenantId)]
        [TestCase(SubscriptionId, TenantId)]
        public void AccountDiscoveryHonorsMatchingOverrides(string subscription, string tenant)
        {
            var account = EdgeActionsManagementTestEnvironment.ResolveCliAccount(Account, subscription, tenant);
            Assert.That(account.SubscriptionId, Is.EqualTo(SubscriptionId));
            Assert.That(account.TenantId, Is.EqualTo(TenantId));
        }

        [TestCase(TenantId, null)]
        [TestCase(null, SubscriptionId)]
        public void AccountMismatchFailsInsteadOfChangingTheTarget(string subscription, string tenant)
        {
            Assert.Throws<InvalidOperationException>(() => EdgeActionsManagementTestEnvironment.ResolveCliAccount(Account, subscription, tenant));
        }

        [TestCase("{}")]
        [TestCase("""{"id":"invalid","tenantId":"00000000-0000-0000-0000-000000000002"}""")]
        [TestCase("""{"id":"00000000-0000-0000-0000-000000000001","tenantId":null}""")]
        public void InvalidAccountDataIsRejected(string json)
        {
            Assert.Throws<InvalidOperationException>(() => EdgeActionsManagementTestEnvironment.ResolveCliAccount(json, null, null));
        }

        [Test]
        public async Task RegisteredProviderNeedsNoRegistration()
        {
            var transport = new MockTransport(ProviderResponse("Registered"));
            await EdgeActionsManagementTestEnvironment.EnsureCdnRegisteredAsync(CreateClient(transport), SubscriptionId, CancellationToken.None);
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        public async Task UnregisteredProviderIsRegistered()
        {
            var transport = new MockTransport(ProviderResponse("NotRegistered"), ProviderResponse("Registered"));
            await EdgeActionsManagementTestEnvironment.EnsureCdnRegisteredAsync(CreateClient(transport), SubscriptionId, CancellationToken.None);
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsolutePath, Is.EqualTo($"/subscriptions/{SubscriptionId}/providers/Microsoft.Cdn/register"));
        }

        [Test]
        public async Task RegistrationAlreadyInProgressIsPolledWithoutAnotherPost()
        {
            var transport = new MockTransport(ProviderResponse("Registering"), ProviderResponse("Registered"));
            await EdgeActionsManagementTestEnvironment.EnsureCdnRegisteredAsync(CreateClient(transport), SubscriptionId, CancellationToken.None);
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        public void RegistrationPermissionErrorsAreNotSuppressed()
        {
            var denied = new MockResponse(403).WithHeader("Content-Type", "application/json");
            denied.SetContent("""{"error":{"code":"AuthorizationFailed","message":"Registration forbidden"}}""");
            var transport = new MockTransport(ProviderResponse("NotRegistered"), denied);
            RequestFailedException error = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await EdgeActionsManagementTestEnvironment.EnsureCdnRegisteredAsync(CreateClient(transport), SubscriptionId, CancellationToken.None));
            Assert.That(error.Status, Is.EqualTo(403));
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
        }

        [Test]
        public void PendingRegistrationHonorsCancellation()
        {
            using var cancellation = new CancellationTokenSource();
            var transport = new MockTransport(request =>
            {
                if (request.Method == RequestMethod.Post)
                {
                    cancellation.Cancel();
                    return ProviderResponse("Registering");
                }
                return ProviderResponse("NotRegistered");
            });
            Assert.That(async () => await EdgeActionsManagementTestEnvironment.EnsureCdnRegisteredAsync(
                CreateClient(transport), SubscriptionId, cancellation.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            return new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
        }

        private static MockResponse ProviderResponse(string state)
        {
            var response = new MockResponse(200).WithHeader("Content-Type", "application/json");
            response.SetContent($$"""
                {
                  "id": "/subscriptions/{{SubscriptionId}}/providers/Microsoft.Cdn",
                  "namespace": "Microsoft.Cdn",
                  "registrationState": "{{state}}"
                }
                """);
            return response;
        }
    }
}
