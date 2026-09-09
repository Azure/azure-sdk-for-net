// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.Tests;

public class BasicKubernetesConfigurationFluxConfigurationsTests
{
    internal static Trycep CreateFluxConfigurationTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KubernetesConfigurationFluxConfigurationsBasic
                Infrastructure infra = new();

                FluxConfiguration flux =
                    new(nameof(flux), FluxConfiguration.ResourceVersions.V2025_04_01)
                    {
                        Namespace = "flux-system",
                        GitRepository = new FluxGitRepository
                        {
                            Uri = "https://github.com/Azure/arc-k8s-demo",
                        },
                    };
                infra.Add(flux);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.kubernetesconfiguration")]
    public async Task CreateFluxConfiguration()
    {
        await using Trycep test = CreateFluxConfigurationTest();
        test.Compare(
            """
            resource flux 'Microsoft.KubernetesConfiguration/fluxConfigurations@2025-04-01' = {
              name: take('flux${uniqueString(resourceGroup().id)}', 24)
              properties: {
                gitRepository: {
                  url: 'https://github.com/Azure/arc-k8s-demo'
                }
                namespace: 'flux-system'
              }
            }
            """);
    }
}
