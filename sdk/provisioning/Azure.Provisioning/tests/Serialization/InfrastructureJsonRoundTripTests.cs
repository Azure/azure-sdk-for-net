// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Serialization;

/// <summary>
/// Round-trip tests for Infrastructure JSON serialization.
/// Each test creates an Infrastructure, serializes to JSON, deserializes back,
/// re-serializes, and asserts JSON equality. Also verifies Bicep equivalence.
/// </summary>
public class InfrastructureJsonRoundTripTests
{
    [OneTimeSetUp]
    public void CheckSchemaIsUpToDate() => SchemaOracle.WarnIfStale();

    [Test]
    public void RoundTrip_SimpleStorageAccount()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_StorageAccountWithNestedObjects()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardGrs },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
            Tags = { ["env"] = "production", ["team"] = "platform" },
        };
        infra.Add(storage);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_StorageWithBlobService()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        BlobService blobs = new("blobs", BlobService.ResourceVersions.V2024_01_01)
        {
            Parent = storage,
        };
        infra.Add(blobs);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_StorageWithBlobServiceAndContainer()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        BlobService blobs = new("blobs", BlobService.ResourceVersions.V2024_01_01)
        {
            Parent = storage,
        };
        infra.Add(blobs);

        BlobContainer container = new("container", BlobContainer.ResourceVersions.V2024_01_01)
        {
            Parent = blobs,
            PublicAccess = StoragePublicAccessType.None,
        };
        infra.Add(container);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_WithOutputs()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
        };
        infra.Add(storage);

        ProvisioningOutput endpoint = new("blobEndpoint", typeof(string))
        {
            Value = storage.PrimaryEndpoints.BlobUri,
        };
        infra.Add(endpoint);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_WithParameters()
    {
        Infrastructure infra = new();

        ProvisioningParameter location = new("location", typeof(string))
        {
            Value = BicepFunction.GetResourceGroup().Location,
        };
        infra.Add(location);

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_FunctionCalls()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_MultipleResources()
    {
        Infrastructure infra = new();
        for (int i = 0; i < 5; i++)
        {
            StorageAccount storage = new($"storage{i}", StorageAccount.ResourceVersions.V2024_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardGrs },
                Tags = { ["index"] = i.ToString() },
            };
            infra.Add(storage);
        }

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_KeyVaultWithSecrets()
    {
        Infrastructure infra = new();

        KeyVaultService vault = new("vault", KeyVaultService.ResourceVersions.V2024_11_01)
        {
            Properties = new KeyVaultProperties
            {
                TenantId = System.Guid.Empty,
                Sku = new KeyVaultSku
                {
                    Family = KeyVaultSkuFamily.A,
                    Name = KeyVaultSkuName.Standard,
                },
                EnabledForTemplateDeployment = true,
            },
        };
        infra.Add(vault);

        KeyVaultSecret secret = new("secret", KeyVaultSecret.ResourceVersions.V2024_11_01)
        {
            Parent = vault,
            Properties = new SecretProperties
            {
                Value = "my-secret-value",
            },
        };
        infra.Add(secret);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void RoundTrip_EmptyInfrastructure()
    {
        Infrastructure infra = new();
        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_WithVariables()
    {
        Infrastructure infra = new();
        ProvisioningVariable variable = new("storageName", typeof(string))
        {
            Value = new StringLiteralExpression("myStorage"),
        };
        infra.Add(variable);

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_WithTargetScope()
    {
        Infrastructure infra = new()
        {
            TargetScope = DeploymentScope.Subscription,
        };

        SerializationTestHelpers.AssertJsonRoundTrip(infra);
    }

    [Test]
    public void RoundTrip_JsonProducesExpectedFormat()
    {
        Infrastructure infra = new();
        StorageAccount storage = new("myStorage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        string json = SerializationTestHelpers.SerializeToJson(infra);
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        Assert.IsTrue(root.TryGetProperty("bicepFiles", out JsonElement files));
        Assert.AreEqual(JsonValueKind.Array, files.ValueKind);
        Assert.IsTrue(files.GetArrayLength() >= 1);

        JsonElement file = files[0];
        Assert.IsTrue(file.TryGetProperty("fileName", out _));
        Assert.IsFalse(file.TryGetProperty("targetScope", out _), "targetScope should be omitted for resourceGroup");
        Assert.IsTrue(file.TryGetProperty("resources", out JsonElement resources));

        Assert.IsTrue(resources.TryGetProperty("myStorage", out JsonElement resource));
        Assert.AreEqual("myStorage", resource.GetProperty("bicepIdentifier").GetString());
        Assert.AreEqual("Microsoft.Storage/storageAccounts", resource.GetProperty("type").GetString());
        Assert.AreEqual("2024-01-01", resource.GetProperty("apiVersion").GetString());
        Assert.AreEqual(false, resource.GetProperty("existing").GetBoolean());

        JsonElement value = resource.GetProperty("value");
        Assert.AreEqual("object", value.GetProperty("kind").GetString());
    }

    [Test]
    public void Deserialized_Resources_Are_Typed()
    {
        // Construct a real typed infrastructure with many properties set
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        // Round-trip through JSON
        string json = SerializationTestHelpers.SerializeToJson(infra);
        Infrastructure deserialized = SerializationTestHelpers.DeserializeFromJson(json);

        // Upgrade to typed
        var roundTripped = deserialized.GetProvisionableResources()
            .OfType<StorageAccount>().Single();

        // Validate identity
        Assert.AreEqual("storage", roundTripped.BicepIdentifier);
        Assert.AreEqual(storage.ResourceType.ToString(), roundTripped.ResourceType.ToString());
        Assert.AreEqual(storage.ResourceVersion, roundTripped.ResourceVersion);

        // Validate property-level equivalence by comparing compiled Bicep
        AssertBicepPropertyEquivalence(storage, roundTripped);

        // After upgrade, standard OfType<T>() also works
        var viaOfType = deserialized.GetProvisionableResources().OfType<StorageAccount>().Single();
        Assert.AreSame(roundTripped, viaOfType);

        // Mutation should work
        roundTripped.Kind = StorageKind.BlobStorage;
        ProvisioningPlan plan = deserialized.Build();
        var bicep = plan.Compile();
        string mainBicep = bicep["main.bicep"];
        Assert.IsTrue(mainBicep.Contains("'BlobStorage'"),
            $"Expected modified Kind in Bicep output.\n{mainBicep}");
    }

    [Test]
    public void Deserialized_Resources_Preserve_All_Properties()
    {
        // Rich infrastructure exercising many property types:
        // scalars, enums, booleans, nested objects, tags dictionary
        Infrastructure infra = new();
        StorageAccount storage = new("richStorage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardGrs },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
            Tags = { ["env"] = "production", ["team"] = "platform", ["cost-center"] = "12345" },
        };
        infra.Add(storage);

        BlobService blobs = new("blobs", BlobService.ResourceVersions.V2024_01_01)
        {
            Parent = storage,
        };
        infra.Add(blobs);

        string json = SerializationTestHelpers.SerializeToJson(infra);
        Infrastructure deserialized = SerializationTestHelpers.DeserializeFromJson(json);

        var roundTripped = deserialized.GetProvisionableResources()
            .OfType<StorageAccount>().Single();

        // Verify every property we set is preservedvia expression-level comparison
        AssertBicepPropertyEquivalence(storage, roundTripped);

        // Also verify end-to-end: the full Infrastructure round-trip produces identical Bicep
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    /// <summary>
    /// Compares two resources by compiling each to Bicep statements independently
    /// and verifying the output matches property by property.
    /// </summary>
    private static void AssertBicepPropertyEquivalence(
        ProvisionableConstruct original,
        ProvisionableConstruct roundTripped)
    {
        foreach (var kvp in original.ProvisionableProperties)
        {
            string name = kvp.Key;
            var originalProp = kvp.Value;
            if (originalProp.IsEmpty || originalProp.IsOutput) continue;

            Assert.IsTrue(roundTripped.ProvisionableProperties.ContainsKey(name),
                $"Round-tripped resource missing property '{name}'");

            var rtProp = roundTripped.ProvisionableProperties[name];

            Assert.IsFalse(rtProp.IsEmpty,
                $"Property '{name}' is empty on round-tripped resource but was set on original");

            string originalExpr = originalProp.Compile().ToString();
            string rtExpr = rtProp.Compile().ToString();
            Assert.AreEqual(originalExpr, rtExpr,
                $"Property '{name}' expression mismatch.\nOriginal: {originalExpr}\nRoundTripped: {rtExpr}");
        }
    }

    [Test]
    public void Deserialized_Resources_ModelSubProperties_AreMutable()
    {
        // Fix #1: Model sub-properties (e.g. Sku.Name) must be mutable after hydration
        Infrastructure infra = new();
        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2024_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        };
        infra.Add(storage);

        string json = SerializationTestHelpers.SerializeToJson(infra);
        Infrastructure deserialized = SerializationTestHelpers.DeserializeFromJson(json);

        var roundTripped = deserialized.GetProvisionableResources()
            .OfType<StorageAccount>().Single();

        // This must not throw— sub-property mutation must work
        Assert.DoesNotThrow(() => roundTripped.Sku.Name = StorageSkuName.StandardGrs,
            "Setting Sku.Name on deserialized resource should not throw (sub-property must not be ReadOnly)");

        // Verify the change compiles correctly
        ProvisioningPlan plan = deserialized.Build();
        var bicep = plan.Compile();
        string mainBicep = bicep["main.bicep"];
        Assert.IsTrue(mainBicep.Contains("'Standard_GRS'"),
            $"Expected modified Sku.Name in Bicep output.\n{mainBicep}");
    }

    [Test]
    public void Deserialized_Resources_ExistingFlag_IsPreserved()
    {
        // Fix #3: IsExistingResource must transfer from the wrapper
        Infrastructure infra = new();
        StorageAccount storage = StorageAccount.FromExisting("existingStorage", StorageAccount.ResourceVersions.V2024_01_01);
        storage.Name = "myExistingStorage";
        infra.Add(storage);

        string json = SerializationTestHelpers.SerializeToJson(infra);
        Assert.IsTrue(json.Contains("\"existing\": true"), $"JSON should contain existing flag.\n{json}");

        Infrastructure deserialized = SerializationTestHelpers.DeserializeFromJson(json);
        var roundTripped = deserialized.GetProvisionableResources()
            .OfType<StorageAccount>().Single();

        Assert.IsTrue(roundTripped.IsExistingResource,
            "IsExistingResource should be true after deserialization");

        // Verify Bicep has 'existing' keyword
        ProvisioningPlan plan = deserialized.Build();
        var bicep = plan.Compile();
        string mainBicep = bicep["main.bicep"];
        Assert.IsTrue(mainBicep.Contains("existing"),
            $"Expected 'existing' keyword in Bicep output.\n{mainBicep}");
    }
}
