// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions.BicepFunctionTests;

public class ResourceIdFunctionsTests
{
    [Test]
    public void TestGetResourceId()
    {
        var id1 = BicepFunction.GetResourceId("00000000-0000-0000-0000-000000000000", "myResourceGroup", "Microsoft.Storage/storageAccounts", "myStorageAccount");
        TestHelpers.AssertExpression("resourceId('00000000-0000-0000-0000-000000000000', 'myResourceGroup', 'Microsoft.Storage/storageAccounts', 'myStorageAccount')", id1);

        var id2 = BicepFunction.GetResourceId("Microsoft.Network/virtualNetworks/subnets", "myVnet", "mySubnet");
        TestHelpers.AssertExpression("resourceId('Microsoft.Network/virtualNetworks/subnets', 'myVnet', 'mySubnet')", id2);
    }

    [Test]
    public void TestGetSubscriptionResourceId()
    {
        var id1 = BicepFunction.GetSubscriptionResourceId("Microsoft.Storage/storageAccounts", "myStorageAccount");
        TestHelpers.AssertExpression("subscriptionResourceId('Microsoft.Storage/storageAccounts', 'myStorageAccount')", id1);

        var id2 = BicepFunction.GetSubscriptionResourceId("00000000-0000-0000-0000-000000000000", "Microsoft.Resources/resourceGroups", "myResourceGroup");
        TestHelpers.AssertExpression("subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Resources/resourceGroups', 'myResourceGroup')", id2);
    }

    [Test]
    public void TestGetExtensionResourceId()
    {
        var scope = BicepFunction.GetResourceId("Microsoft.Compute/virtualMachines", "myVm");
        var id1 = BicepFunction.GetExtensionResourceId(scope, "Microsoft.GuestConfigurations/configurations", "myConfiguration");
        TestHelpers.AssertExpression("extensionResourceId(resourceId('Microsoft.Compute/virtualMachines', 'myVm'), 'Microsoft.GuestConfigurations/configurations', 'myConfiguration')", id1);

        var storageAccount = new StorageAccount("account");
        var id2 = BicepFunction.GetExtensionResourceId(storageAccount.Id, "Microsoft.Authorization/policyDefinitions", "myDef");
        TestHelpers.AssertExpression("extensionResourceId(account.id, 'Microsoft.Authorization/policyDefinitions', 'myDef')", id2);
    }
}
