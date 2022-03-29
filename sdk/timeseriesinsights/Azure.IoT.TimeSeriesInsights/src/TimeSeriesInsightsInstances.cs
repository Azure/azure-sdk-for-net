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
    /// Perform operations such as creating, listing, replacing and deleting Time Series instances.
    /// </summary>
    public class TimeSeriesInsightsInstances
    {
        private readonly TimeSeriesInstancesRestClient _instancesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of TimeSeriesInsightsInstances. This constructor should only be used for mocking purposes.
        /// </summary>
        protected TimeSeriesInsightsInstances()
        {
        }

        internal TimeSeriesInsightsInstances(TimeSeriesInstancesRestClient instancesRestClient, ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(instancesRestClient, nameof(instancesRestClient));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _instancesRestClient = instancesRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Gets Time Series instances in pages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsGetAllInstances" language="csharp">
        /// // Get all instances for the Time Series Insights environment
        /// AsyncPageable&lt;TimeSeriesInstance&gt; tsiInstances = instancesClient.GetAsync();
        /// await foreach (TimeSeriesInstance tsiInstance in tsiInstances)
        /// {
        ///     Console.WriteLine($&quot;Retrieved Time Series Insights instance with Id &apos;{tsiInstance.TimeSeriesId}&apos; and name &apos;{tsiInstance.Name}&apos;.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<TimeSeriesInstance> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesInstance>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _instancesRestClient
                            .ListAsync(null, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<TimeSeriesInstance>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = await _instancesRestClient
                            .ListAsync(nextLink, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
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
        /// Gets Time Series instances synchronously in pages.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesInstance}"/> of Time Series instances belonging to the TSI environment and the http response.</returns>
        /// <seealso cref="GetAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesInstance> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();

            try
            {
                Page<TimeSeriesInstance> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = _instancesRestClient.List(null, null, cancellationToken);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<TimeSeriesInstance> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
                    scope.Start();

                    try
                    {
                        Response<GetInstancesPage> getInstancesResponse = _instancesRestClient.List(nextLink, null, cancellationToken);
                        return Page.FromValues(getInstancesResponse.Value.Instances, getInstancesResponse.Value.ContinuationToken, getInstancesResponse.GetRawResponse());
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
        /// Gets Time Series instances by instance names asynchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> GetByNameAsync(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                var batchRequest = new InstancesBatchRequest
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
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
        /// Gets Time Series instances by instance names synchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetByNameAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> GetByName(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                var batchRequest = new InstancesBatchRequest
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Get.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
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
        /// Gets Time Series instances by Time Series Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsGetnstancesById" language="csharp">
        /// // Get Time Series Insights instances by Id
        /// // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
        /// var timeSeriesIds = new List&lt;TimeSeriesId&gt;
        /// {
        ///     tsId,
        /// };
        ///
        /// Response&lt;InstancesOperationResult[]&gt; getByIdsResult = await instancesClient.GetByIdAsync(timeSeriesIds);
        ///
        /// // The response of calling the API contains a list of instance or error objects corresponding by position to the array in the request.
        /// // Instance object is set when operation is successful and error object is set when operation is unsuccessful.
        /// for (int i = 0; i &lt; getByIdsResult.Value.Length; i++)
        /// {
        ///     InstancesOperationResult currentOperationResult = getByIdsResult.Value[i];
        ///
        ///     if (currentOperationResult.Instance != null)
        ///     {
        ///         Console.WriteLine($&quot;Retrieved Time Series Insights instance with Id &apos;{currentOperationResult.Instance.TimeSeriesId}&apos; and name &apos;{currentOperationResult.Instance.Name}&apos;.&quot;);
        ///     }
        ///     else if (currentOperationResult.Error != null)
        ///     {
        ///         Console.WriteLine($&quot;Failed to retrieve a Time Series Insights instance with Id &apos;{timeSeriesIds[i]}&apos;. Error message: &apos;{currentOperationResult.Error.Message}&apos;.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> GetByIdAsync(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                var batchRequest = new InstancesBatchRequest
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Get.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
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
        /// Gets Time Series instances by Time Series Ids synchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of instance or error objects corresponding by position to the array in the request. Instance object is set when operation is successful
        /// and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="GetByIdAsync(IEnumerable{TimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> GetById(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                var batchRequest = new InstancesBatchRequest
                {
                    Get = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Get.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
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
        /// Creates Time Series instances asynchronously. If a provided instance is already in use, then this will attempt to replace the existing
        /// instance with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request.
        /// A <seealso cref="TimeSeriesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleCreateInstance" language="csharp">
        /// // Create a Time Series Instance object with the default Time Series Insights type Id.
        /// // The default type Id can be obtained programmatically by using the ModelSettings client.
        /// // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
        /// var instance = new TimeSeriesInstance(tsId, defaultTypeId)
        /// {
        ///     Name = &quot;instance1&quot;,
        /// };
        ///
        /// var tsiInstancesToCreate = new List&lt;TimeSeriesInstance&gt;
        /// {
        ///     instance,
        /// };
        ///
        /// Response&lt;TimeSeriesOperationError[]&gt; createInstanceErrors = await instancesClient
        ///     .CreateOrReplaceAsync(tsiInstancesToCreate);
        ///
        /// // The response of calling the API contains a list of error objects corresponding by position to the input parameter
        /// // array in the request. If the error object is set to null, this means the operation was a success.
        /// for (int i = 0; i &lt; createInstanceErrors.Value.Length; i++)
        /// {
        ///     TimeSeriesId tsiId = tsiInstancesToCreate[i].TimeSeriesId;
        ///
        ///     if (createInstanceErrors.Value[i] == null)
        ///     {
        ///         Console.WriteLine($&quot;Created Time Series Insights instance with Id &apos;{tsiId}&apos;.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Failed to create a Time Series Insights instance with Id &apos;{tsiId}&apos;, &quot; +
        ///             $&quot;Error Message: &apos;{createInstanceErrors.Value[i].Message}, &quot; +
        ///             $&quot;Error code: &apos;{createInstanceErrors.Value[i].Code}&apos;.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> CreateOrReplaceAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                var batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Put.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the instances,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates Time Series instances synchronously. If a provided instance is already in use, then this will attempt to replace the existing
        /// instance with the provided Time Series Instance.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be created or replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request.
        /// A <seealso cref="TimeSeriesOperationError"/> object will be set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="CreateOrReplaceAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> CreateOrReplace(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateOrReplace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                var batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Put.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                // Extract the errors array from the response. If there was an error with creating or replacing one of the instances,
                // it will be placed at the same index location that corresponds to its place in the input array.
                IEnumerable<TimeSeriesOperationError> errorResults = executeBatchResponse.Value.Put.Select((result) => result.Error);

                return Response.FromValue(errorResults.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces Time Series instances asynchronously.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request. Instance object
        /// is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsReplaceInstance" language="csharp">
        /// // Get Time Series Insights instances by Id
        /// // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
        /// var instanceIdsToGet = new List&lt;TimeSeriesId&gt;
        /// {
        ///     tsId,
        /// };
        ///
        /// Response&lt;InstancesOperationResult[]&gt; getInstancesByIdResult = await instancesClient.GetByIdAsync(instanceIdsToGet);
        ///
        /// TimeSeriesInstance instanceResult = getInstancesByIdResult.Value[0].Instance;
        /// Console.WriteLine($&quot;Retrieved Time Series Insights instance with Id &apos;{instanceResult.TimeSeriesId}&apos; and name &apos;{instanceResult.Name}&apos;.&quot;);
        ///
        /// // Now let&apos;s replace the instance with an updated name
        /// instanceResult.Name = &quot;newInstanceName&quot;;
        ///
        /// var instancesToReplace = new List&lt;TimeSeriesInstance&gt;
        /// {
        ///     instanceResult,
        /// };
        ///
        /// Response&lt;InstancesOperationResult[]&gt; replaceInstancesResult = await instancesClient.ReplaceAsync(instancesToReplace);
        ///
        /// // The response of calling the API contains a list of error objects corresponding by position to the input parameter.
        /// // array in the request. If the error object is set to null, this means the operation was a success.
        /// for (int i = 0; i &lt; replaceInstancesResult.Value.Length; i++)
        /// {
        ///     TimeSeriesId tsiId = instancesToReplace[i].TimeSeriesId;
        ///
        ///     TimeSeriesOperationError currentError = replaceInstancesResult.Value[i].Error;
        ///
        ///     if (currentError != null)
        ///     {
        ///         Console.WriteLine($&quot;Failed to replace Time Series Insights instance with Id &apos;{tsiId}&apos;,&quot; +
        ///             $&quot; Error Message: &apos;{currentError.Message}&apos;, Error code: &apos;{currentError.Code}&apos;.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Replaced Time Series Insights instance with Id &apos;{tsiId}&apos;.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual async Task<Response<InstancesOperationResult[]>> ReplaceAsync(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics
                .CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Replace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                var batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Update.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
                    .ExecuteBatchAsync(batchRequest, null, cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(executeBatchResponse.Value.Update.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces Time Series instances synchronously.
        /// </summary>
        /// <param name="timeSeriesInstances">The Time Series instances to be replaced.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of objects corresponding by position to the <paramref name="timeSeriesInstances"/> array in the request. Instance object
        /// is set when operation is successful and error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="ReplaceAsync(IEnumerable{TimeSeriesInstance}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesInstances"/> is empty.
        /// </exception>
        public virtual Response<InstancesOperationResult[]> Replace(
            IEnumerable<TimeSeriesInstance> timeSeriesInstances,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Replace)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesInstances, nameof(timeSeriesInstances));

                var batchRequest = new InstancesBatchRequest();

                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    batchRequest.Update.Add(instance);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
                    .ExecuteBatch(batchRequest, null, cancellationToken);

                return Response.FromValue(executeBatchResponse.Value.Update.ToArray(), executeBatchResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes Time Series instances from the environment by instance names asynchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleDeleteInstanceById" language="csharp">
        /// // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
        /// var instancesToDelete = new List&lt;TimeSeriesId&gt;
        /// {
        ///     tsId,
        /// };
        ///
        /// Response&lt;TimeSeriesOperationError[]&gt; deleteInstanceErrors = await instancesClient
        ///     .DeleteByIdAsync(instancesToDelete);
        ///
        /// // The response of calling the API contains a list of error objects corresponding by position to the input parameter
        /// // array in the request. If the error object is set to null, this means the operation was a success.
        /// for (int i = 0; i &lt; deleteInstanceErrors.Value.Length; i++)
        /// {
        ///     TimeSeriesId tsiId = instancesToDelete[i];
        ///
        ///     if (deleteInstanceErrors.Value[i] == null)
        ///     {
        ///         Console.WriteLine($&quot;Deleted Time Series Insights instance with Id &apos;{tsiId}&apos;.&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine($&quot;Failed to delete a Time Series Insights instance with Id &apos;{tsiId}&apos;. Error Message: &apos;{deleteInstanceErrors.Value[i].Message}&apos;&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteByNameAsync(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                var batchRequest = new InstancesBatchRequest
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
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
        /// Deletes Time Series instances from the environment by instance names synchronously.
        /// </summary>
        /// <param name="timeSeriesNames">List of names of the Time Series instance to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteByNameAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesNames"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteByName(
            IEnumerable<string> timeSeriesNames,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteByName)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesNames, nameof(timeSeriesNames));

                var batchRequest = new InstancesBatchRequest
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (string timeSeriesName in timeSeriesNames)
                {
                    batchRequest.Delete.Names.Add(timeSeriesName);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
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
        /// Deletes Time Series instances from the environment by Time Series Ids asynchronously.
        /// </summary>
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteByIdAsync(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                var batchRequest = new InstancesBatchRequest
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Delete.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = await _instancesRestClient
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
        /// <param name="timeSeriesIds">List of Ids of the Time Series instances to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// List of error objects corresponding by position to the array in the request. Null means the instance has been deleted, or did not exist.
        /// Error object is set when operation is unsuccessful.
        /// </returns>
        /// <seealso cref="DeleteByIdAsync(IEnumerable{TimeSeriesId}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The exception is thrown when <paramref name="timeSeriesIds"/> is empty.
        /// </exception>
        public virtual Response<TimeSeriesOperationError[]> DeleteById(
            IEnumerable<TimeSeriesId> timeSeriesIds,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(DeleteById)}");
            scope.Start();

            try
            {
                Argument.AssertNotNullOrEmpty(timeSeriesIds, nameof(timeSeriesIds));

                var batchRequest = new InstancesBatchRequest
                {
                    Delete = new InstancesRequestBatchGetOrDelete()
                };

                foreach (TimeSeriesId timeSeriesId in timeSeriesIds)
                {
                    batchRequest.Delete.TimeSeriesIds.Add(timeSeriesId);
                }

                Response<InstancesBatchResponse> executeBatchResponse = _instancesRestClient
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
