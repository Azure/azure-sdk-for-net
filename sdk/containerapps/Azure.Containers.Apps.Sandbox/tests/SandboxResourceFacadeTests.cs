// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxResourceFacadeTests
    {
        private const string SandboxJson =
            """{"id":"sandbox-id","sourcesRef":{"diskImage":{"name":"ubuntu","isPublic":true}},"resources":{"cpu":"1","memory":"2Gi"},"state":"Running"}""";

        [Test]
        public void GroupExposesCapturedIdentifiersWithoutSendingRequests()
        {
            MockTransport transport = new MockTransport();
            SandboxGroupClient group = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);

            Assert.That(group.SubscriptionId, Is.EqualTo(SandboxClientTestHelpers.SubscriptionId));
            Assert.That(group.ResourceGroupName, Is.EqualTo(SandboxClientTestHelpers.ResourceGroupName));
            Assert.That(group.Name, Is.EqualTo(SandboxClientTestHelpers.SandboxGroupName));
            Assert.That(group.Id.ToString(), Is.EqualTo(
                $"/subscriptions/{SandboxClientTestHelpers.SubscriptionId}/resourceGroups/{SandboxClientTestHelpers.ResourceGroupName}/providers/Microsoft.App/sandboxGroups/{SandboxClientTestHelpers.SandboxGroupName}"));
            Assert.That(group.GetSandbox("opaque-id").Id, Is.EqualTo("opaque-id"));
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public void ResourceFactoriesValidateNamesAndDoNotFetchData()
        {
            SandboxGroupClient group = SandboxClientTestHelpers.CreateSandboxGroupClient(new MockTransport());
            Func<string, object>[] factories =
            {
                group.GetSandbox, group.GetConnection, group.GetContentPackage,
                group.GetCredential, group.GetDiskImage, group.GetPublicDiskImage,
                group.GetEgressPolicy, group.GetSecret, group.GetSnapshot, group.GetVolume
            };

            foreach (Func<string, object> factory in factories)
            {
                Assert.Throws<ArgumentNullException>(() => factory(null));
                Assert.Throws<ArgumentException>(() => factory(""));
            }

            Assert.That(group.GetSandbox("sandbox-id").Data, Is.Null);
            Assert.That(group.GetConnection("connection-id").Id, Is.EqualTo("connection-id"));
            Assert.That(group.GetContentPackage("package-id").Id, Is.EqualTo("package-id"));
            Assert.That(group.GetCredential("credential-name").Name, Is.EqualTo("credential-name"));
            Assert.That(group.GetDiskImage("image-id").Id, Is.EqualTo("image-id"));
            Assert.That(group.GetPublicDiskImage("image-name").Name, Is.EqualTo("image-name"));
            Assert.That(group.GetEgressPolicy("policy-id").Id, Is.EqualTo("policy-id"));
            Assert.That(group.GetSecret("secret-id").Id, Is.EqualTo("secret-id"));
            Assert.That(group.GetSnapshot("snapshot-id").Id, Is.EqualTo("snapshot-id"));
            Assert.That(group.GetVolume("volume-name").VolumeName, Is.EqualTo("volume-name"));
        }

        [Test]
        public void GetCreatesNewResourceWithDataAndPreservesResponse()
        {
            MockResponse raw = SandboxClientTestHelpers.CreateJsonResponse(200, SandboxJson);
            MockTransport transport = new MockTransport(raw);
            SandboxResource original = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandbox("sandbox-id");

            Response<SandboxResource> result = original.Get();

            Assert.That(original.Data, Is.Null);
            Assert.That(result.Value, Is.Not.SameAs(original));
            Assert.That(result.Value.Id, Is.EqualTo("sandbox-id"));
            Assert.That(result.Value.Data.Id, Is.EqualTo("sandbox-id"));
            Assert.That(result.GetRawResponse(), Is.SameAs(raw));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.Path, Does.EndWith("/sandboxes/sandbox-id"));
        }

        [Test]
        public async Task GetAsyncCreatesNewResourceWithData()
        {
            MockResponse raw = SandboxClientTestHelpers.CreateJsonResponse(200, """{"name":"credential-name"}""");
            MockTransport transport = new MockTransport(raw);
            CredentialResource original = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetCredential("credential-name");
            using CancellationTokenSource source = new CancellationTokenSource();

            Response<CredentialResource> result = await original.GetAsync(source.Token);

            Assert.That(original.Data, Is.Null);
            Assert.That(result.Value.Name, Is.EqualTo("credential-name"));
            Assert.That(result.Value.Data.Name, Is.EqualTo("credential-name"));
            Assert.That(result.GetRawResponse(), Is.SameAs(raw));
            Assert.That(transport.Requests[0].Uri.Path, Does.EndWith("/credentials/credential-name"));
        }

        [Test]
        public void GetPropagatesServiceFailure()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(404, """{"error":{"code":"NotFound","message":"Missing"}}"""));
            SandboxResource resource = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandbox("missing");

            RequestFailedException exception = Assert.Throws<RequestFailedException>(() => resource.Get());

            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That(resource.Data, Is.Null);
        }

        [Test]
        public void ResourceProtocolMethodForwardsContextAndIdentifier()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(404, """{"error":{"code":"NotFound","message":"Missing"}}"""));
            SandboxResource resource = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandbox("missing");

            Response response = resource.GetProperties(new RequestContext { ErrorOptions = ErrorOptions.NoThrow });

            Assert.That(response.Status, Is.EqualTo(404));
            Assert.That(transport.Requests[0].Uri.Path, Does.EndWith("/sandboxes/missing"));
        }

        [Test]
        public void ResourceOperationUsesScopedIdentifier()
        {
            MockTransport transport = new MockTransport(new MockResponse(204));
            SandboxResource resource = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandbox("sandbox-id");

            Response response = resource.Delete();

            Assert.That(response.Status, Is.EqualTo(204));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Delete));
            Assert.That(transport.Requests[0].Uri.Path, Does.EndWith("/sandboxes/sandbox-id"));
        }

        [Test]
        public async Task CreateSandboxAsyncReturnsScopedResourceWithServiceData()
        {
            MockResponse raw = SandboxClientTestHelpers.CreateJsonResponse(201, SandboxJson);
            MockTransport transport = new MockTransport(raw);
            SandboxGroupClient group = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);

            Response<SandboxResource> result = await group.CreateSandboxAsync(SandboxClientTestBase.CreateSandboxContent("facade-test"));

            Assert.That(result.Value.Id, Is.EqualTo("sandbox-id"));
            Assert.That(result.Value.Data.Id, Is.EqualTo("sandbox-id"));
            Assert.That(result.GetRawResponse(), Is.SameAs(raw));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
        }

        [Test]
        public void UploadVolumeFileUsesResourceNameAndPreservesCallerStream()
        {
            MockTransport transport = new MockTransport(SandboxClientTestHelpers.CreateJsonResponse(201,
                """{"itemName":"file.txt","path":"folder/file.txt","isDirectory":false}"""));
            VolumeResource resource = SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetVolume("my-volume");
            using MemoryStream content = new MemoryStream(Encoding.UTF8.GetBytes("payload"));

            Response<VolumePathItem> result = resource.UploadVolumeFile("folder/file.txt", content, overwrite: true);

            Assert.That(result.Value.Path, Is.EqualTo("folder/file.txt"));
            Assert.That(content.CanRead, Is.True);
            Assert.That(transport.Requests[0].Uri.Path, Does.Contain("/volumes/my-volume/"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("overwrite=true"));
        }

        [Test]
        public void SyncResourcePagesPreserveContinuationAndRawResponse()
        {
            string nextLink = CreateNextLink("page-2");
            MockResponse first = SandboxClientTestHelpers.CreateJsonResponse(200,
                $$"""{"value":[{{SandboxJson}}],"nextLink":"{{nextLink}}"}""");
            MockResponse second = SandboxClientTestHelpers.CreateJsonResponse(200,
                """{"value":[{"id":"sandbox-2","sourcesRef":{"diskImage":{"name":"ubuntu","isPublic":true}},"resources":{"cpu":"1","memory":"2Gi"}}]}""");
            MockTransport transport = new MockTransport(first, second);
            SandboxGroupClient group = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);

            List<Page<SandboxResource>> pages = group.GetSandboxes(skipToken: "page-1", labels: "env=test").AsPages().ToList();

            Assert.That(pages, Has.Count.EqualTo(2));
            Assert.That(pages[0].Values[0].Id, Is.EqualTo("sandbox-id"));
            Assert.That(pages[0].Values[0].Data.Id, Is.EqualTo("sandbox-id"));
            Assert.That(pages[0].ContinuationToken, Is.Not.Null.And.Not.Empty);
            Assert.That(pages[0].GetRawResponse(), Is.SameAs(first));
            Assert.That(pages[1].Values[0].Id, Is.EqualTo("sandbox-2"));
            Assert.That(pages[1].GetRawResponse(), Is.SameAs(second));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("skipToken=page-1"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("labels=env%3Dtest"));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("skipToken=page-2"));
        }

        [Test]
        public async Task AsyncResourcePagesPreserveContinuationAndRawResponse()
        {
            string nextLink = CreateNextLink("page-2");
            MockResponse first = SandboxClientTestHelpers.CreateJsonResponse(200,
                $$"""{"value":[{{SandboxJson}}],"nextLink":"{{nextLink}}"}""");
            MockResponse second = SandboxClientTestHelpers.CreateJsonResponse(200,
                """{"value":[{"id":"sandbox-2","sourcesRef":{"diskImage":{"name":"ubuntu","isPublic":true}},"resources":{"cpu":"1","memory":"2Gi"}}]}""");
            MockTransport transport = new MockTransport(first, second);
            SandboxGroupClient group = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
            List<Page<SandboxResource>> pages = new List<Page<SandboxResource>>();

            await foreach (Page<SandboxResource> page in group.GetSandboxesAsync(skipToken: "page-1").AsPages())
            {
                pages.Add(page);
            }

            Assert.That(pages, Has.Count.EqualTo(2));
            Assert.That(pages[0].Values[0].Data.Id, Is.EqualTo("sandbox-id"));
            Assert.That(pages[0].ContinuationToken, Is.Not.Null.And.Not.Empty);
            Assert.That(pages[0].GetRawResponse(), Is.SameAs(first));
            Assert.That(pages[1].Values[0].Id, Is.EqualTo("sandbox-2"));
            Assert.That(pages[1].GetRawResponse(), Is.SameAs(second));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("skipToken=page-2"));
        }

        private static string CreateNextLink(string skipToken) =>
            $"{SandboxClientTestHelpers.Endpoint}/subscriptions/{SandboxClientTestHelpers.SubscriptionId}/resourceGroups/{SandboxClientTestHelpers.ResourceGroupName}/providers/Microsoft.App/sandboxGroups/{SandboxClientTestHelpers.SandboxGroupName}/sandboxes?skipToken={skipToken}";
    }
}
