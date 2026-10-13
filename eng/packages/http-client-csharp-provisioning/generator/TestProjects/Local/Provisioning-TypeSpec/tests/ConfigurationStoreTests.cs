// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class ConfigurationStoreTests
{
    [Test]
    public async Task EnumAndScalarFormats()
    {
        DateTimeOffset timestamp = new(2026, 7, 29, 9, 30, 0, TimeSpan.Zero);

        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store), ConfigurationStore.ResourceVersions.V2024_05_01)
                {
                    Properties = new ConfigurationStoreProperties
                    {
                        SkuName = "Standard",
                        PublicNetworkAccess = PublicNetworkAccess.Disabled,
                        SkuTier = ConfigurationStoreSkuTier.StandardS1,
                        CreateMode = ConfigurationStoreCreateMode.Recover,
                        RetentionPeriod = new TimeSpan(1, 2, 3, 4),
                        LastModified = timestamp,
                        AuditTimestamps = { timestamp },
                        ExpiresOn = timestamp,
                        ActivationOn = timestamp,
                        ActivationTime = new TimeSpan(0, 2, 3, 4, 5),
                        RetryAfter = TimeSpan.FromMilliseconds(1500),
                        PollingInterval = TimeSpan.FromMilliseconds(1500),
                        EncodedInteger = 42
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
                activationDate: '2026-07-29'
                activationTime: '02:03:04.0050000'
                auditTimestamps: [
                  '2026-07-29T09:30:00.0000000Z'
                ]
                createMode: 'recover'
                encodedInteger: '42'
                expirationTimestamp: 1785317400
                lastModified: 'Wed, 29 Jul 2026 09:30:00 GMT'
                pollingInterval: 1500
                publicNetworkAccess: 'Disabled'
                retentionPeriod: 'P1DT2H3M4S'
                retryAfter: 2
                sku: {
                  name: 'Standard'
                }
                skuTier: 'Standard_S1'
              }
            }
            """);
    }
}
