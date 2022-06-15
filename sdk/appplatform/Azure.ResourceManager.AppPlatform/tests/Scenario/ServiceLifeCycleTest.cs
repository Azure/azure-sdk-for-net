// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppPlatform.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppPlatform.Tests.Scenario
{
    public class ServiceLifeCycleTest : AppPlatformManagementTestBase
    {
        public ServiceLifeCycleTest(bool isAsync) : base(isAsync)
        {
        }

        public ServiceLifeCycleTest(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestServiceLifeCycle()
        {
            string rgName = Recording.GenerateAssetName("appplatform-sdk-test-rg");
            string serviceName = Recording.GenerateAssetName("appplatform-sdk-test-asc");
            string appName = Recording.GenerateAssetName("appplatform-sdk-test-app");
            string deploymentName = Recording.GenerateAssetName("default");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            var rgResource = await CreateResourceGroup(subscription, rgName);
            string resourceId = $"/subscriptions/{subscription.Id}/resourceGroups/{rgName}/providers/Microsoft.AppPlatform/Spring/{serviceName}";
            var id = new ResourceIdentifier(resourceId);
            var serviceData = new AppPlatformServiceResourceData(AzureLocation.EastUS);
            await rgResource.GetAppPlatformServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, serviceName, serviceData);
            AppPlatformServiceResource service = await rgResource.GetAppPlatformServiceResources().GetAsync(serviceName);
            Assert.NotNull(service);

            var appData = new AppPlatformAppResourceData();
            var appOp = await service.GetAppPlatformAppResources().CreateOrUpdateAsync(WaitUntil.Completed, appName, appData);
            AppPlatformAppResource app = null;
            if (appOp.HasValue)
            {
                app = appOp.Value;
            }
            Assert.NotNull(app);

            var deployData = new AppDeploymentResourceData()
            {
                Properties = new DeploymentResourceProperties()
                {
                    Source = new JarUploadedUserSourceInfo()
                },
            };

            AppDeploymentResource deploymentResource = null;
            var deployOp = await app.GetAppDeploymentResources().CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, deployData);
            if (deployOp.HasValue)
            {
                deploymentResource = deployOp.Value;
            }
            Assert.NotNull(deploymentResource);

            await service.DeleteAsync(WaitUntil.Completed);

            await rgResource.GetAppPlatformServiceResources().GetAsync(serviceName);

            await rgResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
