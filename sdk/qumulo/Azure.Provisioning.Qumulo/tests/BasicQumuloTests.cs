// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Qumulo.Tests;

public class BasicQumuloTests
{
    internal static Trycep CreateFileSystemTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:QumuloBasic
                Infrastructure infra = new();

                ProvisioningParameter adminPassword =
                    new(nameof(adminPassword), typeof(string)) { IsSecure = true };
                infra.Add(adminPassword);

                ProvisioningParameter userEmail =
                    new(nameof(userEmail), typeof(string)) { IsSecure = true };
                infra.Add(userEmail);

                ProvisioningParameter delegatedSubnetId =
                    new(nameof(delegatedSubnetId), typeof(string));
                infra.Add(delegatedSubnetId);

                ProvisioningParameter marketplacePlanId =
                    new(nameof(marketplacePlanId), typeof(string));
                infra.Add(marketplacePlanId);

                ProvisioningParameter marketplaceOfferId =
                    new(nameof(marketplaceOfferId), typeof(string));
                infra.Add(marketplaceOfferId);

                QumuloFileSystemResource fileSystem =
                    new(nameof(fileSystem), QumuloFileSystemResource.ResourceVersions.V2026_04_16)
                    {
                        Name = "qumulo-filesystem",
                        StorageSkuName = "Standard",
                        AdminPassword = adminPassword,
                        UserDetailsEmail = userEmail,
                        DelegatedSubnetId = delegatedSubnetId,
                        MarketplaceDetails = new MarketplaceDetails
                        {
                            PlanId = marketplacePlanId,
                            OfferId = marketplaceOfferId,
                        },
                    };
                infra.Add(fileSystem);

                infra.Add(new ProvisioningOutput("fileSystemId", typeof(string)) { Value = fileSystem.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateFileSystem()
    {
        await using Trycep test = CreateFileSystemTest();
        test.Compare(
            """
            @secure()
            param adminPassword string

            @secure()
            param userEmail string

            param delegatedSubnetId string

            param marketplacePlanId string

            param marketplaceOfferId string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource fileSystem 'Qumulo.Storage/fileSystems@2026-04-16' = {
              name: 'qumulo-filesystem'
              location: location
              properties: {
                adminPassword: adminPassword
                delegatedSubnetId: delegatedSubnetId
                marketplaceDetails: {
                  offerId: marketplaceOfferId
                  planId: marketplacePlanId
                }
                storageSku: 'Standard'
                userDetails: {
                  email: userEmail
                }
              }
            }

            output fileSystemId string = fileSystem.id
            """);
    }
}
