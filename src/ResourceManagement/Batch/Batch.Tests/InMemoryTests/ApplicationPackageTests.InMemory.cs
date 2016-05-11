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

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Batch.Tests.InMemoryTests
{
    public class ApplicationPackageTests
    {
        [Fact]
        public void IfAnAccountIsCreatedWithAutoStorage_ThenTheAutoStorageAccountIdMustNotBeNull()
        {
            var handler = new RecordedDelegatingHandler();

            var client = BatchTestHelper.GetBatchManagementClient(handler);

            // If storageId is not set this will throw an ValidationException
            var ex = Assert.Throws<ValidationException>(() => client.Account.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                AutoStorage = new AutoStorageBaseProperties()
            }));

            Assert.Equal("StorageAccountId", ex.Target.ToString());
        }

        [Fact]
        public void AddApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                    'version' : 'beta',
                    'storageUrlExpiry' : '" + utcNow.ToString("o") + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.AddApplicationPackageWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "beta")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(utcNow, result.Body.StorageUrlExpiry);
            Assert.Equal("foo", result.Body.Id);
            Assert.Equal("beta", result.Body.Version);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Body.StorageUrl);
            Assert.Equal(HttpStatusCode.Created, result.Response.StatusCode);
        }

        [Fact]
        public void AddApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'displayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'fooVersion', 'state':'pending', 'format': 'betaFormat', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.AddApplicationWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new AddApplicationParameters
                {
                    AllowUpdates = true,
                    DisplayName = "display-name"
                })).Unwrap().GetAwaiter().GetResult();


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.Created, result.Response.StatusCode);
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
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.ActivateApplicationPackageWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "version",
                new ActivateApplicationPackageParameters("zip"))).Unwrap().GetAwaiter().GetResult();


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
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
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.DeleteApplicationWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
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
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.DeleteApplicationPackageWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "version")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
        }

        [Fact]
        public void GetApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'displayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'fooVersion', 'state':'pending', 'format': 'betaFormat', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.GetApplicationWithHttpMessagesAsync(
                "applicationId",
                "acctName",
                "id")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Assert.Equal("foo", result.Body.Id);
            Assert.Equal(true, result.Body.AllowUpdates);
            Assert.Equal("beta", result.Body.DefaultVersion);
            Assert.Equal("displayName", result.Body.DisplayName);
            Assert.Equal(1, result.Body.Packages.Count);
            Assert.Equal("betaFormat", result.Body.Packages.First().Format);
            Assert.Equal(PackageState.Pending, result.Body.Packages.First().State);
            Assert.Equal("fooVersion", result.Body.Packages.First().Version);
            Assert.Equal(utcNow, result.Body.Packages.First().LastActivationTime);
        }

        [Fact]
        public void GetApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '//storageUrl',
                    'state' : 'Pending',
                    'version' : 'beta',
                    'format':'zip',
                    'storageUrlExpiry':'" + utcNow.ToString("o") + @"',
                    'lastActivationTime':'" + utcNow.ToString("o") + @"',
                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.GetApplicationPackageWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "id",
                "VER")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            //Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Assert.Equal("foo", result.Body.Id);
            Assert.Equal("//storageUrl", result.Body.StorageUrl);
            Assert.Equal(PackageState.Pending, result.Body.State);
            Assert.Equal("beta", result.Body.Version);
            Assert.Equal("zip", result.Body.Format);
            Assert.Equal(utcNow, result.Body.LastActivationTime);
            Assert.Equal(utcNow, result.Body.StorageUrlExpiry);
        }

        [Fact]
        public void ApplicationListNextThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);
            Assert.Throws<ValidationException>(() => client.Application.ListNext(null));
        }

        [Fact]
        public void ListApplicationValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ 'value':[{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'DisplayName',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'version1', 'state':'pending', 'format': 'beta', 'lastActivationTime': '" + utcNow.ToString("o") + @"'},
                        {'version':'version2', 'state':'pending', 'format': 'alpha', 'lastActivationTime': '" + utcNow.ToString("o") + @"'}],

                    }]}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() => client.Application.ListWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Application application = result.Body.First();
            Assert.Equal("foo", application.Id);
            Assert.Equal(true, application.AllowUpdates);
            Assert.Equal("beta", application.DefaultVersion);
            Assert.Equal("DisplayName", application.DisplayName);
            Assert.Equal(2, application.Packages.Count);
            Assert.Equal("beta", application.Packages.First().Format);
            Assert.Equal(PackageState.Pending, application.Packages.First().State);
            Assert.Equal("version1", application.Packages.First().Version);
            Assert.Equal(utcNow, application.Packages.First().LastActivationTime);
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
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.UpdateApplicationWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new UpdateApplicationParameters()
                {
                    AllowUpdates = true,
                    DisplayName = "display-name",
                    DefaultVersion = "blah"
                }
                )).Unwrap().GetAwaiter().GetResult();


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal("PATCH", handler.Method.ToString());
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.Response.StatusCode);
        }

        [Fact]
        public void CannotPassNullArgumentsToActivateApplicationPackage()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.ActivateApplicationPackage(null, "foo", "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ValidationException>(() => client.Application.ActivateApplicationPackage("foo", null, "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ValidationException>(() => client.Application.ActivateApplicationPackage("foo", "foo", null, "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ValidationException>(() => client.Application.ActivateApplicationPackage("foo", "foo", "foo", null, new ActivateApplicationPackageParameters()));
            Assert.Throws<ValidationException>(() => client.Application.ActivateApplicationPackage("foo", "foo", "foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToAddApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.AddApplication(null, "foo", "foo", new AddApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.AddApplication("foo", null, "foo", new AddApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.AddApplication("foo", "foo", null, new AddApplicationParameters()));
            Assert.Throws<NullReferenceException>(() => client.Application.AddApplication("foo", "foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.DeleteApplication(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.DeleteApplication("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.DeleteApplication("foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplicationPackage()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.DeleteApplicationPackage(null, "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.DeleteApplicationPackage("foo", null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.DeleteApplicationPackage("foo", "foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.DeleteApplicationPackage("foo", "foo", "bar", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToGetApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);
            Assert.Throws<ValidationException>(() => client.Application.GetApplication(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.GetApplication("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.GetApplication("foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToListApplications()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.List(null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.List("foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToUpdateApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.UpdateApplication(null, "foo", "foo", new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.UpdateApplication("foo", null, "foo", new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.UpdateApplication("foo", "foo", null, new UpdateApplicationParameters()));
            Assert.Throws<ValidationException>(() => client.Application.UpdateApplication("foo", "foo", "foo", null));
        }
    }
}
