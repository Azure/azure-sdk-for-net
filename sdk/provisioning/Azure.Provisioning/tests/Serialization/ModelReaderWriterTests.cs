// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Serialization;

/// <summary>
/// Tests for ModelReaderWriter contract compliance on Infrastructure,
/// BicepExpression, and BicepStatement types.
/// </summary>
public class ModelReaderWriterTests
{
    #region Infrastructure MRW Tests

    [Test]
    public void MRW_Write_BicepFormat_MatchesCompilePath()
    {
        Infrastructure infra = new();
        Storage.StorageAccount storage = new("storage", Storage.StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = Storage.StorageKind.StorageV2,
            Sku = new Storage.StorageSku { Name = Storage.StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        var compiled = plan.Compile();
        string expectedBicep = compiled["main.bicep"];

        BinaryData bicepData = ModelReaderWriter.Write(infra, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        string actualBicep = bicepData.ToString();

        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void MRW_Write_JsonFormat_ProducesValidJson()
    {
        Infrastructure infra = new();
        Storage.StorageAccount storage = new("storage", Storage.StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = Storage.StorageKind.StorageV2,
            Sku = new Storage.StorageSku { Name = Storage.StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        BinaryData jsonData = ModelReaderWriter.Write(infra, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string json = jsonData.ToString();

        using JsonDocument doc = JsonDocument.Parse(json);
        Assert.IsTrue(doc.RootElement.TryGetProperty("fileName", out _));
    }

    [Test]
    public void MRW_ReadWrite_JsonFormat_RoundTrips()
    {
        Infrastructure infra = new();
        Storage.StorageAccount storage = new("storage", Storage.StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = Storage.StorageKind.StorageV2,
            Sku = new Storage.StorageSku { Name = Storage.StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        BinaryData jsonData = ModelReaderWriter.Write(infra, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);

        Infrastructure deserialized = ModelReaderWriter.Read<Infrastructure>(jsonData, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.IsNotNull(deserialized);

        BinaryData jsonData2 = ModelReaderWriter.Write(deserialized, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        Assert.AreEqual(jsonData.ToString(), jsonData2.ToString());
    }

    [Test]
    public void MRW_Read_BicepFormat_ThrowsFormatException()
    {
        Infrastructure infra = new();
        Storage.StorageAccount storage = new("storage", Storage.StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = Storage.StorageKind.StorageV2,
            Sku = new Storage.StorageSku { Name = Storage.StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        BinaryData bicepData = ModelReaderWriter.Write(infra, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);

        Assert.Throws<FormatException>(() =>
            ModelReaderWriter.Read<Infrastructure>(bicepData, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default));
    }

    [Test]
    public void MRW_Write_UnsupportedFormat_ThrowsFormatException()
    {
        Infrastructure infra = new();
        Assert.Throws<FormatException>(() =>
            ModelReaderWriter.Write(infra, new ModelReaderWriterOptions("xml"), AzureProvisioningContext.Default));
    }

    #endregion

    #region BicepExpression MRW Tests

    [Test]
    public void MRW_BicepExpression_WriteJson_RoundTrips()
    {
        BicepExpression expr = new StringLiteralExpression("hello");

        BinaryData json = ModelReaderWriter.Write(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        Assert.IsNotNull(json);
        Assert.IsTrue(json.ToString().Contains("\"kind\":\"string\"") || json.ToString().Contains("\"kind\": \"string\""),
            $"Expected string kind. Got: {json}");

        BicepExpression deserialized = ModelReaderWriter.Read<BicepExpression>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.IsNotNull(deserialized);
        Assert.AreEqual(expr, deserialized);
    }

    [Test]
    public void MRW_BicepExpression_WriteBicep_ProducesExpectedOutput()
    {
        BicepExpression expr = new StringLiteralExpression("hello");

        BinaryData bicep = ModelReaderWriter.Write(expr, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.AreEqual("'hello'", bicep.ToString());
    }

    [Test]
    public void MRW_BicepExpression_ComplexExpression_RoundTrips()
    {
        BicepExpression expr = new FunctionCallExpression(
            new IdentifierExpression("take"),
            new FunctionCallExpression(
                new IdentifierExpression("concat"),
                new StringLiteralExpression("prefix"),
                new FunctionCallExpression(
                    new IdentifierExpression("uniqueString"),
                    new StringLiteralExpression("seed"))),
            new IntLiteralExpression(24));

        BinaryData json = ModelReaderWriter.Write(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        BicepExpression deserialized = ModelReaderWriter.Read<BicepExpression>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.AreEqual(expr, deserialized);
    }

    [Test]
    public void MRW_BicepExpression_PropertyAccess_RoundTrips()
    {
        BicepExpression expr = new MemberExpression(
            new MemberExpression(
                new IdentifierExpression("storageAccount"),
                "properties"),
            "primaryEndpoints");

        BinaryData json = ModelReaderWriter.Write(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        BicepExpression deserialized = ModelReaderWriter.Read<BicepExpression>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.AreEqual(expr, deserialized);
    }

    [Test]
    public void MRW_BicepExpression_ContextualVariable_RoundTrips()
    {
        BicepExpression expr = new MemberExpression(
            new FunctionCallExpression(new IdentifierExpression("subscription")),
            "subscriptionId");

        BinaryData json = ModelReaderWriter.Write(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"kind\":\"contextual-variable\"") || jsonStr.Contains("\"kind\": \"contextual-variable\""),
            $"Expected contextual-variable kind. Got: {jsonStr}");

        BicepExpression deserialized = ModelReaderWriter.Read<BicepExpression>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        Assert.AreEqual(expr, deserialized);
    }

    [Test]
    public void MRW_BicepExpression_UnaryExpression_RoundTrips()
    {
        var notExpr = new UnaryExpression(UnaryBicepOperator.Not, new BoolLiteralExpression(true));
        SerializationTestHelpers.AssertExpressionRoundTrip(notExpr);

        var negExpr = new UnaryExpression(UnaryBicepOperator.Negate, new IntLiteralExpression(5));
        SerializationTestHelpers.AssertExpressionRoundTrip(negExpr);

        var suppressExpr = new UnaryExpression(UnaryBicepOperator.SuppressNull, new IdentifierExpression("x"));
        SerializationTestHelpers.AssertExpressionRoundTrip(suppressExpr);
    }

    [Test]
    public void MRW_BicepExpression_BinaryExpression_RoundTrips()
    {
        var left = new IdentifierExpression("a");
        var right = new IntLiteralExpression(1);

        BinaryBicepOperator[] operators =
        [
            BinaryBicepOperator.And, BinaryBicepOperator.Or, BinaryBicepOperator.Coalesce,
            BinaryBicepOperator.Equal, BinaryBicepOperator.EqualIgnoreCase,
            BinaryBicepOperator.NotEqual, BinaryBicepOperator.NotEqualIgnoreCase,
            BinaryBicepOperator.Greater, BinaryBicepOperator.GreaterOrEqual,
            BinaryBicepOperator.Less, BinaryBicepOperator.LessOrEqual,
            BinaryBicepOperator.Add, BinaryBicepOperator.Subtract,
            BinaryBicepOperator.Multiply, BinaryBicepOperator.Divide, BinaryBicepOperator.Modulo,
        ];

        foreach (var op in operators)
        {
            var expr = new BinaryExpression(left, op, right);
            SerializationTestHelpers.AssertExpressionRoundTrip(expr);
        }
    }

    [Test]
    public void MRW_BicepExpression_ConditionalExpression_RoundTrips()
    {
        var expr = new ConditionalExpression(
            new BoolLiteralExpression(true),
            new StringLiteralExpression("yes"),
            new StringLiteralExpression("no"));
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_InterpolatedString_RoundTrips()
    {
        var expr = new InterpolatedStringExpression(
        [
            new StringLiteralExpression("prefix-"),
            new IdentifierExpression("name"),
            new StringLiteralExpression("-suffix"),
        ]);
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_IfConditionExpression_RoundTrips()
    {
        var expr = new IfConditionExpression(
            new IdentifierExpression("enabled"),
            new ObjectExpression(
                new PropertyExpression("name", new StringLiteralExpression("myResource"))));
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_NestedExpression_RoundTrips()
    {
        var expr = new NestedExpression(new IdentifierExpression("kv"), "secret");
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_SafeMemberExpression_RoundTrips()
    {
        var expr = new SafeMemberExpression(new IdentifierExpression("obj"), "prop");
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);

        var json = ModelReaderWriter.Write<BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        using var doc = JsonDocument.Parse(json);
        Assert.AreEqual(true, doc.RootElement.GetProperty("nullish").GetBoolean());
    }

    [Test]
    public void MRW_BicepExpression_SafeIndexExpression_RoundTrips()
    {
        var expr = new SafeIndexExpression(new IdentifierExpression("arr"), new IntLiteralExpression(0));
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);

        var json = ModelReaderWriter.Write<BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        using var doc = JsonDocument.Parse(json);
        Assert.AreEqual(true, doc.RootElement.GetProperty("nullish").GetBoolean());
    }

    [Test]
    public void MRW_BicepExpression_TypeExpression_AllTypes_RoundTrips()
    {
        Type[] types = [typeof(bool), typeof(int), typeof(string), typeof(object), typeof(Array)];
        foreach (var type in types)
        {
            var expr = new TypeExpression(type);
            SerializationTestHelpers.AssertExpressionRoundTrip(expr);
        }
    }

    [Test]
    public void MRW_BicepExpression_IndexExpression_RoundTrips()
    {
        var expr = new IndexExpression(
            new IdentifierExpression("arr"),
            new StringLiteralExpression("key"));
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_ObjectExpression_Empty_RoundTrips()
    {
        var expr = new ObjectExpression();
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_ArrayExpression_Empty_RoundTrips()
    {
        var expr = new ArrayExpression();
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    [Test]
    public void MRW_BicepExpression_InstanceFunctionCall_RoundTrips()
    {
        var expr = new InstanceFunctionCallExpression(
            new IdentifierExpression("storageAccount"),
            "listKeys",
            new StringLiteralExpression("2024-01-01"));
        SerializationTestHelpers.AssertExpressionRoundTrip(expr);
    }

    #endregion

    #region BicepStatement MRW Tests

    [Test]
    public void MRW_BicepStatement_WriteJson_ResourceStatement()
    {
        BicepExpression body = new ObjectExpression(
            new PropertyExpression("name", new StringLiteralExpression("myStorage")),
            new PropertyExpression("kind", new StringLiteralExpression("StorageV2")));
        ResourceStatement stmt = new("storage", new StringLiteralExpression("Microsoft.Storage/storageAccounts@2024-01-01"), body);

        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"bicepIdentifier\""), $"Missing bicepIdentifier. Got: {jsonStr}");
        Assert.IsTrue(jsonStr.Contains("\"type\""), $"Missing type. Got: {jsonStr}");
        Assert.IsTrue(jsonStr.Contains("\"apiVersion\""), $"Missing apiVersion. Got: {jsonStr}");
    }

    [Test]
    public void MRW_BicepStatement_WriteBicep_ProducesExpectedOutput()
    {
        ParameterStatement stmt = new("location", new TypeExpression(typeof(string)), null);

        BinaryData bicep = ModelReaderWriter.Write<BicepStatement>(stmt, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        string bicepStr = bicep.ToString();
        Assert.IsTrue(bicepStr.Contains("param location string"), $"Expected param declaration. Got: {bicepStr}");
    }

    [Test]
    public void MRW_BicepStatement_Read_ThrowsNotSupported()
    {
        ParameterStatement stmt = new("p", new TypeExpression(typeof(string)), null);
        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);

        Assert.Throws<NotSupportedException>(() =>
            ModelReaderWriter.Read<BicepStatement>(json, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default));
    }

    [Test]
    public void MRW_BicepStatement_OutputStatement_WriteJson()
    {
        OutputStatement stmt = new("endpoint", new TypeExpression(typeof(string)),
            new MemberExpression(new IdentifierExpression("storage"), "name"));

        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"bicepIdentifier\""), $"Missing bicepIdentifier. Got: {jsonStr}");
        Assert.IsTrue(jsonStr.Contains("\"valueType\""), $"Missing valueType. Got: {jsonStr}");
    }

    [Test]
    public void MRW_BicepStatement_ParameterStatement_WithDefault()
    {
        ParameterStatement stmt = new("location", new TypeExpression(typeof(string)),
            new MemberExpression(
                new FunctionCallExpression(new IdentifierExpression("resourceGroup")),
                "location"));

        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"defaultValue\""), $"Missing defaultValue. Got: {jsonStr}");

        BinaryData bicep = ModelReaderWriter.Write<BicepStatement>(stmt, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.IsTrue(bicep.ToString().Contains("param location string = resourceGroup().location"),
            $"Expected bicep with default. Got: {bicep}");
    }

    [Test]
    public void MRW_BicepStatement_VariableStatement_WriteJson()
    {
        VariableStatement stmt = new("myVar", new StringLiteralExpression("hello"));

        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"bicepIdentifier\""), $"Missing bicepIdentifier. Got: {jsonStr}");
        Assert.IsTrue(jsonStr.Contains("\"myVar\""), $"Missing variable name. Got: {jsonStr}");

        BinaryData bicep = ModelReaderWriter.Write<BicepStatement>(stmt, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.IsTrue(bicep.ToString().Contains("var myVar = 'hello'"), $"Expected var declaration. Got: {bicep}");
    }

    [Test]
    public void MRW_BicepStatement_CommentStatement_WriteBicep()
    {
        CommentStatement stmt = new("This is a comment");

        BinaryData bicep = ModelReaderWriter.Write<BicepStatement>(stmt, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.IsTrue(bicep.ToString().Contains("// This is a comment"), $"Expected comment. Got: {bicep}");
    }

    [Test]
    public void MRW_BicepStatement_ExpressionStatement_WriteBicep()
    {
        ExpressionStatement stmt = new(new IdentifierExpression("myResource"));

        BinaryData bicep = ModelReaderWriter.Write<BicepStatement>(stmt, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default);
        Assert.AreEqual("myResource", bicep.ToString());
    }

    [Test]
    public void MRW_BicepStatement_ModuleStatement_WriteJson()
    {
        BicepExpression body = new ObjectExpression(
            new PropertyExpression("name", new StringLiteralExpression("myModule")),
            new PropertyExpression("scope", new IdentifierExpression("resourceGroup")));
        ModuleStatement stmt = new("storageModule", new StringLiteralExpression("./storage.bicep"), body);

        BinaryData json = ModelReaderWriter.Write<BicepStatement>(stmt, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        string jsonStr = json.ToString();
        Assert.IsTrue(jsonStr.Contains("\"bicepIdentifier\""), $"Missing bicepIdentifier. Got: {jsonStr}");
        Assert.IsTrue(jsonStr.Contains("\"path\""), $"Missing path. Got: {jsonStr}");
    }

    #endregion
}
