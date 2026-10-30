// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    internal class GeneratedParameterNamingTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        [TestCase(false)]
        [TestCase(true)]
        public async Task ActionBodyNamesForwardToTheOriginalWireParameters(bool async)
        {
            var policy = new ResponsePolicy("""{"address":"127.0.0.1"}""");
            var client = CreateClient(policy);
            var id = AcronymWidgetResource.CreateResourceIdentifier(
                subscriptionId: SubscriptionId, resourceGroupName: "group", sourceIPv6Address: "source", sourceIPAddress: "widget");
            Assert.That(id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}/resourceGroups/group/providers/MgmtTypeSpec/sourceAddresses/source/acronymWidgets/widget"));
            var resource = client.GetAcronymWidgetResource(id);

            var result = async
                ? await resource.ConfigureAsync(ipAddress: new IPAddress("127.0.0.1"))
                : resource.Configure(ipAddress: new IPAddress("127.0.0.1"));

            Assert.That(result.Value.Address, Is.EqualTo("127.0.0.1"));
            Assert.That(policy.Uri!.AbsolutePath, Does.EndWith("/acronymWidgets/widget/configure"));
            Assert.That(policy.Body, Does.Contain("\"address\":\"127.0.0.1\""));

            var ipv4Result = async
                ? await resource.ConfigureIPv4Async(ipv4Address: new IPv4Address("127.0.0.1"))
                : resource.ConfigureIPv4(ipv4Address: new IPv4Address("127.0.0.1"));

            Assert.That(ipv4Result.Value.Address, Is.EqualTo("127.0.0.1"));
            Assert.That(policy.Uri!.AbsolutePath, Does.EndWith("/acronymWidgets/widget/configureIPv4"));
            Assert.That(policy.Body, Does.Contain("\"address\":\"127.0.0.1\""));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CollectionAccessorForwardsExtraPathParameter(bool async)
        {
            var policy = new ResponsePolicy("""{"value":[]}""");
            var client = CreateClient(policy);
            var group = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "group"));
            var collection = group.GetAcronymWidgets(sourceIPv6Address: "source");

            if (async)
            {
                await foreach (var _ in collection.GetAllAsync())
                {
                    Assert.Fail("The response contains no resources.");
                }
            }
            else
            {
                Assert.That(collection.GetAll().ToArray(), Is.Empty);
            }

            Assert.That(policy.Uri!.AbsolutePath, Does.EndWith("/sourceAddresses/source/acronymWidgets"));
        }

        private static ArmClient CreateClient(HttpPipelinePolicy policy)
        {
            var options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            return new ArmClient(Mock.Of<TokenCredential>(), SubscriptionId, options);
        }

        private sealed class ResponsePolicy(string response) : HttpPipelinePolicy
        {
            public Uri? Uri { get; private set; }
            public string? Body { get; private set; }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Uri = message.Request.Uri.ToUri();
                if (message.Request.Content is { } content)
                {
                    using var stream = new MemoryStream();
                    content.WriteTo(stream, CancellationToken.None);
                    Body = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                }
                message.Response = new TestResponse(200).SetContent(response);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Process(message, pipeline);
                return ValueTask.CompletedTask;
            }
        }
    }
}
