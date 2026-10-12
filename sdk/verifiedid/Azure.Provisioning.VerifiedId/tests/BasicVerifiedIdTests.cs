// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.VerifiedId.Tests;

public class BasicVerifiedIdTests
{
    internal static Trycep CreateVerifiedIdAuthorityTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:VerifiedIdAuthorityBasic
                Infrastructure infra = new();

                VerifiedIdAuthority authority =
                    new(nameof(authority), VerifiedIdAuthority.ResourceVersions.V2024_01_26_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(authority);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.verifiedid/2024-01-26-preview/authorities")]
    public async Task CreateVerifiedIdAuthority()
    {
        await using Trycep test = CreateVerifiedIdAuthorityTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource authority 'Microsoft.VerifiedId/authorities@2024-01-26-preview' = {
              name: take('authority-${uniqueString(resourceGroup().id)}', 24)
              location: location
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
