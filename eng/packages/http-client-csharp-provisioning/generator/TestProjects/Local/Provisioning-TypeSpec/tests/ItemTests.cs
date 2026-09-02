// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class ItemTests
{
    [Test]
    public async Task InheritedAndCreateBodyProperties()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store));
                Item item = new(nameof(item))
                {
                    Parent = store,
                    Tags = { ["environment"] = "test" },
                    Value = "value",
                    ContentType = "text/plain",
                    NullableValue = new BicepValue<string>(new NullLiteralExpression()),
                    Attributes = new ItemAttributes
                    {
                        Enabled = true,
                        DisplayName = "item attributes",
                        Expires = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero)
                    }
                };
                infra.Add(store);
                infra.Add(item);
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

            resource item 'ProvisioningTypeSpec/configurationStores/items@2024-05-01' = {
              name: take('item-${uniqueString(resourceGroup().id)}', 24)
              properties: {
                value: 'value'
                contentType: 'text/plain'
                nullableValue: null
                attributes: {
                  enabled: true
                  displayName: 'item attributes'
                  expires: '2026-07-29T09:30:00.0000000Z'
                }
              }
              tags: {
                environment: 'test'
              }
              parent: store
            }
            """);
    }
}
