// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Provisioning.Resources;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues;

public class BicepValueTests
{
    [Test]
    public void ValidateLiteralBicepValue()
    {
        // string value
        AssertExpression("'test'", new BicepValue<string>("test"));

        // int value
        AssertExpression("42", new BicepValue<int>(42));
        AssertExpression("-42", new BicepValue<int>(-42));

        // long value
        AssertExpression("42", new BicepValue<long>(42L));
        AssertExpression("2147483647", new BicepValue<long>(2147483647L));
        AssertExpression("json('2147483648')", new BicepValue<long>(2147483648));
        AssertExpression("-2147483648", new BicepValue<long>(-2147483648L));
        AssertExpression("json('-2147483649')", new BicepValue<long>(-2147483649));
        AssertExpression("json('9223372036854775807')", new BicepValue<long>(9223372036854775807));

        // bool value
        AssertExpression("true", new BicepValue<bool>(true));
        AssertExpression("false", new BicepValue<bool>(false));

        // double value
        AssertExpression("json('3.14')", new BicepValue<double>(3.14));
        AssertExpression("json('-3.14')", new BicepValue<double>(-3.14));
        // double value with whole numbers
        AssertExpression("314", new BicepValue<double>(314d));
        AssertExpression("2147483647", new BicepValue<double>(2147483647d));
        AssertExpression("json('2147483648')", new BicepValue<double>(2147483648d));
        AssertExpression("-2147483647", new BicepValue<double>(-2147483647d));
        AssertExpression("-2147483648", new BicepValue<double>(-2147483648d));
        AssertExpression("json('-2147483649')", new BicepValue<double>(-2147483649d));

        static void AssertExpression(string expected, BicepValue bicepValue)
        {
            Assert.AreEqual(expected, bicepValue.ToString());
        }
    }

    [Test]
    public void ValidateTimeSpanPropertyWithFormat()
    {
        var infra = new Infrastructure();
        var powershell = new AzurePowerShellScript("script", "2023-08-01")
        {
            RetentionInterval = new TimeSpan(11, 22, 33),
            AzPowerShellVersion = "10.0",
            ScriptContent = "echo 'Hello, world!'",
        };

        infra.Add(powershell);
        var plan = infra.Build();

        var result = plan.Compile();
        Assert.AreEqual(
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
            """.NormalizeLineEndings(), result.Values.First().NormalizeLineEndings());
    }
}
