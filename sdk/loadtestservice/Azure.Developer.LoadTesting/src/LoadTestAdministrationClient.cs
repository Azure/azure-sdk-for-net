// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestAdministrationClient
    {
        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as application/octet-stream. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for complete file validation</param>
        /// <param name="testId"> Unique name for the load test, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="fileName"> Unique name for test file with file extension like : App.jmx. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="fileType"> File type. Allowed values: &quot;JMX_FILE&quot; | &quot;USER_PROPERTIES&quot; | &quot;ADDITIONAL_ARTIFACTS&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual FileUploadResultOperation UploadTestFile(WaitUntil waitUntil, string testId, string fileName, RequestContent content, TimeSpan? timeSpan = null, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = UploadTestFile(testId, fileName, content, fileType, context);
                FileUploadResultOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion((TimeSpan)timeSpan, cancellationToken: default);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload input file for a given test name. File size can&apos;t be more than 50 MB. Existing file with same name for the given test will be overwritten. File should be provided in the request body as application/octet-stream. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for complete file validation</param>
        /// <param name="testId"> Unique name for the load test, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="fileName"> Unique name for test file with file extension like : App.jmx. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="fileType"> File type. Allowed values: &quot;JMX_FILE&quot; | &quot;USER_PROPERTIES&quot; | &quot;ADDITIONAL_ARTIFACTS&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testId"/>, <paramref name="fileName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testId"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<FileUploadResultOperation> UploadTestFileAsync(WaitUntil waitUntil, string testId, string fileName, RequestContent content, TimeSpan? timeSpan = null, string fileType = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testId, nameof(testId));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestAdministrationClient.UploadTestFile");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = await UploadTestFileAsync(testId, fileName, content, fileType, context).ConfigureAwait(false);
                FileUploadResultOperation operation = new(testId, fileName, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync((TimeSpan)timeSpan, cancellationToken: default).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all load tests by the fully qualified resource Id e.g subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.LoadTestService/loadtests/{resName}. </summary>
        /// <param name="orderby"> Sort on the supported fields in (field asc/desc) format. eg: lastModifiedDateTime asc. Supported fields - lastModifiedDateTime. </param>
        /// <param name="search"> Prefix based, case sensitive search on searchable fields - displayName, createdBy. For example, to search for a test, with display name is Login Test, the search parameter can be Login. </param>
        /// <param name="lastModifiedStartTime"> Start DateTime(ISO 8601 literal format) of the last updated time range to filter tests. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(ISO 8601 literal format) of the last updated time range to filter tests. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetTestsAsync(string orderby, string search, DateTimeOffset? lastModifiedStartTime, DateTimeOffset? lastModifiedEndTime, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestsRequest(orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestsNextPageRequest(nextLink, orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTests", "value", "nextLink", context);
        }

        /// <summary> Get all load tests by the fully qualified resource Id e.g subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.LoadTestService/loadtests/{resName}. </summary>
        /// <param name="orderby"> Sort on the supported fields in (field asc/desc) format. eg: lastModifiedDateTime asc. Supported fields - lastModifiedDateTime. </param>
        /// <param name="search"> Prefix based, case sensitive search on searchable fields - displayName, createdBy. For example, to search for a test, with display name is Login Test, the search parameter can be Login. </param>
        /// <param name="lastModifiedStartTime"> Start DateTime(ISO 8601 literal format) of the last updated time range to filter tests. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(ISO 8601 literal format) of the last updated time range to filter tests. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetTests(string orderby, string search, DateTimeOffset? lastModifiedStartTime, DateTimeOffset? lastModifiedEndTime, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestsRequest(orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestsNextPageRequest(nextLink, orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTests", "value", "nextLink", context);
        }

        /// <summary>
        /// Get all load tests by the fully qualified resource Id e.g
        /// subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.LoadTestService/loadtests/{resName}.
        /// </summary>
        /// <param name="orderby">
        /// Sort on the supported fields in (field asc/desc) format. eg:
        /// lastModifiedDateTime asc. Supported fields - lastModifiedDateTime
        /// </param>
        /// <param name="search">
        /// Prefix based, case sensitive search on searchable fields - displayName,
        /// createdBy. For example, to search for a test, with display name is Login Test,
        /// the search parameter can be Login.
        /// </param>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter tests. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter tests. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<LoadTest> GetTestsAsync(string orderby = null, string search = null, DateTimeOffset? lastModifiedStartTime = null, DateTimeOffset? lastModifiedEndTime = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestsRequest(orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestsNextPageRequest(nextLink, orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => LoadTest.DeserializeLoadTest(e), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTests", "value", "nextLink", context);
        }

        /// <summary>
        /// Get all load tests by the fully qualified resource Id e.g
        /// subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.LoadTestService/loadtests/{resName}.
        /// </summary>
        /// <param name="orderby">
        /// Sort on the supported fields in (field asc/desc) format. eg:
        /// lastModifiedDateTime asc. Supported fields - lastModifiedDateTime
        /// </param>
        /// <param name="search">
        /// Prefix based, case sensitive search on searchable fields - displayName,
        /// createdBy. For example, to search for a test, with display name is Login Test,
        /// the search parameter can be Login.
        /// </param>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter tests. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter tests. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<LoadTest> GetTests(string orderby = null, string search = null, DateTimeOffset? lastModifiedStartTime = null, DateTimeOffset? lastModifiedEndTime = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestsRequest(orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestsNextPageRequest(nextLink, orderby, search, lastModifiedStartTime, lastModifiedEndTime, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => LoadTest.DeserializeLoadTest(e), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTests", "value", "nextLink", context);
        }

        /// <summary> List test profiles. </summary>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="testProfileIds"> Comma separated list of IDs of the test profiles to filter. </param>
        /// <param name="testIds"> Comma separated list IDs of the tests which should be associated with the test profiles to fetch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get all test profiles for the given filters. </remarks>
        public virtual AsyncPageable<TestProfile> GetTestProfilesAsync(DateTimeOffset? lastModifiedStartTime = null, DateTimeOffset? lastModifiedEndTime = null, IEnumerable<string> testProfileIds = null, IEnumerable<string> testIds = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestProfilesRequest(pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestProfilesNextPageRequest(nextLink, pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => TestProfile.DeserializeTestProfile(e), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTestProfiles", "value", "nextLink", context);
        }

        /// <summary> List test profiles. </summary>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="testProfileIds"> Comma separated list of IDs of the test profiles to filter. </param>
        /// <param name="testIds"> Comma separated list IDs of the tests which should be associated with the test profiles to fetch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get all test profiles for the given filters. </remarks>
        public virtual Pageable<TestProfile> GetTestProfiles(DateTimeOffset? lastModifiedStartTime = null, DateTimeOffset? lastModifiedEndTime = null, IEnumerable<string> testProfileIds = null, IEnumerable<string> testIds = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestProfilesRequest(pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestProfilesNextPageRequest(nextLink, pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => TestProfile.DeserializeTestProfile(e), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTestProfiles", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List test profiles.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTestProfilesAsync(DateTimeOffset?,DateTimeOffset?,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="testProfileIds"> Comma separated list of IDs of the test profiles to filter. </param>
        /// <param name="testIds"> Comma separated list IDs of the tests which should be associated with the test profiles to fetch. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetTestProfilesAsync(DateTimeOffset? lastModifiedStartTime, DateTimeOffset? lastModifiedEndTime, IEnumerable<string> testProfileIds, IEnumerable<string> testIds, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestProfilesRequest(pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestProfilesNextPageRequest(nextLink, pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTestProfiles", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List test profiles.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTestProfiles(DateTimeOffset?,DateTimeOffset?,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="lastModifiedStartTime"> Start DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="lastModifiedEndTime"> End DateTime(RFC 3339 literal format) of the last updated time range to filter test profiles. </param>
        /// <param name="testProfileIds"> Comma separated list of IDs of the test profiles to filter. </param>
        /// <param name="testIds"> Comma separated list IDs of the tests which should be associated with the test profiles to fetch. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetTestProfiles(DateTimeOffset? lastModifiedStartTime, DateTimeOffset? lastModifiedEndTime, IEnumerable<string> testProfileIds, IEnumerable<string> testIds, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestProfilesRequest(pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestProfilesNextPageRequest(nextLink, pageSizeHint, lastModifiedStartTime, lastModifiedEndTime, testProfileIds, testIds, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestAdministrationClient.GetTestProfiles", "value", "nextLink", context);
        }
    }
}
