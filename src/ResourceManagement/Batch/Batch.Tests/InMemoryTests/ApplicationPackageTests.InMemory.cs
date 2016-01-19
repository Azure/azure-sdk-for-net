using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public void AddApplicationPackage()
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

            AddApplicationPackageResponse result = client.Applications.AddApplicationPackage("foo", "acctName", "appId", "beta");

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
        public void AddApplication()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.Created
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.AddApplication(
                "foo",
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
        public void ActivateApplicationPackage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.ActivateApplicationPackage(
                "foo",
                "acctName",
                "appId", "beta",
                new ActivateApplicationPackageParameters("zip"));


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void DeleteApplication()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplication(
                "foo",
                "acctName",
                "appId");


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void DeleteApplicationPackage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.DeleteApplicationPackage(
                "foo",
                "acctName",
                "appId",
                "beta");


            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void GetApplication()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'allowUpdates': 'true',
                    'displayName' : 'boo',
                    'defaultVersion' : 'beta',
                    'packages':[
                        {'version':'John', 'state':'pending', 'format': 'beta', 'lastActivationTime': '" + utcNow + @"'}], 

                    }")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            GetApplicationResponse result = client.Applications.GetApplication("foo", "acctName", "id");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);


            Assert.Equal(result.Application.Id, "foo");
            Assert.Equal(result.Application.AllowUpdates, true);
            Assert.Equal(result.Application.DefaultVersion, "beta");
            Assert.Equal(result.Application.DisplayName, "boo");
            Assert.Equal(result.Application.ApplicationPackages.Count, 1);
            Assert.Equal(result.Application.ApplicationPackages.First().Format, "beta");
            Assert.Equal(result.Application.ApplicationPackages.First().State, PackageState.Pending);
            Assert.Equal(result.Application.ApplicationPackages.First().Version, "John");
            Assert.Equal(result.Application.ApplicationPackages.First().LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }

        [Fact]
        public void GetApplicationPackage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                    'id': 'foo',
                    'storageUrl': '//blah',
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

            GetApplicationPackageResponse result = client.Applications.GetApplicationPackage("foo", "acctName", "id", "VER");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(result.Id, "foo");
            Assert.Equal(result.StorageUrl, "//blah");
            Assert.Equal(result.State, PackageState.Pending);
            Assert.Equal(result.Version, "beta");
            Assert.Equal(result.Format, "zip");
            Assert.Equal(result.LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
            Assert.Equal(result.StorageUrlExpiry, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }


        [Fact]
        public void ListApplication()
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
                        {'version':'John', 'state':'pending', 'format': 'beta', 'lastActivationTime': '" + utcNow + @"'},
                        {'version':'Smith', 'state':'pending', 'format': 'alpha', 'lastActivationTime': '" + utcNow + @"'}], 

                    }]}")
            };


            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            ListApplicationsResponse result = client.Applications.List("foo", "acctName", new ListApplicationsParameters());

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
            Assert.Equal(application.ApplicationPackages.First().Version, "John");
            Assert.Equal(application.ApplicationPackages.First().LastActivationTime, DateTime.Parse(utcNow, null, DateTimeStyles.RoundtripKind));
        }

        [Fact]
        public void UpdateApplication()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                StatusCode = HttpStatusCode.NoContent
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            AzureOperationResponse result = client.Applications.UpdateApplication(
                "foo",
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
        public void ApplicationPackageErrorCases()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);
            
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage(null, "foo", "foo", "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", null, "foo", "null", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", null, "foo", new ActivateApplicationPackageParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.ActivateApplicationPackage("foo", "foo", "foo", null, new ActivateApplicationPackageParameters()));

            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication(null, null, null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", null, null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication("foo", "foo", null, new AddApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.AddApplication(null, "foo", "foo", new AddApplicationParameters()));

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication(null, "foo", "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", null, "foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplication("foo", "foo", null));

            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage(null, "foo", "foo","foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", null, "foo","foo"));
            Assert.Throws<ArgumentNullException>(() => client.Applications.DeleteApplicationPackage("foo", "foo", null,"foo"));
            

            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication(null, null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", null, null));
            Assert.Throws<ArgumentNullException>(() => client.Applications.GetApplication("foo", "foo", null));

            Assert.Throws<ArgumentNullException>(() => client.Applications.List(null, null, new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List(null, "foo", new ListApplicationsParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.List("foo", null, new ListApplicationsParameters()));

            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication(null, "foo", "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", null, "foo", new UpdateApplicationParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Applications.UpdateApplication("foo", "foo", null, new UpdateApplicationParameters()));
        }
    }
}
