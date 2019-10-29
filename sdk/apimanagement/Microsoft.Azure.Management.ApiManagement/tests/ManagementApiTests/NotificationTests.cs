// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class NotificationTests : TestBase
    {
        [Fact]
        public async Task UpdateDeleteRecipientEmail()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var notifications = testBase.client.Notification.ListByService(testBase.rgName, testBase.serviceName);

                Assert.NotNull(notifications);
                Assert.Equal(7, notifications.Count());

                var firstNotification = notifications.First();
                Assert.NotNull(firstNotification);
                Assert.NotNull(firstNotification.Title);
                Assert.NotNull(firstNotification.Recipients);
                Assert.Empty(firstNotification.Recipients.Emails);
                Assert.Empty(firstNotification.Recipients.Users);
                Assert.NotNull(firstNotification.Description);

                try
                {
                    // add a recipient to the notification
                    string userEmail = "contoso@microsoft.com";
                    var recipientEmailContract = await testBase.client.NotificationRecipientEmail.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        userEmail);

                    Assert.NotNull(recipientEmailContract);
                    Assert.Equal(userEmail, recipientEmailContract.Email);

                    // check the recipient exists
                    await testBase.client.NotificationRecipientEmail.CheckEntityExistsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        userEmail);

                    // get the notification details
                    var notificationContract = await testBase.client.Notification.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name);
                    Assert.NotNull(notificationContract);
                    Assert.NotNull(notificationContract.Recipients);
                    Assert.Empty(notificationContract.Recipients.Users);
                    Assert.Single(notificationContract.Recipients.Emails);

                    // delete the recipient email
                    await testBase.client.NotificationRecipientEmail.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        userEmail);

                    await testBase.client.NotificationRecipientEmail.CheckEntityExistsAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            firstNotification.Name,
                            userEmail);
                }
                finally
                {

                }
            }
        }

        [Fact]
        public async Task UpdateDeleteRecipientUser()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var notifications = testBase.client.Notification.ListByService(testBase.rgName, testBase.serviceName);

                Assert.NotNull(notifications);
                Assert.Equal(7, notifications.Count());

                var firstNotification = notifications.First();
                Assert.NotNull(firstNotification);
                Assert.NotNull(firstNotification.Title);
                Assert.NotNull(firstNotification.Recipients);
                Assert.Empty(firstNotification.Recipients.Users);
                Assert.Empty(firstNotification.Recipients.Emails);
                Assert.NotNull(firstNotification.Description);

                var listUsersResponse = testBase.client.User.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listUsersResponse);
                Assert.Single(listUsersResponse);

                try
                {
                    // add a recipient to the notification
                    var recipientUserContract = await testBase.client.NotificationRecipientUser.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        listUsersResponse.First().Name);

                    Assert.NotNull(recipientUserContract);
                    Assert.Equal(listUsersResponse.First().Id, recipientUserContract.UserId);

                    // check the recipient exists
                    await testBase.client.NotificationRecipientUser.CheckEntityExistsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        listUsersResponse.First().Name);

                    // get the notification details
                    var notificationContract = await testBase.client.Notification.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name);
                    Assert.NotNull(notificationContract);
                    Assert.NotNull(notificationContract.Recipients);
                    Assert.Single(notificationContract.Recipients.Users);
                    Assert.Empty(notificationContract.Recipients.Emails);

                    // delete the recipient email
                    await testBase.client.NotificationRecipientUser.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstNotification.Name,
                        listUsersResponse.First().Name);

                    await testBase.client.NotificationRecipientUser.CheckEntityExistsAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            firstNotification.Name,
                            listUsersResponse.First().Name);
                }
                finally
                {

                }
            }
        }
    }
}
