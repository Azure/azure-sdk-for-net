// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.ExtendedLocations;
using Azure.ResourceManager.Kubernetes;
using Azure.ResourceManager.KubernetesConfiguration;
using Azure.ResourceManager.AppContainers.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.ResourceManager.ExtendedLocations.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.KubernetesConfiguration.Models;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class EnviromentTests : AppContainersManagementTestBase
    {
        public EnviromentTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("KubernetesClusterExtension error")]
        public async Task AppContainerTest()
        {
            string extendName = Recording.GenerateAssetName("sustom");
            string connectedClusterName = Recording.GenerateAssetName("cluster");
            string configName = Recording.GenerateAssetName("config");
            string envName = Recording.GenerateAssetName("env");
            string envName2 = Recording.GenerateAssetName("env");
            string envName3 = Recording.GenerateAssetName("env");
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            var connectedClusterCollection = rg.GetConnectedClusters();
            var connectedClusterData = new ConnectedClusterData(DefaultLocation, new ManagedServiceIdentity("SystemAssigned"), "MIICYzCCAcygAwIBAgIBADANBgkqhkiG9w0BAQUFADAuMQswCQYDVQQGEwJVUzEMMAoGA1UEChMDSUJNMREwDwYDVQQLEwhMb2NhbCBDQTAeFw05OTEyMjIwNTAwMDBaFw0wMDEyMjMwNDU5NTlaMC4xCzAJBgNVBAYTAlVTMQwwCgYDVQQKEwNJQk0xETAPBgNVBAsTCExvY2FsIENBMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQD2bZEo7xGaX2/0GHkrNFZvlxBou9v1Jmt/PDiTMPve8r9FeJAQ0QdvFST/0JPQYD20rH0bimdDLgNdNynmyRoS2S/IInfpmf69iyc2G0TPyRvmHIiOZbdCd+YBHQi1adkj17NDcWj6S14tVurFX73zx0sNoMS79q3tuXKrDsxeuwIDAQABo4GQMIGNMEsGCVUdDwGG+EIBDQQ+EzxHZW5lcmF0ZWQgYnkgdGhlIFNlY3VyZVdheSBTZWN1cml0eSBTZXJ2ZXIgZm9yIE9TLzM5MCAoUkFDRikwDgYDVR0PAQH/BAQDAgAGMA8GA1UdEwEB/wQFMAMBAf8wHQYDVR0OBBYEFJ3+ocRyCTJw067dLSwr/nalx6YMMA0GCSqGSIb3DQEBBQUAA4GBAMaQzt+zaj1GU77yzlr8iiMBXgdQrwsZZWJo5exnAucJAEYQZmOfyLiM D6oYq+ZnfvM0n8G/Y79q8nhwvuxpYOnRSAXFp6xSkrIOeZtJMY1h00LKp/JX3Ng1svZ2agE126JHsQ0bhzN5TKsYfbwfTwfjdWAGy6Vf1nYi/rO+ryMO");
            var connectedCluster = (await connectedClusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectedClusterName, connectedClusterData)).Value;
            var configCollection = rg.GetKubernetesClusterExtensions("Microsoft.Kubernetes", "connectedClusters", connectedCluster.Data.Name);
            KubernetesClusterExtensionData configData = new KubernetesClusterExtensionData()
            {
                ExtensionType = "azuremonitor-containers",
                AutoUpgradeMinorVersion = true,
                //ReleaseTrain = "Preview",
                Scope = new KubernetesClusterExtensionScope()
                {
                    ClusterReleaseNamespace = "kube-system",
                },
                ConfigurationSettings =
{
["omsagent.env.clusterName"] = "clusterName1",
["omsagent.secret.wsid"] = "a38cef99-5a89-52ed-b6db-22095c23664b",
},
                ConfigurationProtectedSettings =
{
["omsagent.secret.key"] = "secretKeyValue01",
},
            };
            var config = (await configCollection.CreateOrUpdateAsync(WaitUntil.Completed, configName, configData)).Value;
            var customlocationCollection = rg.GetCustomLocations();
            var customlocationdata = new CustomLocationData(DefaultLocation)
            {
                HostResourceId = connectedCluster.Id,
                ClusterExtensionIds = { config.Id },
                HostType = CustomLocationHostType.Kubernetes,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Namespace = Recording.GenerateAssetName("clnamespace-"),
                DisplayName = Recording.GenerateAssetName("cltest-"),
                Authentication = null
            };
            var customLocation = (await customlocationCollection.CreateOrUpdateAsync(WaitUntil.Completed, extendName, customlocationdata)).Value;
            var data = ResourceDataHelpers.GetEnvironmentData(customLocation.Id);

            //1.Create
            var containerAppConnectedEnvironmentCollection = rg.GetContainerAppConnectedEnvironments();
            var envResource_lro = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, "examplekenv", data);
            var envResource = envResource_lro.Value;
            Assert.AreEqual(envName, envResource.Data.Name);
            //2.Get
            var resource2 = await envResource.GetAsync();
            ResourceDataHelpers.AssertEnviroment(envResource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName2, data);
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName3, data);
            int count = 0;
            await foreach (var num in containerAppConnectedEnvironmentCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await containerAppConnectedEnvironmentCollection.ExistsAsync(envName));
            Assert.IsFalse(await containerAppConnectedEnvironmentCollection.ExistsAsync(envName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await containerAppConnectedEnvironmentCollection.ExistsAsync(null));
            //Resource
            //5.Get
            var resource3 = await envResource.GetAsync();
            ResourceDataHelpers.AssertEnviroment(envResource.Data, resource3.Value.Data);
            //6.Delete
            await envResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
