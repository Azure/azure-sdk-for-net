// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
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
    public void ValidateFloatingPointUsesInvariantCulture()
    {
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        try
        {
            // Use Danish culture where decimal separator is comma (e.g. "0,5" instead of "0.5")
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            // BicepValue<double> should produce dot-separated decimals regardless of locale
            TestHelpers.AssertExpression("json('0.5')", new BicepValue<double>(0.5));
            TestHelpers.AssertExpression("json('3.14')", new BicepValue<double>(3.14));
            TestHelpers.AssertExpression("json('-1.23')", new BicepValue<double>(-1.23));

            // BicepValue<float> should also produce dot-separated decimals
            TestHelpers.AssertExpression("json('0.5')", new BicepValue<float>(0.5f));
            TestHelpers.AssertExpression("json('0.25')", new BicepValue<float>(0.25f));
            TestHelpers.AssertExpression("json('-0.125')", new BicepValue<float>(-0.125f));

            // Very small fractional values
            TestHelpers.AssertExpression("json('0.001')", new BicepValue<double>(0.001));

            // Large values with fractional parts
            TestHelpers.AssertExpression("json('123456.789')", new BicepValue<double>(123456.789));

            // Values that are whole numbers should still render as int, even under non-invariant culture
            TestHelpers.AssertExpression("0", new BicepValue<double>(0.0));
            TestHelpers.AssertExpression("1", new BicepValue<double>(1.0));
            TestHelpers.AssertExpression("-1", new BicepValue<double>(-1.0));
            TestHelpers.AssertExpression("0", new BicepValue<float>(0.0f));
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }
    }

    [Test]
    public void ValidateFloatingPointEdgeCases()
    {
        // Zero
        TestHelpers.AssertExpression("0", new BicepValue<double>(0.0));
        TestHelpers.AssertExpression("0", new BicepValue<float>(0.0f));

        // Negative zero should still be 0
        TestHelpers.AssertExpression("0", new BicepValue<double>(-0.0));
        TestHelpers.AssertExpression("0", new BicepValue<float>(-0.0f));

        // Very small decimals (the original bug scenario: minCapacity = 0.5)
        TestHelpers.AssertExpression("json('0.5')", new BicepValue<double>(0.5));
        TestHelpers.AssertExpression("json('0.25')", new BicepValue<double>(0.25));

        // Boundary: double whole number at int max/min
        TestHelpers.AssertExpression("2147483647", new BicepValue<double>((double)int.MaxValue));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<double>((double)int.MinValue));

        // Just beyond int range with fractional part
        TestHelpers.AssertExpression("json('2147483647.5')", new BicepValue<double>(2147483647.5));
        TestHelpers.AssertExpression("json('-2147483648.5')", new BicepValue<double>(-2147483648.5));

        // float value
        TestHelpers.AssertExpression("json('0.5')", new BicepValue<float>(0.5f));
        TestHelpers.AssertExpression("json('-0.25')", new BicepValue<float>(-0.25f));
        // float value with whole numbers
        TestHelpers.AssertExpression("314", new BicepValue<float>(314f));
        TestHelpers.AssertExpression("0", new BicepValue<float>(0f));
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
