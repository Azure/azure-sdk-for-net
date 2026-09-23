// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes.Tests;

public class BasicKubernetesConfigurationPrivateLinkScopesTests
{
    internal static Trycep CreatePrivateLinkScopeTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KubernetesConfigurationPrivateLinkScopesBasic
                Infrastructure infra = new();

                KubernetesConfigurationPrivateLinkScope scope =
                    new(nameof(scope), KubernetesConfigurationPrivateLinkScope.ResourceVersions.V2024_11_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                        Properties = new KubernetesConfigurationPrivateLinkScopeProperties
                        {
                            ClusterResourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/example"),
                            PublicNetworkAccess = KubernetesConfigurationPrivateLinkScopePublicNetworkAccessType.Disabled,
                        },
                    };
                infra.Add(scope);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreatePrivateLinkScope()
    {
        await using Trycep test = CreatePrivateLinkScopeTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource scope 'Microsoft.KubernetesConfiguration/privateLinkScopes@2024-11-01-preview' = {
              name: take('scope${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                clusterResourceId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/example'
                publicNetworkAccess: 'Disabled'
              }
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
