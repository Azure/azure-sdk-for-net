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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Batch.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;

using Xunit;

namespace Batch.Tests.InMemoryTests
{
    public class ApplicationPackageTests
    {
        public BatchManagementClient GetBatchManagementClient(RecordedDelegatingHandler handler)
        {
            var certCreds = new CertificateCloudCredentials(Guid.NewGuid().ToString(), new System.Security.Cryptography.X509Certificates.X509Certificate2());
            handler.IsPassThrough = false;
            return new BatchManagementClient(certCreds).WithHandler(handler);
        }

        [Fact]
        public void AccountCreateWithApplicationPackagesAsyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");
            var utcNow = DateTime.UtcNow.ToString("o");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'autoStorage' :{
                                        'storageAccountId' : '//storageAccount1',
                                        'lastKeySync': '" + utcNow + @"',
                                    }
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            var client = GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.Accounts.Create("foo", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                Tags = tags,
                Properties = new AccountBaseProperties
                {
                    AutoStorage = new AutoStorageBaseProperties
                    {
                        StorageAccountId = "//storageAccount1"
                    }
                }
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // op status is a get
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.NotNull(handler.Requests[1].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(result.Resource.Properties.ProvisioningState, AccountProvisioningState.Succeeded);
            Assert.True(result.Resource.Tags.Count == 2);
            Assert.Equal(result.Resource.Properties.AutoStorage.StorageAccountId, "//storageAccount1");
            Assert.Equal(result.Resource.Properties.AutoStorage.LastKeySync, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));

        }


        [Fact]
        public void IfAnAccountIsCreatedWithAutoStorage_ThenTheAutoStorageAccountIdMustNotBeNull()
        {
            var handler = new RecordedDelegatingHandler();

            var client = GetBatchManagementClient(handler);

            // If storageId is not set this will throw an ArgumentNullException
            var ex = Assert.Throws<ArgumentNullException>(() => client.Accounts.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                Properties = new AccountBaseProperties
                {
                    AutoStorage = new AutoStorageBaseProperties()
                }
            }));

            Assert.Equal("parameters.Properties.AutoStorage.StorageAccountId", ex.ParamName);
        }

        [Fact]
        public void GetAccountWithApplicationPackagesAsyncValidateMessage()
        {

            var utcNow = DateTime.UtcNow.ToString("o");

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                    'type' : 'Microsoft.Batch/batchAccounts',
                    'name': 'acctName',
                    'location': 'South Central US',
                    'properties': {
                        'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                        'provisioningState' : 'Succeeded',
                        'coreQuota' : '20',
                        'poolQuota' : '100',
                        'activeJobAndJobScheduleQuota' : '200',
                        'autoStorage':{
                            'storageAccountId':'//StorageAccountId',
                            'lastKeySync': '" + utcNow + @"',
                        }
                    },
                    'tags' : {
                        'tag1' : 'value for tag1',
                        'tag2' : 'value for tag2'
                    }
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.Get("foo", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.Equal("acctName", result.Resource.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Resource.Id);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(20, result.Resource.Properties.CoreQuota);
            Assert.Equal(100, result.Resource.Properties.PoolQuota);
            Assert.Equal(200, result.Resource.Properties.ActiveJobAndJobScheduleQuota);

            AutoStorageProperties autoStorageInformation = result.Resource.Properties.AutoStorage;
            Assert.Equal(autoStorageInformation.StorageAccountId, "//StorageAccountId");
            Assert.Equal(autoStorageInformation.LastKeySync, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.Resource.Properties.AutoStorage.LastKeySync, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));

            Assert.True(result.Resource.Tags.ContainsKey("tag1"));

        }


        [Fact]
        public void AddApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                    'version' : 'beta',
                    'storageUrlExpiry' : '" + utcNow + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AddApplicationPackageResponse result = client.Applications.AddApplicationPackage("resourceGroupName", "acctName", "appId", "beta");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            Assert.Equal(result.StorageUrlExpiry, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.Id, "foo");
            Assert.Equal(result.Version, "beta");
            Assert.Equal(result.StorageUrl, "/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName");
        }

        [Fact]
        public void AddApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.AddApplication(
                "resourceGroupName",
                "acctName",
                "appId",
                new AddApplicationParameters { AllowUpdates = true, DisplayName = "display-name" });


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public void ActivateApplicationPackageValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.ActivateApplicationPackage(
                "resourceGroupName",
                "acctName",
                "appId", "version",
                new ActivateApplicationPackageParameters("zip"));


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void DeleteApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplication(
                "resourceGroupName",
                "acctName",
                "appId");


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void DeleteApplicationPackageValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplicationPackage(
                "resourceGroupName",
                "acctName",
                "appId",
                "version");


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void GetApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'displayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'fooVersion', 'state':'pending', 'format': 'betaFormat', 'lastActivationTime': '" + utcNow + @"'}],

                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            GetApplicationResponse result = client.Applications.GetApplication("applicationId", "acctName", "id");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);


            Assert.Equal(result.Application.Id, "foo");
            Assert.Equal(result.Application.AllowUpdates, true);
            Assert.Equal(result.Application.DefaultVersion, "beta");
            Assert.Equal(result.Application.DisplayName, "displayName");
            Assert.Equal(result.Application.ApplicationPackages.Count, 1);
            Assert.Equal(result.Application.ApplicationPackages.First().Format, "betaFormat");
            Assert.Equal(result.Application.ApplicationPackages.First().State, PackageState.Pending);
            Assert.Equal(result.Application.ApplicationPackages.First().Version, "fooVersion");
            Assert.Equal(result.Application.ApplicationPackages.First().LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }

        [Fact]
        public void GetApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '//storageUrl',
                    'state' : 'Pending',
                    'version' : 'beta',
                    'format':'zip',
                    'storageUrlExpiry':'" + utcNow + @"',
                    'lastActivationTime':'" + utcNow + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            GetApplicationPackageResponse result = client.Applications.GetApplicationPackage("resourceGroupName", "acctName", "id", "VER");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(result.Id, "foo");
            Assert.Equal(result.StorageUrl, "//storageUrl");
            Assert.Equal(result.State, PackageState.Pending);
            Assert.Equal(result.Version, "beta");
            Assert.Equal(result.Format, "zip");
            Assert.Equal(result.LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.StorageUrlExpiry, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }


        [Fact]
        public void ListApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ 'value':[{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'boo',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'version1', 'state':'pending', 'format': 'beta', 'lastActivationTime': '" + utcNow + @"'},
                        {'version':'version2', 'state':'pending', 'format': 'alpha', 'lastActivationTime': '" + utcNow + @"'}],

                    }]}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            ListApplicationsResponse result = client.Applications.List("resourceGroupName", "acctName", new ListApplicationsParameters());

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Application application = result.Applications.First();
            Assert.Equal(application.Id, "foo");
            Assert.Equal(application.AllowUpdates, true);
            Assert.Equal(application.DefaultVersion, "beta");
            Assert.Equal(application.DisplayName, "boo");
            Assert.Equal(application.ApplicationPackages.Count, 2);
            Assert.Equal(application.ApplicationPackages.First().Format, "beta");
            Assert.Equal(application.ApplicationPackages.First().State, PackageState.Pending);
            Assert.Equal(application.ApplicationPackages.First().Version, "version1");
            Assert.Equal(application.ApplicationPackages.First().LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }

        [Fact]
        public void UpdateApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.UpdateApplication(
                "resourceGroupName",
                "acctName",
                "appId", new UpdateApplicationParameters() { AllowUpdates = true, DisplayName = "display-name", DefaultVersion = "blah" }
                );


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal("PATCH", handler.Method.ToString());
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void ActivateApplicationPackageThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage(null, "foo", "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", null, "foo", "null", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", null, "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", "foo", null, new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", null, null, null, new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", null, null, new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", "foo", null, new ActivateApplicationPackageParameters()));
        }

        [Fact]
        public void AddApplicationThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication(null, null, null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", null, null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", "foo", null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication(null, "foo", "foo", new AddApplicationParameters()));
        }

        [Fact]
        public void DeleteApplicationThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication(null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", "foo", null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication(null, null, null));
        }

        [Fact]
        public void DeleteApplicationPackageThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage(null, "foo", "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", "bar", null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", null, null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage(null, null, null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage(null, null, null, null));
        }

        [Fact]
        public void GetApplicationThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication(null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication(null, null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication(null, null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", "foo", null));
        }

        [Fact]
        public void ListThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.List(null, null, new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List(null, "foo", new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List("foo", null, new ListApplicationsParameters()));
        }

        [Fact]
        public void UpdateApplicationThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication(null, "foo", "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", null, "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", "foo", null, new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", null, null, new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication(null, "foo", null, new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication(null, null, "foo", new UpdateApplicationParameters()));
        }
    }
}
