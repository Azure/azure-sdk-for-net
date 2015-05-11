//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Net.Http;
using System.Collections.Generic;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSitesBackupTests : TestBase
    {
        public WebSiteManagementClient GetWebSiteManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            var client = new WebSiteManagementClient(token).WithHandler(handler);
            client = client.WithHandler(handler);
            return client;
        }

        [Fact]
        public void ListBackups()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.ListBackups)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.ListBackups("space1", "site1");

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate response 
            Assert.Equal(10, result.BackupItems.Count);

            var firstResult = result.BackupItems[0];
            Assert.Equal(firstResult.Status, BackupItemStatus.Succeeded);

            Assert.Equal("baysite_201408052247.zip", firstResult.BlobName);
            Assert.True(firstResult.Name.StartsWith("baysite_"));
            Assert.Equal(54503, firstResult.SizeInBytes);
            Assert.False(firstResult.Scheduled);
            Assert.True(firstResult.StorageAccountUrl.StartsWith("https://"));

            var dbResult = result.BackupItems[9];
            Assert.Equal("30d04e4b-adc2-4632-93ba-0dca15a5c778", dbResult.CorrelationId);
            Assert.Equal(1, dbResult.Databases.Count);
            Assert.Equal("MySql", dbResult.Databases[0].DatabaseType);
            Assert.Equal("db1", dbResult.Databases[0].Name);
            Assert.True(!string.IsNullOrEmpty(dbResult.Databases[0].ConnectionString));
        }

        [Fact]
        public void GetBackupConfiguration()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetBackupConfiguration)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var backupConfiguration = client.WebSites.GetBackupConfiguration("space1", "baysite");

            Assert.Equal(17, backupConfiguration.BackupSchedule.FrequencyInterval);
            Assert.Equal(FrequencyUnit.Day, backupConfiguration.BackupSchedule.FrequencyUnit);
            Assert.Equal(true, backupConfiguration.BackupSchedule.KeepAtLeastOneBackup);
            Assert.Equal(26, backupConfiguration.BackupSchedule.RetentionPeriodInDays);
            Assert.Equal(new DateTime(635435517126146425).ToLocalTime(), backupConfiguration.BackupSchedule.StartTime);

            Assert.Equal(false, backupConfiguration.Enabled);
            Assert.True(backupConfiguration.StorageAccountUrl.StartsWith("https://"));
        }

        [Fact]
        public void BackupSite()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.BackupSite)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            BackupRequest backupRequest = new BackupRequest()
            {
                Name = "abc.zip",
                Databases = new List<DatabaseBackupSetting>(),
                StorageAccountUrl = "https://username.blob.core.windows.net/backup/?sv=2012-02-12"
            };
            backupRequest.Databases.Add(new DatabaseBackupSetting()
            {
                ConnectionString = "Server=someserver;Database=somedatabase;Uid=someusername;Pwd=somepassword;",
                DatabaseType = "MySql",
                Name = "db1"
            });

            var backupResponse = client.WebSites.Backup("space1", "baysite", backupRequest);
            Assert.Equal(HttpStatusCode.OK, backupResponse.StatusCode);

            var backupResult = backupResponse.BackupItem;
            Assert.Equal(backupResult.Status, BackupItemStatus.Created);
            Assert.Equal(1, backupResult.Databases.Count);

            Assert.Equal("abc.zip", backupResult.BlobName);
            Assert.Equal("abc.zip", backupResult.Name);
            Assert.Equal(0, backupResult.SizeInBytes);
            Assert.False(backupResult.Scheduled);
            Assert.True(backupResult.StorageAccountUrl.StartsWith("https://"));

            Assert.Equal("MySql", backupResult.Databases[0].DatabaseType);
            Assert.Equal("db1", backupResult.Databases[0].Name);
            Assert.True(!string.IsNullOrEmpty(backupResult.Databases[0].ConnectionString));
        }

        [Fact]
        public void RestoreSiteDiscover()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.RestoreSiteDiscover)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            RestoreRequest req = new RestoreRequest()
            {
                BlobName = "abc.zip",
                StorageAccountUrl = "https://someuser.blob.core.windows.net/backup/?sv=2012-02-12",
                Overwrite = false
            };

            string newSiteName = "site1";
            var discoverResponse = client.WebSites.Discover("space1", newSiteName, req);

            Assert.Equal(1, discoverResponse.Databases.Count);
            Assert.Equal("MySql", discoverResponse.Databases[0].DatabaseType);
            Assert.Equal("db1", discoverResponse.Databases[0].Name);
            Assert.True(string.IsNullOrEmpty(discoverResponse.Databases[0].ConnectionString));
            Assert.True(string.IsNullOrEmpty(discoverResponse.Databases[0].ConnectionStringName));

            Assert.Equal("abc.zip", discoverResponse.BlobName);
            Assert.Equal(false, discoverResponse.Overwrite);
            Assert.True(discoverResponse.StorageAccountUrl.StartsWith("https://someuser.blob"));
        }
    }
}
