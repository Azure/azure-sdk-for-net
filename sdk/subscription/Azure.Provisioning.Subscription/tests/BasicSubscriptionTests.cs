// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Subscription.Tests;

public class BasicSubscriptionTests
{
    internal static Trycep CreateSubscriptionAliasTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SubscriptionAliasBasic
                Infrastructure infra = new() { TargetScope = DeploymentScope.Tenant };

                SubscriptionAlias subscriptionAlias =
                    new(nameof(subscriptionAlias), SubscriptionAlias.ResourceVersions.V2025_11_01_PREVIEW)
                    {
                        Name = "contoso-subscription",
                        Properties = new SubscriptionAliasProperties
                        {
                            DisplayName = "Contoso Subscription",
                            BillingScope = "/providers/Microsoft.Billing/billingAccounts/00000000",
                            Workload = SubscriptionWorkload.Production,
                        },
                    };
                infra.Add(subscriptionAlias);

                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = subscriptionAlias.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateSubscriptionAlias()
    {
        await using Trycep test = CreateSubscriptionAliasTest();
        test.Compare(
            """
            targetScope = 'tenant'

            resource subscriptionAlias 'Microsoft.Subscription/aliases@2025-11-01-preview' = {
              name: 'contoso-subscription'
              properties: {
                billingScope: '/providers/Microsoft.Billing/billingAccounts/00000000'
                displayName: 'Contoso Subscription'
                workload: 'Production'
              }
            }

            output resourceId string = subscriptionAlias.id
            """);
    }
}
