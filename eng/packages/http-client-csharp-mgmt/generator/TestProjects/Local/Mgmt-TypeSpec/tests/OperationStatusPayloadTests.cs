// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using NUnit.Framework;

namespace Azure.Generator.MgmtTypeSpec.Tests.Tests;

internal class OperationStatusPayloadTests
{
    [Test]
    public void StatusRoundTripPreservesFloat64PercentComplete([Values("J", "W")] string format, [Values] bool nested)
    {
        var options = new ModelReaderWriterOptions(format);
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        var payload = nested ? """{"status":"Ready","operations":[{"status":"Running","percentComplete":33.3333333333}]}"""
            : """{"status":"Running","percentComplete":33.3333333333}""";
        var value = ModelReaderWriter.Read<ExtendedOperationStatus>(BinaryData.FromString(payload), options, context)!;
        using var output = JsonDocument.Parse(ModelReaderWriter.Write(value, options, context));
        var status = nested ? output.RootElement.GetProperty("operations")[0] : output.RootElement;
        Assert.That(status.GetProperty("percentComplete").GetDouble(), Is.EqualTo(33.3333333333));
    }

    [Test]
    public void GeneratedStatusKeepsItsOwnRecursivePayloadAndLeavesOtherErrorsMapped()
    {
        var options = new ModelReaderWriterOptions("J");
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        var value = ModelReaderWriter.Read<ExtendedOperationStatus>(BinaryData.FromString("""
            {"status":"Ready","serviceError":{"serviceCode":"Service"},"serviceOptional":{"value":"Optional service value"},"operations":[{"status":"Failed","resourceId":"/subscriptions/00000000-0000-0000-0000-000000000002",
             "error":{"code":"Parent","details":[{"code":"Child","additionalInfo":[{"type":"T","info":{"n":1}}]}]}}]}
            """), options, context)!;
        Assert.That(value, Is.Not.InstanceOf<Azure.ResourceManager.Models.OperationStatusResult>());
        Assert.That(typeof(OperationStatusError).IsEnum, Is.True);
        var nested = value.Operations[0];
        Assert.That(nested.GetType(), Is.EqualTo(typeof(ExtendedOperationStatus).BaseType));
        Assert.That(nested.GetType().Name, Is.Not.EqualTo(nameof(Azure.ResourceManager.Models.OperationStatusResult)));
        Assert.That(value.ServiceError, Is.TypeOf<OperationStatusError2>());
        Assert.That(value.ServiceError.ServiceCode, Is.EqualTo("Service"));
        Assert.That(value.ServiceOptionalValue, Is.EqualTo("Optional service value"));
        using var output = JsonDocument.Parse(ModelReaderWriter.Write(value, options, context));
        Assert.That(output.RootElement.GetProperty("serviceError").GetProperty("serviceCode").GetString(), Is.EqualTo("Service"));
        Assert.That(output.RootElement.GetProperty("serviceOptional").GetProperty("value").GetString(), Is.EqualTo("Optional service value"));
        Assert.That(nested.ResourceId.ToString(), Is.EqualTo("/subscriptions/00000000-0000-0000-0000-000000000002"));
        Assert.That(nested.Error.Details[0].Code, Is.EqualTo("Child"));
        Assert.That(nested.Error.Details[0].AdditionalInfo[0].Type, Is.EqualTo("T"));
        Assert.That(typeof(FooActionResult).GetProperty(nameof(FooActionResult.Error))!.PropertyType, Is.EqualTo(typeof(Azure.ResponseError)));
    }

    [Test]
    public void StatusJsonPersistencePreservesExplicitNullErrorInfo([Values] bool nested)
    {
        var options = new ModelReaderWriterOptions("J");
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        const string failure = """{"status":"Failed","error":{"additionalInfo":[{"type":"T","info":null},{"type":"Missing"}]}}""";
        var payload = nested ? $$"""{"status":"Ready","operations":[{{failure}}]}""" : failure;
        var value = ModelReaderWriter.Read<ExtendedOperationStatus>(BinaryData.FromString(payload), options, context)!;
        using var output = JsonDocument.Parse(ModelReaderWriter.Write(value, options, context));
        var status = nested ? output.RootElement.GetProperty("operations")[0] : output.RootElement;
        var info = status.GetProperty("error").GetProperty("additionalInfo");
        Assert.That(info[0].GetProperty("info").ValueKind, Is.EqualTo(JsonValueKind.Null));
        Assert.That(info[1].TryGetProperty("info", out _), Is.False);
    }

    [Test]
    public void StatusWireReadPreservesErrorExtensionsForJsonPersistence([Values] bool nested)
    {
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        const string failure = """{"status":"Failed","error":{"code":"X","innererror":{"code":"Y"},"extension":42}}""";
        var payload = nested ? $$"""{"status":"Ready","operations":[{{failure}}]}""" : failure;
        var value = ModelReaderWriter.Read<ExtendedOperationStatus>(BinaryData.FromString(payload), new ModelReaderWriterOptions("W"), context)!;
        using var output = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("J"), context));
        var status = nested ? output.RootElement.GetProperty("operations")[0] : output.RootElement;
        var error = status.GetProperty("error");
        Assert.That(error.GetProperty("innererror").GetProperty("code").GetString(), Is.EqualTo("Y"));
        Assert.That(error.GetProperty("extension").GetInt32(), Is.EqualTo(42));

        using var request = Azure.Core.RequestContent.Create(value, new ModelReaderWriterOptions("W"));
        using var body = new MemoryStream();
        request.WriteTo(body, default);
        using var wire = JsonDocument.Parse(body.ToArray());
        var wireStatus = nested ? wire.RootElement.GetProperty("operations")[0] : wire.RootElement;
        Assert.That(wireStatus.GetProperty("error").EnumerateObject(), Is.Empty);
    }

    [Test]
    public void StatusErrorExtensionsCannotOverwriteDeclaredMembers()
    {
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        var options = new ModelReaderWriterOptions("J");
        var value = MgmtTypeSpecTestsModelFactory.OperationStatusError3(code: "Original");
        value.AdditionalProperties["code"] = BinaryData.FromString("\"Replacement\"");
        value.AdditionalProperties["message"] = BinaryData.FromString("\"Unexpected\"");
        value.AdditionalProperties["extension"] = BinaryData.FromString("42");

        var result = ModelReaderWriter.Write(value, options, context);
        using var output = JsonDocument.Parse(result);
        Assert.Multiple(() =>
        {
            Assert.That(output.RootElement.TryGetProperty("message", out _), Is.False);
            Assert.That(output.RootElement.GetProperty("extension").GetInt32(), Is.EqualTo(42));
            Assert.That(ModelReaderWriter.Read<OperationStatusError3>(result, options, context)!.Code, Is.EqualTo("Original"));
        });
    }

    [Test]
    public void StatusFactoriesDistinguishOmittedAndExplicitlyEmptyCollections([Values] bool explicitEmpty)
    {
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        var options = new ModelReaderWriterOptions("J");
        var status = MgmtTypeSpecTestsModelFactory.ExtendedOperationStatus(status: "Ready",
            operations: explicitEmpty ? [] : null);
        var error = MgmtTypeSpecTestsModelFactory.OperationStatusError3(code: "X",
            details: explicitEmpty ? [] : null, additionalInfo: explicitEmpty ? [] : null);
        using var statusJson = JsonDocument.Parse(ModelReaderWriter.Write(status, options, context));
        using var errorJson = JsonDocument.Parse(ModelReaderWriter.Write(error, options, context));
        Assert.Multiple(() =>
        {
            Assert.That(statusJson.RootElement.TryGetProperty("operations", out _), Is.EqualTo(explicitEmpty));
            Assert.That(errorJson.RootElement.TryGetProperty("details", out _), Is.EqualTo(explicitEmpty));
            Assert.That(errorJson.RootElement.TryGetProperty("additionalInfo", out _), Is.EqualTo(explicitEmpty));
        });
    }

    [Test]
    public void StatusJsonPersistencePreservesArmErrorAdditionalInfo([Values] bool nested)
    {
        var options = new ModelReaderWriterOptions("J");
        var context = AzureGeneratorMgmtTypeSpecTestsContext.Default;
        const string failure = """{"status":"Failed","error":{"code":"X","additionalInfo":[{"type":"T","info":{"n":1}}]}}""";
        var payload = nested ? $$"""{"status":"Ready","operations":[{{failure}}]}""" : failure;
        var value = ModelReaderWriter.Read<ExtendedOperationStatus>(BinaryData.FromString(payload), options, context)!;
        using var output = JsonDocument.Parse(ModelReaderWriter.Write(value, options, context));
        var status = nested ? output.RootElement.GetProperty("operations")[0] : output.RootElement;
        var error = status.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("X"));
        Assert.That(error.TryGetProperty("additionalInfo", out var additionalInfo), Is.True);
        Assert.That(additionalInfo[0].GetProperty("type").GetString(), Is.EqualTo("T"));
        Assert.That(additionalInfo[0].GetProperty("info").GetProperty("n").GetInt32(), Is.EqualTo(1));
    }
}
