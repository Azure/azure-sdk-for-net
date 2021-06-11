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

    public partial class SparkSessionClient
    {
        public virtual async Task<SparkSessionOperation> StartCreateSparkSessionAsync(RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
            => await StartCreateSparkSessionInternal(true, requestBody, detailed, requestOptions).ConfigureAwait(false);

        public virtual SparkSessionOperation StartCreateSparkSession(RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
            => StartCreateSparkSessionInternal(false, requestBody, detailed, requestOptions).EnsureCompleted();

        private async Task<SparkSessionOperation> StartCreateSparkSessionInternal (bool async, RequestContent requestBody, bool? detailed = null, RequestOptions requestOptions = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkSessionClient)}.{nameof(StartCreateSparkSession)}");
            scope.Start();
            try
            {
                Response session;
                if (async)
                {
                    session = await CreateSparkSessionAsync(requestBody, detailed, requestOptions).ConfigureAwait(false);
                }
                else
                {
                    session = CreateSparkSession(requestBody, detailed, requestOptions);
                }
                return new SparkSessionOperation(this, _clientDiagnostics, session);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<SparkStatementOperation> StartCreateSparkStatementAsync(int sessionId, RequestContent requestBody, RequestOptions requestOptions = default)
            => await StartCreateSparkStatementInternal (true, sessionId, requestBody, requestOptions).ConfigureAwait(false);

        public virtual SparkStatementOperation StartCreateSparkStatement(int sessionId, RequestContent requestBody, RequestOptions requestOptions = default)
            => StartCreateSparkStatementInternal (false, sessionId, requestBody, requestOptions).EnsureCompleted();

        private async Task<SparkStatementOperation> StartCreateSparkStatementInternal (bool async, int sessionId, RequestContent requestBody, RequestOptions requestOptions = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SparkSessionClient)}.{nameof(StartCreateSparkStatement)}");
            scope.Start();
            try
            {
                Response statementSession;
                if (async)
                {
                    statementSession = await CreateSparkStatementAsync(sessionId, requestBody, requestOptions).ConfigureAwait(false);
                }
                else
                {
                    statementSession = CreateSparkStatement(sessionId, requestBody, requestOptions);
                }
                return new SparkStatementOperation(this, _clientDiagnostics, statementSession, sessionId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #pragma warning restore AZC0002
    }
}
