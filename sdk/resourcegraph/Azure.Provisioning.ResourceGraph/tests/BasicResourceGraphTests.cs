// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ResourceGraph.Tests;

public class BasicResourceGraphTests
{
    internal static Trycep CreateResourceGraphQueryTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ResourceGraphQueryBasic
                Infrastructure infra = new();

                ResourceGraphQuery query =
                    new(nameof(query))
                    {
                        Query = "Resources | where type =~ 'Microsoft.Compute/virtualMachines' | summarize count() by tostring(properties.storageProfile.osDisk.osType)",
                        Description = "This shared query counts all virtual machine resources and summarizes by the OS type.",
                    };
                infra.Add(query);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/demos/resourcegraph-sharedquery-countos")]
    public async Task CreateResourceGraphQuery()
    {
        await using Trycep test = CreateResourceGraphQueryTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource query 'Microsoft.ResourceGraph/queries@2024-04-01' = {
              name: take('query${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                description: 'This shared query counts all virtual machine resources and summarizes by the OS type.'
                query: 'Resources | where type =~ \'Microsoft.Compute/virtualMachines\' | summarize count() by tostring(properties.storageProfile.osDisk.osType)'
              }
            }
            """);
    }
}
