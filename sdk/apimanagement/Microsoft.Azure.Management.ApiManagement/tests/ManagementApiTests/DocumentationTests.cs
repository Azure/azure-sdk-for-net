// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;


using ApiManagement.Tests;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class DocumentationTests : TestBase
    {
        [Fact]
        [Trait("owner", "malincrist")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var listResponse = testBase.client.Documentation.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.Empty(listResponse);
                Assert.Null(listResponse.NextPageLink);


                var documentationId = TestUtilities.GenerateName("newDocumentation");

                try
                {
                    var documentationTitle = TestUtilities.GenerateName("documentationTitle");
                    var documentationContent = TestUtilities.GenerateName("documentationContent");

                    var createParameters = new DocumentationContract()
                    {
                        Title = documentationTitle,
                        Content = documentationContent
                    };

                    var createResponse = testBase.client.Documentation.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId,
                        createParameters);

                    Assert.NotNull(createResponse);
                    Assert.Equal(documentationContent, createResponse.Content);
                    Assert.Equal(documentationTitle, createResponse.Title);

                    // get async
                    var documentationTag = await testBase.client.Documentation.GetEntityTagAsync(
                          testBase.rgName,
                        testBase.serviceName,
                        documentationId);

                    Assert.NotNull(documentationTag);

                    // update documentation
                    var updateTitle = TestUtilities.GenerateName("documentationTitle");
                    var updateContent = TestUtilities.GenerateName("documentationContent");

                    var updateParameters = new DocumentationUpdateContract()
                    {
                        Title = updateTitle,
                        Content = updateContent
                    };

                    testBase.client.Documentation.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId,
                        updateParameters,
                        documentationTag.ETag);

                    // get to check it was updated
                    var getUpdatedResponse = testBase.client.Documentation.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId);

                    Assert.NotNull(getUpdatedResponse);
                    Assert.Equal(updateContent, getUpdatedResponse.Content);
                    Assert.Equal(updateTitle, getUpdatedResponse.Title);

                    // check listing documentation
                    var documentationList = await testBase.client.Documentation.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<DocumentationContract> { Top = 1 });

                    Assert.NotNull(documentationList);
                    Assert.Single(documentationList);
                    Assert.Equal(updateTitle, documentationList.First().Title);
                    Assert.Equal(updateContent, documentationList.First().Content);
                    Assert.Null(documentationList.NextPageLink);

                    // delete documentation
                    documentationTag = await testBase.client.Documentation.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId);

                    Assert.NotNull(documentationTag);

                    testBase.client.Documentation.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId,
                        documentationTag.ETag);

                    // get the deleted documentation to make sure it is deleted
                    Assert.Throws<ErrorResponseException>(() =>
                    testBase.client.Documentation.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId));
                }
                finally
                {
                    testBase.client.Documentation.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        documentationId,
                        "*");
                }
            }
        }
    }
}
