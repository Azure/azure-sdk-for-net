// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Communication.Tests;

public class BasicCommunicationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    public async Task CreateCommunicationServices()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter location =
                    new(nameof(location), typeof(string))
                    {
                        Value = "global"
                    };
                infra.Add(location);

                CommunicationService comm =
                    new(nameof(comm), "2023-03-31")
                    {
                        Location = location,
                        DataLocation = "unitedstates"
                    };
                infra.Add(comm);

                return infra;
            })
        .Compare(
            """
            param location string = 'global'

            resource comm 'Microsoft.Communication/communicationServices@2023-03-31' = {
              name: take('comm-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                dataLocation: 'unitedstates'
              }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
