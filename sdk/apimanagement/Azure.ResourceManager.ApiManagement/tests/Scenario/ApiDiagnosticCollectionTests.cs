// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiDiagnosticCollectionTests : ApiManagementManagementTestBase
    {
        public ApiDiagnosticCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiCollection Collection { get; set; }

        private ApiResource Resources { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync(AzureLocation.EastUS);
            VNetCollection = ResourceGroup.GetVirtualNetworks();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;

            Collection = ApiServiceResource.GetApis();
            var name = Recording.GenerateAssetName("testapi-");
            var content = new ApiCreateOrUpdateContent()
            {
                Description = "apidescription5200",
                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract()
                {
                    Header = "header4520",
                    Query = "query3037"
                },
                DisplayName = "apiname1463",
                ServiceLink = "http://newechoapi.cloudapp.net/api",
                Path = "newapiPath",
                Protocols = { ApiOperationInvokableProtocol.Https, ApiOperationInvokableProtocol.Http }
            };
            Resources = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, name, content)).Value;
        }

        [Test]
        public async Task CreateOrUpdate_GetAll_Get_Exists_Delete()
        {
            await CreateApiAsync();
            var collection = Resources.GetApiDiagnostics();
            var logColle = ApiServiceResource.GetApiManagementLoggers();
            var logData = new ApiManagementLoggerData()
            {
                LoggerType = LoggerType.ApplicationInsights,
                Description = "adding a new logger",
                Credentials = { { "instrumentationKey", "4fc0bf44-3517-4ef3-b615-4a5b09362400" } }
            };
            var logResource = await logColle.CreateOrUpdateAsync(WaitUntil.Completed, "azuremonitor", logData);
            var data = new DiagnosticContractData()
            {
                AlwaysLog = AlwaysLog.AllErrors,
                LoggerId = "/loggers/azuremonitor",
                Sampling = new SamplingSettings() { Percentage = 50, SamplingType = SamplingType.Fixed },
                Frontend = new PipelineDiagnosticSettings()
                {
                    Request = new HttpMessageDiagnostic()
                    {
                        Headers = { "Content-type" },
                        Body = new BodyDiagnosticSettings() { Bytes = 512 }
                    },
                    Response = new HttpMessageDiagnostic()
                    {
                        Headers = { "Content-type" },
                        Body = new BodyDiagnosticSettings() { Bytes = 512 }
                    }
                },
                Backend = new PipelineDiagnosticSettings()
                {
                    Request = new HttpMessageDiagnostic()
                    {
                        Headers = { "Content-type" },
                        Body = new BodyDiagnosticSettings() { Bytes = 512 }
                    },
                    Response = new HttpMessageDiagnostic()
                    {
                        Headers = { "Content-type" },
                        Body = new BodyDiagnosticSettings() { Bytes = 512 }
                    }
                },
            };
            var result = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, "applicationinsights", data)).Value;
            Assert.That(result.Data.Name, Is.EqualTo("applicationinsights"));
            Assert.That(result.Data.Frontend.Response.Headers.FirstOrDefault(), Is.EqualTo("Content-type"));

            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.GreaterThanOrEqualTo(1));

            result = await collection.GetAsync("applicationinsights");
            Assert.That(result.Data, Is.Not.Null);

            var resultTrue = (await collection.ExistsAsync("applicationinsights")).Value;
            var resultFalse = (await collection.ExistsAsync("foo")).Value;
            Assert.That(resultTrue, Is.True);
            Assert.That(resultFalse, Is.False);

            var resultNew = await result.GetAsync();
            Assert.That(resultNew.Value.Data, Is.Not.Null);

            await resultNew.Value.DeleteAsync(WaitUntil.Completed, ETag.All);
            resultFalse = (await collection.ExistsAsync("applicationinsights")).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
