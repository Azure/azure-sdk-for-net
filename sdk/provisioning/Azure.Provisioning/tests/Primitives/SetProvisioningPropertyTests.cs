// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives
{
    public class SetProvisioningPropertyTests
    {
        [Test]
        public async Task SetProvisioningProperty_WithDictionaryItem_ShouldNotThrow()
        {
            await using var test = new Trycep();

            test.Define(
                ctx =>
                {
                    ProvisioningParameter parameter1 = new("parameter1", typeof(string));

                    StorageAccount acct = new("storage")
                    {
                        Kind = StorageKind.StorageV2,
                        Sku = new StorageSku
                        {
                            Name = StorageSkuName.StandardLrs
                        },
                        Tags =
                        {
                            { "firstAccount", parameter1 }
                        }
                    };

                    ProvisioningParameter parameter2 = new("parameter2", typeof(string));

                    Infrastructure infra = new();
                    infra.Add(acct);
                    infra.Add(parameter1);
                    infra.Add(parameter2);

                    // This is the key part - iterating over dictionary items and calling SetProvisioningProperty
                    foreach (KeyValuePair<string, IBicepValue> binding in acct.ProvisionableProperties)
                    {
                        if (binding.Value is IDictionary<string, IBicepValue> dict)
                        {
                            foreach (IBicepValue item in dict.Values)
                            {
                                BicepValue<object> newValue = parameter2;
                                acct.SetProvisioningProperty(item, newValue);
                            }
                        }
                    }

                    return infra;
                })
                .Compare(
                    """
                    param parameter1 string
                    
                    param parameter2 string
                    
                    @description('The location for the resource(s) to be deployed.')
                    param location string = resourceGroup().location
                    
                    resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
                      name: take('storage${uniqueString(resourceGroup().id)}', 24)
                      kind: 'StorageV2'
                      location: location
                      sku: {
                        name: 'Standard_LRS'
                      }
                      tags: {
                        firstAccount: parameter2
                      }
                    }
                    """);
        }

        [Test]
        public async Task SetProvisioningProperty_WithDictionaryItem_MultipleKeys_ShouldNotThrow()
        {
            await using var test = new Trycep();

            test.Define(
                ctx =>
                {
                    ProvisioningParameter parameter1 = new("parameter1", typeof(string));
                    ProvisioningParameter parameter2 = new("parameter2", typeof(string));

                    StorageAccount acct = new("storage")
                    {
                        Kind = StorageKind.StorageV2,
                        Sku = new StorageSku
                        {
                            Name = StorageSkuName.StandardLrs
                        },
                        Tags =
                        {
                            { "key1", "value1" },
                            { "key2", "value2" }
                        }
                    };

                    Infrastructure infra = new();
                    infra.Add(acct);
                    infra.Add(parameter1);
                    infra.Add(parameter2);

                    // Update specific dictionary items
                    foreach (KeyValuePair<string, IBicepValue> binding in acct.ProvisionableProperties)
                    {
                        if (binding.Value is IDictionary<string, IBicepValue> dict)
                        {
                            if (dict.TryGetValue("key1", out IBicepValue? item1))
                            {
                                BicepValue<object> newValue1 = parameter1;
                                acct.SetProvisioningProperty(item1, newValue1);
                            }
                            if (dict.TryGetValue("key2", out IBicepValue? item2))
                            {
                                BicepValue<object> newValue2 = parameter2;
                                acct.SetProvisioningProperty(item2, newValue2);
                            }
                        }
                    }

                    return infra;
                })
                .Compare(
                    """
                    param parameter1 string
                    
                    param parameter2 string
                    
                    @description('The location for the resource(s) to be deployed.')
                    param location string = resourceGroup().location
                    
                    resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
                      name: take('storage${uniqueString(resourceGroup().id)}', 24)
                      kind: 'StorageV2'
                      location: location
                      sku: {
                        name: 'Standard_LRS'
                      }
                      tags: {
                        key1: parameter1
                        key2: parameter2
                      }
                    }
                    """);
        }
    }
}
