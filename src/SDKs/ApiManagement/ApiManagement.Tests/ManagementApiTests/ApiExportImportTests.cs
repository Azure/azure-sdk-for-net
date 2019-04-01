// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiExportImportTests : TestBase
    {
        [Fact]
        public void SwaggerTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string swaggerPath = "./Resources/SwaggerPetStoreV2.json";
                const string path = "swaggerApi";
                string swaggerApi = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string swaggerApiContent;
                    using (StreamReader reader = File.OpenText(swaggerPath))
                    {
                        swaggerApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        ContentFormat = ContentFormat.SwaggerJson,
                        ContentValue = swaggerApiContent
                    };

                    var swaggerApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            swaggerApi,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, swaggerApi);

                    Assert.NotNull(getResponse);
                    Assert.Equal(swaggerApi, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Swagger Petstore Extensive", getResponse.DisplayName);
                    Assert.Equal("http://petstore.swagger.wordnik.com/api", getResponse.ServiceUrl);

                    ApiExportResult swaggerExport = testBase.client.ApiExport.Get(testBase.rgName, testBase.serviceName, swaggerApi, ExportFormat.Swagger);

                    Assert.NotNull(swaggerExport);
                    Assert.NotNull(swaggerExport.Link);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, swaggerApi, "*");
                }

            }
        }

        [Fact]
        public void WadlTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string wadlPath = "./Resources/WADLYahoo.xml";
                const string path = "yahooWadl";
                string wadlApi = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string wadlApiContent;
                    using (StreamReader reader = File.OpenText(wadlPath))
                    {
                        wadlApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        ContentFormat = ContentFormat.WadlXml,
                        ContentValue = wadlApiContent
                    };

                    var wadlApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            wadlApi,
                            apiCreateOrUpdate);

                    Assert.NotNull(wadlApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, wadlApi);

                    Assert.NotNull(getResponse);
                    Assert.Equal(wadlApi, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Yahoo News Search", getResponse.DisplayName);
                    Assert.Equal("http://api.search.yahoo.com/NewsSearchService/V1/", getResponse.ServiceUrl);
                    Assert.True(getResponse.IsCurrent);
                    Assert.True(getResponse.Protocols.Contains(Protocol.Https));
                    Assert.Equal("1", getResponse.ApiRevision);

                    ApiExportResult wadlExport = testBase.client.ApiExport.Get(testBase.rgName, testBase.serviceName, wadlApi, ExportFormat.Wadl);

                    Assert.NotNull(wadlExport);
                    Assert.NotNull(wadlExport.Link);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, wadlApi, "*");
                }
            }
        }

        [Fact]
        public void WsdlTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string wsdlPath = "./Resources/Weather.wsdl";
                const string path = "weatherapi";
                string wsdlApi = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string wsdlApiContent;
                    using (StreamReader reader = File.OpenText(wsdlPath))
                    {
                        wsdlApiContent = reader.ReadToEnd();
                    }

                    // Exporting WSDL is only supported for Soap PassThrough APIs (Apis of Type:soap)
                    // Creating one.
                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        ContentFormat = ContentFormat.Wsdl,
                        ContentValue = wsdlApiContent,
                        SoapApiType = SoapApiType.SoapPassThrough, // create Soap Pass through API
                        WsdlSelector = new ApiCreateOrUpdatePropertiesWsdlSelector()
                        {
                            WsdlServiceName = "Weather",
                            WsdlEndpointName = "WeatherSoap"
                        }
                    };

                    var wsdlApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            wsdlApi,
                            apiCreateOrUpdate);

                    Assert.NotNull(wsdlApiResponse);
                    Assert.Equal(SoapApiType.SoapPassThrough, wsdlApiResponse.ApiType);

                    // get the api to check it was created
                    var apiContract = testBase.client.Api.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        wsdlApi);

                    Assert.NotNull(apiContract);
                    Assert.Equal(wsdlApi, apiContract.Name);
                    Assert.Equal(path, apiContract.Path);
                    Assert.Equal("Weather", apiContract.DisplayName);
                    Assert.Equal("http://wsf.cdyne.com/WeatherWS/Weather.asmx", apiContract.ServiceUrl);
                    Assert.True(apiContract.IsCurrent);
                    Assert.True(apiContract.Protocols.Contains(Protocol.Https));
                    Assert.Equal("1", apiContract.ApiRevision);

                    ApiExportResult wsdlExport = testBase.client.ApiExport.Get(
                        testBase.rgName, 
                        testBase.serviceName, 
                        wsdlApi, 
                        ExportFormat.Wsdl);

                    Assert.NotNull(wsdlExport);
                    Assert.NotNull(wsdlExport.Link);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        wsdlApi,
                        "*");
                }
            }
        }
    }
}
