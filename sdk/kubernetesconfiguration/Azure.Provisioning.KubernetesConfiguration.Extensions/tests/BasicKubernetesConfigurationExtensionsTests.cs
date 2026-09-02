// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.Extensions.Tests;

public class BasicKubernetesConfigurationExtensionsTests
{
    internal static Trycep CreateClusterExtensionTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KubernetesConfigurationExtensionsBasic
                Infrastructure infra = new();

                KubernetesClusterExtension extension =
                    new(nameof(extension), KubernetesClusterExtension.ResourceVersions.V2025_03_01)
                    {
                        ExtensionType = "microsoft.flux",
                    };
                infra.Add(extension);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateClusterExtension()
    {
        await using Trycep test = CreateClusterExtensionTest();
        test.Compare(
            """
            resource extension 'Microsoft.KubernetesConfiguration/extensions@2025-03-01' = {
              name: take('extension${uniqueString(resourceGroup().id)}', 24)
              properties: {
                extensionType: 'microsoft.flux'
              }
            }
            """);
    }
}
