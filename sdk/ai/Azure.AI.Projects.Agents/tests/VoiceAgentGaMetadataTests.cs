// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using NUnit.Framework;

#pragma warning disable AAIP001, AAIP002

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentGaMetadataTests
{
    [TestCase(typeof(VoiceAgentDefinition))]
    [TestCase(typeof(TelephonyAddress))]
    [TestCase(typeof(PhoneNumber))]
    [TestCase(typeof(TeamsAddress))]
    [TestCase(typeof(TelephonyBinding))]
    [TestCase(typeof(TwilioTelephonyBinding))]
    [TestCase(typeof(TeamsPhoneExtensibilityTelephonyBinding))]
    [TestCase(typeof(TelephonyProvider))]
    public void ConditionalPreviewValuesDoNotMarkGaTypesExperimental(Type type)
        => Assert.That(Diagnostics(type), Does.Not.Contain("AAIP001"));

    [TestCase(typeof(VoiceAgentLiveDefinition))]
    [TestCase(typeof(SipTelephonyBinding))]
    [TestCase(typeof(SipAddress))]
    public void RequiredPreviewTypesRemainExperimental(Type type)
        => Assert.That(Diagnostics(type), Does.Contain("AAIP001"));

    [Test]
    public void DefaultResponseInitializationDoesNotRequirePreviewOptIn()
    {
        ConstructorInfo constructor = typeof(VoiceResult).GetConstructor(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
        Assert.That(constructor, Is.Not.Null);
        Assert.That(Diagnostics(constructor), Is.Empty);
        Assert.That(new VoiceResult().Output, Is.Empty);
    }

    [Test]
    public void CampaignErrorDetailsRemainPublicWithoutExposingInternalHelpers()
    {
        Assert.That(typeof(TelephonyCampaign).GetProperty(nameof(TelephonyCampaign.Error)).PropertyType.IsPublic, Is.True);
        Assert.That(typeof(FoundryOpenAIError).GetMethod("ToOpenAIError", BindingFlags.Public | BindingFlags.Instance), Is.Null);
        Assert.That(typeof(FoundryOpenAIError).GetProperty("Misalignment", BindingFlags.Public | BindingFlags.Instance), Is.Null);
        MethodInfo[] factories = typeof(ProjectsAgentsModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.ReturnType == typeof(FoundryOpenAIError)).ToArray();
        Assert.That(factories, Has.Length.EqualTo(1));
        Assert.That(factories[0].GetParameters().Select(parameter => parameter.Name), Does.Not.Contain("misalignment"));
    }

    [Test]
    public void CampaignValidationErrorsRetainPublicServiceDetails()
    {
        BinaryData payload = BinaryData.FromString("""
            {"row_number":7,"error":{"code":"invalid_recipient_schedule",
            "message":"Provide a timestamp with an explicit timezone.","param":"schedule"}}
            """);
        TelephonyCampaignValidationError result = ModelReaderWriter.Read<TelephonyCampaignValidationError>(
            payload, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.Multiple(() =>
        {
            Assert.That(result.RowNumber, Is.EqualTo(7));
            Assert.That(result.Error.Code, Is.EqualTo("invalid_recipient_schedule"));
            Assert.That(result.Error.Message, Is.EqualTo("Provide a timestamp with an explicit timezone."));
            Assert.That(result.Error.Param, Is.EqualTo("schedule"));
        });

        using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(
            result, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
        Assert.That(written.RootElement.GetProperty("error").GetProperty("code").GetString(),
            Is.EqualTo("invalid_recipient_schedule"));
    }

    [Test]
    public void SipAddressUsesTheSharedStringValueContract()
    {
        SipAddress address = new("sips:agent@fake.example");
        TelephonyAddress shared = address;
        Assert.That(shared.Value, Is.EqualTo("sips:agent@fake.example"));

        BinaryData payload = ModelReaderWriter.Write(shared, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        TelephonyAddress restored = ModelReaderWriter.Read<TelephonyAddress>(
            payload, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(restored, Is.TypeOf<SipAddress>());
        Assert.That(restored.Value, Is.EqualTo(shared.Value));
    }

    private static string[] Diagnostics(MemberInfo member)
        => member.GetCustomAttributesData()
            .Where(attribute => attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute")
            .Select(attribute => (string)attribute.ConstructorArguments[0].Value)
            .ToArray();
}
