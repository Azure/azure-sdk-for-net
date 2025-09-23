// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.CognitiveServices.Tests;

public class BasicLiveCognitiveServicesTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cognitiveservices/cognitive-services-translate/main.bicep")]
    [LiveOnly]
    public async Task CreateTranslation()
    {
        await using Trycep test = BasicCognitiveServicesTests.CreateTranslationTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
