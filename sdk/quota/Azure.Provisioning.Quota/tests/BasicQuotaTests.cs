// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Quota.Tests;

public class BasicQuotaTests
{
    internal static Trycep CreateGroupQuotaTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:GroupQuotaBasic
                Infrastructure infra = new()
                {
                    TargetScope = DeploymentScope.ManagementGroup,
                };

                GroupQuotaEntity groupQuota =
                    new(nameof(groupQuota), GroupQuotaEntity.ResourceVersions.V2025_09_01)
                    {
                        Name = "samplegroupquota",
                        Properties = new GroupQuotasEntityProperties
                        {
                            DisplayName = "Sample group quota",
                        },
                    };
                infra.Add(groupQuota);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.quota/groupquotas")]
    public async Task CreateGroupQuota()
    {
        await using Trycep test = CreateGroupQuotaTest();
        test.Compare(
            """
            targetScope = 'managementGroup'

            resource groupQuota 'Microsoft.Quota/groupQuotas@2025-09-01' = {
              name: 'samplegroupquota'
              properties: {
                displayName: 'Sample group quota'
              }
            }
            """);
    }
}
