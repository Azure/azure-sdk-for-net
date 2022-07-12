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

        private static IEnumerable<(BinaryData Data, int Start)> BatchingInSequence<T>(IEnumerable<T> logEntries)
        {
            //TODO: use Array pool instead
            MemoryStream stream = new MemoryStream(_singleUploadThreshold);
            WriteMemory(stream, BinaryData.FromString("[").ToMemory());
            int start = 0;
            int entryCount = 0;
            foreach (var log in logEntries)
            {
                BinaryData data = log is BinaryData d ? d : BinaryData.FromObjectAsJson(log);

                var memory = data.ToMemory();
                if ((stream.Length + memory.Length + 1) >= _singleUploadThreshold)
                {
                    WriteMemory(stream, BinaryData.FromString("]").ToMemory());
                    yield return (BinaryData.FromStream(stream), start);
                    start = entryCount;
                }
                else
                {
                    stream.Position = 0;
                }
                WriteMemory(stream, memory);
                WriteMemory(stream, BinaryData.FromString(",").ToMemory());
                entryCount++;
            }
        }

        private static void WriteMemory(MemoryStream stream, ReadOnlyMemory<byte> memory)
        {
            stream.Write(memory.ToArray(), 0, memory.Length); //TODO: fix ToArray
        }

        /// <summary>
        /// Overload upload
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="streamName"></param>
        /// <param name="logEntries"></param>
        /// <param name="cancellationToken"></param>
        public virtual void Upload<T>(string ruleId, string streamName, IEnumerable<T> logEntries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNullOrEmpty(streamName, nameof(streamName));
            Argument.AssertNotNullOrEmpty(logEntries, nameof(logEntries));

            using var scope = ClientDiagnostics.CreateScope("LogsIngestionClient.Upload");
            scope.Start();
            try
            {
                foreach (var partition in BatchingInSequence(logEntries))
                {
                    // Upload it in a single request
                    //using HttpMessage message = CreateUploadRequest(ruleId, streamName, BatchingInSequence.Data, "gzip", context); //TODO: catch errors and correlate with BatchingInSequence.start
                    Upload(ruleId, streamName, partition.Data, "gzip", new RequestContext() { CancellationToken = cancellationToken});
                }
                //var binaryData = BinaryData.FromObjectAsJson(logEntries);
                // If we can compute the size and it's small enough
                //if (TryGetLength(binaryData.ToStream(), out long length) && length < _singleUploadThreshold)
                //{
                //    // Upload it in a single request
                //    using HttpMessage message = CreateUploadRequest(ruleId, streamName, BinaryData.FromObjectAsJson(logEntries), "gzip", context);
                //}

                // Otherwise stage individual blocks one at a time.  It's not as
                // fast as a parallel upload, but you get the benefit of the retry
                // policy working on a single block instead of the entire stream.
                //return UploadInSequence(
                //    content,
                //    blockSize,
                //    blobHttpHeaders,
                //    metadata,
                //    conditions,
                //    progressHandler,
                //    accessTier,
                //    cancellationToken);
                ////using HttpMessage message = CreateUploadRequest(ruleId, streamName, BinaryData.FromObjectAsJson(logEntries), "gzip", context);
                //return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Some streams will throw if you try to access their length so we wrap
        // the check in a TryGet helper.
        private static bool TryGetLength(Stream content, out long length)
        {
            length = 0;
            try
            {
                if (content.CanSeek)
                {
                    length = content.Length;
                    return true;
                }
            }
            catch (NotSupportedException)
            {
            }
            return false;
        }
    }
}
