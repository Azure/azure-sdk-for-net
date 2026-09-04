// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DevHub.Tests;

public class BasicDevHubTests
{
    internal static Trycep CreateIacProfileTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DevHubIacProfileBasic
                Infrastructure infra = new();

                IacProfile profile =
                    new(nameof(profile), IacProfile.ResourceVersions.V2025_03_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                        RepositoryName = "infrastructure",
                        RepositoryMainBranch = "main",
                        RepositoryOwner = "contoso",
                    };
                infra.Add(profile);

                infra.Add(new ProvisioningOutput("profileName", typeof(string)) { Value = profile.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = profile.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateIacProfile()
    {
        await using Trycep test = CreateIacProfileTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource profile 'Microsoft.DevHub/iacProfiles@2025-03-01-preview' = {
              name: take('profile-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                githubProfile: {
                  repositoryMainBranch: 'main'
                  repositoryName: 'infrastructure'
                  repositoryOwner: 'contoso'
                }
              }
              tags: {
                environment: 'test'
              }
            }

            output profileName string = profile.name

            output resourceId string = profile.id
            """);
    }
}
