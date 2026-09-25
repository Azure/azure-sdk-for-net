// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppNetwork.Tests;

public class BasicAppNetworkTests
{
    internal static Trycep CreateAppLinkTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AppLinkBasic
                Infrastructure infra = new();

                AppLink appLink = new(nameof(appLink), AppLink.ResourceVersions.V2026_08_01_PREVIEW)
                {
                    Name = "app-link",
                    Location = new AzureLocation("eastus")
                };
                infra.Add(appLink);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateAppLink()
    {
        await using Trycep test = CreateAppLinkTest();

        test.Compare(
            """
            resource appLink 'Microsoft.AppLink/appLinks@2026-08-01-preview' = {
              name: 'app-link'
              location: 'eastus'
            }
            """);
    }
}
