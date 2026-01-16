// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.TestFramework;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Deployment.Tests;

[LiveOnly]
internal class ExtensionTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    public void LintClean()
    {
        if (SkipTools) { return; }

        Infrastructure infra = new();
        StorageAccount resource =
            new("storage", StorageAccount.ResourceVersions.V2023_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false
            };
        infra.Add(resource);

        // Lint
        ProvisioningPlan plan = infra.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();
        Assert.That(messages.Count, Is.EqualTo(0));
    }

    [Test]
    public void LintWarn()
    {
        if (SkipTools) { return; }

        Infrastructure infra = new();
        ProvisioningParameter param = new("endpoint", typeof(string));
        infra.Add(param);

        // Lint
        ProvisioningPlan plan = infra.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();

        // Make sure it warns about the unused param
        Assert.That(messages.Count, Is.EqualTo(1));
        Assert.That(messages[0].IsError, Is.False);
        Assert.That(messages[0].Code, Is.EqualTo("no-unused-params"));
        Assert.That(messages[0].Message, Does.Contain("endpoint"));
    }

    [Test]
    public void LintError()
    {
        if (SkipTools) { return; }

        Infrastructure infra = new();
        // Use a string as the default value for a param typed int
        ProvisioningParameter param = new("bar", typeof(int)) { Value = "Hello, World." };
        infra.Add(param);

        ProvisioningPlan plan = infra.Build();
        IReadOnlyList<BicepErrorMessage> messages = plan.Lint();

        // Ignore the "unused param" first warning and make sure we get a type error
        Assert.That(messages.Count, Is.EqualTo(2));
        Assert.That(messages[1].IsError, Is.True);
        Assert.That(messages[1].Code, Is.EqualTo("BCP033"));
        Assert.That(messages[1].Message, Does.Contain("int"));
    }

    [Test]
    public void GetArmTemplate()
    {
        if (SkipTools) { return; }

        Infrastructure infra = new();
        StorageAccount resource =
            new("storage", StorageAccount.ResourceVersions.V2023_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false
            };
        infra.Add(resource);

        ProvisioningPlan plan = infra.Build();
        string arm = plan.CompileArmTemplate();

        // Trim to just the resources section so we don't get tripped up
        // by generator version metadata that depends upon the locally
        // installed tool
        string resources = JsonDocument.Parse(arm).RootElement.GetProperty("resources").ToString();

        Assert.That(
            resources,
            Is.EqualTo("""
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
            """));
    }
}
