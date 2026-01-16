// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class NotificationTests : ApiManagementManagementTestBase
    {
        public NotificationTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementNotifications();

            var notifications = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.That(notifications, Is.Not.Null);
            Assert.That(notifications.Count, Is.EqualTo(7));

            var firstNotification = notifications.FirstOrDefault();
            Assert.That(firstNotification, Is.Not.Null);
            Assert.That(firstNotification.Data.Title, Is.Not.Null);
            Assert.That(firstNotification.Data.Recipients, Is.Not.Null);
            Assert.That(firstNotification.Data.Recipients.Emails, Is.Empty);
            Assert.That(firstNotification.Data.Recipients.Users, Is.Empty);
            Assert.That(firstNotification.Data.Description, Is.Not.Null);

            // add a recipient to the notification
            string userEmail = "contoso@microsoft.com";
            var recipientEmailContract = (await firstNotification.CreateOrUpdateNotificationRecipientEmailAsync(userEmail)).Value;

            Assert.That(recipientEmailContract, Is.Not.Null);
            Assert.That(recipientEmailContract.Email, Is.EqualTo(userEmail));

            // get the notification details
            var notificationContract = (await collection.GetAsync(firstNotification.Data.Name)).Value;
            Assert.That(notificationContract, Is.Not.Null);
            Assert.That(notificationContract.Data.Recipients, Is.Not.Null);
            Assert.That(notificationContract.Data.Recipients.Users, Is.Empty);
            Assert.That(notificationContract.Data.Recipients.Emails.Count, Is.EqualTo(1));

            // delete the recipient email
            await notificationContract.DeleteNotificationRecipientEmailAsync(userEmail);

            // check the recipient exists
            var resultFalse = (await firstNotification.CheckNotificationRecipientEmailEntityExistsAsync(userEmail)).Value;
            Assert.That(resultFalse, Is.False);

            var userCollection = ApiServiceResource.GetApiManagementUsers();
            var listUsersResponse = await userCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(listUsersResponse, Is.Not.Null);
            Assert.That(listUsersResponse.Count, Is.EqualTo(1));

            // add a recipient to the notification
            var recipientUserContract = (await firstNotification.CreateOrUpdateNotificationRecipientUserAsync(listUsersResponse.FirstOrDefault().Data.Name)).Value;

            Assert.That(recipientUserContract, Is.Not.Null);
            Assert.That(recipientUserContract.UserId, Is.EqualTo(listUsersResponse.First().Id));

            // get the notification details
            notificationContract = (await collection.GetAsync(firstNotification.Data.Name)).Value;
            Assert.That(notificationContract, Is.Not.Null);
            Assert.That(notificationContract.Data.Recipients, Is.Not.Null);
            Assert.That(notificationContract.Data.Recipients.Users.Count, Is.EqualTo(1));

            // delete the recipient user
            await notificationContract.DeleteNotificationRecipientUserAsync(listUsersResponse.FirstOrDefault().Data.Name);

            // check the recipient exists
            resultFalse = (await firstNotification.CheckNotificationRecipientUserEntityExistsAsync(listUsersResponse.FirstOrDefault().Data.Name)).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
