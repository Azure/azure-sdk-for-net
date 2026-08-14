// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SecurityCenter.Tests;

public class BasicSecurityCenterTests
{
    internal static Trycep CreateDefenderPricingTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SecurityCenterBasic
                Infrastructure infra = new();

                SecurityCenterPricing pricing =
                    new(nameof(pricing))
                    {
                        Name = "VirtualMachines",
                        PricingTier = SecurityCenterPricingTier.Standard,
                        SubPlan = "P2",
                    };
                infra.Add(pricing);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/defender-for-cloud/")]
    public async Task CreateDefenderPricing()
    {
        await using Trycep test = CreateDefenderPricingTest();
        test.Compare(
            """
            resource pricing 'Microsoft.Security/pricings@2023-01-01' = {
              name: 'VirtualMachines'
              properties: {
                pricingTier: 'Standard'
                subPlan: 'P2'
              }
            }
            """);
    }
}
