// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;


    /// <summary>
    /// A certificate that can be installed on compute nodes and can be used to authenticate operations on a node.
    /// </summary>
    public partial class Certificate : IRefreshable
    {
        internal Certificate(BatchClient parentBatchClient, Models.CertificateAddParameter protocolObject, IEnumerable<BatchClientBehavior> baseBehaviors) : 
            this(
            parentBatchClient,
            baseBehaviors,
            protocolObject.Data, 
            protocolObject.Thumbprint, 
            protocolObject.ThumbprintAlgorithm, 
            UtilitiesInternal.MapNullableEnum<Models.CertificateFormat, Common.CertificateFormat>(protocolObject.CertificateFormat),
            protocolObject.Password)
        {
        }

#region Certificate

        /// <summary>
        /// Adds the certificate to the Batch account.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The commit operation runs asynchronously.</remarks>
        public async Task CommitAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start the operation
            Task asyncTask = this.parentBatchClient.ProtocolLayer.AddCertificate(this.GetTransportObject(), bhMgr, cancellationToken);

            // a-wait for comletion
            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Adds the certificate to the Batch account.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitAsync"/>.</remarks>
        public void Commit(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = CommitAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes the certificate from the Batch account.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the certificate be deleted.  The request puts the certificate in the <see cref="Common.CertificateState.Deleting"/> state.
        /// The Batch service will perform the actual certificate deletion without any further client action.</para>
        /// <para>You cannot delete a certificate if a resource (pool or compute node) is using it. Before you can delete a certificate, you must therefore make sure that:</para>
        /// <list type="bullet">
        /// <item><description>The certificate is not associated with any pools.</description></item>
        /// <item><description>The certificate is not installed on any compute nodes.  (Even if you remove a certificate from a pool, it is not removed from existing compute nodes in that pool until they restart.)</description></item>
        /// </list>
        /// <para>If you try to delete a certificate that is in use, the deletion fails. The certificate state changes to <see cref="Common.CertificateState.DeleteFailed"/>.
        /// You can use <see cref="CancelDeleteAsync"/> to set the status back to Active if you decide that you want to continue using the certificate.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteCertificate(this.ThumbprintAlgorithm, this.Thumbprint, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the certificate from the Batch account.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the certificate be deleted.  The request puts the certificate in the <see cref="Common.CertificateState.Deleting"/> state.
        /// The Batch service will perform the actual certificate deletion without any further client action.</para>
        /// <para>You cannot delete a certificate if a resource (pool or compute node) is using it. Before you can delete a certificate, you must therefore make sure that:</para>
        /// <list type="bullet">
        /// <item><description>The certificate is not associated with any pools.</description></item>
        /// <item><description>The certificate is not installed on any compute nodes.  (Even if you remove a certificate from a pool, it is not removed from existing compute nodes in that pool until they restart.)</description></item>
        /// </list>
        /// <para>If you try to delete a certificate that is in use, the deletion fails. The certificate state changes to <see cref="Common.CertificateState.DeleteFailed"/>.
        /// You can use <see cref="CancelDeleteAsync"/> to set the status back to Active if you decide that you want to continue using the certificate.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteAsync"/>.</para>
        /// </remarks>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = DeleteAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Cancels a failed deletion of the certificate.  This can be done only when
        /// the certificate is in the <see cref="Common.CertificateState.DeleteFailed"/> state, and restores the certificate to the <see cref="Common.CertificateState.Active"/> state.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>If you still wish to delete the certificate (instead of returning it to Active), you do not need to cancel
        /// the failed deletion. You must make sure that the certificate is not being used by any resources, and then you
        /// can try again to delete the certificate (see <see cref="DeleteAsync"/>.</para>
        /// <para>The cancel delete operation runs asynchronously.</para>
        /// </remarks>
        public async Task CancelDeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // start operation
            Task asyncTask = this.parentBatchClient.ProtocolLayer.CancelDeleteCertificate(this.ThumbprintAlgorithm, this.Thumbprint, bhMgr, cancellationToken);

            // wait for completion
            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Cancels a failed deletion of the certificate.  This can be done only when
        /// the certificate is in the <see cref="Common.CertificateState.DeleteFailed"/> state, and restores the certificate to the <see cref="Common.CertificateState.Active"/> state.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>If you still wish to delete the certificate (instead of returning it to Active), you do not need to cancel
        /// the failed deletion. You must make sure that the certificate is not being used by any resources, and then you
        /// can try again to delete the certificate (see <see cref="Delete"/>.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CancelDeleteAsync"/>.</para>
        /// </remarks>
        public void CancelDelete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = CancelDeleteAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion Certificate


#region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="Certificate"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Thumbprint"/> or <see cref="ThumbprintAlgorithm"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous refresh operation.</returns>
        public async Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            // start operation
            Task<AzureOperationResponse<Models.Certificate, Models.CertificateGetHeaders>> asyncTask =
                this.parentBatchClient.ProtocolLayer.GetCertificate(this.ThumbprintAlgorithm, this.Thumbprint, bhMgr, cancellationToken);

            AzureOperationResponse<Models.Certificate, Models.CertificateGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // extract the refreshed protocol object
            Models.Certificate refreshedProtoCert = response.Body;

            // swap in the new protocol object
            this.propertyContainer = new PropertyContainer(refreshedProtoCert);
        }

        /// <summary>
        /// Refreshes the current <see cref="Certificate"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Thumbprint"/> or <see cref="ThumbprintAlgorithm"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asynctask = RefreshAsync(detailLevel, additionalBehaviors))
            {
                asynctask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion IRefreshable

    }
}
