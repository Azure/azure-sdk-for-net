// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.ReadmeSnippets;

internal class BicepValueTypesSnippets
{
    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void BicepValueTypes_ThreeKindsOfBicepValue()
    {
        StorageAccount storageAccount = new(nameof(storageAccount));
        #region Snippet:ThreeKindsOfBicepValue
        BicepValue<string> literalName = "my-storage-account";

        // Expression value
        BicepValue<string> expressionName = BicepFunction.CreateGuid();

        // Unset value (can be assigned later)
        BicepValue<string> unsetName = storageAccount.Name;
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void BicepValueTypes_BicepListUsages()
    {
        #region Snippet:BicepListUsages
        // Literal list
        BicepList<string> tagNames = new() { "Environment", "Project", "Owner" };

        // Modifying items
        tagNames.Add("CostCenter"); // add an item
        tagNames.Remove("Owner"); // remove an item
        tagNames[0] = "Env"; // modify an item
        tagNames.Clear(); // clear all items

        // Expression list (referencing a parameter)
        ProvisioningParameter parameter = new(nameof(parameter), typeof(string[]));
        BicepList<string> dynamicTags = parameter;
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void BicepValueTypes_BicepDictionaryUsages()
    {
        #region Snippet:BicepDictionaryUsages
        // Literal dictionary
        BicepDictionary<string> tags = new()
        {
            ["Environment"] = "Production",
            ["Project"] = "WebApp",
            ["Owner"] = "DevTeam"
        };

        // Accessing values
        tags["CostCenter"] = "12345";

        // Expression dictionary
        ProvisioningParameter parameter = new(nameof(parameter), typeof(object));
        BicepDictionary<string> dynamicTags = parameter;
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void BicepValueTypes_WorkingWithAzureResources()
    {
        #region Snippet:WorkingWithAzureResources
        // Define parameters for dynamic configuration
        ProvisioningParameter location = new(nameof(location), typeof(string));
        ProvisioningParameter environment = new(nameof(environment), typeof(string));
        // Create a storage account with BicepValue properties
        StorageAccount myStorage = new(nameof(myStorage), StorageAccount.ResourceVersions.V2023_01_01)
        {
            // Set literal values
            Name = "mystorageaccount",
            Kind = StorageKind.StorageV2,

            // Use BicepValue for dynamic configuration
            Location = location, // Reference a parameter

            // Configure nested properties
            Sku = new StorageSku
            {
                Name = StorageSkuName.StandardLrs
            },

            // Use BicepList for collections
            Tags = new BicepDictionary<string>
            {
                ["Environment"] = "Production",
                ["Project"] = environment // Mix literal and dynamic values
            }
        };

        // Access output properties and use them in output (these are BicepValue<T> that reference the deployed resource)
        ProvisioningOutput storageAccountId = new(nameof(storageAccountId), typeof(string))
        {
            Value = myStorage.Id
        };
        ProvisioningOutput primaryBlobEndpoint = new(nameof(primaryBlobEndpoint), typeof(string))
        {
            Value = myStorage.PrimaryEndpoints.BlobUri
        };
        #endregion
    }
}
