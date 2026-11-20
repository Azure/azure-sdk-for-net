// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeActions.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionVersionOperationTests : ClientTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string StatusUrl = "https://management.azure.com/providers/Microsoft.Cdn/operationStatuses/test?api-version=2026-10-01";
        private const string ResultUrl = "https://management.azure.com/providers/Microsoft.Cdn/operationResults/test?api-version=2026-10-01";
        private static readonly ResourceIdentifier VersionId = EdgeActionVersionResource.CreateResourceIdentifier(SubscriptionId, "test-rg", "eadotnet", "v1");

        public EdgeActionVersionOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DeployVersionCodePollsStatusThenReturnsFullResource()
        {
            var transport = new MockTransport(
                Accepted(),
                JsonResponse(200, """{"status":"InProgress"}"""),
                JsonResponse(200, """{"status":"Succeeded"}"""),
                JsonResponse(200, $$"""
                    {
                      "id": "{{VersionId}}",
                      "name": "v1",
                      "type": "Microsoft.Cdn/edgeActions/versions",
                      "location": "global",
                      "properties": {
                        "deploymentType": "file",
                        "isDefaultVersion": "True",
                        "provisioningState": "Succeeded",
                        "validationStatus": "Succeeded"
                      }
                    }
                    """));
            EdgeActionVersionResource version = CreateVersion(transport);
            var code = new EdgeActionVersionCode("ZnVuY3Rpb24gaGFuZGxlcihldmVudCkgeyByZXR1cm4gZXZlbnQ7IH0=", "v1");
            ArmOperation<EdgeActionVersionResource> operation = IsAsync
                ? await version.DeployVersionCodeAsync(WaitUntil.Started, code)
                : version.DeployVersionCode(WaitUntil.Started, code);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.That(operation.HasCompleted, Is.False);
            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Id, Is.EqualTo(VersionId));
            Assert.That(operation.Value.Data.Name, Is.EqualTo("v1"));
            Assert.That(operation.Value.Data.ResourceType, Is.EqualTo(EdgeActionVersionResource.ResourceType));
            Assert.That(operation.Value.Data.Properties.ProvisioningState, Is.EqualTo(EdgeActionProvisioningState.Succeeded));
            Assert.That(transport.Requests.Count, Is.EqualTo(4));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(VersionId + "/deployVersionCode"));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(StatusUrl));
            Assert.That(transport.Requests[2].Uri.ToUri().AbsoluteUri, Is.EqualTo(StatusUrl));
            Assert.That(transport.Requests[3].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[3].Uri.ToUri().AbsoluteUri, Is.EqualTo(ResultUrl));
        }

        [Test]
        public async Task GetVersionCodeReadsLocationResult()
        {
            var transport = new MockTransport(
                Accepted(),
                JsonResponse(200, """{"status":"Succeeded"}"""),
                JsonResponse(200, """{"name":"v1","content":"aGFuZGxlcg=="}"""));
            EdgeActionVersionResource version = CreateVersion(transport);
            ArmOperation<EdgeActionVersionCode> operation = IsAsync
                ? await version.GetVersionCodeAsync(WaitUntil.Started)
                : version.GetVersionCode(WaitUntil.Started);
            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Name, Is.EqualTo("v1"));
            Assert.That(operation.Value.Content, Is.EqualTo("aGFuZGxlcg=="));
            Assert.That(transport.Requests.Count, Is.EqualTo(3));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(VersionId + "/getVersionCode"));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(StatusUrl));
            Assert.That(transport.Requests[2].Uri.ToUri().AbsoluteUri, Is.EqualTo(ResultUrl));
        }

        [Test]
        public void SwapDefaultHonorsCancellationWhilePolling()
        {
            using var timeout = new CancellationTokenSource();
            var transport = new MockTransport(request =>
            {
                if (request.Method == RequestMethod.Post)
                {
                    return Accepted();
                }
                timeout.Cancel();
                return JsonResponse(200, """{"status":"InProgress"}""");
            });
            EdgeActionVersionResource version = CreateVersion(transport);
            if (IsAsync)
            {
                Assert.That(async () => await version.SwapDefaultAsync(WaitUntil.Completed, timeout.Token),
                    Throws.InstanceOf<OperationCanceledException>());
            }
            else
            {
                Assert.That(() => version.SwapDefault(WaitUntil.Completed, timeout.Token),
                    Throws.InstanceOf<OperationCanceledException>());
            }
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task SwapDefaultCompletesWithoutResourceBody()
        {
            var transport = new MockTransport(Accepted(), JsonResponse(200, """{"status":"Succeeded"}"""), new MockResponse(204));
            EdgeActionVersionResource version = CreateVersion(transport);
            ArmOperation operation = IsAsync
                ? await version.SwapDefaultAsync(WaitUntil.Started)
                : version.SwapDefault(WaitUntil.Started);
            if (IsAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(VersionId + "/swapDefault"));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(StatusUrl));
        }

        [Test]
        public async Task FailedDeploymentDoesNotFetchResult()
        {
            var transport = new MockTransport(
                Accepted(),
                JsonResponse(200, """{"status":"Failed","error":{"code":"DeploymentFailed","message":"Invalid package"}}"""));
            EdgeActionVersionResource version = CreateVersion(transport);
            var code = new EdgeActionVersionCode("aW52YWxpZA==", "v1");
            ArmOperation<EdgeActionVersionResource> operation = IsAsync
                ? await version.DeployVersionCodeAsync(WaitUntil.Started, code)
                : version.DeployVersionCode(WaitUntil.Started, code);
            RequestFailedException error = IsAsync
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync())
                : Assert.Throws<RequestFailedException>(() => operation.UpdateStatus());
            Assert.That(error.Status, Is.EqualTo(200));
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.False);
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(StatusUrl));
        }

        private EdgeActionVersionResource CreateVersion(MockTransport transport)
        {
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            return client.GetEdgeActionVersionResource(VersionId);
        }

        private static MockResponse Accepted()
        {
            return new MockResponse(202)
                .WithHeader("Azure-AsyncOperation", StatusUrl)
                .WithHeader("Location", ResultUrl)
                .WithHeader("Retry-After", "0");
        }

        private static MockResponse JsonResponse(int status, string body)
        {
            var response = new MockResponse(status).WithHeader("Content-Type", "application/json").WithHeader("Retry-After", "0");
            response.SetContent(body);
            return response;
        }
    }
}
