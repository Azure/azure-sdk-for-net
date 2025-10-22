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

            Assert.NotNull(notifications);
            Assert.AreEqual(7, notifications.Count);

            var firstNotification = notifications.FirstOrDefault();
            Assert.NotNull(firstNotification);
            Assert.NotNull(firstNotification.Data.Title);
            Assert.NotNull(firstNotification.Data.Recipients);
            Assert.IsEmpty(firstNotification.Data.Recipients.Emails);
            Assert.IsEmpty(firstNotification.Data.Recipients.Users);
            Assert.NotNull(firstNotification.Data.Description);

            // add a recipient to the notification
            string userEmail = "contoso@microsoft.com";
            var recipientEmailContract = (await firstNotification.CreateOrUpdateNotificationRecipientEmailAsync(userEmail)).Value;

            Assert.NotNull(recipientEmailContract);
            Assert.AreEqual(userEmail, recipientEmailContract.Email);

            // get the notification details
            var notificationContract = (await collection.GetAsync(firstNotification.Data.Name)).Value;
            Assert.NotNull(notificationContract);
            Assert.NotNull(notificationContract.Data.Recipients);
            Assert.IsEmpty(notificationContract.Data.Recipients.Users);
            Assert.AreEqual(notificationContract.Data.Recipients.Emails.Count, 1);

            // delete the recipient email
            await notificationContract.DeleteNotificationRecipientEmailAsync(userEmail);

            // check the recipient exists
            var resultFalse = (await firstNotification.CheckNotificationRecipientEmailEntityExistsAsync(userEmail)).Value;
            Assert.IsFalse(resultFalse);

            var userCollection = ApiServiceResource.GetApiManagementUsers();
            var listUsersResponse = await userCollection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listUsersResponse);
            Assert.AreEqual(listUsersResponse.Count, 1);

            // add a recipient to the notification
            var recipientUserContract = (await firstNotification.CreateOrUpdateNotificationRecipientUserAsync(listUsersResponse.FirstOrDefault().Data.Name)).Value;

            Assert.NotNull(recipientUserContract);
            Assert.AreEqual(listUsersResponse.First().Id, recipientUserContract.UserId);

            // get the notification details
            notificationContract = (await collection.GetAsync(firstNotification.Data.Name)).Value;
            Assert.NotNull(notificationContract);
            Assert.NotNull(notificationContract.Data.Recipients);
            Assert.AreEqual(notificationContract.Data.Recipients.Users.Count, 1);

            // delete the recipient user
            await notificationContract.DeleteNotificationRecipientUserAsync(listUsersResponse.FirstOrDefault().Data.Name);

            // check the recipient exists
            resultFalse = (await firstNotification.CheckNotificationRecipientUserEntityExistsAsync(listUsersResponse.FirstOrDefault().Data.Name)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}
