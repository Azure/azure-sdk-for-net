// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests for stable VoiceLive session response fields.
    /// </summary>
    [TestFixture]
    public class RtcCallSdpEventsTests
    {
        [Test]
        public void SessionResponse_ExpiresAt_SerializesAndDeserializes()
        {
            const long expectedUnix = 1784073600;
            var expected = DateTimeOffset.FromUnixTimeSeconds(expectedUnix);

            var response = TestUtilities.DeserializeViaIJsonModel<VoiceLiveSessionResponse>(
                """{"expires_at":1784073600}""",
                new VoiceLiveSessionResponse());

            Assert.That(response.ExpiresAt, Is.EqualTo(expected));

            var json = TestUtilities.SerializeViaIJsonModel(new VoiceLiveSessionResponse { ExpiresAt = expected });
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("expires_at").GetInt64(), Is.EqualTo(expectedUnix));
        }
    }
}
