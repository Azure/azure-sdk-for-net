// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class ListQueryParametersTests
    {
        private class FakeCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new AccessToken("fake", DateTimeOffset.UtcNow.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }

        private static MockResponse CreateResponse()
        {
            var response = new MockResponse(200);
            response.SetContent("{\"value\":[]}");
            return response;
        }

        private static System.Collections.Generic.Dictionary<string, string> ParseQuery(Uri uri)
            => uri.Query.TrimStart('?')
                .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Split(new[] { '=' }, 2))
                .ToDictionary(p => Uri.UnescapeDataString(p[0]), p => p.Length > 1 ? Uri.UnescapeDataString(p[1].Replace('+', ' ')) : string.Empty);

        [Test]
        public void ListCves_SendsFilterOrderbySearchAndTop()
        {
            var transport = new MockTransport(CreateResponse());
            var client = new ArmClient(
                new FakeCredential(),
                "00000000-0000-0000-0000-000000000000",
                new ArmClientOptions { Transport = transport });

            var firmwareId = IotFirmwareResource.CreateResourceIdentifier(
                "00000000-0000-0000-0000-000000000000", "rg", "workspace", "firmware");
            var firmware = client.GetIotFirmwareResource(firmwareId);

            _ = firmware.GetCves(filter: "severity eq 'High'", orderby: "cveName desc", search: "openssl", maxCount: 5).ToList();

            var query = ParseQuery(transport.SingleRequest.Uri.ToUri());
            Assert.AreEqual("2027-01-01", query["api-version"]);
            Assert.AreEqual("severity eq 'High'", query["$filter"]);
            Assert.AreEqual("cveName desc", query["$orderby"]);
            Assert.AreEqual("openssl", query["$search"]);
            Assert.AreEqual("5", query["$top"]);
        }

        [Test]
        public void ListCves_OmitsQueryParametersWhenNotSet()
        {
            var transport = new MockTransport(CreateResponse());
            var client = new ArmClient(
                new FakeCredential(),
                "00000000-0000-0000-0000-000000000000",
                new ArmClientOptions { Transport = transport });

            var firmware = client.GetIotFirmwareResource(IotFirmwareResource.CreateResourceIdentifier(
                "00000000-0000-0000-0000-000000000000", "rg", "workspace", "firmware"));

            _ = firmware.GetCves().ToList();

            var query = ParseQuery(transport.SingleRequest.Uri.ToUri());
            Assert.IsFalse(query.ContainsKey("$filter"));
            Assert.IsFalse(query.ContainsKey("$orderby"));
            Assert.IsFalse(query.ContainsKey("$search"));
            Assert.IsFalse(query.ContainsKey("$top"));
        }
    }
}
