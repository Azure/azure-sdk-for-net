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

        /// <summary> Create new spark batch job. </summary>
        /// <param name="sparkBatchJobOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkBatchJob>> CreateSparkBatchJobAsync(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.CreateSparkBatchJob");
            scope.Start();
            try
            {
                return await RestClient.CreateSparkBatchJobAsync(sparkBatchJobOptions, detailed, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create new spark batch job. </summary>
        /// <param name="sparkBatchJobOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkBatchJob> CreateSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.CreateSparkBatchJob");
            scope.Start();
            try
            {
                return RestClient.CreateSparkBatchJob(sparkBatchJobOptions, detailed, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<SparkBatchOperation> StartCreateSparkBatchJobAsync(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.StartCreateSparkBatchJobAsync");
            scope.Start();
            try
            {
                Response<SparkBatchJob> batchSession = await RestClient.CreateSparkBatchJobAsync(sparkBatchJobOptions, detailed, cancellationToken).ConfigureAwait(false);
                return new SparkBatchOperation(this, this._clientDiagnostics, batchSession);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual SparkBatchOperation StartCreateSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.StartCreateSparkBatchJob");
            scope.Start();
            try
            {
                Response<SparkBatchJob> batchSession = RestClient.CreateSparkBatchJob(sparkBatchJobOptions, detailed, cancellationToken);
                return new SparkBatchOperation(this, this._clientDiagnostics, batchSession);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkBatchJob>> GetSparkBatchJobAsync(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.GetSparkBatchJob");
            scope.Start();
            try
            {
                return await RestClient.GetSparkBatchJobAsync(batchId, detailed, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkBatchJob> GetSparkBatchJob(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.GetSparkBatchJob");
            scope.Start();
            try
            {
                return RestClient.GetSparkBatchJob(batchId, detailed, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<SparkBatchOperation> StartGetSparkBatchJobAsync(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.StartGetSparkBatchJobAsync");
            scope.Start();
            try
            {
                Response<SparkBatchJob> batchSession = await RestClient.GetSparkBatchJobAsync(batchId, detailed, cancellationToken).ConfigureAwait(false);
                return new SparkBatchOperation(this, this._clientDiagnostics, batchSession);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual SparkBatchOperation StartGetSparkBatchJob(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkBatchClient.StartGetSparkBatchJob");
            scope.Start();
            try
            {
                Response<SparkBatchJob> batchSession = RestClient.GetSparkBatchJob(batchId, detailed, cancellationToken);
                return new SparkBatchOperation(this, this._clientDiagnostics, batchSession);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
