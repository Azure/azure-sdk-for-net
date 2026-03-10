// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    [CodeGenSuppress("ExecuteGetPrivateDnsZoneSuffixAsync", typeof(CancellationToken))]
    [CodeGenSuppress("ExecuteGetPrivateDnsZoneSuffix", typeof(CancellationToken))]
    public partial class MockablePostgreSqlFlexibleServersTenantResource
    {
        /// <summary>
        /// Gets the private DNS zone suffix.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = PrivateDnsZoneSuffixClientDiagnostics.CreateScope("MockablePostgreSqlFlexibleServersTenantResource.ExecuteGetPrivateDnsZoneSuffix");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PrivateDnsZoneSuffixRestClient.CreateExecuteGetPrivateDnsZoneSuffixRequest(context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<string> response = Response.FromValue(result.Content.ToString(), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the private DNS zone suffix.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> ExecuteGetPrivateDnsZoneSuffix(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = PrivateDnsZoneSuffixClientDiagnostics.CreateScope("MockablePostgreSqlFlexibleServersTenantResource.ExecuteGetPrivateDnsZoneSuffix");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PrivateDnsZoneSuffixRestClient.CreateExecuteGetPrivateDnsZoneSuffixRequest(context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<string> response = Response.FromValue(result.Content.ToString(), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
