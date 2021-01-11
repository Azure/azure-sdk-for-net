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
    [CodeGenSuppress("CreateSparkSessionAsync", typeof(SparkSessionOptions), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSparkSession", typeof(SparkSessionOptions), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSparkStatementAsync", typeof(int), typeof(SparkStatementOptions), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSparkStatement", typeof(int), typeof(SparkStatementOptions), typeof(CancellationToken))]
    public partial class SparkSessionClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparkSessionClient"/>.
        /// </summary>
        public SparkSessionClient(Uri endpoint, string sparkPoolName, TokenCredential credential)
            : this(endpoint, sparkPoolName, credential, SparkClientOptions.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkSessionClient"/>.
        /// </summary>
        public SparkSessionClient(Uri endpoint, string sparkPoolName, TokenCredential credential, SparkClientOptions options)
            : this(new ClientDiagnostics(options),
                  SynapseClientPipeline.Build(options, credential),
                  endpoint.ToString(),
                  sparkPoolName,
                  options.VersionString)
        {
        }

       public virtual async Task<SparkSessionOperation> StartCreateSparkSessionAsync(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
            => await StartCreateSparkSessionInternal(true, sparkSessionOptions, detailed, cancellationToken).ConfigureAwait(false);

        public virtual SparkSessionOperation StartCreateSparkSession(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
            => StartCreateSparkSessionInternal(false, sparkSessionOptions, detailed, cancellationToken).EnsureCompleted();

        private async Task<SparkSessionOperation> StartCreateSparkSessionInternal (bool async, SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkSessionClient)}.{nameof(StartCreateSparkSession)}");
            scope.Start();
            try
            {
                Response<SparkSession> session;
                if (async)
                {
                    session = await RestClient.CreateSparkSessionAsync(sparkSessionOptions, detailed, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    session = RestClient.CreateSparkSession(sparkSessionOptions, detailed, cancellationToken);
                }
                return new SparkSessionOperation(this, _clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<SparkStatementOperation> StartCreateSparkStatementAsync(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
            => await StartCreateSparkStatementInternal (true, sessionId, sparkStatementOptions, cancellationToken).ConfigureAwait(false);

        internal virtual SparkStatementOperation StartCreateSparkStatement(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
            => StartCreateSparkStatementInternal (false, sessionId, sparkStatementOptions, cancellationToken).EnsureCompleted();

        private async Task<SparkStatementOperation> StartCreateSparkStatementInternal (bool async, int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkSessionClient)}.{nameof(StartCreateSparkStatement)}");
            scope.Start();
            try
            {
                Response<SparkStatement> statementSession;
                if (async)
                {
                    statementSession = await RestClient.CreateSparkStatementAsync(sessionId, sparkStatementOptions, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    statementSession = RestClient.CreateSparkStatement(sessionId, sparkStatementOptions, cancellationToken);
                }
                return new SparkStatementOperation(this, _clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
