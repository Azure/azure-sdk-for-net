// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.LoadTesting.Tests;

public class BasicLoadTestingTests
{
    internal static Trycep CreateLoadTestingResourceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:LoadTestingResourceBasic
                Infrastructure infra = new();

                LoadTestingResource loadTest =
                    new(nameof(loadTest), LoadTestingResource.ResourceVersions.V2022_12_01)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(loadTest);

                infra.Add(new ProvisioningOutput("loadTestName", typeof(string)) { Value = loadTest.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = loadTest.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/load-testing/quickstart-create-and-run-load-test-with-bicep")]
    public async Task CreateLoadTestingResource()
    {
        await using Trycep test = CreateLoadTestingResourceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource loadTest 'Microsoft.LoadTestService/loadTests@2022-12-01' = {
              name: take('loadtest${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
            }

            output loadTestName string = loadTest.name

            output resourceId string = loadTest.id
            """);
    }
}
