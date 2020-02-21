// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.IO;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiExportImportTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public void SwaggerTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
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
                        Format = ContentFormat.SwaggerJson,
                        Value = swaggerApiContent
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
                    Assert.NotNull(swaggerExport.Value.Link);
                    Assert.Equal("swagger-link-json", swaggerExport.ExportResultFormat);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, swaggerApi, "*");
                }

            }
        }

        [Fact]
        [Trait("owner", "vifedo")]
        public void WadlTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
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
                        Format = ContentFormat.WadlXml,
                        Value = wadlApiContent
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
                    Assert.NotNull(wadlExport.Value.Link);
                    Assert.Equal("wadl-link-json", wadlExport.ExportResultFormat);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, wadlApi, "*");
                }
            }
        }

        [Fact]
        [Trait("owner", "vifedo")]
        public void WsdlTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
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
                        Format = ContentFormat.Wsdl,
                        Value = wsdlApiContent,
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

                    /* WSDL Export spits our broken Json 
                    ApiExportResult wsdlExport = testBase.client.ApiExport.Get(
                        testBase.rgName, 
                        testBase.serviceName, 
                        wsdlApi, 
                        ExportFormat.Wsdl);

                    Assert.NotNull(wsdlExport);
                    Assert.NotNull(wsdlExport.Value.Link);
                    Assert.Equal("wsdl-link+xml", wsdlExport.ExportResultFormat);
                    */
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

        [Fact]
        [Trait("owner", "vifedo")]
        public void OpenApiTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string openapiFilePath = "./Resources/petstore.yaml";
                const string path = "openapi3";
                string openApiId = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string openApiContent;
                    using (StreamReader reader = File.OpenText(openapiFilePath))
                    {
                        openApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        Format = ContentFormat.Openapi,
                        Value = openApiContent
                    };

                    var swaggerApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            openApiId,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, openApiId);

                    Assert.NotNull(getResponse);
                    Assert.Equal(openApiId, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Swagger Petstore", getResponse.DisplayName);
                    Assert.Equal("http://petstore.swagger.io/v1", getResponse.ServiceUrl);

                    ApiExportResult openApiExport = testBase.client.ApiExport.Get(testBase.rgName, testBase.serviceName, openApiId, ExportFormat.Openapi);

                    Assert.NotNull(openApiExport);
                    Assert.NotNull(openApiExport.Value.Link);
                    Assert.Equal("openapi-link", openApiExport.ExportResultFormat);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, openApiId, "*");
                }

            }
        }

        [Fact]
        public void OpenApiInJsonTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string openapiFilePath = "./Resources/petstoreOpenApi.json";
                const string path = "openapi4";
                string openApiId = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string openApiContent;
                    using (StreamReader reader = File.OpenText(openapiFilePath))
                    {
                        openApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        Format = ContentFormat.Openapijson,
                        Value = openApiContent
                    };

                    var swaggerApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            openApiId,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, openApiId);

                    Assert.NotNull(getResponse);
                    Assert.Equal(openApiId, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Swagger Petstore", getResponse.DisplayName);
                    Assert.Equal("http://petstore.swagger.io/v2", getResponse.ServiceUrl);

                    ApiExportResult openApiExport = testBase.client.ApiExport.Get(testBase.rgName, testBase.serviceName, openApiId, ExportFormat.Openapi);

                    Assert.NotNull(openApiExport);
                    Assert.NotNull(openApiExport.Value.Link);
                    Assert.Equal("openapi-link", openApiExport.ExportResultFormat);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, openApiId, "*");
                }

            }
        }
    }
}
