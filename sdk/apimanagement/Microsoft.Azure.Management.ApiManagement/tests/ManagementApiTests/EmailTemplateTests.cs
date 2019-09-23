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

namespace ApiManagement.Tests.ManagementApiTests
{
    public class EmailTemplateTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var emailTemplates = testBase.client.EmailTemplate.ListByService(testBase.rgName, testBase.serviceName);

                Assert.NotNull(emailTemplates);
                Assert.Equal(14, emailTemplates.Count());

                var firstTemplate = emailTemplates.First();
                Assert.NotNull(firstTemplate);
                Assert.NotNull(firstTemplate.Name);
                Assert.NotNull(firstTemplate.Subject);
                Assert.NotNull(firstTemplate.Title);
                Assert.True(firstTemplate.IsDefault);

                try
                {
                    var publisherEmailTemplate = testBase.client.EmailTemplate.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        firstTemplate.Name,
                        new EmailTemplateUpdateParameters()
                        {
                            Subject = "New Subject"
                        });

                    Assert.NotNull(publisherEmailTemplate);

                    var publisherEmailTemplateResponse = await testBase.client.EmailTemplate.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstTemplate.Name);

                    Assert.NotNull(publisherEmailTemplateResponse);
                    Assert.Equal("New Subject", publisherEmailTemplateResponse.Body.Subject);
                    Assert.False(publisherEmailTemplateResponse.Body.IsDefault);
                    Assert.NotNull(publisherEmailTemplateResponse.Body.Body);
                    Assert.NotNull(publisherEmailTemplateResponse.Body.Parameters);
                    Assert.NotNull(publisherEmailTemplateResponse.Headers.ETag);

                    // reset the template to default
                    testBase.client.EmailTemplate.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        firstTemplate.Name,
                        publisherEmailTemplateResponse.Headers.ETag);

                    publisherEmailTemplate = testBase.client.EmailTemplate.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        firstTemplate.Name);

                    Assert.NotNull(publisherEmailTemplate);
                    Assert.True(publisherEmailTemplate.IsDefault);
                }
                finally
                {
                    testBase.client.EmailTemplate.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        firstTemplate.Name,
                        "*");
                }
            }
        }
    }
}
