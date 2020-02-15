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
using System.Collections.Generic;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class PropertiesTest : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                string propertyId = TestUtilities.GenerateName("newproperty");
                string secretPropertyId = TestUtilities.GenerateName("secretproperty");

                try
                {
                    string propertyDisplayName = TestUtilities.GenerateName("propertydisplay");
                    string propertyValue = TestUtilities.GenerateName("propertyValue");
                    var createParameters = new PropertyContract(propertyDisplayName, propertyValue);

                    // create a property
                    var propertyResponse = testBase.client.Property.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId,
                        createParameters);

                    ValidateProperty(propertyResponse, testBase, propertyId, propertyDisplayName, propertyValue, false);

                    // get the property
                    var getResponse = testBase.client.Property.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId);

                    ValidateProperty(propertyResponse, testBase, propertyId, propertyDisplayName, propertyValue, false);

                    // create  secret property
                    string secretPropertyDisplayName = TestUtilities.GenerateName("secretPropertydisplay");
                    string secretPropertyValue = TestUtilities.GenerateName("secretPropertyValue");
                    List<string> tags = new List<string> { "secret" };
                    var secretCreateParameters = new PropertyContract(secretPropertyDisplayName, secretPropertyValue)
                    {
                        Secret = true,
                        Tags = tags
                    };

                    var secretPropertyResponse = testBase.client.Property.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        secretCreateParameters);

                    ValidateProperty(secretPropertyResponse, testBase, secretPropertyId, secretPropertyDisplayName, secretPropertyValue, true);

                    // list the properties
                    var listResponse = testBase.client.Property.ListByService(testBase.rgName, testBase.serviceName, null);
                    Assert.NotNull(listResponse);
                    Assert.Equal(2, listResponse.Count());

                    // delete a property
                    testBase.client.Property.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId,
                        "*");

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Property.Get(testBase.rgName, testBase.serviceName, propertyId));

                    // get the property etag
                    var propertyTag = await testBase.client.Property.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId);
                    Assert.NotNull(propertyTag);
                    Assert.NotNull(propertyTag.ETag);

                    // patch the secret property
                    var updateProperty = new PropertyUpdateParameters()
                    {
                        Secret = false
                    };
                    testBase.client.Property.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        updateProperty,
                        propertyTag.ETag);

                    // check it is patched
                    var secretResponse = await testBase.client.Property.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId);

                    ValidateProperty(
                        secretResponse,
                        testBase,
                        secretPropertyId,
                        secretPropertyDisplayName,
                        secretPropertyValue,
                        false);

                    // delete this property
                    testBase.client.Property.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        "*");

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Property.Get(testBase.rgName, testBase.serviceName, secretPropertyId));
                }
                finally
                {
                    testBase.client.Property.Delete(testBase.rgName, testBase.serviceName, propertyId, "*");
                    testBase.client.Property.Delete(testBase.rgName, testBase.serviceName, secretPropertyId, "*");
                }
            }
        }

        static void ValidateProperty(
            PropertyContract contract,
            ApiManagementTestBase testBase,
            string propertyId,
            string propertyDisplayName,
            string propertyValue,
            bool isSecret,
            List<string> tags = null)
        {
            Assert.NotNull(contract);
            Assert.Equal(propertyDisplayName, contract.DisplayName);
            Assert.Equal(propertyValue, contract.Value);
            Assert.Equal(isSecret, contract.Secret);
            Assert.Equal(propertyId, contract.Name);
            if (tags != null)
            {
                Assert.NotNull(contract.Tags);
                Assert.Equal(tags.Count, contract.Tags.Count);
            }
        }
    }
}
