using System;
using Microsoft.Azure.Management.KubernetesConfiguration.Models;
using Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

public class FluxExtensionSetupFixture : IDisposable
{
    private readonly ClusterInfo cluster;
    private readonly Extension extension;

    public FluxExtensionSetupFixture()
    {
        this.cluster = new ClusterInfo(
            name: "arc-cluster",
            type: ClusterInfo.ClusterType.connectedClusters,
            location: "eastus2euap",
            resourceGroup: "dotnet-sdk-tests"
        );
        this.extension = new Extension(
            name: "flux",
            extensionType: "microsoft.flux",
            identity: new Identity
            {
                Type = ResourceIdentityType.SystemAssigned
            });

        using (var context = MockContext.Start(this.GetType()))
        {
            using (var testFixture = new ExtensionTestBase(context))
            {
                testFixture.Cluster = cluster;
                testFixture.Extension = this.extension;
                testFixture.CreateExtension();
            }
        }
    }
    public void Dispose()
    {
        using (var context = MockContext.Start(this.GetType()))
        {
            using (var testFixture = new ExtensionTestBase(context))
            {
                testFixture.Cluster = cluster;
                testFixture.Extension = this.extension;
                testFixture.DeleteExtension();
            }
        }
    }
}