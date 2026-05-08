// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// The historical AutoRest-based SDK exposed `listConnectionStrings` as a
// Pageable<CosmosDBAccountConnectionString> for back-compat (the wire response is
// a single non-paged object with an inline ConnectionStrings array).
//
// MPG/TCGC currently emits this op as Response<DatabaseAccountListConnectionStringsResult>
// and the `Legacy.markAsPageable` decorator declared in client.tsp:2310 has no effect
// for this single-object shape. Suppress the generated overloads and re-implement the
// historical Pageable surface here so customer code keeps compiling.
namespace Azure.ResourceManager.CosmosDB
{
    [CodeGenSuppress("GetConnectionStrings", typeof(CancellationToken))]
    [CodeGenSuppress("GetConnectionStringsAsync", typeof(CancellationToken))]
    public partial class CosmosDBAccountResource
    {
        /// <summary>
        /// Lists the connection strings for the specified Azure Cosmos DB database account.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<CosmosDBAccountConnectionString> GetConnectionStrings(CancellationToken cancellationToken = default)
        {
            Response<DatabaseAccountListConnectionStringsResult> response = GetConnectionStringsCore(cancellationToken);
            Page<CosmosDBAccountConnectionString> page = Page<CosmosDBAccountConnectionString>.FromValues(
                (response.Value?.ConnectionStrings ?? new List<CosmosDBAccountConnectionString>()).ToArray(),
                null,
                response.GetRawResponse());
            return Pageable<CosmosDBAccountConnectionString>.FromPages(new[] { page });
        }

        /// <summary>
        /// Lists the connection strings for the specified Azure Cosmos DB database account.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<CosmosDBAccountConnectionString> GetConnectionStringsAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncConnectionStringsPageable(this, cancellationToken);
        }

        private sealed class AsyncConnectionStringsPageable : AsyncPageable<CosmosDBAccountConnectionString>
        {
            private readonly CosmosDBAccountResource _resource;
            private readonly CancellationToken _ct;

            public AsyncConnectionStringsPageable(CosmosDBAccountResource resource, CancellationToken cancellationToken)
            {
                _resource = resource;
                _ct = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<CosmosDBAccountConnectionString>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<DatabaseAccountListConnectionStringsResult> response = await _resource.GetConnectionStringsCoreAsync(_ct).ConfigureAwait(false);
                yield return Page<CosmosDBAccountConnectionString>.FromValues(
                    (response.Value?.ConnectionStrings ?? new List<CosmosDBAccountConnectionString>()).ToArray(),
                    null,
                    response.GetRawResponse());
            }
        }

        // Direct rest-client calls because the generated GetConnectionStrings overloads are
        // suppressed via [CodeGenSuppress] above. Mirrors the body the generator produced
        // (Generated/CosmosDBAccountResource.cs ~lines 1654-1722).
        private Response<DatabaseAccountListConnectionStringsResult> GetConnectionStringsCore(CancellationToken cancellationToken)
        {
            using Azure.Core.Pipeline.DiagnosticScope scope = _databaseAccountsClientDiagnostics.CreateScope("CosmosDBAccountResource.GetConnectionStrings");
            scope.Start();
            try
            {
                Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
                Azure.Core.HttpMessage message = _databaseAccountsRestClient.CreateGetConnectionStringsRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DatabaseAccountListConnectionStringsResult.FromResponse(result), result);
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<DatabaseAccountListConnectionStringsResult>> GetConnectionStringsCoreAsync(CancellationToken cancellationToken)
        {
            using Azure.Core.Pipeline.DiagnosticScope scope = _databaseAccountsClientDiagnostics.CreateScope("CosmosDBAccountResource.GetConnectionStrings");
            scope.Start();
            try
            {
                Azure.RequestContext context = new Azure.RequestContext { CancellationToken = cancellationToken };
                Azure.Core.HttpMessage message = _databaseAccountsRestClient.CreateGetConnectionStringsRequest(System.Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DatabaseAccountListConnectionStringsResult.FromResponse(result), result);
            }
            catch (System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
