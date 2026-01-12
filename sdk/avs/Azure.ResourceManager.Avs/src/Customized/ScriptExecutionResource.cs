// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    // TODO: Remove once https://github.com/Azure/azure-sdk-for-net/issues/54886 is resolved
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetExecutionLogsAsync", typeof(IList<ScriptOutputStreamType>), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetExecutionLogs", typeof(IList<ScriptOutputStreamType>), typeof(CancellationToken))]
    public partial class ScriptExecutionResource : ArmResource
    {
        /// <summary>
        /// Return the logs for a script execution resource
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/scriptExecutions/{scriptExecutionName}/getExecutionLogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ScriptExecutions_GetExecutionLogs. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ScriptExecutionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scriptOutputStreamType"> Name of the desired output stream to return. If not provided, will return all. An empty array will return nothing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ScriptExecutionResource>> GetExecutionLogsAsync(IEnumerable<ScriptOutputStreamType> scriptOutputStreamType = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _scriptExecutionsClientDiagnostics.CreateScope("ScriptExecutionResource.GetExecutionLogs");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = null;
                if (scriptOutputStreamType != null)
                {
                    var jsonContent = new Utf8JsonRequestContent();
                    jsonContent.JsonWriter.WriteStartArray();
                    foreach (ScriptOutputStreamType item in scriptOutputStreamType)
                    {
                        jsonContent.JsonWriter.WriteStringValue(item.ToString());
                    }
                    jsonContent.JsonWriter.WriteEndArray();
                    content = jsonContent;
                }
                HttpMessage message = _scriptExecutionsRestClient.CreateGetExecutionLogsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ScriptExecutionData> response = Response.FromValue(ScriptExecutionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ScriptExecutionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Return the logs for a script execution resource
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/scriptExecutions/{scriptExecutionName}/getExecutionLogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ScriptExecutions_GetExecutionLogs. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ScriptExecutionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scriptOutputStreamType"> Name of the desired output stream to return. If not provided, will return all. An empty array will return nothing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ScriptExecutionResource> GetExecutionLogs(IEnumerable<ScriptOutputStreamType> scriptOutputStreamType = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _scriptExecutionsClientDiagnostics.CreateScope("ScriptExecutionResource.GetExecutionLogs");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = null;
                if (scriptOutputStreamType != null)
                {
                    var jsonContent = new Utf8JsonRequestContent();
                    jsonContent.JsonWriter.WriteStartArray();
                    foreach (ScriptOutputStreamType item in scriptOutputStreamType)
                    {
                        jsonContent.JsonWriter.WriteStringValue(item.ToString());
                    }
                    jsonContent.JsonWriter.WriteEndArray();
                    content = jsonContent;
                }
                HttpMessage message = _scriptExecutionsRestClient.CreateGetExecutionLogsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ScriptExecutionData> response = Response.FromValue(ScriptExecutionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ScriptExecutionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
