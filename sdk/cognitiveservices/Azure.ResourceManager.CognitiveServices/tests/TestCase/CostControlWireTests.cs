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
        private static readonly DateTimeOffset StartsOn = new(2030, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset EndsOn = StartsOn.AddMonths(1);

        [Test]
        public async Task CostControlCrudSerializesExpectedWireContract()
        {
            var transport = new MockTransport(
                Json(201, CostControlBody(25, "etag-1"), "etag-1"),
                Json(200, CostControlBody(25, "etag-1"), "etag-1"),
                Json(200, $$"""{"value":[{{CostControlBody(25, "etag-1")}}],"nextLink":"https://management.azure.com/subscriptions/{{SubscriptionId}}/resourceGroups/{{ResourceGroupName}}/providers/Microsoft.CognitiveServices/accounts/{{AccountName}}/costControls?api-version=2026-11-15-preview&$skiptoken=next"}"""),
                Json(200, "{\"value\":[]}"),
                Json(200, CostControlBody(50, "etag-2"), "etag-2"),
                new MockResponse(200),
                Json(404, "{\"error\":{\"code\":\"ResourceNotFound\",\"message\":\"Cost control not found.\"}}"));

            ArmClientOptions options = new() { Transport = transport };
            ArmClient client = new(new MockCredential(), SubscriptionId, options);
            ResourceIdentifier accountId = CognitiveServicesAccountResource.CreateResourceIdentifier(
                SubscriptionId,
                ResourceGroupName,
                AccountName);
            CognitiveServicesAccountCostControlCollection collection = client
                .GetCognitiveServicesAccountResource(accountId)
                .GetCognitiveServicesAccountCostControls();

            CognitiveServicesAccountCostControlData data = CreateData(25);
            data.Properties.ProviderActions.Add("block-at-limit", new CostControlAction(CostControlThresholdType.Percentage, 100));
            data.Properties.Notifications.Add("alert-at-eighty", new CostControlNotification(
                new ResourceIdentifier($"{accountId}/connections/events"), CostControlThresholdType.Percentage, 80, true));
            MatchConditions createOnly = new() { IfNoneMatch = ETag.All };
            ArmOperation<CognitiveServicesAccountCostControlResource> create = await collection.CreateOrUpdateAsync(
                WaitUntil.Started,
                CostControlName,
                data,
                createOnly);
            CognitiveServicesAccountCostControlResource resource = create.Value;

            resource = (await collection.GetAsync(CostControlName)).Value;
            var listed = await collection.GetAllAsync().ToEnumerableAsync();

            CostControlPatchProperties patchProperties = new() { Amount = 50 };
            resource = (await resource.UpdateAsync(
                new CostControlPatch { Properties = patchProperties },
                resource.Data.ETag)).Value;
            await resource.DeleteAsync(WaitUntil.Started, resource.Data.ETag);
            RequestFailedException notFound = Assert.ThrowsAsync<RequestFailedException>(
                async () => await collection.GetAsync(CostControlName));
            Assert.That(notFound.Status, Is.EqualTo(404));

            Assert.That(listed, Has.Count.EqualTo(1));
            Assert.That(transport.Requests, Has.Count.EqualTo(7));
            AssertRequest(transport.Requests[0], RequestMethod.Put, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[0].Headers.TryGetValue("If-None-Match", out string ifNoneMatch), Is.True);
            Assert.That(ifNoneMatch, Is.EqualTo("*"));

            JsonElement createBody = BodyJson(transport.Requests[0]);
            JsonElement properties = createBody.GetProperty("properties");
            Assert.That(properties.GetProperty("category").GetString(), Is.EqualTo("Cost"));
            Assert.That(properties.GetProperty("amount").GetDouble(), Is.EqualTo(25));
            Assert.That(properties.GetProperty("timeGrain").GetString(), Is.EqualTo("Monthly"));
            Assert.That(properties.GetProperty("timePeriod").GetProperty("startDate").GetDateTimeOffset(), Is.EqualTo(StartsOn));
            Assert.That(properties.GetProperty("timePeriod").GetProperty("endDate").GetDateTimeOffset(), Is.EqualTo(EndsOn));
            JsonElement action = properties.GetProperty("providerProperties").GetProperty("actions").GetProperty("block-at-limit");
            Assert.That(action.GetProperty("type").GetString(), Is.EqualTo("Block"));
            Assert.That(action.GetProperty("threshold").GetDouble(), Is.EqualTo(100));
            Assert.That(action.GetProperty("operator").GetString(), Is.EqualTo("GreaterThanOrEqualTo"));
            JsonElement notification = properties.GetProperty("notifications").GetProperty("alert-at-eighty");
            Assert.That(notification.GetProperty("thresholdType").GetString(), Is.EqualTo("Percentage"));
            Assert.That(notification.GetProperty("threshold").GetDouble(), Is.EqualTo(80));
            Assert.That(notification.GetProperty("enabled").GetBoolean(), Is.True);
            Assert.That(notification.GetProperty("eventGridConnectionId").GetString(), Is.EqualTo($"{accountId}/connections/events"));

            AssertRequest(transport.Requests[1], RequestMethod.Get, $"/costControls/{CostControlName}");
            AssertRequest(transport.Requests[2], RequestMethod.Get, "/costControls");
            AssertRequest(transport.Requests[3], RequestMethod.Get, "/costControls");
            Assert.That(transport.Requests[3].Uri.ToUri().Query, Does.Contain("skiptoken"));
            AssertRequest(transport.Requests[4], RequestMethod.Patch, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[4].Headers.TryGetValue("If-Match", out string updateEtag), Is.True);
            Assert.That(updateEtag, Is.EqualTo("\"etag-1\""));
            Assert.That(BodyJson(transport.Requests[4]).GetProperty("properties")
                .GetProperty("amount").GetDouble(), Is.EqualTo(50));

            AssertRequest(transport.Requests[5], RequestMethod.Delete, $"/costControls/{CostControlName}");
            Assert.That(transport.Requests[5].Headers.TryGetValue("If-Match", out string deleteEtag), Is.True);
            Assert.That(deleteEtag, Is.EqualTo("\"etag-2\""));
            AssertRequest(transport.Requests[6], RequestMethod.Get, $"/costControls/{CostControlName}");
        }

        [Test]
        public async Task CostControlUpdatePreservesFilterIntent(
            [Values(false, true)] bool isAsync,
            [Values("omitted", "filter", "null", "filterThenNull")] string assignment)
        {
            MockTransport transport = new(Json(200, CostControlBody(50, "etag-2"), "etag-2"));
            ArmClient client = new(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            ResourceIdentifier resourceId = CognitiveServicesAccountCostControlResource.CreateResourceIdentifier(
                SubscriptionId, ResourceGroupName, AccountName, CostControlName);
            CognitiveServicesAccountCostControlResource resource = client.GetCognitiveServicesAccountCostControlResource(resourceId);
            CostControlPatchProperties properties = new() { Amount = 50 };
            if (assignment == "filter" || assignment == "filterThenNull")
            {
                properties.Filter = ModelReaderWriter.Read<CostControlFilter>(
                    BinaryData.FromString("{\"additionalInfo\":{\"name\":\"modelName\",\"operator\":\"In\",\"values\":[\"test-model\"]}}"));
            }
            if (assignment == "null" || assignment == "filterThenNull")
            {
                properties.Filter = null;
            }
            CostControlPatch patch = new() { Properties = properties };
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
            Assert.That(body.GetProperty("amount").GetDouble(), Is.EqualTo(50));
            bool present = body.TryGetProperty("filter", out JsonElement filter);
            Assert.That(present, Is.EqualTo(assignment != "omitted"));
            if (present)
            {
                Assert.That(filter.ValueKind, Is.EqualTo(assignment == "filter" ? JsonValueKind.Object : JsonValueKind.Null));
                if (assignment == "filter")
                {
                    Assert.That(filter.GetProperty("additionalInfo").GetProperty("values")[0].GetString(), Is.EqualTo("test-model"));
                }
            }
        }

        [TestCase("{}", "J")]
        [TestCase("{\"filter\":null}", "J")]
        [TestCase("{\"filter\":{\"additionalInfo\":{\"name\":\"modelName\",\"operator\":\"In\",\"values\":[\"test-model\"]}}}", "J")]
        [TestCase("{}", "W")]
        [TestCase("{\"filter\":null}", "W")]
        [TestCase("{\"filter\":{\"additionalInfo\":{\"name\":\"modelName\",\"operator\":\"In\",\"values\":[\"test-model\"]}}}", "W")]
        public void CostControlPatchFilterRoundTrips(string json, string format)
        {
            ModelReaderWriterOptions options = new(format);
            CostControlPatchProperties model = ModelReaderWriter.Read<CostControlPatchProperties>(BinaryData.FromString(json), options);
            using JsonDocument original = JsonDocument.Parse(json);
            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
            bool expectedPresence = original.RootElement.TryGetProperty("filter", out JsonElement expected);
            bool actualPresence = serialized.RootElement.TryGetProperty("filter", out JsonElement actual);
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
            Assert.That(request.Uri.ToUri().Query, Does.Contain("api-version=2026-11-15-preview"));
        }

        private static CognitiveServicesAccountCostControlData CreateData(double amount)
            => new()
            {
                Properties = new CostControlProperties(CostControlCategory.Cost, amount, CostControlTimeGrain.Monthly,
                    new CostControlTimePeriod(StartsOn, EndsOn))
            };

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
            using JsonDocument document = JsonDocument.Parse(Encoding.UTF8.GetString(stream.ToArray()));
            return document.RootElement.Clone();
        }

        private static string CostControlBody(double amount, string etag)
            => $$"""
                {
                  "id":"/subscriptions/{{SubscriptionId}}/resourceGroups/{{ResourceGroupName}}/providers/Microsoft.CognitiveServices/accounts/{{AccountName}}/costControls/{{CostControlName}}",
                  "name":"{{CostControlName}}",
                  "type":"Microsoft.CognitiveServices/accounts/costControls",
                  "etag":"{{etag}}",
                  "properties":{
                                        "category":"Cost",
                                        "amount":{{amount}},
                                        "timeGrain":"Monthly",
                                        "timePeriod":{"startDate":"2030-01-01T00:00:00Z","endDate":"2030-02-01T00:00:00Z"}
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