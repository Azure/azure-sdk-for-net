// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AlertProcessingRules.Tests;

public class BasicLiveAlertProcessingRulesTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.recoveryservices/recovery-services-create-alert-processing-rule/main.bicep")]
    [LiveOnly]
    public async Task CreateBackupAlertProcessingRule()
    {
        await using Trycep test = BasicAlertProcessingRulesTests.CreateAlertProcessingRuleTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
