// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Serialization;

/// <summary>
/// Tests that validate serialized JSON conforms to the TypeSpec schema spec.
/// </summary>
public class SchemaComplianceTests
{
    [OneTimeSetUp]
    public void CheckSchemaIsUpToDate() => SchemaOracle.WarnIfStale();

    [Test]
    public void VerifyJsonMatchesPastedSchema()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storageAccount", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardGrs },
            IsHnsEnabled = true,
            Tags = { ["env-name"] = "demo", ["workload"] = "samples" },
        };
        infra.Add(storage);

        BlobService blobService = new("blobService", BlobService.ResourceVersions.V2024_01_01)
        {
            Parent = storage,
        };
        infra.Add(blobService);

        ProvisioningOutput storageAccountName = new("storageAccountName", typeof(object))
        {
            Value = storage.Name,
        };
        infra.Add(storageAccountName);

        string json = SerializationTestHelpers.SerializeToJson(infra);
        TestContext.Out.WriteLine(json);

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // === Top-level: { "infras": [...] } ===
        Assert.IsTrue(root.TryGetProperty("infras", out JsonElement infras));
        Assert.AreEqual(JsonValueKind.Array, infras.ValueKind);

        JsonElement file = infras[0];

        // === File-level: fileName, targetScope ===
        Assert.AreEqual("main.bicep", file.GetProperty("fileName").GetString());
        Assert.IsFalse(file.TryGetProperty("targetScope", out _), "targetScope should be omitted for resourceGroup (default)");

        // === Resources: keyed by bicepIdentifier ===
        JsonElement resources = file.GetProperty("resources");
        Assert.IsTrue(resources.TryGetProperty("storageAccount", out JsonElement storageRes));

        Assert.AreEqual("storageAccount", storageRes.GetProperty("bicepIdentifier").GetString());
        Assert.AreEqual("Microsoft.Storage/storageAccounts", storageRes.GetProperty("type").GetString());
        Assert.AreEqual("2024-01-01", storageRes.GetProperty("apiVersion").GetString());
        Assert.AreEqual(false, storageRes.GetProperty("existing").GetBoolean());

        // === Value uses kind/value pattern ===
        JsonElement body = storageRes.GetProperty("value");
        Assert.AreEqual("object", body.GetProperty("kind").GetString());

        JsonElement bodyValue = body.GetProperty("value");

        // String literal: kind=string, value=string
        JsonElement kindProp = bodyValue.GetProperty("kind");
        Assert.AreEqual("string", kindProp.GetProperty("kind").GetString());
        Assert.AreEqual("StorageV2", kindProp.GetProperty("value").GetString());

        // Nested object: sku.name
        JsonElement sku = bodyValue.GetProperty("sku");
        Assert.AreEqual("object", sku.GetProperty("kind").GetString());
        JsonElement skuName = sku.GetProperty("value").GetProperty("name");
        Assert.AreEqual("string", skuName.GetProperty("kind").GetString());
        Assert.AreEqual("Standard_GRS", skuName.GetProperty("value").GetString());

        // Boolean: isHnsEnabled
        JsonElement props = bodyValue.GetProperty("properties");
        Assert.AreEqual("object", props.GetProperty("kind").GetString());
        JsonElement hns = props.GetProperty("value").GetProperty("isHnsEnabled");
        Assert.AreEqual("boolean", hns.GetProperty("kind").GetString());
        Assert.AreEqual(true, hns.GetProperty("value").GetBoolean());

        // Tags object with string values
        JsonElement tags = bodyValue.GetProperty("tags");
        Assert.AreEqual("object", tags.GetProperty("kind").GetString());
        JsonElement envTag = tags.GetProperty("value").GetProperty("env-name");
        Assert.AreEqual("string", envTag.GetProperty("kind").GetString());
        Assert.AreEqual("demo", envTag.GetProperty("value").GetString());

        // === Child resource with parent (identifier kind) ===
        Assert.IsTrue(resources.TryGetProperty("blobService", out JsonElement blobRes));
        JsonElement blobBody = blobRes.GetProperty("value").GetProperty("value");
        JsonElement parentRef = blobBody.GetProperty("parent");
        Assert.AreEqual("identifier", parentRef.GetProperty("kind").GetString());
        Assert.AreEqual("storageAccount", parentRef.GetProperty("id").GetString());

        // === Outputs: { bicepIdentifier, valueType, value } ===
        Assert.IsTrue(file.TryGetProperty("outputs", out JsonElement outputs));
        Assert.IsTrue(outputs.TryGetProperty("storageAccountName", out JsonElement output));
        Assert.AreEqual("storageAccountName", output.GetProperty("bicepIdentifier").GetString());

        // valueType should be primitive-type
        JsonElement valueType = output.GetProperty("valueType");
        Assert.AreEqual("primitive-type", valueType.GetProperty("kind").GetString());

        // value should be property-access (storageAccount.name)
        JsonElement outputValue = output.GetProperty("value");
        Assert.AreEqual("property-access", outputValue.GetProperty("kind").GetString());
        Assert.AreEqual("name", outputValue.GetProperty("property").GetString());
        Assert.AreEqual(false, outputValue.GetProperty("nullish").GetBoolean());

        // base should be identifier
        JsonElement outputBase = outputValue.GetProperty("base");
        Assert.AreEqual("identifier", outputBase.GetProperty("kind").GetString());
        Assert.AreEqual("storageAccount", outputBase.GetProperty("id").GetString());

        // === Parameters (auto-generated location param) ===
        if (file.TryGetProperty("parameters", out JsonElement parameters))
        {
            foreach (JsonProperty param in parameters.EnumerateObject())
            {
                JsonElement p = param.Value;
                Assert.IsTrue(p.TryGetProperty("bicepIdentifier", out _), $"Parameter {param.Name} missing bicepIdentifier");
                Assert.IsTrue(p.TryGetProperty("valueType", out JsonElement pType), $"Parameter {param.Name} missing valueType");
                Assert.AreEqual("primitive-type", pType.GetProperty("kind").GetString());
            }
        }

        // === Verify function-call and contextual-variable kinds work with resolvers ===
        Infrastructure infraWithResolvers = new();
        StorageAccount storageWithName = new("sa", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infraWithResolvers.Add(storageWithName);
        infraWithResolvers.Build();
        string jsonWithResolvers = SerializationTestHelpers.SerializeToJson(infraWithResolvers);
        Assert.IsTrue(jsonWithResolvers.Contains("\"kind\": \"function-call\""),
            $"Expected function-call kind in resolved JSON.\n{jsonWithResolvers}");
        Assert.IsTrue(jsonWithResolvers.Contains("\"kind\": \"contextual-variable\""),
            $"Expected contextual-variable kind in resolved JSON.\n{jsonWithResolvers}");
        Assert.IsTrue(jsonWithResolvers.Contains("\"kind\": \"integer\""),
            $"Expected integer kind in resolved JSON.\n{jsonWithResolvers}");
    }

    [Test]
    public void SchemaCompliance_ArrayValue_UsesItemsProperty()
    {
        var expr = new ArrayExpression(new StringLiteralExpression("a"), new IntLiteralExpression(1));
        var json = ModelReaderWriter.Write<BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        Assert.AreEqual("array", root.GetProperty("kind").GetString());
        Assert.IsTrue(root.TryGetProperty("items", out _), "ArrayValue should use 'items' per schema spec");
        Assert.IsFalse(root.TryGetProperty("value", out _), "ArrayValue should NOT use 'value'");
    }

    [Test]
    public void SchemaCompliance_NullValue_HasValueNull()
    {
        var expr = new NullLiteralExpression();
        var json = ModelReaderWriter.Write<BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        Assert.AreEqual("null", root.GetProperty("kind").GetString());
        Assert.IsTrue(root.TryGetProperty("value", out JsonElement val), "NullValue must have 'value' property per schema spec");
        Assert.AreEqual(JsonValueKind.Null, val.ValueKind);
    }

    [Test]
    public void SchemaCompliance_TargetScope_OmittedForResourceGroup()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("s", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);
        string json = SerializationTestHelpers.SerializeToJson(infra);
        using var doc = JsonDocument.Parse(json);
        var file = doc.RootElement.GetProperty("infras")[0];
        Assert.IsFalse(file.TryGetProperty("targetScope", out _), "targetScope should be omitted for resourceGroup (default)");
    }

    [Test]
    public void SchemaCompliance_TargetScope_PresentForSubscription()
    {
        Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };
        string json = SerializationTestHelpers.SerializeToJson(infra);
        using var doc = JsonDocument.Parse(json);
        var file = doc.RootElement.GetProperty("infras")[0];
        Assert.AreEqual("subscription", file.GetProperty("targetScope").GetString());
    }

    [Test]
    public void SchemaCompliance_DecoratorsNode_IsStructuredObject()
    {
        Infrastructure infra = new();
        var param = new ProvisioningParameter("myParam", typeof(string))
        {
            IsSecure = true,
            Description = "A secret param",
        };
        infra.Add(param);
        string json = SerializationTestHelpers.SerializeToJson(infra);
        using var doc = JsonDocument.Parse(json);
        var file = doc.RootElement.GetProperty("infras")[0];
        var paramNode = file.GetProperty("parameters").GetProperty("myParam");
        if (paramNode.TryGetProperty("decorators", out JsonElement decs))
        {
            Assert.AreEqual(JsonValueKind.Object, decs.ValueKind, "Decorators should be an object, not an array");
            if (decs.TryGetProperty("secure", out JsonElement secure))
                Assert.AreEqual(JsonValueKind.True, secure.ValueKind);
            if (decs.TryGetProperty("description", out JsonElement desc))
                Assert.AreEqual("A secret param", desc.GetString());
        }
    }

    [Test]
    public void SchemaCompliance_ExpressionNode_ValidKinds()
    {
        var validKinds = new HashSet<string>
        {
            "null", "boolean", "integer", "string", "array", "object",
            "identifier", "function-call", "instance-function-call",
            "property-access", "array-access", "contextual-variable"
        };

        var expressions = new BicepExpression[]
        {
            new NullLiteralExpression(),
            new BoolLiteralExpression(true),
            new IntLiteralExpression(42),
            new StringLiteralExpression("hello"),
            new ArrayExpression(new StringLiteralExpression("a")),
            new ObjectExpression(new PropertyExpression("key", new StringLiteralExpression("val"))),
            new IdentifierExpression("myVar"),
            new FunctionCallExpression(new IdentifierExpression("toLower"), new StringLiteralExpression("ABC")),
            new MemberExpression(new IdentifierExpression("x"), "y"),
            new IndexExpression(new IdentifierExpression("arr"), new IntLiteralExpression(0)),
        };

        foreach (var expr in expressions)
        {
            var json = ModelReaderWriter.Write<BicepExpression>(expr, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default);
            using var doc = JsonDocument.Parse(json);
            string kind = doc.RootElement.GetProperty("kind").GetString()!;
            Assert.IsTrue(validKinds.Contains(kind), $"Expression kind '{kind}' is not in the schema spec ExpressionNode union");
        }
    }

    #region Schema Validation Helpers

    private static HashSet<string> ValidExpressionKinds => SchemaOracle.AllValidExpressionKinds;
    private static HashSet<string> ValidTypeKinds => SchemaOracle.TypeKinds.Value;
    private static HashSet<string> ValidTargetScopes => SchemaOracle.TargetScopes.Value;

    /// <summary>
    /// Validates a serialized JSON document against the TypeSpec schema spec.
    /// Called by round-trip tests to ensure every serialized document is schema-compliant.
    /// </summary>
    internal static void AssertSchemaCompliance(string json)
    {
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        Assert.IsTrue(root.TryGetProperty("infras", out JsonElement files), "Missing 'infras'");
        Assert.AreEqual(JsonValueKind.Array, files.ValueKind);

        foreach (JsonElement file in files.EnumerateArray())
        {
            AssertBicepFileNode(file);
        }
    }

    private static void AssertBicepFileNode(JsonElement file)
    {
        Assert.IsTrue(file.TryGetProperty("fileName", out _), "BicepFileNode missing 'fileName'");

        if (file.TryGetProperty("targetScope", out JsonElement scope))
        {
            Assert.IsTrue(ValidTargetScopes.Contains(scope.GetString()!),
                $"Invalid targetScope: {scope.GetString()}");
        }

        if (file.TryGetProperty("resources", out JsonElement resources))
        {
            Assert.AreEqual(JsonValueKind.Object, resources.ValueKind);
            foreach (JsonProperty prop in resources.EnumerateObject())
                AssertResourceDeclarationNode(prop.Value, prop.Name);
        }

        if (file.TryGetProperty("modules", out JsonElement modules))
        {
            Assert.AreEqual(JsonValueKind.Object, modules.ValueKind);
            foreach (JsonProperty prop in modules.EnumerateObject())
                AssertModuleDeclarationNode(prop.Value, prop.Name);
        }

        if (file.TryGetProperty("outputs", out JsonElement outputs))
        {
            Assert.AreEqual(JsonValueKind.Object, outputs.ValueKind);
            foreach (JsonProperty prop in outputs.EnumerateObject())
                AssertOutputDeclarationNode(prop.Value, prop.Name);
        }

        if (file.TryGetProperty("parameters", out JsonElement parameters))
        {
            Assert.AreEqual(JsonValueKind.Object, parameters.ValueKind);
            foreach (JsonProperty prop in parameters.EnumerateObject())
                AssertParameterDeclarationNode(prop.Value, prop.Name);
        }

        if (file.TryGetProperty("variables", out JsonElement variables))
        {
            Assert.AreEqual(JsonValueKind.Object, variables.ValueKind);
            foreach (JsonProperty prop in variables.EnumerateObject())
                AssertVariableDeclarationNode(prop.Value, prop.Name);
        }
    }

    private static void AssertResourceDeclarationNode(JsonElement node, string key)
    {
        Assert.AreEqual(key, node.GetProperty("bicepIdentifier").GetString(), $"Resource key '{key}' mismatch with bicepIdentifier");
        Assert.IsTrue(node.TryGetProperty("type", out _), $"Resource '{key}' missing 'type'");
        Assert.IsTrue(node.TryGetProperty("apiVersion", out _), $"Resource '{key}' missing 'apiVersion'");
        Assert.IsTrue(node.TryGetProperty("existing", out _), $"Resource '{key}' missing 'existing'");
        Assert.IsTrue(node.TryGetProperty("value", out JsonElement value), $"Resource '{key}' missing 'value'");
        Assert.AreEqual("object", value.GetProperty("kind").GetString(), $"Resource '{key}' value must be ObjectValue");
        AssertExpressionNode(value, $"resource '{key}'.value");
        if (node.TryGetProperty("decorators", out JsonElement decs))
            AssertDecoratorsNode(decs, $"resource '{key}'");
    }

    private static void AssertModuleDeclarationNode(JsonElement node, string key)
    {
        Assert.AreEqual(key, node.GetProperty("bicepIdentifier").GetString(), $"Module key '{key}' mismatch");
        Assert.IsTrue(node.TryGetProperty("path", out _), $"Module '{key}' missing 'path'");
        Assert.IsTrue(node.TryGetProperty("value", out JsonElement value), $"Module '{key}' missing 'value'");
        Assert.AreEqual("object", value.GetProperty("kind").GetString(), $"Module '{key}' value must be ObjectValue");
        AssertExpressionNode(value, $"module '{key}'.value");
        if (node.TryGetProperty("decorators", out JsonElement decs))
            AssertDecoratorsNode(decs, $"module '{key}'");
    }

    private static void AssertOutputDeclarationNode(JsonElement node, string key)
    {
        Assert.AreEqual(key, node.GetProperty("bicepIdentifier").GetString(), $"Output key '{key}' mismatch");
        Assert.IsTrue(node.TryGetProperty("valueType", out JsonElement vt), $"Output '{key}' missing 'valueType'");
        AssertTypeNode(vt, $"output '{key}'.valueType");
        Assert.IsTrue(node.TryGetProperty("value", out JsonElement value), $"Output '{key}' missing 'value'");
        AssertExpressionNode(value, $"output '{key}'.value");
        if (node.TryGetProperty("decorators", out JsonElement decs))
            AssertDecoratorsNode(decs, $"output '{key}'");
    }

    private static void AssertParameterDeclarationNode(JsonElement node, string key)
    {
        Assert.AreEqual(key, node.GetProperty("bicepIdentifier").GetString(), $"Parameter key '{key}' mismatch");
        Assert.IsTrue(node.TryGetProperty("valueType", out JsonElement vt), $"Parameter '{key}' missing 'valueType'");
        AssertTypeNode(vt, $"parameter '{key}'.valueType");
        if (node.TryGetProperty("defaultValue", out JsonElement dv))
            AssertExpressionNode(dv, $"parameter '{key}'.defaultValue");
        if (node.TryGetProperty("decorators", out JsonElement decs))
            AssertDecoratorsNode(decs, $"parameter '{key}'");
    }

    private static void AssertVariableDeclarationNode(JsonElement node, string key)
    {
        Assert.AreEqual(key, node.GetProperty("bicepIdentifier").GetString(), $"Variable key '{key}' mismatch");
        Assert.IsTrue(node.TryGetProperty("value", out JsonElement value), $"Variable '{key}' missing 'value'");
        AssertExpressionNode(value, $"variable '{key}'.value");
        if (node.TryGetProperty("decorators", out JsonElement decs))
            AssertDecoratorsNode(decs, $"variable '{key}'");
    }

    private static void AssertExpressionNode(JsonElement node, string path)
    {
        string kind = node.GetProperty("kind").GetString()!;
        Assert.IsTrue(ValidExpressionKinds.Contains(kind),
            $"Invalid expression kind '{kind}' at {path}. Valid: {string.Join(", ", ValidExpressionKinds)}");

        switch (kind)
        {
            case "null":
                Assert.IsTrue(node.TryGetProperty("value", out JsonElement nv) && nv.ValueKind == JsonValueKind.Null,
                    $"NullValue at {path} must have 'value': null");
                break;
            case "boolean":
                Assert.IsTrue(node.TryGetProperty("value", out _), $"BooleanValue at {path} missing 'value'");
                break;
            case "integer":
                Assert.IsTrue(node.TryGetProperty("value", out JsonElement iv) && iv.ValueKind == JsonValueKind.String,
                    $"IntegerValue at {path} must have string 'value'");
                break;
            case "string":
                Assert.IsTrue(node.TryGetProperty("value", out _), $"StringValue at {path} missing 'value'");
                break;
            case "array":
                Assert.IsTrue(node.TryGetProperty("items", out JsonElement items),
                    $"ArrayValue at {path} must use 'items' not 'value'");
                foreach (JsonElement item in items.EnumerateArray())
                    AssertExpressionNode(item, $"{path}.items[]");
                break;
            case "object":
                Assert.IsTrue(node.TryGetProperty("value", out JsonElement obj), $"ObjectValue at {path} missing 'value'");
                foreach (JsonProperty prop in obj.EnumerateObject())
                    AssertExpressionNode(prop.Value, $"{path}.value.{prop.Name}");
                break;
            case "identifier":
                Assert.IsTrue(node.TryGetProperty("id", out _), $"Identifier at {path} missing 'id'");
                break;
            case "function-call":
                Assert.IsTrue(node.TryGetProperty("target", out _), $"FunctionCall at {path} missing 'target'");
                Assert.IsTrue(node.TryGetProperty("args", out JsonElement args), $"FunctionCall at {path} missing 'args'");
                foreach (JsonElement arg in args.EnumerateArray())
                    AssertExpressionNode(arg, $"{path}.args[]");
                break;
            case "property-access":
                Assert.IsTrue(node.TryGetProperty("base", out JsonElement paBase), $"PropertyAccess at {path} missing 'base'");
                Assert.IsTrue(node.TryGetProperty("property", out _), $"PropertyAccess at {path} missing 'property'");
                Assert.IsTrue(node.TryGetProperty("nullish", out _), $"PropertyAccess at {path} missing 'nullish'");
                AssertExpressionNode(paBase, $"{path}.base");
                break;
            case "array-access":
                Assert.IsTrue(node.TryGetProperty("base", out JsonElement aaBase), $"ArrayAccess at {path} missing 'base'");
                Assert.IsTrue(node.TryGetProperty("index", out JsonElement aaIdx), $"ArrayAccess at {path} missing 'index'");
                Assert.IsTrue(node.TryGetProperty("nullish", out _), $"ArrayAccess at {path} missing 'nullish'");
                Assert.IsTrue(node.TryGetProperty("fromEnd", out _), $"ArrayAccess at {path} missing 'fromEnd'");
                AssertExpressionNode(aaBase, $"{path}.base");
                AssertExpressionNode(aaIdx, $"{path}.index");
                break;
            case "contextual-variable":
                Assert.IsTrue(node.TryGetProperty("context", out _), $"ContextualVariable at {path} missing 'context'");
                Assert.IsTrue(node.TryGetProperty("property", out _), $"ContextualVariable at {path} missing 'property'");
                break;
        }
    }

    private static void AssertTypeNode(JsonElement node, string path)
    {
        string kind = node.GetProperty("kind").GetString()!;
        Assert.IsTrue(ValidTypeKinds.Contains(kind),
            $"Invalid type kind '{kind}' at {path}. Valid: {string.Join(", ", ValidTypeKinds)}");
    }

    private static void AssertDecoratorsNode(JsonElement node, string path)
    {
        Assert.AreEqual(JsonValueKind.Object, node.ValueKind,
            $"DecoratorsNode at {path} must be an object, not {node.ValueKind}");
    }

    #endregion
}
