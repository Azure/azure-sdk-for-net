// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchCompatibilityTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task PoolUpdateAcceptsLegacyData(bool useAsync)
        {
            string subscriptionId = Guid.NewGuid().ToString();
            ResourceIdentifier poolId = BatchAccountPoolResource.CreateResourceIdentifier(subscriptionId, "group", "account", "pool");
            MockTransport transport = new MockTransport(request =>
            {
                Assert.That(request.Method, Is.EqualTo(RequestMethod.Patch));
                Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(poolId.ToString()));
                Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatch), Is.True);
                Assert.That(ifMatch, Is.EqualTo("*"));

                using MemoryStream stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                using JsonDocument body = JsonDocument.Parse(stream.ToArray());
                Assert.That(body.RootElement.GetProperty("properties").GetProperty("displayName").GetString(), Is.EqualTo("Updated pool"));
                return new MockResponse(200).SetContent($"{{\"id\":\"{poolId}\",\"properties\":{{\"displayName\":\"Updated pool\"}}}}");
            });
            ArmClient client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            BatchAccountPoolResource pool = client.GetBatchAccountPoolResource(poolId);
            BatchAccountPoolData poolData = new BatchAccountPoolData { DisplayName = "Updated pool" };

            Response<BatchAccountPoolResource> result = useAsync
                ? await pool.UpdateAsync(data: poolData, ifMatch: ETag.All)
                : pool.Update(data: poolData, ifMatch: ETag.All);

            Assert.That(result.Value.Data.DisplayName, Is.EqualTo("Updated pool"));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        }

        [Test]
        public void LegacyTaskAuthenticationModeRetainsWireValue()
        {
            const string wireValue = "TaskAuthenticationToken";
            MockResponse response = new MockResponse(200).SetContent($"{{\"properties\":{{\"allowedAuthenticationModes\":[\"{wireValue}\"]}}}}");
            BatchAccountData account = BatchAccountData.FromResponse(response);
            CollectionAssert.AreEqual(new[] { BatchAuthenticationMode.TaskAuthenticationToken }, account.AllowedAuthenticationModes);

            BatchAccountPatch patch = new BatchAccountPatch
            {
                Properties = new BatchAccountUpdateProperties { AllowedAuthenticationModes = { BatchAuthenticationMode.TaskAuthenticationToken } }
            };
            using RequestContent content = BatchAccountPatch.ToRequestContent(patch);
            using MemoryStream stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.That(body.RootElement.GetProperty("properties").GetProperty("allowedAuthenticationModes")[0].GetString(), Is.EqualTo(wireValue));
        }
    }
}
