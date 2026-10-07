// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.ResourceManager.Sql
{
    // Suppressing the string type parameter overloads for job version related APIs, since the jobVersion is the name of the resource SqlServerJobVersion which should be string but the definition in the spec is int, MPG can not handle this scenario correctly.
    // To mitigate this, we alternate the type of the jobVersion paramater in the API spec to string, and add back the int overloads in the code as backward compatibility. And suppress the string overloads in the codegen since they are not expected to be used directly.
    // Open Github issue for MPG: https://github.com/Azure/azure-sdk-for-net/issues/60105, once the issue is resolved, we can remove the int overloads and the suppression attributes in the code.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(string), typeof(CancellationToken))]
    public partial class SqlServerJobVersionCollection
    {
        /// <summary>
        /// Gets a job version.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SqlServerJobVersionResource>> GetAsync(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SqlServerJobVersionData> response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SqlServerJobVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a job version.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SqlServerJobVersionResource> Get(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SqlServerJobVersionData> response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SqlServerJobVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<SqlServerJobVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((SqlServerJobVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<SqlServerJobVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((SqlServerJobVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<SqlServerJobVersionResource>> GetIfExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<SqlServerJobVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((SqlServerJobVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<SqlServerJobVersionResource>(response.GetRawResponse());
                }
                return Response.FromValue(new SqlServerJobVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobVersions_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobVersion"> The version of the job to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<SqlServerJobVersionResource> GetIfExists(int jobVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _jobVersionsClientDiagnostics.CreateScope("SqlServerJobVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobVersion.ToString(CultureInfo.InvariantCulture), context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<SqlServerJobVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(SqlServerJobVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((SqlServerJobVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<SqlServerJobVersionResource>(response.GetRawResponse());
                }
                return Response.FromValue(new SqlServerJobVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
