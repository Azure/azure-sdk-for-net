// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Communication.Tests;

public class BasicCommunicationTests
{
    internal static Trycep CreateCommunicationServicesTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CommunicationBasic
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
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateCommunicationServices()
    {
        await using Trycep test = CreateCommunicationServicesTest();
        test.Compare(
            """
            param location string = 'global'

            resource comm 'Microsoft.Communication/communicationServices@2023-03-31' = {
              name: take('comm-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                dataLocation: 'unitedstates'
              }
            }
            """);
    }
}
