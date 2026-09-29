// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BasicTypeSpec;
using NUnit.Framework;

namespace TestProjects.Local.Tests
{
    public class ResourceIdentifierTests
    {
        private const string ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.App/sandboxes/test";

        [TestCase("J", false)]
        [TestCase("J", true)]
        [TestCase("X", false)]
        [TestCase("X", true)]
        public void ModelRoundTrips(string format, bool includeOptionalIds)
        {
            var model = CreateModel(includeOptionalIds);
            var options = new ModelReaderWriterOptions(format);

            var data = ModelReaderWriter.Write(model, options, BasicTypeSpecContext.Default);
            AssertWireValue(data.ToString(), format == "X", includeOptionalIds);
            var result = ModelReaderWriter.Read<ResourceIdentifierModel>(data, options, BasicTypeSpecContext.Default);

            AssertModel(result!, includeOptionalIds);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task OperationUsesResourceIdentifiers(bool xml)
        {
            using var handler = new EchoHandler(xml);
            using var httpClient = new HttpClient(handler);
            var client = new BasicTypeSpecClient(new Uri("https://example.test"), new AzureKeyCredential("test-key"), new BasicTypeSpecClientOptions
            {
                Transport = new HttpClientTransport(httpClient)
            });
            var model = CreateModel(true);

            var response = xml
                ? await client.GetResourceIdentifiersXmlAsync()
                : await client.RoundTripResourceIdentifiersAsync(model.Id, model.Id, model.Id, model);

            AssertModel(response.Value, true);
        }

        private static ResourceIdentifierModel CreateModel(bool includeOptionalIds)
        {
            var id = new ResourceIdentifier(ResourceId);
            return new ResourceIdentifierModel(id, includeOptionalIds ? id : null!, new[] { id })
            {
                OptionalId = includeOptionalIds ? id : null!
            };
        }

        private static void AssertModel(ResourceIdentifierModel model, bool includeOptionalIds)
        {
            Assert.AreEqual(new ResourceIdentifier(ResourceId), model.Id);
            Assert.AreEqual(includeOptionalIds ? new ResourceIdentifier(ResourceId) : null, model.OptionalId);
            Assert.AreEqual(includeOptionalIds ? new ResourceIdentifier(ResourceId) : null, model.NullableId);
            CollectionAssert.AreEqual(new[] { new ResourceIdentifier(ResourceId) }, model.Ids);
        }

        private static void AssertWireValue(string body, bool xml, bool includeOptionalIds)
        {
            if (xml)
            {
                var element = XElement.Parse(body);
                Assert.AreEqual(ResourceId, element.Element("id")!.Value);
                Assert.AreEqual(includeOptionalIds ? ResourceId : null, element.Element("optionalId")?.Value);
                Assert.AreEqual(includeOptionalIds ? ResourceId : null, element.Element("nullableId")?.Value);
                Assert.AreEqual(ResourceId, element.Element("ids")!.Elements().Single().Value);
            }
            else
            {
                using var document = JsonDocument.Parse(body);
                var element = document.RootElement;
                Assert.AreEqual(ResourceId, element.GetProperty("id").GetString());
                Assert.AreEqual(includeOptionalIds, element.TryGetProperty("optionalId", out var optionalId));
                if (includeOptionalIds)
                {
                    Assert.AreEqual(ResourceId, optionalId.GetString());
                }
                Assert.AreEqual(includeOptionalIds ? ResourceId : null, element.GetProperty("nullableId").GetString());
                Assert.AreEqual(ResourceId, element.GetProperty("ids")[0].GetString());
            }
        }

        private sealed class EchoHandler(bool xml) : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                string body;
                if (xml)
                {
                    Assert.AreEqual("/resource-identifiers/xml", request.RequestUri!.AbsolutePath);
                    body = $"<ResourceIdentifierModel><id>{ResourceId}</id><optionalId>{ResourceId}</optionalId><nullableId>{ResourceId}</nullableId><ids><armResourceIdentifier>{ResourceId}</armResourceIdentifier></ids></ResourceIdentifierModel>";
                }
                else
                {
                    Assert.AreEqual("/resource-identifiers/" + Uri.EscapeDataString(ResourceId), request.RequestUri!.AbsolutePath);
                    Assert.AreEqual("?queryId=" + Uri.EscapeDataString(ResourceId), request.RequestUri.Query);
                    Assert.AreEqual(ResourceId, request.Headers.GetValues("x-resource-id").Single());
                    body = await request.Content!.ReadAsStringAsync(cancellationToken);
                    AssertWireValue(body, false, true);
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(body, Encoding.UTF8, xml ? "application/xml" : "application/json")
                };
            }
        }
    }
}
