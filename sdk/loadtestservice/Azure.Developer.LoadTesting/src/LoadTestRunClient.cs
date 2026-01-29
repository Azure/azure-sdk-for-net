// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpoint"/> is an empty string, and was expected to be non-empty. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new LoadTestingClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpoint"/> is an empty string, and was expected to be non-empty. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential, LoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new LoadTestingClientOptions();

            _endpoint = endpoint;
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) });
            _apiVersion = options.Version;
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary> Create and start a new test run with the given name. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for test run to get completed</param>
        /// <param name="testRunId"> Unique name for the load test run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="oldTestRunId"> Existing test run identifier that should be rerun, if this is provided, the test will run with the JMX file, configuration and app components from the existing test run. You can override the configuration values for new test run in the request body. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testRunId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual TestRunResultOperation BeginTestRun(WaitUntil waitUntil, string testRunId, RequestContent content, TimeSpan? timeSpan = null, string oldTestRunId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginTestRun");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = CreateOrUpdateTestRun(testRunId, content, oldTestRunId, context);
                TestRunResultOperation operation = new(testRunId, this, initialResponse);
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

        /// <summary> Create and start a new test run with the given name. </summary>
        /// <param name="testRunId"> Unique name for the load test run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for test run to get completed</param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="oldTestRunId"> Existing test run identifier that should be rerun, if this is provided, the test will run with the JMX file, configuration and app components from the existing test run. You can override the configuration values for new test run in the request body. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testRunId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<TestRunResultOperation> BeginTestRunAsync(WaitUntil waitUntil, string testRunId, RequestContent content, TimeSpan? timeSpan = null, string oldTestRunId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginTestRun");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = await CreateOrUpdateTestRunAsync(testRunId, content, oldTestRunId, context).ConfigureAwait(false);
                TestRunResultOperation operation = new(testRunId, this, initialResponse);
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

        /// <summary> Create and start a new test profile run with the given name. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for test profile run to get completed</param>
        /// <param name="testProfileRunId"> Unique name for the test profile run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testProfileRunId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testProfileRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual Operation<BinaryData> BeginTestProfileRun(WaitUntil waitUntil, string testProfileRunId, RequestContent content, TimeSpan? timeSpan = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testProfileRunId, nameof(testProfileRunId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginTestProfileRun");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = CreateOrUpdateTestProfileRun(testProfileRunId, content, context);
                TestProfileRunResultOperation operation = new(testProfileRunId, this, initialResponse);
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

        /// <summary> Create and start a new test profile run with the given name. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO, if passed WaitUntil.Completed then waits for test profile run to get completed</param>
        /// <param name="testProfileRunId"> Unique name for the test profile run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="timeSpan"> pollingInterval for poller class, default value or null value is treated as 5 secs</param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testProfileRunId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testProfileRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<Operation<BinaryData>> BeginTestProfileRunAsync(WaitUntil waitUntil, string testProfileRunId, RequestContent content, TimeSpan? timeSpan = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testProfileRunId, nameof(testProfileRunId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginTestProfileRun");
            scope.Start();

            if (timeSpan == null)
            {
                timeSpan = TimeSpan.FromSeconds(5);
            }

            try
            {
                Response initialResponse = await CreateOrUpdateTestProfileRunAsync(testProfileRunId, content, context).ConfigureAwait(false);
                TestProfileRunResultOperation operation = new(testProfileRunId, this, initialResponse);
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

        /// <summary> Get all test runs with given filters. </summary>
        /// <param name="orderby"> Sort on the supported fields in (field asc/desc) format. eg: executedDateTime asc. Supported fields - executedDateTime. </param>
        /// <param name="search"> Prefix based, case sensitive search on searchable fields - description, executedUser. For example, to search for a test run, with description 500 VUs, the search parameter can be 500. </param>
        /// <param name="testId"> Unique name of an existing load test. </param>
        /// <param name="executionFrom"> Start DateTime(ISO 8601 literal format) of test-run execution time filter range. </param>
        /// <param name="executionTo"> End DateTime(ISO 8601 literal format) of test-run execution time filter range. </param>
        /// <param name="status"> Comma separated list of test run status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BinaryData> GetTestRunsAsync(string orderby, string search, string testId, DateTimeOffset? executionFrom, DateTimeOffset? executionTo, string status, RequestContext context)
        {
            return new LoadTestRunClientGetTestRunsAsyncCollectionResult(
                this,
                orderby,
                search,
                testId,
                executionFrom,
                executionTo,
                status,
                null,
                [],
                [],
                context);
        }

        /// <summary> Get all test runs with given filters. </summary>
        /// <param name="orderby"> Sort on the supported fields in (field asc/desc) format. eg: executedDateTime asc. Supported fields - executedDateTime. </param>
        /// <param name="search"> Prefix based, case sensitive search on searchable fields - description, executedUser. For example, to search for a test run, with description 500 VUs, the search parameter can be 500. </param>
        /// <param name="testId"> Unique name of an existing load test. </param>
        /// <param name="executionFrom"> Start DateTime(ISO 8601 literal format) of test-run execution time filter range. </param>
        /// <param name="executionTo"> End DateTime(ISO 8601 literal format) of test-run execution time filter range. </param>
        /// <param name="status"> Comma separated list of test run status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BinaryData> GetTestRuns(string orderby, string search, string testId, DateTimeOffset? executionFrom, DateTimeOffset? executionTo, string status, RequestContext context)
        {
            return new LoadTestRunClientGetTestRunsCollectionResult(
                this,
                orderby,
                search,
                testId,
                executionFrom,
                executionTo,
                status,
                null,
                [],
                [],
                context);
        }

        /// <summary> Get all test runs for the given filters. </summary>
        /// <param name="orderby">
        /// Sort on the supported fields in (field asc/desc) format. eg: executedDateTime
        /// asc. Supported fields - executedDateTime
        /// </param>
        /// <param name="search">
        /// Prefix based, case sensitive search on searchable fields - description,
        /// executedUser. For example, to search for a test run, with description 500 VUs,
        /// the search parameter can be 500.
        /// </param>
        /// <param name="testId"> Unique name of an existing load test. </param>
        /// <param name="executionFrom"> Start DateTime(RFC 3339 literal format) of test-run execution time filter range. </param>
        /// <param name="executionTo"> End DateTime(RFC 3339 literal format) of test-run execution time filter range. </param>
        /// <param name="status"> Comma separated list of test run status. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
#pragma warning disable AZC0002
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<LoadTestRun> GetTestRunsAsync(string orderby, string search, string testId, DateTimeOffset? executionFrom, DateTimeOffset? executionTo, string status, CancellationToken cancellationToken)
#pragma warning restore AZC0002
        {
            return new LoadTestRunClientGetTestRunsAsyncCollectionResultOfT(
                this,
                orderby,
                search,
                testId,
                executionFrom,
                executionTo,
                status,
                null,
                [],
                [],
                cancellationToken.ToRequestContext());
        }

        /// <summary> Get all test runs for the given filters. </summary>
        /// <param name="orderby">
        /// Sort on the supported fields in (field asc/desc) format. eg: executedDateTime
        /// asc. Supported fields - executedDateTime
        /// </param>
        /// <param name="search">
        /// Prefix based, case sensitive search on searchable fields - description,
        /// executedUser. For example, to search for a test run, with description 500 VUs,
        /// the search parameter can be 500.
        /// </param>
        /// <param name="testId"> Unique name of an existing load test. </param>
        /// <param name="executionFrom"> Start DateTime(RFC 3339 literal format) of test-run execution time filter range. </param>
        /// <param name="executionTo"> End DateTime(RFC 3339 literal format) of test-run execution time filter range. </param>
        /// <param name="status"> Comma separated list of test run status. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
#pragma warning disable AZC0002
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<LoadTestRun> GetTestRuns(string orderby, string search, string testId, DateTimeOffset? executionFrom, DateTimeOffset? executionTo, string status, CancellationToken cancellationToken)
#pragma warning restore AZC0002
        {
            return new LoadTestRunClientGetTestRunsCollectionResultOfT(
                this,
                orderby,
                search,
                testId,
                executionFrom,
                executionTo,
                status,
                null,
                [],
                [],
                cancellationToken.ToRequestContext());
        }

        /// <summary> List test profile runs. </summary>
        /// <param name="minStartDateTime"> Minimum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxStartDateTime"> Maximum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="minEndDateTime"> Minimum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxEndDateTime"> Maximum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="createdDateStartTime"> Start DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="createdDateEndTime"> End DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="testProfileRunIds"> Comma separated list of IDs of the test profile runs to filter. </param>
        /// <param name="testProfileIds"> Comma separated IDs of the test profiles which should be associated with the test profile runs to fetch. </param>
        /// <param name="statuses"> Comma separated list of Statuses of the test profile runs to filter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get all test profile runs for the given filters. </remarks>
        public virtual AsyncPageable<TestProfileRun> GetTestProfileRunsAsync(DateTimeOffset? minStartDateTime = null, DateTimeOffset? maxStartDateTime = null, DateTimeOffset? minEndDateTime = null, DateTimeOffset? maxEndDateTime = null, DateTimeOffset? createdDateStartTime = null, DateTimeOffset? createdDateEndTime = null, IEnumerable<string> testProfileRunIds = null, IEnumerable<string> testProfileIds = null, IEnumerable<string> statuses = null, CancellationToken cancellationToken = default)
        {
            return new LoadTestRunClientGetTestProfileRunsAsyncCollectionResultOfT(
                this,
                null,
                minEndDateTime,
                maxStartDateTime,
                minEndDateTime,
                maxEndDateTime,
                createdDateStartTime,
                createdDateEndTime,
                testProfileRunIds,
                testProfileIds,
                statuses,
                cancellationToken.ToRequestContext());
        }

        /// <summary> List test profile runs. </summary>
        /// <param name="minStartDateTime"> Minimum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxStartDateTime"> Maximum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="minEndDateTime"> Minimum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxEndDateTime"> Maximum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="createdDateStartTime"> Start DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="createdDateEndTime"> End DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="testProfileRunIds"> Comma separated list of IDs of the test profile runs to filter. </param>
        /// <param name="testProfileIds"> Comma separated IDs of the test profiles which should be associated with the test profile runs to fetch. </param>
        /// <param name="statuses"> Comma separated list of Statuses of the test profile runs to filter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get all test profile runs for the given filters. </remarks>
        public virtual Pageable<TestProfileRun> GetTestProfileRuns(DateTimeOffset? minStartDateTime = null, DateTimeOffset? maxStartDateTime = null, DateTimeOffset? minEndDateTime = null, DateTimeOffset? maxEndDateTime = null, DateTimeOffset? createdDateStartTime = null, DateTimeOffset? createdDateEndTime = null, IEnumerable<string> testProfileRunIds = null, IEnumerable<string> testProfileIds = null, IEnumerable<string> statuses = null, CancellationToken cancellationToken = default)
        {
            return new LoadTestRunClientGetTestProfileRunsCollectionResultOfT(
                this,
                null,
                minEndDateTime,
                maxStartDateTime,
                minEndDateTime,
                maxEndDateTime,
                createdDateStartTime,
                createdDateEndTime,
                testProfileRunIds,
                testProfileIds,
                statuses,
                cancellationToken.ToRequestContext());
        }

        /// <summary>
        /// [Protocol Method] List test profile runs.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTestProfileRunsAsync(DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,IEnumerable{string},IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="minStartDateTime"> Minimum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxStartDateTime"> Maximum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="minEndDateTime"> Minimum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxEndDateTime"> Maximum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="createdDateStartTime"> Start DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="createdDateEndTime"> End DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="testProfileRunIds"> Comma separated list of IDs of the test profile runs to filter. </param>
        /// <param name="testProfileIds"> Comma separated IDs of the test profiles which should be associated with the test profile runs to fetch. </param>
        /// <param name="statuses"> Comma separated list of Statuses of the test profile runs to filter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetTestProfileRunsAsync(DateTimeOffset? minStartDateTime, DateTimeOffset? maxStartDateTime, DateTimeOffset? minEndDateTime, DateTimeOffset? maxEndDateTime, DateTimeOffset? createdDateStartTime, DateTimeOffset? createdDateEndTime, IEnumerable<string> testProfileRunIds, IEnumerable<string> testProfileIds, IEnumerable<string> statuses, RequestContext context)
        {
            return new LoadTestRunClientGetTestProfileRunsAsyncCollectionResult(
                this,
                null,
                minStartDateTime,
                maxStartDateTime,
                minEndDateTime,
                maxEndDateTime,
                createdDateStartTime,
                createdDateEndTime,
                testProfileRunIds,
                testProfileIds,
                statuses,
                context);
        }

        /// <summary>
        /// [Protocol Method] List test profile runs.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetTestProfileRuns(DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,DateTimeOffset?,IEnumerable{string},IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="minStartDateTime"> Minimum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxStartDateTime"> Maximum Start DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="minEndDateTime"> Minimum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="maxEndDateTime"> Maximum End DateTime(RFC 3339 literal format) of the test profile runs to filter on. </param>
        /// <param name="createdDateStartTime"> Start DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="createdDateEndTime"> End DateTime(RFC 3339 literal format) of the created time range to filter test profile runs. </param>
        /// <param name="testProfileRunIds"> Comma separated list of IDs of the test profile runs to filter. </param>
        /// <param name="testProfileIds"> Comma separated IDs of the test profiles which should be associated with the test profile runs to fetch. </param>
        /// <param name="statuses"> Comma separated list of Statuses of the test profile runs to filter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetTestProfileRuns(DateTimeOffset? minStartDateTime, DateTimeOffset? maxStartDateTime, DateTimeOffset? minEndDateTime, DateTimeOffset? maxEndDateTime, DateTimeOffset? createdDateStartTime, DateTimeOffset? createdDateEndTime, IEnumerable<string> testProfileRunIds, IEnumerable<string> testProfileIds, IEnumerable<string> statuses, RequestContext context)
        {
            return new LoadTestRunClientGetTestProfileRunsCollectionResult(
                this,
                null,
                minStartDateTime,
                maxStartDateTime,
                minEndDateTime,
                maxEndDateTime,
                createdDateStartTime,
                createdDateEndTime,
                testProfileRunIds,
                testProfileIds,
                statuses,
                context);
        }
    }
}
