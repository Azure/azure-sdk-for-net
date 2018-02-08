// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            var ex = Assert.Throws<ValidationException>(() => client.BatchAccount.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
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
                client.ApplicationPackage.CreateWithHttpMessagesAsync(
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
                client.Application.CreateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new ApplicationCreateParameters
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
                client.ApplicationPackage.ActivateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                "version",
                "zip")).Unwrap().GetAwaiter().GetResult();


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
                client.Application.DeleteWithHttpMessagesAsync(
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
                client.ApplicationPackage.DeleteWithHttpMessagesAsync(
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
                client.Application.GetWithHttpMessagesAsync(
                "applicationId",
                "acctName",
                "id")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Assert.Equal("foo", result.Body.Id);
            Assert.True(result.Body.AllowUpdates);
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
                client.ApplicationPackage.GetWithHttpMessagesAsync(
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
            Assert.True(application.AllowUpdates);
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
                client.Application.UpdateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctName",
                "appId",
                new ApplicationUpdateParameters
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

            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate(null, "foo", "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", null, "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", "foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Activate("foo", "foo", "foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToAddApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.Create(null, "foo", "foo", new ApplicationCreateParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", null, "foo", new ApplicationCreateParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", "foo", null, new ApplicationCreateParameters()));
            Assert.Throws<NullReferenceException>(() => client.Application.Create("foo", "foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.Application.Delete(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Delete("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Delete("foo", "foo", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToDeleteApplicationPackage()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete(null, "foo", "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", "foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.ApplicationPackage.Delete("foo", "foo", "bar", null));
        }

        [Fact]
        public void CannotPassNullArgumentsToGetApplication()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);
            Assert.Throws<ValidationException>(() => client.Application.Get(null, "foo", "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Get("foo", null, "foo"));
            Assert.Throws<ValidationException>(() => client.Application.Get("foo", "foo", null));
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

            Assert.Throws<ValidationException>(() => client.Application.Update(null, "foo", "foo", new ApplicationUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", null, "foo", new ApplicationUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", null, new ApplicationUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", "foo", null));
        }
    }
}
