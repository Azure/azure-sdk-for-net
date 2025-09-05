// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Search.Tests;

public class BasicSearchTests
{
    internal static Trycep CreateSearchServiceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SearchBasic
                Infrastructure infra = new();

                SearchService search =
                    new(nameof(search))
                    {
                        SearchSkuName = SearchServiceSkuName.Standard,
                        ReplicaCount = 1,
                        PartitionCount = 1,
                        HostingMode = SearchServiceHostingMode.Default,
                    };
                infra.Add(search);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.search/azure-search-create/main.bicep")]
    public async Task CreateSearchService()
    {
        await using Trycep test = CreateSearchServiceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource search 'Microsoft.Search/searchServices@2023-11-01' = {
              name: take('search-${uniqueString(resourceGroup().id)}', 60)
              location: location
              properties: {
                hostingMode: 'default'
                partitionCount: 1
                replicaCount: 1
              }
              sku: {
                name: 'standard'
              }
            }
            """);
    }
}
