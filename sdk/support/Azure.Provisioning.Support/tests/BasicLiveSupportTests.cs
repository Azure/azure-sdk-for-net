// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// cspell:ignore Trycep

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Deployments;
using Azure.ResourceManager.Resources.Deployments.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Support.Tests;

public class BasicLiveSupportTests(bool async)
    : ProvisioningTestBase(async, skipTools: false, skipLiveCalls: false)
{
    [Test]
    [LiveOnly]
    public async Task CreateFileWorkspace()
    {
        await using Trycep test = BasicSupportTests.CreateFileWorkspaceTest();
        test.SetupLiveCalls(this).Lint();

        // Trycep.ValidateAsync only supports resource-group deployments.
        ArmDeploymentContent content = new(
            new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(test.Plan!.CompileArmTemplate()),
            })
        {
            Location = test.ResourceLocation,
        };
        ArmDeploymentResource deployment = test.DeploymentOptions.ArmClient.GetArmDeploymentResource(
            ArmDeploymentResource.CreateResourceIdentifier(
                $"/subscriptions/{TestEnvironment.SubscriptionId}",
                "support-provisioning-validation"));

        ArmOperation<ArmDeploymentValidateResult> result = await deployment.ValidateAsync(WaitUntil.Completed, content);
        Assert.That(result.Value.Error, Is.Null);
    }
}
