// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Education.Tests;

public class BasicEducationTests
{
    internal static Trycep CreateEducationLabTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:EducationLabBasic
                Infrastructure infra = new();

                EducationLab lab =
                    new(nameof(lab), EducationLab.ResourceVersions.V2021_12_01_PREVIEW)
                    {
                        DisplayName = "Contoso Education Lab",
                        Description = "Education lab for Contoso students",
                        BudgetPerStudent = new EducationAmount
                        {
                            Currency = "USD",
                            Value = 100,
                        },
                        ExpiresOn = DateTimeOffset.Parse("2027-06-30T00:00:00Z"),
                    };
                infra.Add(lab);

                infra.Add(new ProvisioningOutput("labName", typeof(string)) { Value = lab.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = lab.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/rest/api/education/labs/create-or-update?view=rest-education-2021-12-01-preview")]
    public async Task CreateEducationLab()
    {
        await using Trycep test = CreateEducationLabTest();
        test.Compare(
            """
            resource lab 'Microsoft.Education/labs@2021-12-01-preview' = {
              name: 'default'
              properties: {
                budgetPerStudent: {
                  currency: 'USD'
                  value: 100
                }
                description: 'Education lab for Contoso students'
                displayName: 'Contoso Education Lab'
                expirationDate: '2027-06-30T00:00:00.0000000Z'
              }
            }

            output labName string = 'default'

            output resourceId string = lab.id
            """);
    }
}
