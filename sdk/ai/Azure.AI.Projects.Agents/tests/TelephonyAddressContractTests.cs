// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyAddressContractTests
{
    [TestCase("sip:support@example.com")]
    [TestCase("sips:support@example.com;transport=tls")]
    public void SipAddressPreservesValueThroughBaseAndDerivedViews(string value)
    {
        SipAddress address = new(value);
        TelephonyAddress baseAddress = address;
        Assert.That(baseAddress.Value, Is.EqualTo(value));

        string updated = value.Replace("support", "help");
        baseAddress.Value = updated;
        Assert.That(address.Value, Is.EqualTo(updated));

        BinaryData data = ModelReaderWriter.Write(baseAddress, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(data);
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("sip"));
            Assert.That(document.RootElement.GetProperty("value").GetString(), Is.EqualTo(updated));
        });

        TelephonyAddress restored = ModelReaderWriter.Read<TelephonyAddress>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(restored, Is.TypeOf<SipAddress>());
        Assert.That(restored.Value, Is.EqualTo(updated));
        Assert.That(((SipAddress)restored).Value, Is.EqualTo(updated));
    }

    [Test]
    public void SipAddressRequiresValue()
        => Assert.Throws<ArgumentNullException>(() => new SipAddress(null));

    [Test]
    public void FreshBindingCanBePersistedWithoutAServiceGeneratedIncomingUrl()
    {
        TelephonyBinding binding = new TwilioTelephonyBinding("connection", "+15555550100");
        BinaryData data = ModelReaderWriter.Write(binding, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        TelephonyBinding restored = ModelReaderWriter.Read<TelephonyBinding>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.Multiple(() =>
        {
            Assert.That(restored, Is.TypeOf<TwilioTelephonyBinding>());
            Assert.That(restored.ConnectionName, Is.EqualTo("connection"));
            Assert.That(restored.IncomingCallUrl, Is.Null);
            Assert.That(((TwilioTelephonyBinding)restored).PhoneNumber, Is.EqualTo("+15555550100"));
        });
    }

    [TestCase(null)]
    [TestCase("https://example.com/incoming")]
    public void IncomingCallUrlPersistsButIsNotSentInBindingRequests(string incomingCallUrl)
    {
        string urlJson = incomingCallUrl == null ? "null" : $"\"{incomingCallUrl}\"";
        TelephonyBinding binding = ModelReaderWriter.Read<TelephonyBinding>(
            BinaryData.FromString($$"""
                {
                  "provider": "twilio",
                  "connection_name": "connection",
                  "phone_number": "+15555550100",
                  "incoming_call_url": {{urlJson}}
                }
                """),
            ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        BinaryData persisted = ModelReaderWriter.Write(binding, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        TelephonyBinding restored = ModelReaderWriter.Read<TelephonyBinding>(
            persisted, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(
            restored, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default));

        Assert.Multiple(() =>
        {
            Assert.That(restored.IncomingCallUrl?.AbsoluteUri, Is.EqualTo(incomingCallUrl));
            Assert.That(wire.RootElement.TryGetProperty("incoming_call_url", out _), Is.False);
            Assert.That(wire.RootElement.GetProperty("connection_name").GetString(), Is.EqualTo("connection"));
        });
    }
}
