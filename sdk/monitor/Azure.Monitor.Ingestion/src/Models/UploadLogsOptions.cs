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
        public int MaxConcurrency
        {
            get { return _maxConcurrency; }
            set { _maxConcurrency = AssertNotNegative(value, "MaxConcurrency"); }
        }

        private int _maxConcurrency = 5;

        /// <summary>
        /// An optional EventHandler that provides the list of failed logs and the corresponding exception.
        /// </summary>
        public event SyncAsyncEventHandler<UploadFailedEventArgs> UploadFailedEventHandler;

        internal virtual async Task InvokeEvent(UploadFailedEventArgs uploadFailedArgs)
        {
            await UploadFailedEventHandler.RaiseAsync(uploadFailedArgs, nameof(LogsIngestionClient), "Upload", uploadFailedArgs.ClientDiagnostics).ConfigureAwait(false);
        }

        internal virtual async Task<Exception> OnUploadFailedAsync(UploadFailedEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.IsRunningSynchronously)
                {
#pragma warning disable AZC0103 // Do not wait synchronously in asynchronous scope.
                    // for customer code so async not ran over sync
                    InvokeEvent(eventArgs).GetAwaiter().GetResult();
#pragma warning restore AZC0103 // Do not wait synchronously in asynchronous scope.
                }
                else
                {
                    await InvokeEvent(eventArgs).ConfigureAwait(false);
                }
                return null;
            }
            catch (Exception ex)
            {
                // return exception to caller and caller should check exception to abort processing and rethrow this exception
                return ex;
            }
        }

        internal static int AssertNotNegative(int argumentValue, string argumentName)
        {
            if (argumentValue <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"Argument {argumentName} must be a non-negative concurrency (integer) value. The provided value was {argumentValue}.");
            }
            else
                return argumentValue;
        }

        internal bool HasHandler => UploadFailedEventHandler != null;
    }
}
