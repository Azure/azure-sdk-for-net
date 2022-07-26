// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Ingestion
{
    /// <summary> The IngestionUsingDataCollectionRules service client. </summary>
    [CodeGenClient("IngestionUsingDataCollectionRulesClient")]
    public partial class LogsIngestionClient
    {
        /// <summary> Initializes a new instance of LogsIngestionClient for mocking. </summary>
        protected LogsIngestionClient()
        {
        }

        // The size we use to determine whether to upload as a single PUT BLOB
        // request or stage as multiple blocks.
        private const int _singleUploadThreshold = 1000000; // 1 Mb in byte format

        internal HttpMessage CreateUploadRequest(string ruleId, string streamName, RequestContent content, string contentEncoding, RequestContext context)
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

        ///// <summary>
        ///// test
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="logEntries"></param>
        ///// <returns></returns>
        //public static IEnumerable<(BinaryData Data, int Start)> Batching<T>(IEnumerable<T> logEntries)
        //{
        //    //TODO: use Array pool instead
        //    MemoryStream stream = new MemoryStream(_singleUploadThreshold);
        //    WriteMemory(stream, BinaryData.FromString("[").ToMemory());
        //    int start = 0;
        //    int entryCount = 0;
        //    foreach (var log in logEntries)
        //    {
        //        BinaryData entry = log is BinaryData d ? d : BinaryData.FromObjectAsJson(log);

        //        var memory = entry.ToMemory();
        //        if ((stream.Length + memory.Length + 1) >= _singleUploadThreshold) // if adding this entry makes stream > 1 Mb send current stream now
        //        {
        //            WriteMemory(stream, BinaryData.FromString("]").ToMemory());
        //            yield return (BinaryData.FromStream(stream), start);
        //            start = entryCount;
        //        }
        //        else
        //        {
        //            stream.Position = 0;
        //        }
        //        WriteMemory(stream, memory);
        //        WriteMemory(stream, BinaryData.FromString(",").ToMemory());
        //        entryCount++;
        //    }
        //}

        /// <summary>
        /// test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logEntries"></param>
        /// <returns></returns>
        public static IEnumerable<BinaryData> Batching<T>(IEnumerable<T> logEntries)
        {
            //TODO: use Array pool instead
            MemoryStream stream = new MemoryStream(_singleUploadThreshold);
            WriteMemory(stream, BinaryData.FromString("[").ToMemory());
            int entryCount = 0;
            foreach (var log in logEntries)
            {
                BinaryData entry = log is BinaryData d ? d : BinaryData.FromObjectAsJson(log);

                var memory = entry.ToMemory();
                if ((stream.Length + memory.Length + 1) >= _singleUploadThreshold) // if adding this entry makes stream > 1 Mb send current stream now
                {
                    WriteMemory(stream, BinaryData.FromString("]").ToMemory());
                    stream.Position = 0;
                    yield return (BinaryData.FromStream(stream));
                    stream = new MemoryStream(_singleUploadThreshold);
                }
                else
                {
                    WriteMemory(stream, memory);
                    WriteMemory(stream, BinaryData.FromString(",").ToMemory());
                    if ((entryCount + 1) == logEntries.Count())
                    {
                        // reached end of logEntries and we haven't returned yet
                        WriteMemory(stream, BinaryData.FromString("]").ToMemory());
                        stream.Position = 0;
                        yield return (BinaryData.FromStream(stream));
                    }
                }
                entryCount++;
            }
        }
        private static void WriteMemory(MemoryStream stream, ReadOnlyMemory<byte> memory)
        {
            stream.Write(memory.ToArray(), 0, memory.Length); //TODO: fix ToArray
        }

        ///// <summary>
        ///// Overload upload
        ///// </summary>
        ///// <param name="ruleId"></param>
        ///// <param name="streamName"></param>
        ///// <param name="logEntries"></param>
        ///// <param name="cancellationToken"></param>
        //public virtual void Upload<T>(string ruleId, string streamName, IEnumerable<T> logEntries, CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
        //    Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
        //    Argument.AssertNotNullOrEmpty(logEntries, nameof(logEntries));

        //    using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
        //    scope.Start();
        //    try
        //    {
        //        foreach (var partition in Batching(logEntries))
        //        {
        //            // Upload it in a single request
        //            //using HttpMessage message = CreateUploadRequest(ruleId, streamName, Batching.Data, "gzip", context); //TODO: catch errors and correlate with Batching.start
        //            Upload(ruleId, streamName, partition, "gzip", new RequestContext() { CancellationToken = cancellationToken});
        //        }
        //        //var binaryData = BinaryData.FromObjectAsJson(logEntries);
        //        // If we can compute the size and it's small enough
        //        //if (TryGetLength(binaryData.ToStream(), out long length) && length < _singleUploadThreshold)
        //        //{
        //        //    // Upload it in a single request
        //        //    using HttpMessage message = CreateUploadRequest(ruleId, streamName, BinaryData.FromObjectAsJson(logEntries), "gzip", context);
        //        //}

        //        // Otherwise stage individual blocks one at a time.  It's not as
        //        // fast as a parallel upload, but you get the benefit of the retry
        //        // policy working on a single block instead of the entire stream.
        //        //return UploadInSequence(
        //        //    content,
        //        //    blockSize,
        //        //    blobHttpHeaders,
        //        //    metadata,
        //        //    conditions,
        //        //    progressHandler,
        //        //    accessTier,
        //        //    cancellationToken);
        //        ////using HttpMessage message = CreateUploadRequest(ruleId, streamName, BinaryData.FromObjectAsJson(logEntries), "gzip", context);
        //        //return _pipeline.ProcessMessage(message, context);
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        /// <summary>
        /// Overload upload
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="streamName"></param>
        /// <param name="logEntries"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response Upload<T>(string ruleId, string streamName, IEnumerable<T> logEntries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logEntries, nameof(logEntries));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            scope.Start();
            try
            {
                foreach (var partition in Batching(logEntries))
                {
                    //TODO: catch errors and correlate with Batching.start
                    return Upload(ruleId, streamName, partition, "gzip", new RequestContext() { CancellationToken = cancellationToken });
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            return null;
        }

        /// <summary>
        /// Overload upload
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="streamName"></param>
        /// <param name="logEntries"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response> UploadAsync<T>(string ruleId, string streamName, IEnumerable<T> logEntries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logEntries, nameof(logEntries));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            scope.Start();
            try
            {
                foreach (var partition in Batching(logEntries))
                {
                    //TODO: catch errors and correlate with Batching.start
                    return await UploadAsync(ruleId, streamName, partition, "gzip", new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            return null;
        }
    }
}
