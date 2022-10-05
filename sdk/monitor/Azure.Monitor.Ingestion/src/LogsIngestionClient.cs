// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Ingestion
{
    /// <summary> The IngestionUsingDataCollectionRules service client. </summary>
    [CodeGenClient("IngestionUsingDataCollectionRulesClient")]
    [CodeGenSuppress("Upload", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("UploadAsync", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    public partial class LogsIngestionClient
    {
        /// <summary> Initializes a new instance of LogsIngestionClient for mocking. </summary>
        protected LogsIngestionClient()
        {
        }

        // The size we use to determine whether to upload as a single PUT BLOB
        // request or stage as multiple blocks.
        internal static int SingleUploadThreshold = 1000000; // 1 Mb in byte format

        // If no concurrency count is provided, default to serial upload (one block at a time).
        private int DefaultWorkerCount = 1;

        internal readonly struct BatchedLogs <T>
        {
            public BatchedLogs(List<T> logsList, BinaryData logsData)
            {
                LogsList = logsList;
                LogsData = logsData;
            }

            public List<T> LogsList { get; }
            public BinaryData LogsData { get; }
        }

        internal readonly struct BatchUpload
        {
            public BatchUpload(Response response, UploadLogsError error)
            {
                Response = response;
                Error = error;
            }

            // The response from the upload
            public Response Response { get; }
            // Contains the error and the associated logs
            public UploadLogsError Error { get; }
        }

        internal HttpMessage CreateUploadRequest(string ruleId, string streamName, RequestContent content, string contentEncoding = "gzip", RequestContext context = null)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/dataCollectionRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendPath("/streams/", false);
            uri.AppendPath(streamName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            if (contentEncoding != null)
            {
                request.Headers.Add("Content-Encoding", contentEncoding);
            }
            if (contentEncoding == "gzip")
            {
                GZipUtf8JsonRequestContent gzContent = new(content);
                request.Content = gzContent;
            }
            else
            {
                request.Content = content;
            }
            return message;
        }

        /// <summary>
        /// Hidden method for batching data - serializing into arrays of JSON no more than SingleUploadThreshold each
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logEntries"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static IEnumerable<BatchedLogs<T>> Batch<T>(IEnumerable<T> logEntries, UploadLogsOptions options = null)
        {
            //TODO: use Array pool instead
            MemoryStream stream = new MemoryStream(SingleUploadThreshold);
            WriteMemory(stream, BinaryData.FromString("[").ToMemory());
            int entryCount = 0;
            List<T> currentLogList = new List<T>();
            foreach (var log in logEntries)
            {
                BinaryData entry;
                // If log is already BinaryData, no need to serialize it
                if (log is BinaryData d)
                    entry = d;
                // If log is not BinaryData, serialize it. Default Serializer is System.Text.Json
                else if (options == null || options.Serializer == null)
                    entry = BinaryData.FromObjectAsJson(log);
                // Otherwise use Serializer specified in options
                else
                    entry = options.Serializer.Serialize(log);

                var memory = entry.ToMemory();
                if (memory.Length > SingleUploadThreshold) // if single log is > 1 Mb send to be gzipped by itself
                {
                    MemoryStream tempStream = new MemoryStream(); // create tempStream for individual log
                    WriteMemory(tempStream, BinaryData.FromString("[").ToMemory());
                    WriteMemory(tempStream, memory);
                    WriteMemory(tempStream, BinaryData.FromString("]").ToMemory());
                    tempStream.Position = 0;
                    yield return new BatchedLogs<T>(new List<T>{log}, BinaryData.FromStream(tempStream));
                }
                else if ((stream.Length + memory.Length + 1) >= SingleUploadThreshold) // if adding this entry makes stream > 1 Mb send current stream now
                {
                    WriteMemory(stream, BinaryData.FromString("]").ToMemory());
                    stream.Position = 0; // set Position to 0 to return everything from beginning of stream
                    yield return new BatchedLogs<T>(currentLogList, BinaryData.FromStream(stream));

                    // reset stream and currentLogList
                    stream = new MemoryStream(SingleUploadThreshold); // reset stream
                    currentLogList = new List<T>(); // reset log list
                    WriteMemory(stream, memory); // add log to memory and currentLogList
                    currentLogList.Add(log);
                }
                else
                {
                    WriteMemory(stream, memory);
                    if ((entryCount + 1) == logEntries.Count())
                    {
                        // reached end of logs and we haven't returned yet
                        WriteMemory(stream, BinaryData.FromString("]").ToMemory());
                        stream.Position = 0;
                        currentLogList.Add(log);
                        yield return new BatchedLogs<T>(currentLogList, BinaryData.FromStream(stream));
                    }
                    else
                    {
                        WriteMemory(stream, BinaryData.FromString(",").ToMemory());
                        currentLogList.Add(log);
                    }
                }
                entryCount++;
            }
        }

        private static void WriteMemory(MemoryStream stream, ReadOnlyMemory<byte> memory)
        {
            stream.Write(memory.ToArray(), 0, memory.Length); //TODO: fix ToArray
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="logs"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="options"> The options model to configure the request to upload logs to Azure Monitor. </param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/>, <paramref name="streamName"/> or <paramref name="logs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> or <paramref name="streamName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-Success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Upload with required parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-account-name.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", data);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> See error response code and error response message for more detail. </remarks>
        public virtual Response<UploadLogsResult> Upload<T>(string ruleId, string streamName, IEnumerable<T> logs, UploadLogsOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logs, nameof(logs));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");

            RequestContext requestContext = GenerateRequestContext(cancellationToken);
            Response response = null;
            List<UploadLogsError> errors = new List<UploadLogsError>();
            try
            {
                scope.Start();

                // Partition the stream into individual blocks
                foreach (BatchedLogs<T> batch in Batch(logs, options))
                {
                    // Because we are uploading in sequence, wait for each batch to upload before starting the next batch
                    BatchUpload task = CommitBatchListSyncOrAsync(
                        batch,
                        ruleId,
                        streamName,
                        false,
                        cancellationToken).EnsureCompleted();

                    // If we have an error, add error from response into errors list which represents the errors from all the batches
                    if (task.Error != null)
                        errors.Add(task.Error);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }

            // Calculate the status using the helper method Status
            UploadLogsResult finalResult = new UploadLogsResult(errors, GetStatus(logs, errors));
            return Response.FromValue(finalResult, response);
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="logs"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="options">  The options model to configure the request to upload logs to Azure Monitor. </param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/>, <paramref name="streamName"/> or <paramref name="logs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> or <paramref name="streamName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-Success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Upload with required parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-account-name.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", data);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> See error response code and error response message for more detail. </remarks>
        public virtual async Task<Response<UploadLogsResult>> UploadAsync<T>(string ruleId, string streamName, IEnumerable<T> logs, UploadLogsOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logs, nameof(logs));

            // Calculate the number of threads to use.
            // If there are 0 workers or an UploadLogsOptions object was not provided, method will run serially. Otherwise will run in parallel with number of workers given.
            int _maxWorkerCount = (options == null || options.MaxConcurrency <= 0) ? DefaultWorkerCount : options.MaxConcurrency;
            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");

            RequestContext requestContext = GenerateRequestContext(cancellationToken);
            Response response = null;
            List<UploadLogsError> errors = new List<UploadLogsError>();

            try
            {
                scope.Start();
                // A list of tasks that are currently executing which will
                // always be smaller than or equal to MaxWorkerCount
                List<Task<BatchUpload>> runningTasks = new();
                // Partition the stream into individual blocks
                foreach (BatchedLogs<T> batch in Batch(logs, options))
                {
                    // Start staging the next batch (but don't await the Task!)
                    Task<BatchUpload> task = CommitBatchListSyncOrAsync(
                        batch,
                        ruleId,
                        streamName,
                        true,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add(task);

                    // If we run out of workers
                    if (runningTasks.Count >= _maxWorkerCount)
                    {
                        // Wait for at least one of them to finish
                        await Task.WhenAny(runningTasks).ConfigureAwait(false);
                        // Clear any completed blocks from the task list
                        for (int i = 0; i < runningTasks.Count; i++)
                        {
                            Task<BatchUpload> runningTask = runningTasks[i];
                            if (!runningTask.IsCompleted)
                            {
                                continue;
                            }

                            // Before removing runningTask - check if it has any errors and add to error list
                            if (runningTask.Result.Error != null)
                                errors.Add(runningTask.Result.Error);

                            // Remove completed task from task list
                            runningTasks.RemoveAt(i);
                            i--;
                        }
                    }
                }

                // Wait for all the remaining blocks to finish uploading
                await Task.WhenAll(runningTasks).ConfigureAwait(false);

                // Process all errors after tasks are done to determine status
                // Will run on a single thread
                foreach (Task<BatchUpload> task in runningTasks)
                {
                    // Go through errors from each task and if we have an error, add error from response into errors list which represents the errors from all the batches
                    if (task.Result.Error != null)
                        errors.Add(task.Result.Error);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }

            // Calculate the status using the helper method Status
            UploadLogsResult finalResult = new UploadLogsResult(errors, GetStatus(logs, errors));
            return Response.FromValue(finalResult, response);
        }

        private async Task<BatchUpload> CommitBatchListSyncOrAsync<T>(BatchedLogs<T> batch, string ruleId, string streamName, bool async, CancellationToken cancellationToken)
        {
            UploadLogsError error = null;
            RequestContext requestContext = GenerateRequestContext(cancellationToken);
            Response response = null;

            using HttpMessage message = CreateUploadRequest(ruleId, streamName, batch.LogsData, "gzip", requestContext);

            if (async)
            {
                response = await _pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = _pipeline.ProcessMessage(message, requestContext, cancellationToken);
            }

            if (response.Status != 204) // if any error is thrown log it
            {
                RequestFailedException requestFailedException = new RequestFailedException(response);
                ResponseError responseError = new ResponseError(requestFailedException.ErrorCode, requestFailedException.Message);
                error = new UploadLogsError(responseError, (IReadOnlyList<BinaryData>)batch.LogsList);
            }
            return new BatchUpload(response, error);
        }

        private static RequestContext GenerateRequestContext(CancellationToken cancellationToken)
        {
            var requestContext = new RequestContext() { CancellationToken = cancellationToken };
            requestContext.AddClassifier(500, false);
            requestContext.AddClassifier(403, false);
            requestContext.AddClassifier(413, false);
            requestContext.AddClassifier(429, false);
            requestContext.AddClassifier(503, false);
            return requestContext;
        }

        private static UploadLogsStatus GetStatus<T>(IEnumerable<T> logEntries, List<UploadLogsError> errors)
        {
            UploadLogsStatus status;
            // Errors holds the lists of all failed logs per batch so summing up these gives us the total number of failed logs
            int totalLogsFailed = 0;
            foreach (UploadLogsError error in errors)
            {
                totalLogsFailed += error.FailedLogs.Count;
            }

            // If there are no errors, all entries were successfully uploaded
            if (totalLogsFailed == 0)
            {
                status = UploadLogsStatus.Success;
            }
            // If the number of total failed logs is equal to the logs count this means all the uploads failed
            else if (totalLogsFailed == logEntries.Count())
            {
                status = UploadLogsStatus.Failure;
            }
            // At least one batch has failed, indicating a PartialFailure result
            else
            {
                status = UploadLogsStatus.PartialFailure;
            }

            return status;
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/>, <paramref name="streamName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> or <paramref name="streamName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call UploadAsync with required parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = await client.UploadAsync("<ruleId>", "<streamName>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call UploadAsync with all parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = await client.UploadAsync("<ruleId>", "<streamName>", RequestContent.Create(data), <gzip>);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> See error response code and error response message for more detail. </remarks>
        public virtual async Task<Response> UploadAsync(string ruleId, string streamName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            try
            {
                scope.Start();
                using HttpMessage message = CreateUploadRequest(ruleId, streamName, content, "gzip", context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/>, <paramref name="streamName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> or <paramref name="streamName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Upload with required parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call Upload with all parameters and request content.
        /// <code><![CDATA[
        /// var credential = new DefaultAzureCredential();
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new LogsIngestionClient(endpoint, credential);
        ///
        /// var data = new[] {
        ///     new {}
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", RequestContent.Create(data), <gzip>);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> See error response code and error response message for more detail. </remarks>
        internal virtual Response Upload(string ruleId, string streamName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            try
            {
                scope.Start();
                using HttpMessage message = CreateUploadRequest(ruleId, streamName, content, "gzip", context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
