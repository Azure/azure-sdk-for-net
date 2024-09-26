// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Deployment.Tests;

internal class ExtensionTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    public void LintClean()
    {
        if (SkipTools) { return; }

        StorageAccount resource = StorageResources.CreateAccount("storage");

        // Lint
        ProvisioningPlan plan = resource.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();
        Assert.AreEqual(0, messages.Count);
    }

    [Test]
    public void LintWarn()
    {
        if (SkipTools) { return; }

        BicepParameter param = new("endpoint", typeof(string));

        // Lint
        ProvisioningPlan plan = param.ParentInfrastructure!.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();

        // Make sure it warns about the unused param
        Assert.AreEqual(1, messages.Count);
        Assert.IsFalse(messages[0].IsError);
        Assert.AreEqual("no-unused-params", messages[0].Code);
        StringAssert.Contains("endpoint", messages[0].Message);
    }

    [Test]
    public void LintError()
    {
        if (SkipTools) { return; }

        // Use a string as the default value for a param typed int
        BicepParameter param = new("bar", typeof(int)) { Value = "Hello, World." };

        ProvisioningPlan plan = param.ParentInfrastructure!.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();

        // Ignore the "unused param" first warning and make sure we get a type error
        Assert.AreEqual(2, messages.Count);
        Assert.IsTrue(messages[1].IsError);
        Assert.AreEqual("BCP033", messages[1].Code);
        StringAssert.Contains("int", messages[1].Message);
    }

    [Test]
    public void GetArmTemplate()
    {
        if (SkipTools) { return; }

        StorageAccount resource = StorageResources.CreateAccount("storage");

        ProvisioningPlan plan = resource.Build();
        string arm = plan.CompileArmTemplate();

        // Trim to just the resources section so we don't get tripped up
        // by generator version metadata that depends upon the locally
        // installed tool
        string resources = JsonDocument.Parse(arm).RootElement.GetProperty("resources").ToString();

        Assert.AreEqual(
            """
            [
                {
                  "type": "Microsoft.Storage/storageAccounts",
                  "apiVersion": "2023-01-01",
                  "name": "[take(format('storage{0}', uniqueString(resourceGroup().id)), 24)]",
                  "kind": "StorageV2",
                  "location": "[resourceGroup().location]",
                  "sku": {
                    "name": "Standard_LRS"
                  },
                  "properties": {
                    "allowBlobPublicAccess": false,
                    "isHnsEnabled": true
                  }
                }
              ]
            """,
            resources);
    }
}
