// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Ingestion
{
    /// <summary> The IngestionUsingDataCollectionRules service client. </summary>
    [CodeGenSuppress("LogsIngestionClient", typeof(Uri), typeof(TokenCredential), typeof(LogsIngestionClientOptions))]
    public partial class LogsIngestionClient
    {
        /// <summary> The message to show when AOT compilation is used for non-compliant overloads. </summary>
        private const string AotWarningMessage = "Serialization is performed at runtime without a serialization context available.";

        /// <summary> Initializes a new instance of LogsIngestionClient for mocking. </summary>
        protected LogsIngestionClient()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LogsIngestionClient"/>. </summary>
        /// <param name="endpoint"> The Data Collection Endpoint for the Data Collection Rule. For example, https://dce-name.eastus-2.ingest.monitor.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LogsIngestionClient(Uri endpoint, TokenCredential credential, LogsIngestionClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new LogsIngestionClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? LogsIngestionAudience.AzurePublicCloud : options.Audience)}";
            var scopes = new List<string> { authorizationScope };
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, scopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        // The size we use to determine whether to upload as a single PUT BLOB
        // request or stage as multiple blocks.
        // 1 Mb in byte format
        internal static int SingleUploadThreshold = 1024 * 1024;

        // For test purposes only
        // If Compression wants to be turned off (hard to generate 1 Mb data gzipped) set Compression to gzip
        internal static string Compression;

        internal readonly struct BatchedLogs
        {
            public BatchedLogs(List<object> logs, BinaryData logsData)
            {
                Logs = logs;
                LogsData = logsData;
            }

            public List<object> Logs { get; }
            public BinaryData LogsData { get; }
        }

        internal HttpMessage CreateUploadRequest(string ruleId, string streamName, RequestContent content, string contentEncoding, RequestContext context = null)
        {
            var message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);
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
            // If any encoding is specified, avoid gzipping. If contentEncoding == "gzip" that means content is already gzipped, so we shouldn't gzip again
            if (contentEncoding == null)
            {
                // contentEncoding is now "gzip"
                request.Headers.Add("Content-Encoding", "gzip");
                GZipUtf8JsonRequestContent gzContent = new(content);
                request.Content = gzContent;
            }
            else
            {
                request.Headers.Add("Content-Encoding", contentEncoding);
                request.Content = content;
            }
            return message;
        }

        internal static IEnumerable<BatchedLogs> Batch(IEnumerable<BinaryData> logEntries, LogsUploadOptions options = null)
        {
            // Create an ArrayBufferWriter as backing store for Utf8JsonWriter
            ArrayBufferWriter<byte> arrayBuffer = new ArrayBufferWriter<byte>(SingleUploadThreshold);
            Utf8JsonWriter writer = new Utf8JsonWriter(arrayBuffer);
            writer.WriteStartArray();
            List<object> currentLogList = new List<object>();
            foreach (var log in logEntries)
            {
                var memory = log.ToMemory();
                // if single log (as an array) is >= 1 Mb send to be gzipped by itself
                if ((memory.Length + 2) >= SingleUploadThreshold)
                {
                    // Create tempArrayBufferWriter (unsized to store log) and tempWriter for individual log
                    ArrayBufferWriter<byte> tempArrayBuffer = new ArrayBufferWriter<byte>();
                    Utf8JsonWriter tempWriter = new Utf8JsonWriter(tempArrayBuffer);
                    tempWriter.WriteStartArray();
                    WriteMemory(tempWriter, memory);
                    tempWriter.WriteEndArray();
                    tempWriter.Flush();
                    yield return new BatchedLogs(new List<object> { log }, BinaryData.FromBytes(tempArrayBuffer.WrittenMemory));
                    continue;
                }

                // if adding this entry (and array end) would make stream > 1 Mb send current stream now
                if ((writer.BytesCommitted + writer.BytesPending + memory.Length + 2) > SingleUploadThreshold)
                {
                    writer.WriteEndArray();
                    writer.Flush();
                    // This batch is full so send it now
                    yield return new BatchedLogs(currentLogList, BinaryData.FromBytes(arrayBuffer.WrittenMemory));

                    // Reset arrayBuffer and writer for next batch
                    arrayBuffer = new ArrayBufferWriter<byte>(SingleUploadThreshold);
                    writer.Reset(arrayBuffer);
                    writer.WriteStartArray();
                    // reset log list
                    currentLogList = new List<object>();
                }

                // Add entry to stream and update logList
                WriteMemory(writer, memory);
                currentLogList.Add(log);
            }

            // no more logs, send existing stream and LogList if anything
            if (currentLogList.Count > 0)
            {
                writer.WriteEndArray();
                writer.Flush();
                yield return new BatchedLogs(currentLogList, BinaryData.FromBytes(arrayBuffer.WrittenMemory));
            }
        }

        private static void WriteMemory(Utf8JsonWriter writer, ReadOnlyMemory<byte> memory)
        {
            using (JsonDocument doc = JsonDocument.Parse(memory))
            {
                // Comma separator added automatically by JsonDocument
                doc.RootElement.WriteTo(writer);
            }
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
        /// <remarks>
        ///   See error response code and error response message for more detail.
        ///   This overload is not AOT-compliant; for uploading logs in AOT scenarios, use the <see cref="Upload(string, string, IEnumerable{BinaryData}, LogsUploadOptions, CancellationToken)"/> overload with logs that you have serialized to <see cref="BinaryData"/>.
        /// </remarks>
        [RequiresUnreferencedCode(AotWarningMessage)]
        [RequiresDynamicCode(AotWarningMessage)]
        public virtual Response Upload<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(string ruleId, string streamName, IEnumerable<T> logs, LogsUploadOptions options = null, CancellationToken cancellationToken = default)
        {
            var serializedLogs = SerializeLogs(logs, options);
            return Upload(ruleId, streamName, serializedLogs, options, cancellationToken);
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="logs"> The content to send as the body of the request, serialized to <see cref="BinaryData"/> form.</param>
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
        ///     BinaryData.FromObjectAsJson(new {})
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", data);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        ///   See error response code and error response message for more detail.
        ///   This overload is AOT-compliant and should be used in AOT scenarios, as it does not require serialization at runtime.
        /// </remarks>
        public virtual Response Upload(string ruleId, string streamName, IEnumerable<BinaryData> logs, LogsUploadOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logs, nameof(logs));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            Response response = null;
            List<Exception> exceptions = null;
            options ??= new LogsUploadOptions();
            scope.Start();

            // Keep track of the number of failed logs across batches
            int logsFailed = 0;
            var shouldAbort = false;
            // Partition the stream into individual blocks
            foreach (BatchedLogs batch in Batch(logs, options))
            {
                //stop queuing new work on abort
                if (shouldAbort)
                    break;
                try
                {
                    // Cancel all future Uploads if user triggers CancellationToken
                    cancellationToken.ThrowIfCancellationRequested();
                    // Because we are uploading in sequence, wait for each batch to upload before starting the next batch
                    response = UploadBatchListSyncOrAsync(
                        batch,
                        ruleId,
                        streamName,
                        async: false,
                        cancellationToken).EnsureCompleted();

                    if (response.Status != 204)
                    {
                        // if there is no Handler on options, throw exception otherwise raise Handler
                        if (!options.HasHandler)
                        {
                            // throw exception here that is caught in catch and we increment LogsFailed
                            throw new RequestFailedException(response);
                        }
                        else
                        {
                            logsFailed += batch.Logs.Count;
                            var eventArgs = new LogsUploadFailedEventArgs(batch.Logs, new RequestFailedException(response), isRunningSynchronously: true, ClientDiagnostics, cancellationToken);
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
                            // sync/async parameter in eventArgs
                            var userThrownException = options.OnUploadFailedAsync(eventArgs).EnsureCompleted();
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
                            // if exception is thrown stop processing future batches
                            if (userThrownException != null)
                            {
                                shouldAbort = true;
                                AddException(ref exceptions, userThrownException);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!options.HasHandler)
                    {
                        logsFailed += batch.Logs.Count;
                        // If we have an error, add Exception from response into exceptions list without throwing
                        AddException(
                            ref exceptions,
                            ex);
                    }
                    else
                    {
                        logsFailed += batch.Logs.Count;
                        var eventArgs = new LogsUploadFailedEventArgs(batch.Logs, new RequestFailedException(response), isRunningSynchronously: true, ClientDiagnostics, cancellationToken);
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
                        var exceptionOnUpload = options.OnUploadFailedAsync(eventArgs).EnsureCompleted();
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
                        // if exception is thrown stop processing future batches
                        if (exceptionOnUpload != null)
                        {
                            shouldAbort = true;
                            AddException(ref exceptions, exceptionOnUpload);
                        }
                    }

                    // Cancel all future Uploads if user triggers CancellationToken
                    if (ex is OperationCanceledException && cancellationToken.IsCancellationRequested)
                    {
                        shouldAbort = true;
                        AddException(ref exceptions, ex);
                    }
                }
            }
            if (exceptions?.Count > 0)
            {
                var ex = new AggregateException($"{logsFailed} out of the {logs.Count()} logs failed to upload. Please check the InnerExceptions for more details.", exceptions);
                scope.Failed(ex);
                throw ex;
            }

            // If no exceptions return response
            return response; //204 - response of last batch with header
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
        /// <remarks>
        ///   See error response code and error response message for more detail.
        ///   This overload is not AOT-compliant; for uploading logs in AOT scenarios, use the <see cref="UploadAsync(string, string, IEnumerable{BinaryData}, LogsUploadOptions, CancellationToken)"/> overload with logs that you have serialized to <see cref="BinaryData"/>.
        /// </remarks>
        [RequiresUnreferencedCode(AotWarningMessage)]
        [RequiresDynamicCode(AotWarningMessage)]
        public virtual async Task<Response> UploadAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(string ruleId, string streamName, IEnumerable<T> logs, LogsUploadOptions options = null, CancellationToken cancellationToken = default)
        {
            var serializedLogs = SerializeLogs(logs, options);
            return await UploadAsync(ruleId, streamName, serializedLogs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Ingestion API used to directly ingest data using Data Collection Rules. </summary>
        /// <param name="ruleId"> The immutable Id of the Data Collection Rule resource. </param>
        /// <param name="streamName"> The streamDeclaration name as defined in the Data Collection Rule. </param>
        /// <param name="logs"> The content to send as the body of the request, serialized to <see cref="BinaryData"/> form.</param>
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
        ///     BinaryData.FromObjectAsJson(new {})
        /// };
        ///
        /// Response response = client.Upload("<ruleId>", "<streamName>", data);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        ///   See error response code and error response message for more detail.
        ///   This overload is AOT-compliant and should be used in AOT scenarios, as it does not require serialization at runtime.
        /// </remarks>
        public virtual async Task<Response> UploadAsync(string ruleId, string streamName, IEnumerable<BinaryData> logs, LogsUploadOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logs, nameof(logs));
            options ??= new LogsUploadOptions();

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");

            List<Exception> exceptions = null;
            var shouldAbort = false;
            scope.Start();

            // A list of tasks that are currently executing which will
            // always be smaller than or equal to MaxWorkerCount
            var runningTasks = new List<(Task<Response> CurrentTask, List<object> Logs)>();

            // Save first batch to return later
            Task<Response> firstTask = null;
            // Keep track of the number of failed logs across batches
            int logsFailed = 0;
            try
            {
                // Partition the stream into individual blocks
                foreach (BatchedLogs batch in Batch(logs, options))
                {
                    if (shouldAbort)
                        break;

                    // Cancel all future Uploads if user triggers CancellationToken
                    cancellationToken.ThrowIfCancellationRequested();
                    // Start staging the next batch (but don't await the Task!)
                    Task<Response> task = UploadBatchListSyncOrAsync(
                        batch,
                        ruleId,
                        streamName,
                        async: true,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add((task, batch.Logs));

                    // If we run out of workers
                    if (runningTasks.Count >= options.MaxConcurrency)
                    {
                        // Wait for at least one of them to finish
                        await Task.WhenAny(runningTasks.Select(_ => _.CurrentTask)).ConfigureAwait(false);
                        firstTask = runningTasks.First().CurrentTask;
                        // Clear any completed blocks from the task list
                        for (int i = 0; i < runningTasks.Count; i++)
                        {
                            Task<Response> runningTask = runningTasks[i].CurrentTask;
                            if (!runningTask.IsCompleted)
                            {
                                continue;
                            }
                            // Check completed task for Exception/RequestFailedException and increase logsFailed count
                            if (!options.HasHandler)
                            {
                                ProcessCompletedTask(runningTasks[i], ref exceptions, ref logsFailed);
                            }
                            else
                            {
                                var processCompletedTask = await ProcessCompletedTaskEventHandlerAsync(runningTask, batch.Logs, options, cancellationToken).ConfigureAwait(false);
                                logsFailed += processCompletedTask.FailedLogsCount;
                                // if exception is thrown stop processing future batches
                                if (processCompletedTask.Exception != null)
                                {
                                    shouldAbort = true;
                                    AddException(ref exceptions, processCompletedTask.Exception);
                                }
                            }
                            // Remove completed task from task list
                            runningTasks.RemoveAt(i);
                            i--;
                        }
                    }
                } // foreach closed
            } // end of try block
            catch (Exception ex)
            {
                // We do not want to log exceptions here as we will loop through all the tasks later
                // Cancel all future Uploads if user triggers CancellationToken
                if (ex is OperationCanceledException && cancellationToken.IsCancellationRequested)
                {
                    shouldAbort = true;
                    AddException(ref exceptions, ex);
                }
            }

            try
            {
                // Wait for all the remaining blocks to finish uploading
                await Task.WhenAll(runningTasks.Select(_ => _.CurrentTask)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // We do not want to log exceptions here as we will loop through all the tasks later
                // Cancel all future Uploads if user triggers CancellationToken
                if (ex is OperationCanceledException && cancellationToken.IsCancellationRequested)
                {
                    shouldAbort = true;
                    AddException(ref exceptions, ex);
                }
            }

            // At this point, all tasks have completed. Examine tasks to see if they have exceptions. If Status code != 204, add RequestFailedException to list of exceptions. Increment logsFailed accordingly
            foreach (var task in runningTasks)
            {
                // Check completed task for Exception/RequestFailedException and increase logsFailed count
                // if we need to abort we do not need to invoke EventHandler because we need to throw Exception
                if (shouldAbort || !options.HasHandler)
                {
                    ProcessCompletedTask(task, ref exceptions, ref logsFailed);
                }
                else
                {
                    var processTaskResult = await ProcessCompletedTaskEventHandlerAsync(task.CurrentTask, task.Logs, options, cancellationToken).ConfigureAwait(false);
                    logsFailed += processTaskResult.FailedLogsCount;
                    // if exception is thrown stop processing future batches
                    if (processTaskResult.Exception != null)
                    {
                        AddException(ref exceptions, processTaskResult.Exception);
                    }
                }
            }
            if (exceptions?.Count > 0)
            {
                var ex = new AggregateException($"{logsFailed} out of the {logs.Count()} logs failed to upload. Please check the InnerExceptions for more details.", exceptions);
                scope.Failed(ex);
                throw ex;
            }

            // If no exceptions return response
            if (runningTasks.Count == 0)
                return firstTask.Result;
            else
                return runningTasks.Select(_ => _.CurrentTask).Last().Result; //204 - response of last batch with header
        }

        private static void ProcessCompletedTask((Task<Response> CurrentTask, List<object> Logs) runningTask, ref List<Exception> exceptions, ref int logsFailed)
        {
            // If the task was canceled, the OperationCanceledException was already observed and tracked in our exception list.
            if (runningTask.CurrentTask.IsCanceled)
                return;
            int logsCount = runningTask.Logs.Count;
            // If current task has an exception, log the exception and add number of logs in this task to failed logs
            if (runningTask.CurrentTask.Exception != null)
            {
                AddException(
                    ref exceptions,
                    runningTask.CurrentTask.Exception.InnerException ?? runningTask.CurrentTask.Exception);
                logsFailed += logsCount;
            }
            // If current task returned a response that was not a success, log the exception and add number of logs in this task to failed logs
            else if (runningTask.CurrentTask.Result.Status != 204)
            {
                AddException(
                    ref exceptions,
                    new RequestFailedException(runningTask.CurrentTask.Result));
                logsFailed += logsCount;
            }
        }

        internal async Task<(Exception Exception, int FailedLogsCount)> ProcessCompletedTaskEventHandlerAsync(Task<Response> completedTask, List<object> logs, LogsUploadOptions options, CancellationToken cancellationToken)
        {
            // If the task was canceled, the OperationCanceledException was already observed and tracked in our exception list.
            if (completedTask.IsCanceled)
                return (default, default);

            LogsUploadFailedEventArgs eventArgs;
            if (completedTask.Exception != null)
            {
                eventArgs = new LogsUploadFailedEventArgs(logs, completedTask.Exception.InnerException ?? completedTask.Exception, isRunningSynchronously: false, ClientDiagnostics, cancellationToken);
                var exception = await options.OnUploadFailedAsync(eventArgs).ConfigureAwait(false);
                return (exception, logs.Count);
            }
            else if (completedTask.Result.Status != 204)
            {
                eventArgs = new LogsUploadFailedEventArgs(logs, new RequestFailedException(completedTask.Result), isRunningSynchronously: false, ClientDiagnostics, cancellationToken);
                var exception = await options.OnUploadFailedAsync(eventArgs).ConfigureAwait(false);
                return (exception, logs.Count);
            }
            else
            {
                return (null, 0);
            }
        }

        private async Task<Response> UploadBatchListSyncOrAsync(BatchedLogs batch, string ruleId, string streamName, bool async, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateUploadRequest(ruleId, streamName, batch.LogsData, Compression, null);

            if (async)
            {
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                Pipeline.Send(message, cancellationToken);
            }

            return message.Response;
        }

        private static void AddException(ref List<Exception> exceptions, Exception ex)
        {
            exceptions ??= new List<Exception>();
            exceptions.Add(ex);
        }

        [RequiresUnreferencedCode(AotWarningMessage)]
        [RequiresDynamicCode(AotWarningMessage)]
        private static IEnumerable<BinaryData> SerializeLogs<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(IEnumerable<T> logs, LogsUploadOptions options)
        {
            static BinaryData serialize(T log, LogsUploadOptions options) => log switch
            {
                BinaryData binaryData => binaryData,
                _ when options?.Serializer != null => options.Serializer.Serialize(log),
                _ => BinaryData.FromObjectAsJson(log)
            };

            foreach (var log in logs)
            {
               yield return serialize(log, options);
            }
        }
    }
}
