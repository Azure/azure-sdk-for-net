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
        public event SyncAsyncEventHandler<UploadFailedEventArgs> UploadFailedEventHandler;

        internal ClientDiagnostics _clientDiagnostics;

        internal async Task InvokeEvent(UploadFailedEventArgs uploadFailedArgs, ClientDiagnostics clientDiagnostics)
        {
            await UploadFailedEventHandler.RaiseAsync(uploadFailedArgs, nameof(LogsIngestionClient), "Upload", clientDiagnostics).ConfigureAwait(false);
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="options"></param>
        /// <param name="response"></param>
        protected internal async void OnException(UploadFailedEventArgs eventArgs, UploadLogsOptions options, Response response)
        {
            try
            {
                if (options == null)
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    await options.InvokeEvent(eventArgs, _clientDiagnostics).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="options"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected internal static async Task OnExceptionAsync(UploadFailedEventArgs eventArgs, UploadLogsOptions options, Response response)
        {
            try
            {
                if (options == null)
                {
                    throw new RequestFailedException(response);
                }
                else
                {
                    await options.InvokeEvent(eventArgs, options._clientDiagnostics).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        internal UploadLogsOptions Clone()
        {
            UploadLogsOptions copy = new UploadLogsOptions();
            copy.Serializer = Serializer;
            copy.MaxConcurrency = MaxConcurrency;
            copy.UploadFailedEventHandler = UploadFailedEventHandler;
            return copy;
        }
    }
}
