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

                ProvisioningParameter queryCode = new(nameof(queryCode), typeof(string))
                {
                    Description = "The Azure Resource Graph query to be saved to the shared query.",
                    Value = "Resources | where type =~ 'Microsoft.Compute/virtualMachines' | summarize count() by tostring(properties.storageProfile.osDisk.osType)",
                };
                infra.Add(queryCode);

                ProvisioningParameter queryDescription = new(nameof(queryDescription), typeof(string))
                {
                    Description = "The description of the saved Azure Resource Graph query.",
                    Value = "This shared query counts all virtual machine resources and summarizes by the OS type.",
                };
                infra.Add(queryDescription);

                ResourceGraphQuery query =
                    new(nameof(query))
                    {
                        Query = queryCode,
                        Description = queryDescription,
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
            @description('The Azure Resource Graph query to be saved to the shared query.')
            param queryCode string = 'Resources | where type =~ \'Microsoft.Compute/virtualMachines\' | summarize count() by tostring(properties.storageProfile.osDisk.osType)'

            @description('The description of the saved Azure Resource Graph query.')
            param queryDescription string = 'This shared query counts all virtual machine resources and summarizes by the OS type.'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource query 'Microsoft.ResourceGraph/queries@2024-04-01' = {
              name: take('query${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                description: queryDescription
                query: queryCode
              }
            }
            """);
    }
}
