// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class CostControlWireTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string ResourceGroupName = "rg";
        private const string AccountName = "account";
        private const string CostControlName = "monthly-budget";

        [Test]
        public async Task CostControlCrudSerializesExpectedWireContract()
        {
            var transport = new MockTransport(
                Json(201, CostControlBody("SDK test", 25, "etag-1"), "etag-1"),
                Json(200, CostControlBody("SDK test", 25, "etag-1"), "etag-1"),
                Json(200, $$"""{"value":[{{CostControlBody("SDK test", 25, "etag-1")}}]}"""),
                Json(200, CostControlBody("SDK test updated", 50, "etag-2"), "etag-2"),
                new MockResponse(200));

            ArmClientOptions options = new() { Transport = transport };
            ArmClient client = new(new MockCredential(), SubscriptionId, options);
            ResourceIdentifier accountId = CognitiveServicesAccountResource.CreateResourceIdentifier(
                SubscriptionId,
                ResourceGroupName,
                AccountName);
            CognitiveServicesAccountCostControlCollection collection = client
                .GetCognitiveServicesAccountResource(accountId)
                .GetCognitiveServicesAccountCostControls();

            CognitiveServicesAccountCostControlData data = CreateData("SDK test", 25);
            MatchConditions createOnly = new() { IfNoneMatch = ETag.All };
            ArmOperation<CognitiveServicesAccountCostControlResource> create = await collection.CreateOrUpdateAsync(
                WaitUntil.Started,
                CostControlName,
                data,
                createOnly);
            CognitiveServicesAccountCostControlResource resource = create.Value;

            resource = (await collection.GetAsync(CostControlName)).Value;
            var listed = await collection.GetAllAsync().ToEnumerableAsync();

            CostControlPatchProperties patchProperties = new() { DisplayName = "SDK test updated" };
            patchProperties.Rules.Add(CreateRule(50));
            resource = (await resource.UpdateAsync(
                new CognitiveServicesAccountCostControlPatch { Properties = patchProperties },
                resource.Data.ETag)).Value;
            await resource.DeleteAsync(WaitUntil.Started, resource.Data.ETag);

            Assert.That(listed, Has.Count.EqualTo(1));
            Assert.That(transport.Requests, Has.Count.EqualTo(5));
            AssertRequest(transport.Requests[0], RequestMethod.Put, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[0].Headers.TryGetValue("If-None-Match", out string ifNoneMatch), Is.True);
            Assert.That(ifNoneMatch, Is.EqualTo("*"));

            JsonElement createBody = BodyJson(transport.Requests[0]);
            Assert.That(createBody.GetProperty("properties").GetProperty("rules")[0]
                .GetProperty("counterKey").GetProperty("type").GetString(), Is.EqualTo("Account"));
            JsonElement threshold = createBody.GetProperty("properties").GetProperty("rules")[0].GetProperty("thresholds")[0];
            Assert.That(threshold.GetProperty("type").GetString(), Is.EqualTo("Percentage"));
            Assert.That(threshold.GetProperty("value").GetDouble(), Is.EqualTo(80));
            Assert.That(threshold.GetProperty("action").GetString(), Is.EqualTo("Alert"));

            AssertRequest(transport.Requests[1], RequestMethod.Get, $"/costControls/{CostControlName}");
            AssertRequest(transport.Requests[2], RequestMethod.Get, "/costControls");
            AssertRequest(transport.Requests[3], RequestMethod.Patch, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[3].Headers.TryGetValue("If-Match", out string updateEtag), Is.True);
            Assert.That(updateEtag, Is.EqualTo("\"etag-1\""));
            Assert.That(BodyJson(transport.Requests[3]).GetProperty("properties").GetProperty("rules")[0]
                .GetProperty("amount").GetDouble(), Is.EqualTo(50));

            AssertRequest(transport.Requests[4], RequestMethod.Delete, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[4].Headers.TryGetValue("If-Match", out string deleteEtag), Is.True);
            Assert.That(deleteEtag, Is.EqualTo("\"etag-2\""));
        }

        [Test]
        public async Task CostControlUpdatePreservesDisplayNameIntent(
            [Values(false, true)] bool isAsync,
            [Values("omitted", "name", "null", "nameThenNull")] string assignment)
        {
            MockTransport transport = new(Json(200, CostControlBody("SDK test", 50, "etag-2"), "etag-2"));
            ArmClient client = new(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ResourceIdentifier resourceId = CognitiveServicesAccountCostControlResource.CreateResourceIdentifier(
                SubscriptionId, ResourceGroupName, AccountName, CostControlName);
            CognitiveServicesAccountCostControlResource resource = client.GetCognitiveServicesAccountCostControlResource(resourceId);
            CostControlPatchProperties properties = new();
            properties.Rules.Add(CreateRule(50));
            if (assignment == "name" || assignment == "nameThenNull")
            {
                properties.DisplayName = "New name";
            }
            if (assignment == "null" || assignment == "nameThenNull")
            {
                properties.DisplayName = null;
            }
            CognitiveServicesAccountCostControlPatch patch = new() { Properties = properties };
            if (isAsync)
            {
                await resource.UpdateAsync(patch);
            }
            else
            {
                resource.Update(patch);
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            AssertRequest(transport.Requests[0], RequestMethod.Patch, $"/costControls/{CostControlName}");
            JsonElement body = BodyJson(transport.Requests[0]).GetProperty("properties");
            Assert.That(body.GetProperty("rules")[0].GetProperty("amount").GetDouble(), Is.EqualTo(50));
            bool present = body.TryGetProperty("displayName", out JsonElement displayName);
            Assert.That(present, Is.EqualTo(assignment != "omitted"));
            if (present)
            {
                Assert.That(displayName.ValueKind, Is.EqualTo(assignment == "name" ? JsonValueKind.String : JsonValueKind.Null));
                if (assignment == "name")
                {
                    Assert.That(displayName.GetString(), Is.EqualTo("New name"));
                }
            }
        }

        [TestCase("{}", "J")]
        [TestCase("{\"displayName\":null}", "J")]
        [TestCase("{\"displayName\":\"New name\"}", "J")]
        [TestCase("{}", "W")]
        [TestCase("{\"displayName\":null}", "W")]
        [TestCase("{\"displayName\":\"New name\"}", "W")]
        public void CostControlPatchDisplayNameRoundTrips(string json, string format)
        {
            ModelReaderWriterOptions options = new(format);
            CostControlPatchProperties model = ModelReaderWriter.Read<CostControlPatchProperties>(BinaryData.FromString(json), options);
            using JsonDocument original = JsonDocument.Parse(json);
            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            bool expectedPresence = original.RootElement.TryGetProperty("displayName", out JsonElement expected);
            bool actualPresence = serialized.RootElement.TryGetProperty("displayName", out JsonElement actual);
            Assert.That(actualPresence, Is.EqualTo(expectedPresence));
            if (expectedPresence)
            {
                Assert.That(actual.GetRawText(), Is.EqualTo(expected.GetRawText()));
            }
        }

        [TestCase("J", true)]
        [TestCase("W", false)]
        public void CostControlPatchPreservesUnknownPropertiesOnlyInPersistedFormat(string format, bool expectedPresence)
        {
            ModelReaderWriterOptions options = new(format);
            CostControlPatchProperties model = ModelReaderWriter.Read<CostControlPatchProperties>(
                BinaryData.FromString("{\"futureProperty\":{\"value\":1}}"), options);
            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            bool present = serialized.RootElement.TryGetProperty("futureProperty", out JsonElement property);
            Assert.That(present, Is.EqualTo(expectedPresence));
            if (present)
            {
                Assert.That(property.GetProperty("value").GetInt32(), Is.EqualTo(1));
            }
        }

        [Test]
        [Ignore("The generated model currently omits CostControlConnections when explicitly assigned null.")]
        public async Task AccountUpdateSerializesExplicitNullCostControlConnections()
        {
            MockTransport transport = new(Json(200, AccountBody()));
            ArmClient client = new(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ResourceIdentifier accountId = CognitiveServicesAccountResource.CreateResourceIdentifier(
                SubscriptionId,
                ResourceGroupName,
                AccountName);
            CognitiveServicesAccountResource account = client.GetCognitiveServicesAccountResource(accountId);
            CognitiveServicesAccountData data = new(AzureLocation.EastUS)
            {
                Properties = new CognitiveServicesAccountProperties
                {
                    CostControlConnections = null
                }
            };

            await account.UpdateAsync(WaitUntil.Started, data);

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            MockRequest request = transport.Requests[0];
            Assert.That(request.Method, Is.EqualTo(RequestMethod.Patch));
            JsonElement properties = BodyJson(request).GetProperty("properties");
            Assert.That(properties.TryGetProperty("costControlConnections", out JsonElement connections), Is.True);
            Assert.That(connections.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        private static void AssertRequest(MockRequest request, RequestMethod method, string pathSuffix)
        {
            Assert.That(request.Method, Is.EqualTo(method));
            Assert.That(request.Uri.Path.EndsWith(pathSuffix), Is.True);
            Assert.That(request.Uri.Query, Does.Contain("api-version=2026-09-15-preview"));
        }

        private static CognitiveServicesAccountCostControlData CreateData(string displayName, double amount)
            => new()
            {
                Properties = new CostControlProperties(new[] { CreateRule(amount) })
                {
                    DisplayName = displayName
                }
            };

        private static CostControlRule CreateRule(double amount)
        {
            CostControlRule rule = new(
                "account-budget",
                new CostControlDimension(CostControlDimensionType.Account),
                CostControlUnit.Usd,
                amount)
            {
                Period = CostControlPeriod.Month,
                Recurring = true
            };
            rule.Thresholds.Add(new CostControlThreshold(CostControlThresholdType.Percentage, 80, CostControlThresholdAction.Alert));
            return rule;
        }

        private static MockResponse Json(int status, string body, string etag = null)
        {
            MockResponse response = new(status);
            response.SetContent(body);
            if (etag != null)
            {
                response.AddHeader("ETag", etag);
            }
            return response;
        }

        private static JsonElement BodyJson(MockRequest request)
        {
            using MemoryStream stream = new();
            request.Content.WriteTo(stream, CancellationToken.None);
            return JsonDocument.Parse(Encoding.UTF8.GetString(stream.ToArray())).RootElement;
        }

        private static string CostControlBody(string displayName, double amount, string etag)
            => $$"""
                {
                  "id":"/subscriptions/{{SubscriptionId}}/resourceGroups/{{ResourceGroupName}}/providers/Microsoft.CognitiveServices/accounts/{{AccountName}}/costControls/{{CostControlName}}",
                  "name":"{{CostControlName}}",
                  "type":"Microsoft.CognitiveServices/accounts/costControls",
                  "etag":"{{etag}}",
                  "properties":{
                    "displayName":"{{displayName}}",
                    "rules":[{
                      "name":"account-budget",
                      "counterKey":{"type":"Account"},
                      "unit":"Usd",
                      "amount":{{amount}},
                      "period":"Month",
                      "recurring":true,
                                            "thresholds":[{"type":"Percentage","value":80,"action":"Alert"}]
                    }]
                  }
                }
                """;

                private static string AccountBody()
                        => $$"""
                                {
                                    "id":"/subscriptions/{{SubscriptionId}}/resourceGroups/{{ResourceGroupName}}/providers/Microsoft.CognitiveServices/accounts/{{AccountName}}",
                                    "name":"{{AccountName}}",
                                    "type":"Microsoft.CognitiveServices/accounts",
                                    "location":"eastus",
                                    "properties":{"costControlConnections":null}
                                }
                                """;
    }
}