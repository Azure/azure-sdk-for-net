// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Attestation.Tests;

public class BasicAttestationTests
{
    internal static Trycep CreateAttestationProviderTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AttestationProviderBasic
                Infrastructure infra = new();

                AttestationProvider provider =
                    new(nameof(provider), AttestationProvider.ResourceVersions.V2021_06_01)
                    {
                        PublicNetworkAccess = AttestationPublicNetworkAccessType.Enabled,
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(provider);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description(
      "Azure Quickstart Template: https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.attestation/attestation-provider-create/main.bicep; " +
      "Microsoft Learn quickstart: https://learn.microsoft.com/azure/attestation/quickstart-template")]
    public async Task CreateAttestationProvider()
    {
        await using Trycep test = CreateAttestationProviderTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource provider 'Microsoft.Attestation/attestationProviders@2021-06-01' = {
              name: take('provider-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                publicNetworkAccess: 'Enabled'
              }
            }
            """);
    }
}
