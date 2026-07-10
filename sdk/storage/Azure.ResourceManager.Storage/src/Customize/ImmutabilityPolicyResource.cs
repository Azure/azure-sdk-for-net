// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds method overloads accepting ETag directly (prior GA used Azure.ETag type)
// instead of string. The generated methods use string for If-Match headers.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Storage
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<ImmutabilityPolicyResource>.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Delete", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    public partial class ImmutabilityPolicyResource
    {
        /// <summary> Deletes an immutability policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<ImmutabilityPolicyResource>> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ifMatch, nameof(ifMatch));

            return DeleteAsyncInternal(waitUntil, ifMatch, cancellationToken);
        }

        /// <summary> Deletes an immutability policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<ImmutabilityPolicyResource> Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ifMatch, nameof(ifMatch));

            using DiagnosticScope scope = _blobContainersClientDiagnostics.CreateScope("ImmutabilityPolicyResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _blobContainersRestClient.CreateDeleteImmutabilityPolicyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, context);
                Response response = Pipeline.ProcessMessage(message, context);
                Response<ImmutabilityPolicyData> typedResponse = Response.FromValue(ImmutabilityPolicyData.FromResponse(response), response);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                StorageArmOperation<ImmutabilityPolicyResource> operation = new StorageArmOperation<ImmutabilityPolicyResource>(Response.FromValue(new ImmutabilityPolicyResource(Client, typedResponse.Value), typedResponse.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Backward-compatible overload: Delete with ETag parameter.
        /// <summary> Deletes an immutability policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ImmutabilityPolicyResource> Delete(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        // Backward-compatible overload: DeleteAsync with ETag parameter.
        /// <summary> Deletes an immutability policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ImmutabilityPolicyResource>> DeleteAsync(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        private async Task<ArmOperation<ImmutabilityPolicyResource>> DeleteAsyncInternal(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _blobContainersClientDiagnostics.CreateScope("ImmutabilityPolicyResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _blobContainersRestClient.CreateDeleteImmutabilityPolicyRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ImmutabilityPolicyData> typedResponse = Response.FromValue(ImmutabilityPolicyData.FromResponse(response), response);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                StorageArmOperation<ImmutabilityPolicyResource> operation = new StorageArmOperation<ImmutabilityPolicyResource>(Response.FromValue(new ImmutabilityPolicyResource(Client, typedResponse.Value), typedResponse.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Backward-compatible overload: ExtendImmutabilityPolicy with ETag parameter.
        /// <summary> Extends the immutability period of an unlocked immutability policy. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="data"> The immutability policy properties to extend for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> ExtendImmutabilityPolicy(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken = default)
            => ExtendImmutabilityPolicy(ifMatch.ToString(), data, cancellationToken);

        // Backward-compatible overload: ExtendImmutabilityPolicyAsync with ETag parameter.
        /// <summary> Extends the immutability period of an unlocked immutability policy. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="data"> The immutability policy properties to extend for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> ExtendImmutabilityPolicyAsync(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken = default)
            => ExtendImmutabilityPolicyAsync(ifMatch.ToString(), data, cancellationToken);

        // Backward-compatible overload: LockImmutabilityPolicy with ETag parameter.
        /// <summary> Locks an unlocked immutability policy. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> LockImmutabilityPolicy(ETag ifMatch, CancellationToken cancellationToken = default)
            => LockImmutabilityPolicy(ifMatch.ToString(), cancellationToken);

        // Backward-compatible overload: LockImmutabilityPolicyAsync with ETag parameter.
        /// <summary> Locks an unlocked immutability policy. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to return to the server for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> LockImmutabilityPolicyAsync(ETag ifMatch, CancellationToken cancellationToken = default)
            => LockImmutabilityPolicyAsync(ifMatch.ToString(), cancellationToken);
    }
}
