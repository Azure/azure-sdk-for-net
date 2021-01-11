// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Spark
{
    [CodeGenSuppress("CreateSparkBatchJob", typeof(SparkBatchJobOptions), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSparkBatchJobAsync", typeof(SparkBatchJobOptions), typeof(bool?), typeof(CancellationToken))]
    public partial class SparkBatchClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparkBatchClient"/>.
        /// </summary>
        public SparkBatchClient(Uri endpoint, string sparkPoolName, TokenCredential credential)
            : this(endpoint, sparkPoolName, credential, SparkClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkBatchClient"/>.
        /// </summary>
        public SparkBatchClient(Uri endpoint, string sparkPoolName, TokenCredential credential, SparkClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  sparkPoolName,
                  options.VersionString)
        {
        }

        public virtual async Task<SparkBatchOperation> StartCreateSparkBatchJobAsync(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
            => await StartCreateSparkBatchJobInternal (true, sparkBatchJobOptions, detailed, cancellationToken).ConfigureAwait(false);

        public virtual SparkBatchOperation StartCreateSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
            => StartCreateSparkBatchJobInternal (false, sparkBatchJobOptions, detailed, cancellationToken).EnsureCompleted();

        private async Task<SparkBatchOperation> StartCreateSparkBatchJobInternal (bool async, SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkBatchClient)}.{nameof(StartCreateSparkBatchJob)}");
            scope.Start();
            try
            {
                Response<SparkBatchJob> batchSession;
                if (async)
                {
                    batchSession = await RestClient.CreateSparkBatchJobAsync(sparkBatchJobOptions, detailed, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    batchSession = RestClient.CreateSparkBatchJob(sparkBatchJobOptions, detailed, cancellationToken);
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
}
