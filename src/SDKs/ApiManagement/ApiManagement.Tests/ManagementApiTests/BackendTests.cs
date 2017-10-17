// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class BackendTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // create new group with default parameters
                string backendId = TestUtilities.GenerateName("backendid");
                try
                {
                    string backendName = TestUtilities.GenerateName("backendName");
                    string urlParameter = new UriBuilder("https", backendName, 443).Uri.ToString();

                    var backendCreateParameters = new BackendContract(urlParameter, BackendProtocol.Http);
                    backendCreateParameters.Description = TestUtilities.GenerateName("description");
                    backendCreateParameters.Tls = new BackendTlsProperties(
                        validateCertificateChain: true,
                        validateCertificateName: true);
                    backendCreateParameters.Credentials = new BackendCredentialsContract();
                    backendCreateParameters.Credentials.Authorization = new BackendAuthorizationHeaderCredentials()
                    {
                        Parameter = "opensemame",
                        Scheme = "basic"
                    };
                    backendCreateParameters.Credentials.Query = new Dictionary<string, IList<string>>();
                    backendCreateParameters.Credentials.Query.Add("sv", new List<string> { "xx", "bb", "cc" });
                    backendCreateParameters.Credentials.Header = new Dictionary<string, IList<string>>();
                    backendCreateParameters.Credentials.Header.Add("x-my-1", new List<string> { "val1", "val2" });

                    var backendResponse = testBase.client.Backend.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        backendCreateParameters);

                    Assert.NotNull(backendResponse);

                    // get to check it was created
                    var getResponse = await testBase.client.Backend.GetWithHttpMessagesAsync(testBase.rgName, testBase.serviceName, backendId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Body);
                    Assert.NotNull(getResponse.Headers);
                    Assert.Equal(backendId, getResponse.Body.Name);
                    Assert.NotNull(getResponse.Body.Description);
                    Assert.NotNull(getResponse.Body.Credentials.Authorization);
                    Assert.NotNull(getResponse.Body.Credentials.Query);
                    Assert.NotNull(getResponse.Body.Credentials.Header);
                    Assert.Equal(BackendProtocol.Http, getResponse.Body.Protocol);
                    Assert.Equal(1, getResponse.Body.Credentials.Query.Keys.Count);
                    Assert.Equal(1, getResponse.Body.Credentials.Header.Keys.Count);
                    Assert.NotNull(getResponse.Body.Credentials.Authorization);
                    Assert.Equal("basic", getResponse.Body.Credentials.Authorization.Scheme);

                    var listBackends = testBase.client.Backend.ListByService(testBase.rgName, testBase.serviceName, null);

                    Assert.NotNull(listBackends);

                    // there should be one user
                    Assert.True(listBackends.Count() >= 1);

                    // patch backend
                    string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                    testBase.client.Backend.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        new BackendUpdateParameters()
                        {
                            Description = patchedDescription
                        },
                        getResponse.Headers.ETag);

                    // get to check it was patched
                    var backendGetResponse = await testBase.client.Backend.GetWithHttpMessagesAsync(testBase.rgName, testBase.serviceName, backendId);

                    Assert.NotNull(backendGetResponse);
                    Assert.Equal(backendId, backendGetResponse.Body.Name);
                    Assert.Equal(patchedDescription, backendGetResponse.Body.Description);

                    // delete the backend
                    testBase.client.Backend.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        backendGetResponse.Headers.ETag);

                    // get the deleted backend to make sure it was deleted
                    try
                    {
                        testBase.client.Backend.Get(testBase.rgName, testBase.serviceName, backendId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Backend.Delete(testBase.rgName, testBase.serviceName, backendId, "*");
                }
            }
        }

        [Fact]
        public async Task ServiceFabricCreateUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // create new group with default parameters
                string backendId = TestUtilities.GenerateName("sfbackend");
                string certificateId = TestUtilities.GenerateName("certificateId");
                try
                {
                    var base64ArrayCertificate = Convert.FromBase64String(testBase.base64EncodedTestCertificateData);
                    var cert = new X509Certificate2(base64ArrayCertificate, testBase.testCertificatePassword);

                    var createResponse = testBase.client.Certificate.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        certificateId,
                        new CertificateCreateOrUpdateParameters
                        {
                            Data = testBase.base64EncodedTestCertificateData,
                            Password = testBase.testCertificatePassword
                        },
                        null);

                    Assert.NotNull(createResponse);
                    Assert.Equal(certificateId, createResponse.Name);


                    string backendName = TestUtilities.GenerateName("backendName");
                    string urlParameter = new UriBuilder("https", backendName, 443).Uri.ToString();

                    var backendCreateParameters = new BackendContract(urlParameter, BackendProtocol.Http);
                    backendCreateParameters.Description = TestUtilities.GenerateName("description");
                    backendCreateParameters.Properties = new BackendProperties();
                    backendCreateParameters.Properties.ServiceFabricCluster = new BackendServiceFabricClusterProperties();
                    backendCreateParameters.Properties.ServiceFabricCluster.ClientCertificatethumbprint = cert.Thumbprint;
                    backendCreateParameters.Properties.ServiceFabricCluster.ManagementEndpoints = new List<string>();
                    backendCreateParameters.Properties.ServiceFabricCluster.ManagementEndpoints.Add(urlParameter);
                    backendCreateParameters.Properties.ServiceFabricCluster.MaxPartitionResolutionRetries = 5;
                    backendCreateParameters.Properties.ServiceFabricCluster.ServerX509Names = new List<X509CertificateName>();
                    backendCreateParameters.Properties.ServiceFabricCluster.ServerX509Names.Add(new X509CertificateName("serverCommonName1", "issuerThumbprint1"));

                    var backendResponse = testBase.client.Backend.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        backendCreateParameters);

                    Assert.NotNull(backendResponse);

                    // get to check it was created
                    var getResponse = await testBase.client.Backend.GetWithHttpMessagesAsync(testBase.rgName, testBase.serviceName, backendId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Body);
                    Assert.NotNull(getResponse.Headers);
                    Assert.Equal(backendId, getResponse.Body.Name);
                    Assert.NotNull(getResponse.Body.Description);
                    Assert.NotNull(getResponse.Body.Properties.ServiceFabricCluster);
                    Assert.Equal(BackendProtocol.Http, getResponse.Body.Protocol);
                    Assert.Equal(1, getResponse.Body.Properties.ServiceFabricCluster.ServerX509Names.Count);
                    Assert.Equal(1, getResponse.Body.Properties.ServiceFabricCluster.ManagementEndpoints.Count);
                    Assert.Equal(5, getResponse.Body.Properties.ServiceFabricCluster.MaxPartitionResolutionRetries);

                    var listBackends = testBase.client.Backend.ListByService(testBase.rgName, testBase.serviceName, null);

                    Assert.NotNull(listBackends);

                    // there should be one user
                    Assert.True(listBackends.Count() >= 1);

                    // patch backend
                    string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                    testBase.client.Backend.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        new BackendUpdateParameters()
                        {
                            Description = patchedDescription
                        },
                        getResponse.Headers.ETag);

                    // get to check it was patched
                    var backendGetResponse = await testBase.client.Backend.GetWithHttpMessagesAsync(testBase.rgName, testBase.serviceName, backendId);

                    Assert.NotNull(backendGetResponse);
                    Assert.Equal(backendId, backendGetResponse.Body.Name);
                    Assert.Equal(patchedDescription, backendGetResponse.Body.Description);

                    // delete the backend
                    testBase.client.Backend.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        backendId,
                        backendGetResponse.Headers.ETag);

                    // get the deleted backend to make sure it was deleted
                    try
                    {
                        testBase.client.Backend.Get(testBase.rgName, testBase.serviceName, backendId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Backend.Delete(testBase.rgName, testBase.serviceName, backendId, "*");
                    testBase.client.Certificate.Delete(testBase.rgName, testBase.serviceName, certificateId, "*");
                }
            }
        }
    }
}
