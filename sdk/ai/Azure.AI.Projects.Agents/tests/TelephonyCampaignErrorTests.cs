// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCampaignErrorTests
{
    private const string ErrorJson = """
        {
          "code": "InvalidCampaign",
          "message": "Campaign could not be prepared.",
          "param": "recipients",
          "type": "invalid_request_error",
          "details": [
            {
              "code": "InvalidRecipient",
              "message": "Recipient failed validation.",
              "param": "recipients[1].destination",
              "details": [
                { "code": "InvalidNumber", "message": "The phone number is invalid.", "param": "value" }
              ]
            }
          ],
          "additionalInfo": { "field": { "name": "recipients" }, "nullable": null },
          "debugInfo": { "trace_id": "trace_1", "attempt": 2 },
          "misalignment": {
            "review_target": "response",
            "error_type": "policy",
            "detailed_explanation": "Review required.",
            "diagnostic": { "retryable": false }
          },
          "future_diagnostic": { "source": "preparation" }
        }
        """;

    [TestCase(typeof(TelephonyCampaign))]
    [TestCase(typeof(TelephonyCampaignOperation))]
    [TestCase(typeof(TelephonyCampaignValidationError))]
    public void CampaignErrorPropertiesExposePublicTypedData(Type modelType)
    {
        PropertyInfo property = modelType.GetProperty("Error");

        Assert.Multiple(() =>
        {
            Assert.That(property, Is.Not.Null);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(FoundryOpenAIError)));
            Assert.That(property.GetMethod.IsPublic, Is.True);
            Assert.That(property.PropertyType.IsPublic, Is.True);
        });
    }

    [Test]
    public void PublicErrorDoesNotExposeImplementationHelpersOrUpstreamHierarchy()
    {
        Type type = typeof(FoundryOpenAIError);

        Assert.Multiple(() =>
        {
            Assert.That(type.GetMethod("TryCreateFromResponse"), Is.Null);
            Assert.That(type.GetMethod("ToExceptionMessage"), Is.Null);
            Assert.That(type.GetMethod("ToOpenAIError"), Is.Null);
            Assert.That(type.GetProperty("Misalignment"), Is.Null);
            Assert.That(type.GetProperty("Misalignment", BindingFlags.Instance | BindingFlags.NonPublic), Is.Not.Null);
            Assert.That(typeof(MisalignmentErrorDetailsResource).IsPublic, Is.False);
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Assert.That(property.PropertyType.IsVisible, Is.True, property.Name);
            }
        });
    }

    [Test]
    public void ErrorFactoryExposesOnlyPublicDataAndRetainsNestedDetails()
    {
        FoundryOpenAIError detail = ProjectsAgentsModelFactory.FoundryOpenAIError("InvalidRecipient", "Invalid recipient.");
        FoundryOpenAIError error = ProjectsAgentsModelFactory.FoundryOpenAIError(
            code: "InvalidCampaign",
            message: "Campaign could not be prepared.",
            param: "recipients",
            type: "invalid_request_error",
            details: new[] { detail },
            additionalInfo: new Dictionary<string, BinaryData> { ["field"] = BinaryData.FromString("\"recipients\"") },
            debugInfo: new Dictionary<string, BinaryData> { ["attempt"] = BinaryData.FromString("2") });
        MethodInfo[] factories = typeof(ProjectsAgentsModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.ReturnType == typeof(FoundryOpenAIError))
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(factories, Has.Length.EqualTo(1));
            Assert.That(factories[0].GetParameters().All(parameter => parameter.ParameterType.IsVisible), Is.True);
            Assert.That(factories[0].GetCustomAttributesData()
                .Where(attribute => attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute"), Is.Empty);
            Assert.That(error.Code, Is.EqualTo("InvalidCampaign"));
            Assert.That(error.Param, Is.EqualTo("recipients"));
            Assert.That(error.Type, Is.EqualTo("invalid_request_error"));
            Assert.That(error.Details, Is.EqualTo(new[] { detail }));
            Assert.That(detail.Details, Is.Empty);
            Assert.That(detail.AdditionalInfo, Is.Empty);
            Assert.That(detail.DebugInfo, Is.Empty);
            Assert.That(error.AdditionalInfo["field"].ToObjectFromJson<string>(), Is.EqualTo("recipients"));
            Assert.That(error.DebugInfo["attempt"].ToObjectFromJson<int>(), Is.EqualTo(2));
        });
    }

    [TestCase(typeof(FoundryOpenAIError))]
    [TestCase(typeof(AgentAdministrationClient))]
    [TestCase(typeof(ProjectsAgentDefinition))]
    [TestCase(typeof(ProjectsAgentsModelFactory))]
    public void SharedErrorAndStableTypesRemainNonExperimental(Type type)
        => Assert.That(type.GetCustomAttributesData()
            .Where(attribute => attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute"), Is.Empty);

    [Test]
    public void CampaignFailureRoundTripsTypedError()
    {
        TelephonyCampaign campaign = Read<TelephonyCampaign>($$"""
            {
              "connection_name": "test-connection",
              "source": { "type": "phone_number", "value": "+15555550100" },
              "status": "failed",
              "error": {{ErrorJson}}
            }
            """);

        AssertRoundTrip(campaign, value => value.Error);
        using JsonDocument request = JsonDocument.Parse(ModelReaderWriter.Write(
            campaign, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default));
        Assert.That(request.RootElement.TryGetProperty("error", out _), Is.False, "Response-only errors must not be sent in campaign requests.");
    }

    [Test]
    public void CampaignOperationFailureRoundTripsTypedError()
    {
        TelephonyCampaignOperation operation = Read<TelephonyCampaignOperation>($$"""
            {
              "id": "operation_1",
              "status": "failed",
              "kind": "validation",
              "created_at": 1900000000,
              "error": {{ErrorJson}}
            }
            """);

        AssertRoundTrip(operation, value => value.Error);
    }

    [Test]
    public void CampaignValidationFailureRoundTripsTypedError()
    {
        TelephonyCampaignValidationError validation = Read<TelephonyCampaignValidationError>($$"""
            { "row_number": 2, "error": {{ErrorJson}} }
            """);

        Assert.That(validation.RowNumber, Is.EqualTo(2));
        AssertRoundTrip(validation, value => value.Error);
    }

    [Test]
    public void CampaignAndOperationWithoutFailureHaveNoError()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Read<TelephonyCampaign>("""{"connection_name":"test-connection","source":{"type":"phone_number","value":"+15555550100"}}""").Error, Is.Null);
            Assert.That(Read<TelephonyCampaignOperation>("""{"error":null}""").Error, Is.Null);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void NullableCodeAndParamRetainTheirWirePresence(bool includeParam)
    {
        string json = includeParam
            ? """{"code":null,"message":"Failure.","param":null}"""
            : """{"code":null,"message":"Failure."}""";
        FoundryOpenAIError error = ModelReaderWriter.Read<FoundryOpenAIError>(
            BinaryData.FromString(json), ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            error, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default));

        Assert.Multiple(() =>
        {
            Assert.That(error.Code, Is.Null);
            Assert.That(error.Param, Is.Null);
            Assert.That(document.RootElement.GetProperty("code").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(document.RootElement.TryGetProperty("param", out JsonElement param), Is.EqualTo(includeParam));
            if (includeParam)
            {
                Assert.That(param.ValueKind, Is.EqualTo(JsonValueKind.Null));
            }
        });
    }

    [Test]
    public void ExistingExceptionFormattingAndOpenAIConversionAreUnchanged()
    {
        MockPipelineResponse response = new MockPipelineResponse(400).WithContent(
            """{"code":"InvalidCampaign","message":"Campaign could not be prepared.","param":"recipients"}""");
        FoundryOpenAIError error = FoundryOpenAIError.TryCreateFromResponse(response);
        string newline = Environment.NewLine;
        using JsonDocument openAIError = JsonDocument.Parse(error.ToOpenAIError());
        JsonElement converted = openAIError.RootElement.GetProperty("error");

        Assert.Multiple(() =>
        {
            Assert.That(error.ToExceptionMessage(400), Is.EqualTo(
                $"HTTP 400 (InvalidCampaign){newline}Parameter: recipients{newline}{newline}Campaign could not be prepared."));
            Assert.That(converted.GetProperty("message").GetString(), Is.EqualTo(error.Message));
            Assert.That(converted.GetProperty("type").GetString(), Is.EqualTo("FoundryOpenAIError"));
            Assert.That(converted.GetProperty("code").GetString(), Is.EqualTo(error.Code));
            Assert.That(converted.GetProperty("param").GetString(), Is.Empty);
        });
    }

    [TestCase("A \"quoted\" value")]
    [TestCase(@"A path C:\folder\file")]
    [TestCase("First line\r\nSecond line")]
    public void OpenAIConversionEscapesAllStringFields(string value)
        => AssertOpenAIConversionEscapesStringFields(value);

    [Test]
    public void OpenAIConversionEscapesControlCharacters()
        => AssertOpenAIConversionEscapesStringFields("Tab\tand control\u0001");

    private static void AssertOpenAIConversionEscapesStringFields(string value)
    {
        FoundryOpenAIError detail = ProjectsAgentsModelFactory.FoundryOpenAIError(message: "Detail.", param: value);
        FoundryOpenAIError error = ProjectsAgentsModelFactory.FoundryOpenAIError(
            code: value, message: value, details: new[] { detail });
        using JsonDocument document = JsonDocument.Parse(error.ToOpenAIError());
        JsonElement converted = document.RootElement.GetProperty("error");

        Assert.Multiple(() =>
        {
            Assert.That(converted.GetProperty("message").GetString(), Does.StartWith(value));
            Assert.That(converted.GetProperty("code").GetString(), Is.EqualTo(value));
            Assert.That(converted.GetProperty("param").GetString(), Is.EqualTo(value));
            Assert.That(converted.GetProperty("type").GetString(), Is.EqualTo(nameof(FoundryOpenAIError)));
        });
    }

    [Test]
    public void OpenAIConversionPreservesLeafDetailMessages()
    {
        FoundryOpenAIError detail = ProjectsAgentsModelFactory.FoundryOpenAIError(
            code: "InvalidField", message: "Must be positive.", param: "field");
        FoundryOpenAIError error = ProjectsAgentsModelFactory.FoundryOpenAIError(
            code: "InvalidRequest", message: "Validation failed.", details: new[] { detail });
        using JsonDocument document = JsonDocument.Parse(error.ToOpenAIError());

        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("error").GetProperty("message").GetString(),
                Is.EqualTo("Validation failed. (Must be positive.)"));
            Assert.That(document.RootElement.GetProperty("error").GetProperty("param").GetString(), Is.EqualTo("field"));
        });
    }

    [Test]
    public void OpenAIConversionPreservesNestedAndSiblingDetails()
    {
        FoundryOpenAIError leaf = ProjectsAgentsModelFactory.FoundryOpenAIError(
            message: "The \"number\" is invalid.\nUse a positive value.", param: "number");
        FoundryOpenAIError branch = ProjectsAgentsModelFactory.FoundryOpenAIError(
            message: "Recipient failed validation.", param: "recipient", details: new[] { leaf });
        FoundryOpenAIError sibling = ProjectsAgentsModelFactory.FoundryOpenAIError(
            message: "Another field is missing.", param: "other");
        FoundryOpenAIError error = ProjectsAgentsModelFactory.FoundryOpenAIError(
            message: "Validation failed.", details: new[] { branch, sibling });
        using JsonDocument document = JsonDocument.Parse(error.ToOpenAIError());
        JsonElement converted = document.RootElement.GetProperty("error");
        string message = converted.GetProperty("message").GetString();

        Assert.Multiple(() =>
        {
            Assert.That(message, Does.Contain("Recipient failed validation."));
            Assert.That(message, Does.Contain(leaf.Message));
            Assert.That(message, Does.Contain("Another field is missing."));
            Assert.That(converted.GetProperty("param").GetString(), Is.EqualTo("recipient;other"));
        });
    }

    [Test]
    public void OpenAIConversionPreservesEmptyDefaults()
    {
        FoundryOpenAIError error = ProjectsAgentsModelFactory.FoundryOpenAIError();
        using JsonDocument document = JsonDocument.Parse(error.ToOpenAIError());
        JsonElement converted = document.RootElement.GetProperty("error");

        Assert.Multiple(() =>
        {
            Assert.That(converted.GetProperty("message").GetString(), Is.Empty);
            Assert.That(converted.GetProperty("code").GetString(), Is.Empty);
            Assert.That(converted.GetProperty("param").GetString(), Is.Empty);
            Assert.That(converted.GetProperty("type").GetString(), Is.EqualTo(nameof(FoundryOpenAIError)));
        });
    }

    [Test]
    public void NestedDetailsRemainAvailableToExceptionFormatting()
    {
        FoundryOpenAIError error = FoundryOpenAIError.TryCreateFromResponse(
            new MockPipelineResponse(400).WithContent(ErrorJson));
        string message = error.ToExceptionMessage(400);

        Assert.Multiple(() =>
        {
            Assert.That(message, Does.Contain("HTTP 400 (InvalidCampaign)"));
            Assert.That(message, Does.Contain("Parameter: recipients"));
            Assert.That(message, Does.Contain("Recipient failed validation."));
            Assert.That(message, Does.Contain("The phone number is invalid."));
            Assert.That(message, Does.Contain("recipients[1].destination"));
        });
    }

    [TestCase("{}")]
    [TestCase("null")]
    [TestCase("not-json")]
    public void UnrecognizedResponsesStillUseTheExistingExceptionFallback(string content)
        => Assert.That(FoundryOpenAIError.TryCreateFromResponse(
            new MockPipelineResponse(400).WithContent(content)), Is.Null);

    private static void AssertRoundTrip<T>(T model, Func<T, FoundryOpenAIError> getError)
    {
        AssertError(getError(model));
        BinaryData data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        T restored = Read<T>(data.ToString());
        AssertError(getError(restored));
        using JsonDocument document = JsonDocument.Parse(data);
        JsonElement error = document.RootElement.GetProperty("error");

        Assert.Multiple(() =>
        {
            Assert.That(error.GetProperty("misalignment").GetProperty("review_target").GetString(), Is.EqualTo("response"));
            Assert.That(error.GetProperty("misalignment").GetProperty("diagnostic").GetProperty("retryable").GetBoolean(), Is.False);
            Assert.That(error.GetProperty("future_diagnostic").GetProperty("source").GetString(), Is.EqualTo("preparation"));
            Assert.That(error.GetProperty("additionalInfo").GetProperty("nullable").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });
    }

    private static void AssertError(FoundryOpenAIError error)
    {
        Assert.That(error, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(error.Code, Is.EqualTo("InvalidCampaign"));
            Assert.That(error.Message, Is.EqualTo("Campaign could not be prepared."));
            Assert.That(error.Param, Is.EqualTo("recipients"));
            Assert.That(error.Type, Is.EqualTo("invalid_request_error"));
            Assert.That(error.Details, Has.Count.EqualTo(1));
            Assert.That(error.Details[0].Code, Is.EqualTo("InvalidRecipient"));
            Assert.That(error.Details[0].Param, Is.EqualTo("recipients[1].destination"));
            Assert.That(error.Details[0].Details[0].Code, Is.EqualTo("InvalidNumber"));
            Assert.That(error.AdditionalInfo["field"].ToObjectFromJson<JsonElement>().GetProperty("name").GetString(), Is.EqualTo("recipients"));
            Assert.That(error.AdditionalInfo["nullable"], Is.Null);
            Assert.That(error.DebugInfo["trace_id"].ToObjectFromJson<string>(), Is.EqualTo("trace_1"));
            Assert.That(error.DebugInfo["attempt"].ToObjectFromJson<int>(), Is.EqualTo(2));
        });
    }

    private static T Read<T>(string json) => ModelReaderWriter.Read<T>(
        BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
}
