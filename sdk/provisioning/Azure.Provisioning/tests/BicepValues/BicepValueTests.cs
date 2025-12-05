// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues;

public class BicepValueTests
{
    [Test]
    public void ValidateLiteralBicepValue()
    {
        // string value
        TestHelpers.AssertExpression("'test'", new BicepValue<string>("test"));

        // int value
        TestHelpers.AssertExpression("42", new BicepValue<int>(42));
        TestHelpers.AssertExpression("-42", new BicepValue<int>(-42));

        // long value
        TestHelpers.AssertExpression("42", new BicepValue<long>(42L));
        TestHelpers.AssertExpression("2147483647", new BicepValue<long>(2147483647L));
        TestHelpers.AssertExpression("json('2147483648')", new BicepValue<long>(2147483648));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<long>(-2147483648L));
        TestHelpers.AssertExpression("json('-2147483649')", new BicepValue<long>(-2147483649));
        TestHelpers.AssertExpression("json('9223372036854775807')", new BicepValue<long>(9223372036854775807));

        // bool value
        TestHelpers.AssertExpression("true", new BicepValue<bool>(true));
        TestHelpers.AssertExpression("false", new BicepValue<bool>(false));

        // double value
        TestHelpers.AssertExpression("json('3.14')", new BicepValue<double>(3.14));
        TestHelpers.AssertExpression("json('-3.14')", new BicepValue<double>(-3.14));
        // double value with whole numbers
        TestHelpers.AssertExpression("314", new BicepValue<double>(314d));
        TestHelpers.AssertExpression("2147483647", new BicepValue<double>(2147483647d));
        TestHelpers.AssertExpression("json('2147483648')", new BicepValue<double>(2147483648d));
        TestHelpers.AssertExpression("-2147483647", new BicepValue<double>(-2147483647d));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<double>(-2147483648d));
        TestHelpers.AssertExpression("json('-2147483649')", new BicepValue<double>(-2147483649d));
    }

    [Test]
    public async Task ValidateTimeSpanPropertyWithFormat()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var powershell = new AzurePowerShellScript("script", "2023-08-01")
                {
                    RetentionInterval = new TimeSpan(11, 22, 33),
                    AzPowerShellVersion = "10.0",
                    ScriptContent = "echo 'Hello, world!'",
                };
                infra.Add(powershell);
                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                resource script 'Microsoft.Resources/deploymentScripts@2023-08-01' = {
                  name: take('script${uniqueString(resourceGroup().id)}', 24)
                  location: location
                  kind: 'AzurePowerShell'
                  properties: {
                    azPowerShellVersion: '10.0'
                    retentionInterval: 'PT11H22M33S'
                    scriptContent: 'echo \'Hello, world!\''
                  }
                }
                """);
    }
}
