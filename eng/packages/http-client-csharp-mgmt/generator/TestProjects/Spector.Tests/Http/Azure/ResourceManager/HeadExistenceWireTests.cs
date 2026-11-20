// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.MgmtApiVersionOverride.Tests;
using Azure.ResourceManager;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager;

public class HeadExistenceWireTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
    private static readonly ResourceIdentifier ResourceId = WireVersionTestResource.CreateResourceIdentifier(SubscriptionId, "group", "test");

    [TestCase(false, 200, true)]
    [TestCase(true, 200, true)]
    [TestCase(false, 204, true)]
    [TestCase(true, 204, true)]
    [TestCase(false, 404, false)]
    [TestCase(true, 404, false)]
    public async Task ExistsUsesHeadAndPreservesRawResponse(bool async, int status, bool expected)
    {
        var transport = new ExistenceTransport(status);
        var collection = CreateCollection(transport);

        var response = async ? await collection.ExistsAsync("test") : collection.Exists("test");

        Assert.That(response.Value, Is.EqualTo(expected));
        Assert.That(response.GetRawResponse(), Is.SameAs(transport.LastResponse));
        AssertHeadRequest(transport);
    }

    [TestCase(false, 403)]
    [TestCase(true, 403)]
    [TestCase(false, 500)]
    [TestCase(true, 500)]
    public void ExistsThrowsForOtherFailures(bool async, int status)
    {
        var transport = new ExistenceTransport(status);
        var collection = CreateCollection(transport);

        var exception = async
            ? Assert.ThrowsAsync<RequestFailedException>(async () => await collection.ExistsAsync("test"))
            : Assert.Throws<RequestFailedException>(() => collection.Exists("test"));

        Assert.That(exception!.Status, Is.EqualTo(status));
        AssertHeadRequest(transport);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task GetOnlyParameterRetainsGetAndItsWireValue(bool async)
    {
        var id = FilteredExistenceTestResource.CreateResourceIdentifier(SubscriptionId, "group", "test");
        var content = $"{{\"id\":\"{id}\",\"name\":\"test\",\"type\":\"MgmtTypeSpec/filteredExistenceTests\",\"location\":\"westus\",\"properties\":{{}}}}";
        var transport = new ExistenceTransport(200, content);
        var options = new ArmClientOptions { Transport = transport };
        options.Retry.MaxRetries = 0;
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        var collection = client.GetResourceGroupResource(id.Parent).GetFilteredExistenceTests();

        var response = async ? await collection.ExistsAsync("test", "details") : collection.Exists("test", "details");

        Assert.That(response.Value, Is.True);
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(transport.Requests[0].Uri.AbsolutePath, Is.EqualTo(id.ToString()));
        Assert.That(transport.Requests[0].Uri.Query, Does.Contain("expand=details"));
        Assert.That(transport.Requests[0].Uri.Query, Does.Contain("partition=primary"));
        Assert.That(transport.Requests[0].Uri.Query, Does.Not.Contain("partition=secondary"));
        Assert.That(transport.Requests[0].Partition, Is.EqualTo("primary"));
    }

    private static WireVersionTestCollection CreateCollection(ExistenceTransport transport)
    {
        var options = new ArmClientOptions { Transport = transport };
        options.Retry.MaxRetries = 0;
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        return client.GetResourceGroupResource(ResourceId.Parent).GetWireVersionTests();
    }

    private static void AssertHeadRequest(ExistenceTransport transport)
    {
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Head));
        Assert.That(transport.Requests[0].Uri.AbsolutePath, Is.EqualTo(ResourceId.ToString()));
        Assert.That(transport.Requests[0].Uri.Query, Is.EqualTo("?api-version=opaque-head"));
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new("test-token", DateTimeOffset.MaxValue);
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new(GetToken(requestContext, cancellationToken));
    }

    private sealed class ExistenceTransport(int status, string? content = null) : HttpPipelineTransport
    {
        public List<(RequestMethod Method, Uri Uri, string? Partition)> Requests { get; } = new();
        public Response? LastResponse { get; private set; }
        public override Request CreateRequest() => HttpClientTransport.Shared.CreateRequest();
        public override void Process(HttpMessage message)
        {
            message.Request.Headers.TryGetValue("x-ms-partition", out var partition);
            Requests.Add((message.Request.Method, message.Request.Uri.ToUri(), partition));
            LastResponse = new HeadResponse(status)
            {
                ContentStream = content is null ? null : new MemoryStream(Encoding.UTF8.GetBytes(content))
            };
            message.Response = LastResponse;
        }
        public override ValueTask ProcessAsync(HttpMessage message)
        {
            Process(message);
            return default;
        }
    }

    private sealed class HeadResponse(int status) : Response
    {
        public override int Status => status;
        public override string ReasonPhrase => string.Empty;
        public override Stream? ContentStream { get; set; }
        public override string ClientRequestId { get; set; } = string.Empty;
        public override void Dispose() => ContentStream?.Dispose();
        protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) { value = null; return false; }
        protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) { values = null; return false; }
        protected override bool ContainsHeader(string name) => false;
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();
    }
}
