// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class DiscriminatorTests
{
    [Test]
    public async Task EnumDiscriminator()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store), ConfigurationStore.ResourceVersions.V2024_05_01)
                {
                    Properties = new ConfigurationStoreProperties
                    {
                        BackupPolicy = new PeriodicBackupPolicy
                        {
                            RetentionDays = 7,
                            IntervalInHours = 24
                        }
                    }
                };
                infra.Add(store);
                return infra;
            });

        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource store 'ProvisioningTypeSpec/configurationStores@2024-05-01' = {
              name: take('store-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                backupPolicy: {
                  retentionDays: 7
                  kind: 'Periodic'
                  intervalInHours: 24
                }
              }
            }
            """);
    }
}
