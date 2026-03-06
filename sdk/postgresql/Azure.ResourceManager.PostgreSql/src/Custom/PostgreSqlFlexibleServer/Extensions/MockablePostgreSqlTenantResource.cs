// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    /// <summary> A class to add extension methods to <see cref="Azure.ResourceManager.Resources.TenantResource"/>. </summary>
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    public partial class MockablePostgreSqlFlexibleServersTenantResource : ArmResource
    {
        /// <summary>
        /// Gets the private DNS zone suffix.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = PrivateDnsZoneSuffixClientDiagnostics.CreateScope("MockablePostgreSqlFlexibleServersTenantResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PrivateDnsZoneSuffixRestClient.CreateGetRequest(context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                string value = DeserializeStringFromResponse(result);
                Response<string> response = Response.FromValue(value, result);
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
        public virtual Response<string> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = PrivateDnsZoneSuffixClientDiagnostics.CreateScope("MockablePostgreSqlFlexibleServersTenantResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PrivateDnsZoneSuffixRestClient.CreateGetRequest(context);
                Response result = Pipeline.ProcessMessage(message, context);
                string value = DeserializeStringFromResponse(result);
                Response<string> response = Response.FromValue(value, result);
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

        private static string DeserializeStringFromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            if (document.RootElement.ValueKind == JsonValueKind.Object && document.RootElement.TryGetProperty("value", out JsonElement valueElement))
            {
                return valueElement.GetString();
            }
            return document.RootElement.GetString();
        }
    }
}
