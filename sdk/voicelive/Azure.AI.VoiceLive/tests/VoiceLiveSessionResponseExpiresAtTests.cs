// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests validating the wire-format (Unix seconds) serialization and deserialization
    /// of the <see cref="VoiceLiveSessionResponse.ExpiresAt"/> property.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionResponseExpiresAtTests
    {
        [Test]
        public void ExpiresAt_SerializesAsUnixSeconds()
        {
            var expiresAt = DateTimeOffset.FromUnixTimeSeconds(1_752_537_600); // 2025-07-14T22:40:00Z
            var response = new VoiceLiveSessionResponse { ExpiresAt = expiresAt };

            var json = TestUtilities.SerializeViaIJsonModel(response);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.TryGetProperty("expires_at", out var prop), Is.True);
            Assert.That(prop.ValueKind, Is.EqualTo(JsonValueKind.Number));
            Assert.That(prop.GetInt64(), Is.EqualTo(1_752_537_600));
        }

        [Test]
        public void ExpiresAt_DeserializesFromUnixSeconds()
        {
            var fromWire = TestUtilities.DeserializeViaIJsonModel(
                """{"expires_at":1752537600}""",
                new VoiceLiveSessionResponse());

            Assert.That(fromWire.ExpiresAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1_752_537_600)));
        }

        [Test]
        public void ExpiresAt_RoundTrips()
        {
            var expiresAt = DateTimeOffset.FromUnixTimeSeconds(1_800_000_000);
            var original = new VoiceLiveSessionResponse { ExpiresAt = expiresAt };

            var json = TestUtilities.SerializeViaIJsonModel(original);
            var fromWire = TestUtilities.DeserializeViaIJsonModel(json, new VoiceLiveSessionResponse());

            Assert.That(fromWire.ExpiresAt, Is.EqualTo(expiresAt));
        }

        [Test]
        public void ExpiresAt_WhenUnset_IsOmittedFromJson()
        {
            var response = new VoiceLiveSessionResponse();

            var json = TestUtilities.SerializeViaIJsonModel(response);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.TryGetProperty("expires_at", out _), Is.False);
        }

        [Test]
        public void ExpiresAt_WhenAbsentFromJson_DeserializesAsNull()
        {
            var fromWire = TestUtilities.DeserializeViaIJsonModel("{}", new VoiceLiveSessionResponse());

            Assert.That(fromWire.ExpiresAt, Is.Null);
        }
    }
}
