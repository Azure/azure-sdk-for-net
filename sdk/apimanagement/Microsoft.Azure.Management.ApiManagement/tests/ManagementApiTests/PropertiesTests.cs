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
                    var createParameters = new NamedValueCreateContract(propertyDisplayName, propertyValue);

                    // create a property
                    var propertyResponse = testBase.client.NamedValue.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId,
                        createParameters);

                    ValidateProperty(propertyResponse, testBase, propertyId, propertyDisplayName, propertyValue, false);

                    // get the property
                    var getResponse = testBase.client.NamedValue.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId);

                    ValidateProperty(propertyResponse, testBase, propertyId, propertyDisplayName, propertyValue, false);

                    // create  secret property
                    string secretPropertyDisplayName = TestUtilities.GenerateName("secretPropertydisplay");
                    string secretPropertyValue = TestUtilities.GenerateName("secretPropertyValue");
                    List<string> tags = new List<string> { "secret" };
                    var secretCreateParameters = new NamedValueCreateContract(secretPropertyDisplayName, secretPropertyValue)
                    {
                        Secret = true,
                        Tags = tags
                    };

                    var secretPropertyResponse = testBase.client.NamedValue.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        secretCreateParameters);

                    ValidateProperty(secretPropertyResponse, testBase, secretPropertyId, secretPropertyDisplayName, secretPropertyValue, true);

                    var secretValueResponse = testBase.client.NamedValue.ListValue(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId);

                    Assert.Equal(secretPropertyValue, secretValueResponse.Value);

                    // list the properties
                    var listResponse = testBase.client.NamedValue.ListByService(testBase.rgName, testBase.serviceName, null);
                    Assert.NotNull(listResponse);

                    Assert.Equal(2, listResponse.Count());

                    // delete a property
                    testBase.client.NamedValue.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        propertyId,
                        "*");

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.NamedValue.Get(testBase.rgName, testBase.serviceName, propertyId));

                    // get the property etag
                    var propertyTag = await testBase.client.NamedValue.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId);
                    Assert.NotNull(propertyTag);
                    Assert.NotNull(propertyTag.ETag);

                    // patch the secret property
                    var updateProperty = new NamedValueUpdateParameters()
                    {
                        Secret = false
                    };
                    testBase.client.NamedValue.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        updateProperty,
                        propertyTag.ETag);

                    // check it is patched
                    var secretResponse = await testBase.client.NamedValue.GetAsync(
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
                    testBase.client.NamedValue.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        secretPropertyId,
                        "*");

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.NamedValue.Get(testBase.rgName, testBase.serviceName, secretPropertyId));
                }
                finally
                {
                    testBase.client.NamedValue.Delete(testBase.rgName, testBase.serviceName, propertyId, "*");
                    testBase.client.NamedValue.Delete(testBase.rgName, testBase.serviceName, secretPropertyId, "*");
                }
            }
        }

        static void ValidateProperty(
            NamedValueContract contract,
            ApiManagementTestBase testBase,
            string propertyId,
            string propertyDisplayName,
            string propertyValue,
            bool isSecret,
            List<string> tags = null)
        {
            Assert.NotNull(contract);
            Assert.Equal(propertyDisplayName, contract.DisplayName);
            if (isSecret)
            {
                Assert.Null(contract.Value);
            }
            else
            {
                Assert.Equal(propertyValue, contract.Value);
            }
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
