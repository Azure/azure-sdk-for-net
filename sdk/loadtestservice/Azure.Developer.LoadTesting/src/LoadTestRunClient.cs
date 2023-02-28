// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
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
        public virtual AsyncPageable<BinaryData> GetTestRunsAsync(string orderby = null, string search = null, string testId = null, DateTimeOffset? executionFrom = null, DateTimeOffset? executionTo = null, string status = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestRunsRequest(orderby, search, testId, executionFrom, executionTo, status, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestRunsNextPageRequest(nextLink, orderby, search, testId, executionFrom, executionTo, status, pageSizeHint, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestRunClient.GetTestRuns", "value", "nextLink", context);
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
        public virtual Pageable<BinaryData> GetTestRuns(string orderby = null, string search = null, string testId = null, DateTimeOffset? executionFrom = null, DateTimeOffset? executionTo = null, string status = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTestRunsRequest(orderby, search, testId, executionFrom, executionTo, status, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTestRunsNextPageRequest(nextLink, orderby, search, testId, executionFrom, executionTo, status, pageSizeHint, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestRunClient.GetTestRuns", "value", "nextLink", context);
        }

        /// <summary> List the metric values for a load test run. </summary>
        /// <param name="testRunId"> Unique name for the load test run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="metricName"> Metric name. </param>
        /// <param name="metricNamespace"> Metric namespace to query metric definitions for. </param>
        /// <param name="timespan"> The timespan of the query. It is a string with the following format &apos;startDateTime_ISO/endDateTime_ISO&apos;. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="aggregation"> The aggregation. </param>
        /// <param name="interval"> The interval (i.e. timegrain) of the query. Allowed values: &quot;PT5S&quot; | &quot;PT10S&quot; | &quot;PT1M&quot; | &quot;PT5M&quot; | &quot;PT1H&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testRunId"/>, <paramref name="metricName"/>, <paramref name="metricNamespace"/> or <paramref name="timespan"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/LoadTestRunClient.xml" path="doc/members/member[@name='GetMetricsAsync(String,String,String,String,RequestContent,String,String,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMetricsAsync(string testRunId, string metricName, string metricNamespace, string timespan, RequestContent content = null, string aggregation = null, string interval = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));
            Argument.AssertNotNull(metricName, nameof(metricName));
            Argument.AssertNotNull(metricNamespace, nameof(metricNamespace));
            Argument.AssertNotNull(timespan, nameof(timespan));

            if (content == null)
            {
                content = RequestContent.Create(new { });
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMetricsRequest(testRunId, metricName, metricNamespace, timespan, content, aggregation, interval, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMetricsNextPageRequest(nextLink, testRunId, metricName, metricNamespace, timespan, content, aggregation, interval, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestRunClient.GetMetrics", "value", "nextLink", context);
        }

        /// <summary> List the metric values for a load     test run. </summary>
        /// <param name="testRunId"> Unique name for the load test run, must contain only lower-case alphabetic, numeric, underscore or hyphen characters. </param>
        /// <param name="metricName"> Metric name. </param>
        /// <param name="metricNamespace"> Metric namespace to query metric definitions for. </param>
        /// <param name="timespan"> The timespan of the query. It is a string with the following format &apos;startDateTime_ISO/endDateTime_ISO&apos;. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="aggregation"> The aggregation. </param>
        /// <param name="interval"> The interval (i.e. timegrain) of the query. Allowed values: &quot;PT5S&quot; | &quot;PT10S&quot; | &quot;PT1M&quot; | &quot;PT5M&quot; | &quot;PT1H&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="testRunId"/>, <paramref name="metricName"/>, <paramref name="metricNamespace"/> or <paramref name="timespan"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="testRunId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/LoadTestRunClient.xml" path="doc/members/member[@name='GetMetrics(String,String,String,String,RequestContent,String,String,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMetrics(string testRunId, string metricName, string metricNamespace, string timespan, RequestContent content = null, string aggregation = null, string interval = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));
            Argument.AssertNotNull(metricName, nameof(metricName));
            Argument.AssertNotNull(metricNamespace, nameof(metricNamespace));
            Argument.AssertNotNull(timespan, nameof(timespan));

            if (content == null)
            {
                content = RequestContent.Create(new { });
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMetricsRequest(testRunId, metricName, metricNamespace, timespan, content, aggregation, interval, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMetricsNextPageRequest(nextLink, testRunId, metricName, metricNamespace, timespan, content, aggregation, interval, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "LoadTestRunClient.GetMetrics", "value", "nextLink", context);
        }
    }
}
