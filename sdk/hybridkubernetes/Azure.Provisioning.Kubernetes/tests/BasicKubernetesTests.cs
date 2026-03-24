// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Kubernetes.Tests;

public class BasicKubernetesTests
{
    internal static Trycep CreateConnectedClusterTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KubernetesBasic
                Infrastructure infra = new();

                ConnectedCluster cluster =
                    new(nameof(cluster), ConnectedCluster.ResourceVersions.V2024_01_01)
                    {
                        AgentPublicKeyCertificate = "base64cert",
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        }
                    };
                infra.Add(cluster);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateConnectedCluster()
    {
        await using Trycep test = CreateConnectedClusterTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cluster 'Microsoft.Kubernetes/connectedClusters@2024-01-01' = {
              name: take('cluster-${uniqueString(resourceGroup().id)}', 63)
              properties: {
                agentPublicKeyCertificate: 'base64cert'
              }
              identity: {
                type: 'SystemAssigned'
              }
              location: location
            }
            """);
    }
}
