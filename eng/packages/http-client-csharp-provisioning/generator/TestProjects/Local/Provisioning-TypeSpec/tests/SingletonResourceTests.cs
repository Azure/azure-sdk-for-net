// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class SingletonResourceTests
{
    [Test]
    public async Task DecoratedSingleton()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store));
                SingletonSetting singleton = new(nameof(singleton))
                {
                    Parent = store,
                    SingletonSettingEnabled = true
                };
                infra.Add(store);
                infra.Add(singleton);
                return infra;
            });

        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource store 'ProvisioningTypeSpec/configurationStores@2024-05-01' = {
              name: take('store-${uniqueString(resourceGroup().id)}', 24)
              location: location
            }

            resource singleton 'ProvisioningTypeSpec/configurationStores/settings@2024-05-01' = {
              name: 'default'
              parent: store
              properties: {
                enabled: true
              }
            }
            """);
    }

    [Test]
    public async Task LegacyOperationSingleton()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                LegacySingleton singleton = new(nameof(singleton))
                {
                    LegacySingletonEnabled = true
                };
                infra.Add(singleton);
                return infra;
            });

        test.Compare(
            """
            resource singleton 'ProvisioningTypeSpec/legacySingletons@2024-05-01' = {
              name: 'default'
              properties: {
                enabled: true
              }
            }
            """);
    }

    [Test]
    public async Task SingletonWithoutGeneratedParent()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                OrphanedSingleton singleton = new(nameof(singleton))
                {
                    Name = "unmodeled/default",
                    OrphanedSingletonEnabled = true
                };
                infra.Add(singleton);
                return infra;
            });

        test.Compare(
            """
            resource singleton 'ProvisioningTypeSpec/unmodeledParents/orphanedSingletons@2024-05-01' = {
              name: 'unmodeled/default'
              properties: {
                enabled: true
              }
            }
            """);
    }
}
