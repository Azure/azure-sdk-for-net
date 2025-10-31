// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.ReadmeSnippets;

internal class ToBicepExpressionMethodSnippets
{
    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ToBicepExpression_CommonUseCases()
    {
        #region Snippet:CommonUseCases
        // Create a storage account
        StorageAccount storage = new(nameof(storage), StorageAccount.ResourceVersions.V2023_01_01)
        {
            Name = "mystorageaccount",
            Kind = StorageKind.StorageV2
        };

        // Reference the storage account name in a connection string
        BicepValue<string> connectionString = BicepFunction.Interpolate(
            $"AccountName={storage.Name.ToBicepExpression()};EndpointSuffix=core.windows.net"
        );
        // this would produce: 'AccountName=${storage.name};EndpointSuffix=core.windows.net'
        // If we do not call ToBicepExpression()
        BicepValue<string> nonExpressionConnectionString =
            BicepFunction.Interpolate(
                $"AccountName={storage.Name};EndpointSuffix=core.windows.net"
            );
        // this would produce: 'AccountName=mystorageaccount;EndpointSuffix=core.windows.net'
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ToBicepExpression_NamedProvisionableConstructRequirement()
    {
        #region Snippet:NamedProvisionableConstructRequirement
        // ✅ Works - calling from a property of StorageAccount which inherits from ProvisionableResource
        StorageAccount storage = new("myStorage");
        var nameRef = storage.Name.ToBicepExpression(); // Works

        // ✅ Works - calling from a ProvisioningParameter
        ProvisioningParameter param = new("myParam", typeof(string));
        var paramRef = param.ToBicepExpression(); // Works

        // ❌ Throws exception - StorageSku is just a ProvisionableConstruct (not a NamedProvisionableConstruct)
        StorageSku sku = new() { Name = StorageSkuName.StandardLrs };
        // var badRef = sku.Name.ToBicepExpression(); // Throws exception
        // ✅ Works - if you assign it to another NamedProvisionableConstruct first
        storage.Sku = sku;
        var goodRef = storage.Sku.Name.ToBicepExpression(); // Works
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ToBicepExpression_InstanceSharingCorrect()
    {
        #region Snippet:InstanceSharingCorrect
        // ✅ GOOD: Create separate instances with the same values
        StorageAccount storage1 = new("storage1")
        {
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
        };
        StorageAccount storage2 = new("storage2")
        {
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
        };

        // Each has its own StorageSku instance
        // Bicep expressions work correctly and unambiguously:
        var sku1Ref = storage1.Sku.Name.ToBicepExpression(); // "${storage1.sku.name}"
        var sku2Ref = storage2.Sku.Name.ToBicepExpression(); // "${storage2.sku.name}"
        #endregion
    }

    [Test]
    [Ignore("Ignore this since this is a snippet instead of a test")]
    public void ToBicepExpression_InstanceSharingProblem()
    {
        #region Snippet:InstanceSharingProblem
        // ❌ BAD: Sharing the same StorageSku instance
        StorageSku sharedSku = new() { Name = StorageSkuName.StandardLrs };

        StorageAccount storage1 = new("storage1") { Sku = sharedSku };
        StorageAccount storage2 = new("storage2") { Sku = sharedSku };

        // Now both storage accounts reference the SAME StorageSku object
        // This creates ambiguity when building Bicep expressions:

        // ❌ PROBLEM: Which storage account should this reference?
        // storage1.sku.name or storage2.sku.name?
        var skuNameRef = sharedSku.Name.ToBicepExpression(); // Confusing and unpredictable!

        // The system can't determine whether this should generate:
        // - "${storage1.sku.name}"
        // - "${storage2.sku.name}"
        // This leads to incorrect or unpredictable Bicep output.
        #endregion
    }
}
