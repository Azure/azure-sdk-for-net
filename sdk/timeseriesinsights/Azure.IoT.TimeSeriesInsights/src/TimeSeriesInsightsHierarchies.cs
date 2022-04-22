// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Perform operations such as creating, listing, replacing and deleting Time Series hierarchies.
    /// </summary>
    public class TimeSeriesInsightsHierarchies
    {
        private readonly TimeSeriesHierarchiesRestClient _hierarchiesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of TimeSeriesInsightsHierarchies. This constructor should only be used for mocking purposes.
        /// </summary>
        protected TimeSeriesInsightsHierarchies()
        {
        }

        internal TimeSeriesInsightsHierarchies(TimeSeriesHierarchiesRestClient hierarchiesRestClient, ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(hierarchiesRestClient, nameof(hierarchiesRestClient));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _hierarchiesRestClient = hierarchiesRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies in pages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesHierarchy}"/> of Time Series hierarchies with the http response.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetAllHierarchies" language="csharp">
        /// // Get all Time Series hierarchies in the environment
        /// AsyncPageable&lt;TimeSeriesHierarchy&gt; getAllHierarchies = hierarchiesClient.GetAsync();
        /// await foreach (TimeSeriesHierarchy hierarchy in getAllHierarchies)
        /// {
        ///     Console.WriteLine($&quot;Retrieved Time Series Insights hierarchy with Id: &apos;{hierarchy.Id}&apos; and Name: &apos;{hierarchy.Name}&apos;.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<TimeSeriesHierarchy> GetAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesHierarchy>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = await _hierarchiesRestClient
                            .ListAsync(null, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<TimeSeriesHierarchy>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = await _hierarchiesRestClient
                            .ListAsync(nextLink, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies in pages synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesHierarchy}"/> of Time Series hierarchies with the http response.</returns>
        /// <seealso cref="GetAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesHierarchy> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();

            try
            {
                Page<TimeSeriesHierarchy> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = _hierarchiesRestClient.List(null, null, cancellationToken);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<TimeSeriesHierarchy> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = _hierarchiesRestClient.List(nextLink, null, cancellationToken);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies by hierarchy names asynchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of hierarchy or error objects corresponding by position to the array in the request.
        /// Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> GetByNameAsync(
            IEnumerable<string> timeSeriesHierarchyNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyNames, nameof(timeSeriesHierarchyNames));

                var batchRequest = new HierarchiesBatchRequest()
                {
                    Get = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string timeSeriesName in timeSeriesHierarchyNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = await _hierarchiesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies by hierarchy names synchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of hierarchy or error objects corresponding by position to the array in the request.
        /// Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetByNameAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesHierarchyOperationResult[]> GetByName(
            IEnumerable<string> timeSeriesHierarchyNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyNames, nameof(timeSeriesHierarchyNames));

                var batchRequest = new HierarchiesBatchRequest()
                {
                    Get = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string timeSeriesName in timeSeriesHierarchyNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = _hierarchiesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies by hierarchy Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyIds">List of Time Series hierarchy Ids of the Time Series hierarchies to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of hierarchy or error objects corresponding by position to the array in the request.
        /// Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is empty.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetHierarchiesById" language="csharp">
        /// var tsiHierarchyIds = new List&lt;string&gt;
        /// {
        ///     &quot;sampleHierarchyId&quot;
        /// };
        ///
        /// Response&lt;TimeSeriesHierarchyOperationResult[]&gt; getHierarchiesByIdsResult = await hierarchiesClient
        ///             .GetByIdAsync(tsiHierarchyIds);
        ///
        /// // The response of calling the API contains a list of hieararchy or error objects corresponding by position to the input parameter array in the request.
        /// // If the error object is set to null, this means the operation was a success.
        /// for (int i = 0; i &lt; getHierarchiesByIdsResult.Value.Length; i++)
        /// {
        ///     if (getHierarchiesByIdsResult.Value[i].Error == null)
        ///     {
        ///         Console.WriteLine($&quot;Retrieved Time Series hieararchy with Id: &apos;{getHierarchiesByIdsResult.Value[i].Hierarchy.Id}&apos;.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Failed to retrieve a Time Series hieararchy due to &apos;{getHierarchiesByIdsResult.Value[i].Error.Message}&apos;.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> GetByIdAsync(
            IEnumerable<string> timeSeriesHierarchyIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyIds, nameof(timeSeriesHierarchyIds));

                var batchRequest = new HierarchiesBatchRequest()
                {
                    Get = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string hierarchyId in timeSeriesHierarchyIds)
                {
                    batchRequest.Get.HierarchyIds.Add(hierarchyId);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = await _hierarchiesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies by hierarchy Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyIds">List of Time Series hierarchy Ids of the Time Series hierarchies to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of hierarchy or error objects corresponding by position to the array in the request.
        /// Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetByIdAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesHierarchyOperationResult[]> GetById(
            IEnumerable<string> timeSeriesHierarchyIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyIds, nameof(timeSeriesHierarchyIds));

                var batchRequest = new HierarchiesBatchRequest()
                {
                    Get = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string hierarchyId in timeSeriesHierarchyIds)
                {
                    batchRequest.Get.HierarchyIds.Add(hierarchyId);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = _hierarchiesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Get.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series Insights hierarchies asynchronously. If a provided hierarchy is already in use, then this will attempt to replace the existing hierarchy with the provided Time Series hierarchy.
        /// </summary>
        /// <param name="timeSeriesHierarchies">The Time Series Insights hierarchies to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesHierarchies"/> array in the request.
        /// An error object will be set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchies"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchies"/> is empty.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleCreateHierarchies" language="csharp">
        /// TimeSeriesInsightsHierarchies hierarchiesClient = client.GetHierarchiesClient();
        ///
        /// var hierarchySource = new TimeSeriesHierarchySource();
        /// hierarchySource.InstanceFieldNames.Add(&quot;hierarchyLevel1&quot;);
        ///
        /// var tsiHierarchy = new TimeSeriesHierarchy(&quot;sampleHierarchy&quot;, hierarchySource)
        /// {
        ///     Id = &quot;sampleHierarchyId&quot;
        /// };
        ///
        /// var timeSeriesHierarchies = new List&lt;TimeSeriesHierarchy&gt;
        /// {
        ///     tsiHierarchy
        /// };
        ///
        /// // Create Time Series hierarchies
        /// Response&lt;TimeSeriesHierarchyOperationResult[]&gt; createHierarchiesResult = await hierarchiesClient
        ///     .CreateOrReplaceAsync(timeSeriesHierarchies);
        ///
        /// // The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
        /// // If the error object is set to null, this means the operation was a success.
        /// for (int i = 0; i &lt; createHierarchiesResult.Value.Length; i++)
        /// {
        ///     if (createHierarchiesResult.Value[i].Error == null)
        ///     {
        ///         Console.WriteLine($&quot;Created Time Series hierarchy successfully.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Failed to create a Time Series hierarchy: {createHierarchiesResult.Value[i].Error.Message}.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> CreateOrReplaceAsync(
            IEnumerable<TimeSeriesHierarchy> timeSeriesHierarchies,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchies, nameof(timeSeriesHierarchies));

                var batchRequest = new HierarchiesBatchRequest();

                foreach (TimeSeriesHierarchy hierarchy in timeSeriesHierarchies)
                {
                    batchRequest.Put.Add(hierarchy);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = await _hierarchiesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(executeBatchResponse.Value.Put.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series Insights hierarchies synchronously. If a provided hierarchy is already in use, then this will attempt to replace the existing hierarchy with the provided Time Series hierarchy.
        /// </summary>
        /// <param name="timeSeriesHierarchies">The Time Series Insights hierarchies to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of hierarchies or error objects corresponding by position to the <paramref name="timeSeriesHierarchies"/> array in the request.
        /// Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="CreateOrReplaceAsync(IEnumerable{TimeSeriesHierarchy}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchies"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchies"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesHierarchyOperationResult[]> CreateOrReplace(
            IEnumerable<TimeSeriesHierarchy> timeSeriesHierarchies,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchies, nameof(timeSeriesHierarchies));

                var batchRequest = new HierarchiesBatchRequest();

                foreach (TimeSeriesHierarchy hierarchy in timeSeriesHierarchies)
                {
                    batchRequest.Put.Add(hierarchy);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = _hierarchiesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(executeBatchResponse.Value.Put.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights hierarchies by hierarchy names asynchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the input array in the request. null when the operation is successful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteByNameAsync(
            IEnumerable<string> timeSeriesHierarchyNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyNames, nameof(timeSeriesHierarchyNames));

                var batchRequest = new HierarchiesBatchRequest
                {
                    Delete = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string timeSeriesName in timeSeriesHierarchyNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = await _hierarchiesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights hierarchies by hierarchy names synchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the input array in the request. null when the operation is successful.
        /// </returns>
        /// <seealso cref="DeleteByNameAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteByName(
            IEnumerable<string> timeSeriesHierarchyNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyNames, nameof(timeSeriesHierarchyNames));

                var batchRequest = new HierarchiesBatchRequest
                {
                    Delete = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string timeSeriesName in timeSeriesHierarchyNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = _hierarchiesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series Insights hierarchies by hierarchy Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyIds">List of Time Series hierarchy Ids of the Time Series hierarchies to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the input array in the request. null when the operation is successful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is empty.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleDeleteHierarchiesById" language="csharp">
        /// // Delete Time Series hierarchies with Ids
        /// var tsiHierarchyIdsToDelete = new List&lt;string&gt;
        /// {
        ///     &quot;sampleHiearchyId&quot;
        /// };
        ///
        /// Response&lt;TimeSeriesOperationError[]&gt; deleteHierarchiesResponse = await hierarchiesClient
        ///         .DeleteByIdAsync(tsiHierarchyIdsToDelete);
        ///
        /// // The response of calling the API contains a list of error objects corresponding by position to the input parameter
        /// // array in the request. If the error object is set to null, this means the operation was a success.
        /// foreach (TimeSeriesOperationError result in deleteHierarchiesResponse.Value)
        /// {
        ///     if (result != null)
        ///     {
        ///         Console.WriteLine($&quot;Failed to delete a Time Series Insights hierarchy: {result.Message}.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Deleted a Time Series Insights hierarchy successfully.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteByIdAsync(
            IEnumerable<string> timeSeriesHierarchyIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyIds, nameof(timeSeriesHierarchyIds));

                var batchRequest = new HierarchiesBatchRequest
                {
                    Delete = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string hierarchyId in timeSeriesHierarchyIds)
                {
                    batchRequest.Delete.HierarchyIds.Add(hierarchyId);
                }

                Response<HierarchiesBatchResponse> executeBatchResponse = await _hierarchiesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by Time Series Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesHierarchyIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the input array in the request. null when the operation is successful.
        /// </returns>
        /// <seealso cref="DeleteByIdAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesHierarchyIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteById(
            IEnumerable<string> timeSeriesHierarchyIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteById)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesHierarchyIds, nameof(timeSeriesHierarchyIds));

                var batchRequest = new HierarchiesBatchRequest
                {
                    Delete = new HierarchiesRequestBatchGetDelete()
                };

                foreach (string hierarchyId in timeSeriesHierarchyIds ?? Enumerable.Empty<string>())
                {
                    batchRequest.Delete.HierarchyIds.Add(hierarchyId);
                }
                Response<HierarchiesBatchResponse> executeBatchResponse = _hierarchiesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);
                return Response.FromValue(executeBatchResponse.Value.Delete.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
