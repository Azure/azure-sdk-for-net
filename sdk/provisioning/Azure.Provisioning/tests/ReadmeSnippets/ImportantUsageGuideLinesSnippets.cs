// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.ReadmeSnippets;

internal class ImportantUsageGuideLinesSnippets
{
    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ImportantUsageGuidelines_CreateSeparateInstances()
    {
        #region Snippet:CreateSeparateInstances
        // ✅ Create separate instances
        StorageAccount storage1 = new(nameof(storage1))
        {
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
        };
        StorageAccount storage2 = new(nameof(storage2))
        {
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
        };
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ImportantUsageGuidelines_ReuseInstances()
    {
        #region Snippet:ReuseInstances
        // ❌ DO NOT reuse the same instance
        StorageSku sharedSku = new() { Name = StorageSkuName.StandardLrs };
        StorageAccount storage1 = new(nameof(storage1)) { Sku = sharedSku }; // ❌ Bad
        StorageAccount storage2 = new(nameof(storage2)) { Sku = sharedSku }; // ❌ Bad
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ImportantUsageGuidelines_SafeCollectionAccess()
    {
        #region Snippet:SafeCollectionAccess
        // ✅ Accessing output properties safely - very common scenario
        Infrastructure infra = new();
        CognitiveServicesAccount aiServices = new("aiServices");
        infra.Add(aiServices);

        // Safe to access dictionary keys that exist in the deployed resource
        // but not at design time - no KeyNotFoundException thrown
        BicepValue<string> apiEndpoint = aiServices.Properties.Endpoints["Azure AI Model Inference API"];

        // Works perfectly for building references in outputs
        infra.Add(new ProvisioningOutput("connectionString", typeof(string))
        {
            Value = BicepFunction.Interpolate($"Endpoint={apiEndpoint.ToBicepExpression()}")
        });
        // Generates: output connectionString string = 'Endpoint=${aiServices.properties.endpoints['Azure AI Model Inference API']}'

        // ⚠️ Note: Accessing .Value will still throw at runtime if the data doesn't exist
        // var actualValue = apiEndpoint.Value; // Would throw KeyNotFoundException at runtime
        #endregion
    }
}
