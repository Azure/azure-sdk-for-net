// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
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
            var response = TestUtilities.DeserializeViaIJsonModel<VoiceLiveSessionResponse>(
                """{"expires_at":1234567890}""",
                new VoiceLiveSessionResponse());

            Assert.That(response.ExpiresAt, Is.EqualTo(1234567890L));

            var json = TestUtilities.SerializeViaIJsonModel(new VoiceLiveSessionResponse { ExpiresAt = 1234567890L });
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("expires_at").GetInt64(), Is.EqualTo(1234567890L));
        }
    }
}
