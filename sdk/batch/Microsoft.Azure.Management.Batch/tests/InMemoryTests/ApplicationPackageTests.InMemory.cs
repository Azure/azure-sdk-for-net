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

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryTestsApplicationPackageTests
    {
        [Fact]
        public void IfAnAccountIsCreatedWithAutoStorage_ThenTheAutoStorageAccountIdMustNotBeNull()
        {
            var handler = new RecordedDelegatingHandler();

            var client = BatchTestHelper.GetBatchManagementClient(handler);

            // If storageId is not set this will throw an ValidationException
            var ex = Assert.Throws<ValidationException>(() => client.BatchAccount.Create("resourceGroupName", "accountname", new BatchAccountCreateParameters
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

            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationPackageJson(utcNow))
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.CreateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "appId",
                "beta")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationPackageProperties(result.Body, utcNow);
        }

        [Fact]
        public void AddApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationJson())
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.CreateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "appId",
                new Application
                {
                    AllowUpdates = true,
                    DisplayName = "displayName"
                })).Unwrap().GetAwaiter().GetResult();


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationProperties(result.Body);
        }

        [Fact]
        public void ActivateApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;
            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationPackageJson(utcNow))
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.ActivateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "appId",
                "version",
                "zip")).Unwrap().GetAwaiter().GetResult();


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationPackageProperties(result.Body, utcNow);
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
                "acctname",
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
                "acctname",
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

            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationJson())
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.GetWithHttpMessagesAsync(
                "applicationId",
                "acctname",
                "id")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationProperties(result.Body);
        }

        [Fact]
        public void GetApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationPackageJson(utcNow))
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.ApplicationPackage.GetWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "id",
                "VER")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            //Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationPackageProperties(result.Body, utcNow);
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
                Content = new StringContent($@"{{ 'value':[{ApplicationJson()}] }}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() => client.Application.ListWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            Application application = result.Body.First();
            AssertOnApplicationProperties(application);
        }

        [Fact]
        public void ListApplicationPackageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent($@"{{ 'value':[{ApplicationPackageJson(utcNow)}] }}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() => client.ApplicationPackage.ListWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "appName")).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            ApplicationPackage package = result.Body.First();
            AssertOnApplicationPackageProperties(package, utcNow);
        }

        [Fact]
        public void UpdateApplicationValidateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApplicationJson(displayName: "display-name"))
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response);
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() =>
                client.Application.UpdateWithHttpMessagesAsync(
                "resourceGroupName",
                "acctname",
                "appId",
                new Application
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
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);
            AssertOnApplicationProperties(result.Body, displayName: "display-name");
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

            Assert.Throws<ValidationException>(() => client.Application.Create(null, "foo", "foo", new Application()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", null, "foo", new Application()));
            Assert.Throws<ValidationException>(() => client.Application.Create("foo", "foo", null, new Application()));
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

            Assert.Throws<ValidationException>(() => client.Application.Update(null, "foo", "foo", new Application()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", null, "foo", new Application()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", null, new Application()));
            Assert.Throws<ValidationException>(() => client.Application.Update("foo", "foo", "foo", null));
        }

        private static string ApplicationPackageJson(DateTime utcNow)
        {
            return @"{
                'id': 'foo',
                'name' : 'beta',
                'properties': {
                    'storageUrl': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctname',
                    'state' : 'Pending',
                    'format':'zip',
                    'storageUrlExpiry':'" + utcNow.ToString("o") + @"',
                    'lastActivationTime':'" + utcNow.ToString("o") + @"',
                }
                }";
        }

        private void AssertOnApplicationPackageProperties(ApplicationPackage package, DateTime utcNow)
        {
            Assert.Equal("foo", package.Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctname", package.StorageUrl);
            Assert.Equal(PackageState.Pending, package.State);
            Assert.Equal("beta", package.Name);
            Assert.Equal("zip", package.Format);
            Assert.Equal(utcNow, package.LastActivationTime);
            Assert.Equal(utcNow, package.StorageUrlExpiry);
        }

        private static string ApplicationJson(string displayName = null)
        {
            return $@"{{
                'id': 'foo',
                'properties': {{
                    'allowUpdates': 'true',
                    'displayName' : '{displayName ?? "displayName"}',
                    'defaultVersion' : 'beta',
                }}
                }}";
        }

        private void AssertOnApplicationProperties(Application application, string displayName = null)
        {
            Assert.Equal("foo", application.Id);
            Assert.True(application.AllowUpdates);
            Assert.Equal("beta", application.DefaultVersion);
            Assert.Equal(displayName ?? "displayName", application.DisplayName);
        }
    }
}
