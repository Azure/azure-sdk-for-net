// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;
#pragma warning disable AAIP001
public class VoiceAgentUnitTests
{
    [Test]
    [TestCase(null, null, true)]
    [TestCase(null, "inf", false)]
    [TestCase(0, null, false)]
    [TestCase(42, null, false)]
    public void TestVoiceAgentMaxOutputTokens(int? outputTokens, string inf, bool isDefaultNullValue)
    {
        // Creation
        VoiceAgentMaxOutputTokens outputTokensObj = inf == null ? (isDefaultNullValue ? new(true) : new(outputTokens.Value)) : new(inf);
        Assert.That(outputTokensObj.NumericValue, Is.EqualTo(outputTokens));
        // Serialization
        BinaryData data = ModelReaderWriter.Write(outputTokensObj, ModelReaderWriterOptions.Json);
        if (string.Equals(inf, "inf"))
        {
            Assert.That(data.ToString(), Is.EqualTo("\"inf\""));
        }
        else
        {
            if (!isDefaultNullValue)
            {
                Assert.That(data.ToString(), Is.EqualTo(outputTokens.ToString()));
            }
        }
        // Deserialization
        VoiceAgentMaxOutputTokens deserialized = VoiceAgentMaxOutputTokens.FromBinaryData(data);
        Assert.That(deserialized.NumericValue, Is.EqualTo(outputTokens));
        // Equality
        Assert.That(deserialized.Equals(outputTokensObj), Is.True);
        if (string.Equals(inf, "inf"))
        {
            Assert.That(deserialized.Equals(VoiceAgentMaxOutputTokens.Infinity), Is.True);
        }
        else
        {
            Assert.That(deserialized.Equals(VoiceAgentMaxOutputTokens.Infinity), Is.False);
        }
    }

    [Test]
    public void TestVoiceAgentAvatarVideoCrop()
    {
        VoiceAgentAvatarVideoCrop crop = new(bottomRight: [1, 2, 3], topLeft: [4, 5, 6]);
        Assert.That(crop.BottomRight, Is.EqualTo([1, 2, 3]));
        Assert.That(crop.TopLeft, Is.EqualTo([4, 5, 6]));
        // Test with the objects
        crop = new(bottomRight: [(object)1, (object)2, (object)3], topLeft: [(object)4, (object)5, (object)6]);
        Assert.That(crop.BottomRight, Is.EqualTo([1, 2, 3]));
        Assert.That(crop.TopLeft, Is.EqualTo([4, 5, 6]));
    }

    [Test]
    [TestCase("", null)]
    [TestCase(null, null)]
    [TestCase("https://www.microsoft.com", "https://www.microsoft.com")]
    public void TestOtlpTelemetryEndpoint(string endpoint, string expectedEndpoint)
    {
        OtlpTelemetryEndpoint telemetryEndpoint = new(exportedDataTypes: [], internalEndpoint: endpoint ?? "", protocol: TelemetryTransportProtocol.Http);
        Assert.That(telemetryEndpoint.Endpoint, Is.EqualTo(expectedEndpoint));
        telemetryEndpoint.Endpoint = new Uri("http://example.com");
        Assert.That(telemetryEndpoint.Endpoint, Is.InstanceOf<Uri>());
        Assert.That(telemetryEndpoint.Endpoint, Is.EqualTo(new Uri("http://example.com")));
        telemetryEndpoint.Endpoint = string.IsNullOrEmpty(endpoint) ? null : new Uri(endpoint);
        Assert.That(telemetryEndpoint.Endpoint, Is.EqualTo(expectedEndpoint));
    }
}
