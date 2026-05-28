// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class RaiBlocklistResource : ArmResource
    {
        // TODO: remove this operation once issue https://github.com/Azure/azure-sdk-for-net/issues/57716 is resolved.
        /// <summary>
        /// Batch operation to add blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/addRaiBlocklistItems. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RaiBlocklists_BatchAdd. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RaiBlocklistResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Properties describing the custom blocklist items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<RaiBlocklistResource>> BatchAddRaiBlocklistItemAsync(IEnumerable<RaiBlocklistItemBulkContent> content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _raiBlocklistsClientDiagnostics.CreateScope("RaiBlocklistResource.BatchAddRaiBlocklistItem");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _raiBlocklistsRestClient.CreateBatchAddRaiBlocklistItemRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<RaiBlocklistData> response = Response.FromValue(RaiBlocklistData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new RaiBlocklistResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: remove this operation once issue https://github.com/Azure/azure-sdk-for-net/issues/57716 is resolved.
        /// <summary>
        /// Batch operation to add blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/addRaiBlocklistItems. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RaiBlocklists_BatchAdd. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RaiBlocklistResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Properties describing the custom blocklist items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<RaiBlocklistResource> BatchAddRaiBlocklistItem(IEnumerable<RaiBlocklistItemBulkContent> content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _raiBlocklistsClientDiagnostics.CreateScope("RaiBlocklistResource.BatchAddRaiBlocklistItem");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _raiBlocklistsRestClient.CreateBatchAddRaiBlocklistItemRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<RaiBlocklistData> response = Response.FromValue(RaiBlocklistData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new RaiBlocklistResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: remove this operation once issue https://github.com/Azure/azure-sdk-for-net/issues/57716 is resolved.
        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RaiBlocklists_BatchDelete. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RaiBlocklistResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        public virtual async Task<Response> BatchDeleteRaiBlocklistItemAsync(IEnumerable<string> raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            using DiagnosticScope scope = _raiBlocklistsClientDiagnostics.CreateScope("RaiBlocklistResource.BatchDeleteRaiBlocklistItem");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _raiBlocklistsRestClient.CreateBatchDeleteRaiBlocklistItemRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ToRequestContent(raiBlocklistItemsNames), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: remove this operation once issue https://github.com/Azure/azure-sdk-for-net/issues/57716 is resolved.
        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RaiBlocklists_BatchDelete. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RaiBlocklistResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        public virtual Response BatchDeleteRaiBlocklistItem(IEnumerable<string> raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            using DiagnosticScope scope = _raiBlocklistsClientDiagnostics.CreateScope("RaiBlocklistResource.BatchDeleteRaiBlocklistItem");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _raiBlocklistsRestClient.CreateBatchDeleteRaiBlocklistItemRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ToRequestContent(raiBlocklistItemsNames), context);
                Response response = Pipeline.ProcessMessage(message, context);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RaiBlocklistItems_BatchDelete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RaiBlocklistItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> BatchDeleteRaiBlocklistItemAsync(BinaryData raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            return await BatchDeleteRaiBlocklistItemAsync(ParseRaiBlocklistItemNames(raiBlocklistItemsNames), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Batch operation to delete blocklist items.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/raiBlocklists/{raiBlocklistName}/deleteRaiBlocklistItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RaiBlocklistItems_BatchDelete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RaiBlocklistItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="raiBlocklistItemsNames"> List of RAI Blocklist Items Names. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="raiBlocklistItemsNames"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response BatchDeleteRaiBlocklistItem(BinaryData raiBlocklistItemsNames, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(raiBlocklistItemsNames, nameof(raiBlocklistItemsNames));

            return BatchDeleteRaiBlocklistItem(ParseRaiBlocklistItemNames(raiBlocklistItemsNames), cancellationToken);
        }

        private static IEnumerable<string> ParseRaiBlocklistItemNames(BinaryData raiBlocklistItemsNames)
        {
            using JsonDocument document = JsonDocument.Parse(raiBlocklistItemsNames);
            JsonElement root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Array)
            {
                throw new FormatException("The payload must be a JSON array of strings.");
            }

            List<string> names = new List<string>();
            foreach (JsonElement item in root.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    names.Add(null);
                    continue;
                }

                if (item.ValueKind != JsonValueKind.String)
                {
                    throw new FormatException("Each blocklist item name in the payload must be a string or null.");
                }

                names.Add(item.GetString());
            }

            return names;
        }

        private static RequestContent ToRequestContent(IEnumerable<RaiBlocklistItemBulkContent> raiBlocklistItems)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartArray();
                    foreach (var item in raiBlocklistItems)
                    {
                        writer.WriteObjectValue(item, ModelSerializationExtensions.WireOptions);
                    }
                    writer.WriteEndArray();
                }
                return RequestContent.Create(stream.ToArray());
            }
        }

        private static RequestContent ToRequestContent(IEnumerable<string> raiBlocklistItemNames)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartArray();
                    foreach (var item in raiBlocklistItemNames)
                    {
                        if (item is null)
                        {
                            writer.WriteNullValue();
                        }
                        else
                        {
                            writer.WriteStringValue(item);
                        }
                    }
                    writer.WriteEndArray();
                }
                return RequestContent.Create(stream.ToArray());
            }
        }
    }
}
