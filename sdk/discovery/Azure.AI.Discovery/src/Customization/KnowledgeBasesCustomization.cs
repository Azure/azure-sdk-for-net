// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.AI.Discovery
{
    // Customizes the KnowledgeBases create/update and delete long-running operations.
    //
    // The Bookshelf create/update LRO returns the KnowledgeBase resource on its
    // Operation-Location. That body carries two status-like fields:
    //   * provisioningState -> the create/update lifecycle (Accepted -> Succeeded)
    //   * status            -> the *indexing* lifecycle, which stays "NotStarted"
    //                          for a freshly created KB until indexing is started.
    // Azure.Core's default poller keys off "status", which never reaches a
    // create-terminal value, so CreateOrUpdate(WaitUntil.Completed, ...) would poll
    // forever even though the KB provisions successfully. The delete LRO's
    // operation-status monitor is likewise broken (returns 404 from the first poll).
    //
    // These replacements poll the KnowledgeBase resource itself: create/update reads
    // provisioningState, delete treats a 404 (resource gone) as success. This mirrors
    // the customizations already shipped in the other-language Discovery SDKs.
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(string), typeof(RequestContext))]
    public partial class KnowledgeBases
    {
        /// <summary> Creates or updates a KnowledgeBase, polling <c>provisioningState</c> to completion. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> to wait for the long-running operation to finish provisioning; <see cref="WaitUntil.Started"/> to return immediately. </param>
        /// <param name="knowledgeBaseName"> The knowledgeBase name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The long-running operation for the create or update request. </returns>
        public virtual Operation<BinaryData> CreateOrUpdate(WaitUntil waitUntil, string knowledgeBaseName, RequestContent content, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBases.CreateOrUpdate");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));
                Argument.AssertNotNull(content, nameof(content));

                using HttpMessage message = CreateCreateOrUpdateRequest(knowledgeBaseName, content, context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new ProvisioningStateOperation(this, knowledgeBaseName, response, context);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(context?.CancellationToken ?? default);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a KnowledgeBase, polling <c>provisioningState</c> to completion. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> to wait for the long-running operation to finish provisioning; <see cref="WaitUntil.Started"/> to return immediately. </param>
        /// <param name="knowledgeBaseName"> The knowledgeBase name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The long-running operation for the create or update request. </returns>
        public virtual async Task<Operation<BinaryData>> CreateOrUpdateAsync(WaitUntil waitUntil, string knowledgeBaseName, RequestContent content, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBases.CreateOrUpdate");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));
                Argument.AssertNotNull(content, nameof(content));

                using HttpMessage message = CreateCreateOrUpdateRequest(knowledgeBaseName, content, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new ProvisioningStateOperation(this, knowledgeBaseName, response, context);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a KnowledgeBase, polling the resource until it is removed (HTTP 404). </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> to wait for the resource to be removed; <see cref="WaitUntil.Started"/> to return immediately. </param>
        /// <param name="knowledgeBaseName"> The knowledgeBase name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The long-running operation for the delete request. </returns>
        public virtual Operation Delete(WaitUntil waitUntil, string knowledgeBaseName, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBases.Delete");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

                using HttpMessage message = CreateDeleteRequest(knowledgeBaseName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                var operation = new DeleteUntilGoneOperation(this, knowledgeBaseName, response, context);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(context?.CancellationToken ?? default);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a KnowledgeBase, polling the resource until it is removed (HTTP 404). </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> to wait for the resource to be removed; <see cref="WaitUntil.Started"/> to return immediately. </param>
        /// <param name="knowledgeBaseName"> The knowledgeBase name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The long-running operation for the delete request. </returns>
        public virtual async Task<Operation> DeleteAsync(WaitUntil waitUntil, string knowledgeBaseName, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBases.Delete");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

                using HttpMessage message = CreateDeleteRequest(knowledgeBaseName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var operation = new DeleteUntilGoneOperation(this, knowledgeBaseName, response, context);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Read-only poll of the KnowledgeBase resource. Uses Pipeline.Send so a
        // non-success status (e.g. 404 during delete) is returned rather than thrown.
        internal Response GetForPolling(string knowledgeBaseName, RequestContext context, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateGetRequest(knowledgeBaseName, context);
            Pipeline.Send(message, cancellationToken);
            return message.Response;
        }

        internal async ValueTask<Response> GetForPollingAsync(string knowledgeBaseName, RequestContext context, CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateGetRequest(knowledgeBaseName, context);
            await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        internal static string ReadProvisioningState(Response response)
        {
            try
            {
                BinaryData content = response.Content;
                if (content == null || content.ToMemory().Length == 0)
                {
                    return null;
                }
                using JsonDocument doc = JsonDocument.Parse(content);
                if (doc.RootElement.ValueKind != JsonValueKind.Object)
                {
                    return null;
                }
                if (doc.RootElement.TryGetProperty("provisioningState", out JsonElement ps) && ps.ValueKind == JsonValueKind.String)
                {
                    return ps.GetString();
                }
                if (doc.RootElement.TryGetProperty("status", out JsonElement st) && st.ValueKind == JsonValueKind.String)
                {
                    return st.GetString();
                }
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
