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

        /// <summary> Gets a single spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkSession>> GetSparkSessionAsync(int sessionId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.GetSparkSession");
            scope.Start();
            try
            {
                return await RestClient.GetSparkSessionAsync(sessionId, detailed, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkSession> GetSparkSession(int sessionId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.GetSparkSession");
            scope.Start();
            try
            {
                return RestClient.GetSparkSession(sessionId, detailed, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create new spark session. </summary>
        /// <param name="sparkSessionOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkSession>> CreateSparkSessionAsync(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.CreateSparkSession");
            scope.Start();
            try
            {
                return await RestClient.CreateSparkSessionAsync(sparkSessionOptions, detailed, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create new spark session. </summary>
        /// <param name="sparkSessionOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkSession> CreateSparkSession(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.CreateSparkSession");
            scope.Start();
            try
            {
                return RestClient.CreateSparkSession(sparkSessionOptions, detailed, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<SparkSessionOperation> StartGetSparkSessionAsync(int sessionId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartGetSparkSessionAsync");
            scope.Start();
            try
            {
                Response<SparkSession> session = await RestClient.GetSparkSessionAsync(sessionId, detailed, cancellationToken).ConfigureAwait(false);
                return new SparkSessionOperation(this, this._clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual SparkSessionOperation StartGetSparkSession(int sessionId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartGetSparkSession");
            scope.Start();
            try
            {
                Response<SparkSession> session = RestClient.GetSparkSession(sessionId, detailed, cancellationToken);
                return new SparkSessionOperation(this, _clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

       public virtual async Task<SparkSessionOperation> StartCreateSparkSessionAsync(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartCreateSparkSessionAsync");
            scope.Start();
            try
            {
                Response<SparkSession> session = await RestClient.CreateSparkSessionAsync(sparkSessionOptions, detailed, cancellationToken).ConfigureAwait(false);
                return new SparkSessionOperation(this, this._clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual SparkSessionOperation StartCreateSparkSession(SparkSessionOptions sparkSessionOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartCreateSparkSession");
            scope.Start();
            try
            {
                Response<SparkSession> session = RestClient.CreateSparkSession(sparkSessionOptions, detailed, cancellationToken);
                return new SparkSessionOperation(this, this._clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create statement within a spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="sparkStatementOptions"> Livy compatible batch job request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkStatement>> CreateSparkStatementAsync(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.CreateSparkStatement");
            scope.Start();
            try
            {
                return await RestClient.CreateSparkStatementAsync(sessionId, sparkStatementOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create statement within a spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="sparkStatementOptions"> Livy compatible batch job request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkStatement> CreateSparkStatement(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.CreateSparkStatement");
            scope.Start();
            try
            {
                return RestClient.CreateSparkStatement(sessionId, sparkStatementOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single statement within a spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="statementId"> Identifier for the statement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response<SparkStatement>> GetSparkStatementAsync(int sessionId, int statementId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.GetSparkStatement");
            scope.Start();
            try
            {
                return await RestClient.GetSparkStatementAsync(sessionId, statementId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single statement within a spark session. </summary>
        /// <param name="sessionId"> Identifier for the session. </param>
        /// <param name="statementId"> Identifier for the statement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response<SparkStatement> GetSparkStatement(int sessionId, int statementId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.GetSparkStatement");
            scope.Start();
            try
            {
                return RestClient.GetSparkStatement(sessionId, statementId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<SparkStatementOperation> StartCreateSparkStatementAsync(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartCreateSparkStatementAsync");
            scope.Start();
            try
            {
                Response<SparkStatement> statementSession = await RestClient.CreateSparkStatementAsync(sessionId, sparkStatementOptions, cancellationToken).ConfigureAwait(false);
                return new SparkStatementOperation(this, this._clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual SparkStatementOperation StartCreateSparkStatement(int sessionId, SparkStatementOptions sparkStatementOptions, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartCreateSparkStatement");
            scope.Start();
            try
            {
                Response<SparkStatement> statementSession = RestClient.CreateSparkStatement(sessionId, sparkStatementOptions, cancellationToken);
                return new SparkStatementOperation(this, this._clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<SparkStatementOperation> StartGetSparkStatementAsync(int sessionId, int statementId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartGetSparkStatementAsync");
            scope.Start();
            try
            {
                Response<SparkStatement> statementSession = await RestClient.GetSparkStatementAsync(sessionId, statementId, cancellationToken).ConfigureAwait(false);
                return new SparkStatementOperation(this, this._clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual SparkStatementOperation StartGetSparkStatement(int sessionId, int statementId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.StartGetSparkStatement");
            scope.Start();
            try
            {
                Response<SparkStatement> statementSession = RestClient.GetSparkStatement(sessionId, statementId, cancellationToken);
                return new SparkStatementOperation(this, this._clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
