// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Billing.Tests;

public class BasicBillingTests
{
    internal static Trycep CreateBillingAccountPolicyTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:BillingAccountPolicyBasic
                Infrastructure infra = new() { TargetScope = DeploymentScope.Tenant };

                BillingAccount billingAccount = BillingAccount.FromExisting(
                    nameof(billingAccount),
                    BillingAccount.ResourceVersions.V2024_04_01);
                billingAccount.Name = "1234567";
                infra.Add(billingAccount);

                BillingAccountPolicy billingAccountPolicy =
                    new(nameof(billingAccountPolicy), BillingAccountPolicy.ResourceVersions.V2024_04_01)
                    {
                        Parent = billingAccount,
                        Properties = new BillingAccountPolicyProperties
                        {
                            MarketplacePurchases = MarketplacePurchasesPolicy.AllAllowed,
                            ReservationPurchases = ReservationPurchasesPolicy.Allowed,
                            SavingsPlanPurchases = SavingsPlanPurchasesPolicy.NotAllowed,
                        },
                    };
                infra.Add(billingAccountPolicy);

                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = billingAccountPolicy.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/rest/api/billing/policies/put?view=rest-billing-2024-04-01")]
    public async Task CreateBillingAccountPolicy()
    {
        await using Trycep test = CreateBillingAccountPolicyTest();
        test.Compare(
            """
            targetScope = 'tenant'

            resource billingAccount 'Microsoft.Billing/billingAccounts@2024-04-01' existing = {
              name: '1234567'
            }

            resource billingAccountPolicy 'Microsoft.Billing/billingAccounts/policies@2024-04-01' = {
              name: 'default'
              parent: billingAccount
              properties: {
                marketplacePurchases: 'AllAllowed'
                reservationPurchases: 'Allowed'
                savingsPlanPurchases: 'NotAllowed'
              }
            }

            output resourceId string = billingAccountPolicy.id
            """);
    }
}
