// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiVersionSetTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there is no api-version-set initially
                var versionSetlistResponse = await testBase.client.ApiVersionSet.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(versionSetlistResponse);
                Assert.Empty(versionSetlistResponse);
                Assert.Null(versionSetlistResponse.NextPageLink);

                string newversionsetid = TestUtilities.GenerateName("apiversionsetid");
                const string paramName = "x-ms-sdk-version";

                try
                {
                    var createVersionSetContract = new ApiVersionSetContract()
                    {
                        DisplayName = TestUtilities.GenerateName("versionset"),
                        Description = TestUtilities.GenerateName("versionsetdescript"),
                        VersioningScheme = VersioningScheme.Header,
                        VersionHeaderName = paramName
                    };
                    var versionSetContract = await testBase.client.ApiVersionSet.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid,
                        createVersionSetContract);
                    Assert.NotNull(versionSetContract);
                    Assert.Equal(createVersionSetContract.DisplayName, versionSetContract.DisplayName);
                    Assert.Equal(createVersionSetContract.Description, versionSetContract.Description);
                    Assert.Equal(createVersionSetContract.VersioningScheme, VersioningScheme.Header);
                    Assert.Equal(createVersionSetContract.VersionHeaderName, versionSetContract.VersionHeaderName);
                    Assert.Null(versionSetContract.VersionQueryName);

                    // get the etag
                    var versionSetTag = await testBase.client.ApiVersionSet.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid);
                    Assert.NotNull(versionSetTag);
                    Assert.NotNull(versionSetTag.ETag);

                    // update the version set contract to change versioning scheme
                    var versionSetUpdateParams = new ApiVersionSetUpdateParameters()
                    {
                        VersioningScheme = VersioningScheme.Query,
                        VersionQueryName = paramName,
                        VersionHeaderName = null
                    };
                    await testBase.client.ApiVersionSet.UpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid,
                        versionSetUpdateParams,
                        versionSetTag.ETag);

                    // do a get on the contract
                    versionSetContract = await testBase.client.ApiVersionSet.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid);
                    Assert.NotNull(versionSetContract);
                    Assert.Equal(VersioningScheme.Query, versionSetContract.VersioningScheme);
                    Assert.Equal(paramName, versionSetContract.VersionQueryName);

                    // get the etag again
                    versionSetTag = await testBase.client.ApiVersionSet.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid);
                    Assert.NotNull(versionSetTag);
                    Assert.NotNull(versionSetTag.ETag);

                    // now delete it
                    await testBase.client.ApiVersionSet.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newversionsetid,
                        versionSetTag.ETag);

                    // get the deleted apiversionset to make sure it was deleted
                    try
                    {
                        testBase.client.ApiVersionSet.Get(testBase.rgName, testBase.serviceName, newversionsetid);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    await testBase.client.ApiVersionSet.DeleteAsync(
                       testBase.rgName,
                       testBase.serviceName,
                       newversionsetid,
                       "*");
                }
            }
        }
    }
}
