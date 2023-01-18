// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The options model to configure the request to upload logs to Azure Monitor.
    /// </summary>
    public class UploadLogsOptions
    {
        /// <summary>
        /// The serializer to use to convert the log objects to JSON.
        /// <remarks> Default Serializer is System.Text.Json. </remarks>
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// The max concurrent requests to send to the Azure Monitor service when uploading logs.
        /// <remarks> In the Upload method, this parameter is not used as the batches are uploaded in sequence. For parallel uploads, if this value is not set the default concurrency will be 5. </remarks>
        /// </summary>
        public int MaxConcurrency { get; set; }

        /// <summary>
        /// test
        /// </summary>
        public event SyncAsyncEventHandler<UploadFailedArgs> UploadFailed;

        private ClientDiagnostics _clientDiagnostics = new ClientDiagnostics(new LogsIngestionClientOptions());

        internal async Task InvokeEvent(bool isRunningSynchronously, int logsCount, Response response, CancellationToken cancellationToken = default)
        {
            UploadFailedArgs uploadFailedArgs = new UploadFailedArgs(logsCount, new RequestFailedException(response), isRunningSynchronously, cancellationToken);
            await UploadFailed.RaiseAsync(uploadFailedArgs, nameof(LogsIngestionClient), "Upload", _clientDiagnostics).ConfigureAwait(false);
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="logsCount"></param>
        /// <param name="options"></param>
        /// <param name="response"></param>
        /// <param name="cancellationToken"></param>
        protected internal static async void OnException(int logsCount, UploadLogsOptions options, Response response, CancellationToken cancellationToken = default)
        {
            try
            {
                if (options == null)
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    await options.InvokeEvent(isRunningSynchronously: true, logsCount, response, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="logsCount"></param>
        /// <param name="options"></param>
        /// <param name="response"></param>
        /// <param name="cancellationToken"></param>
        protected internal static async Task OnExceptionAsync(int logsCount, UploadLogsOptions options, Response response, CancellationToken cancellationToken = default)
        {
            try
            {
                if (options == null)
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    await options.InvokeEvent(isRunningSynchronously: false, logsCount, response, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
