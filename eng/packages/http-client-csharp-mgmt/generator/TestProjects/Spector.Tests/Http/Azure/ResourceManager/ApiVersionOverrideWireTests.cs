// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.MgmtApiVersionOverride.Tests;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager;

public class ApiVersionOverrideWireTests
{
    private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
    private static readonly ResourceIdentifier ResourceId = WireVersionTestResource.CreateResourceIdentifier(SubscriptionId, "group", "test");

    [TestCase(false, "default")]
    [TestCase(true, "default")]
    [TestCase(false, "owning-scope")]
    [TestCase(true, "owning-scope")]
    [TestCase(false, "targeted")]
    [TestCase(true, "targeted")]
    public async Task PublicClientsHonorOperationDefaultsAndTargetedRuntimeOverrides(bool async, string configuration)
    {
        var transport = new VersionTransport();
        var options = new ArmClientOptions { Transport = transport };
        if (configuration == "owning-scope")
        {
            // Selection for the extension's scope must not erase the operation's wire default.
            options.SetApiVersion(SubscriptionResource.ResourceType, "owning-version");
            options.SetApiVersion(ResourceGroupResource.ResourceType, "owning-version");
        }
        if (configuration == "targeted")
        {
            options.SetApiVersion(WireVersionTestResource.ResourceType, "runtime-targeted");
        }
        var client = new ArmClient(new TestCredential(), SubscriptionId, options);
        var resource = client.GetWireVersionTestResource(ResourceId);
        var collection = client.GetResourceGroupResource(ResourceId.Parent).GetWireVersionTests();
        var subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SubscriptionId}"));
        var data = new WireVersionTestData(new AzureLocation("westus"));
        string Expected(string defaultVersion) => configuration == "targeted" ? "runtime-targeted" : defaultVersion;

        if (async) await resource.GetAsync(); else resource.Get();
        transport.AssertVersion(Expected("opaque-read"));
        if (async) await resource.UpdateAsync(data); else resource.Update(data);
        transport.AssertVersion(Expected("opaque-write"));
        if (async) await resource.PingAsync(); else resource.Ping();
        transport.AssertVersion(Expected("2024-05-01"));
        if (async) await collection.GetAsync("test"); else collection.Get("test");
        transport.AssertVersion(Expected("opaque-read"));
        if (async) await collection.CreateOrUpdateAsync(WaitUntil.Completed, "test", data);
        else collection.CreateOrUpdate(WaitUntil.Completed, "test", data);
        transport.AssertVersion(Expected("opaque-write"));
        if (async)
        {
            await foreach (var _ in collection.GetAllAsync()) { }
        }
        else collection.GetAll().ToArray();
        transport.AssertVersion(Expected("opaque-read"));
        if (async)
        {
            await foreach (var _ in subscription.GetWireVersionTestsAsync()) { }
        }
        else subscription.GetWireVersionTests().ToArray();
        transport.AssertVersion(Expected("opaque-read"));
        if (async) await subscription.CheckWireVersionAsync(); else subscription.CheckWireVersion();
        // This provider action has no associated resource type and no public per-operation
        // runtime override contract. Resource/scope selections must not change its default.
        transport.AssertVersion("opaque-non-resource");
        Assert.That(transport.Requests, Has.Count.EqualTo(8));
    }

    [Test]
    public void GeneratedDocumentationReportsTheRequestDefaults()
    {
        var documentation = XDocument.Load(Path.ChangeExtension(typeof(WireVersionTestResource).Assembly.Location, ".xml"));
        foreach (var (method, expected) in new[] { ("Get", "opaque-read."), ("Update", "opaque-write."), ("Ping", "2024-05-01.") })
        {
            var member = documentation.Descendants("member").Single(m =>
                (m.Attribute("name")?.Value ?? string.Empty).StartsWith($"M:Azure.Generator.MgmtApiVersionOverride.Tests.WireVersionTestResource.{method}(", StringComparison.Ordinal));
            var versionItem = member.Descendants("item").Single(i => i.Element("term")?.Value.Trim() == "Default Api Version.");
            Assert.That(versionItem.Element("description")?.Value.Trim(), Is.EqualTo(expected));
        }
    }

    private sealed class TestCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new("test-token", DateTimeOffset.MaxValue);
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new(GetToken(requestContext, cancellationToken));
    }

    private sealed class VersionTransport : HttpPipelineTransport
    {
        public List<Uri> Requests { get; } = new();
        public override Request CreateRequest() => HttpClientTransport.Shared.CreateRequest();
        public override void Process(HttpMessage message)
        {
            var uri = message.Request.Uri.ToUri();
            Requests.Add(uri);
            var response = new TestResponse(200);
            if (uri.AbsolutePath.EndsWith("/checkWireVersion", StringComparison.Ordinal))
                response.SetContent("\"ok\"");
            else if (uri.AbsolutePath.EndsWith("/wireVersionTests", StringComparison.Ordinal))
                response.SetContent("{\"value\":[]}");
            else
                response.SetContent($"{{\"id\":\"{ResourceId}\",\"name\":\"test\",\"type\":\"MgmtTypeSpec/wireVersionTests\",\"location\":\"westus\",\"properties\":{{}}}}");
            message.Response = response;
        }
        public override ValueTask ProcessAsync(HttpMessage message)
        {
            Process(message);
            return default;
        }
        public void AssertVersion(string expected)
        {
            var versionQueries = Requests.Last().Query.TrimStart('?').Split('&')
                .Where(q => q.StartsWith("api-version=", StringComparison.Ordinal)).ToArray();
            Assert.That(versionQueries, Has.Length.EqualTo(1));
            Assert.That(Uri.UnescapeDataString(versionQueries[0]["api-version=".Length..]), Is.EqualTo(expected));
        }
    }
}
