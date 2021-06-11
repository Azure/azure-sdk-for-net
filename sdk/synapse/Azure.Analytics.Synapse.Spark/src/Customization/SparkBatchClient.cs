// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Spark
{
    #pragma warning disable AZC0002

    [CodeGenSuppress("CreateSparkBatchJob", typeof(RequestContent), typeof(bool?), typeof(RequestOptions))]
    [CodeGenSuppress("CreateSparkBatchJobAsync", typeof(RequestContent), typeof(bool?), typeof(RequestOptions))]
    public partial class SparkBatchClient
    {
        public virtual async Task<SparkBatchOperation> StartCreateSparkBatchJobAsync(RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
            => await StartCreateSparkBatchJobInternal (true, requestBody, detailed, requestOptions).ConfigureAwait(false);

        public virtual SparkBatchOperation StartCreateSparkBatchJob(RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
            => StartCreateSparkBatchJobInternal (false, requestBody, detailed, requestOptions).EnsureCompleted();

        private async Task<SparkBatchOperation> StartCreateSparkBatchJobInternal (bool async, RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkBatchClient)}.{nameof(StartCreateSparkBatchJob)}");
            scope.Start();
            try
            {
                Response batchSession;
                if (async)
                {
                    batchSession = await CreateSparkBatchJobAsync(requestBody, detailed, requestOptions).ConfigureAwait(false);
                }
                else
                {
                    batchSession = CreateSparkBatchJob(requestBody, detailed, requestOptions);
                }
                return new SparkBatchOperation(this, _clientDiagnostics, batchSession);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }

    #pragma warning restore AZC0002
}
