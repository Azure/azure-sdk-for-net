// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Informs the Commit() call that the state transfer between the client and server is 
    /// either a create-user or update-user operation.
    /// </summary>
    public enum ComputeNodeUserCommitSemantics
    {
        /// <summary>
        /// The Commit operation is adding a new user.
        /// </summary>
        AddUser,

        /// <summary>
        /// The Commit operation is updating an existing user.
        /// </summary>
        UpdateUser
    };

    /// <summary>
    /// A user for a specific Azure Batch compute node.
    /// </summary>
    public partial class ComputeNodeUser
    {
        /// <summary>
        /// Begins an asynchronous call to create or update a user account on the compute node.
        /// </summary>
        /// <param name="addOrUpdate">Selects the type of commit operation to perform.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task CommitAsync(
            ComputeNodeUserCommitSemantics addOrUpdate = ComputeNodeUserCommitSemantics.AddUser, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            Task asyncTask;

            if (ComputeNodeUserCommitSemantics.AddUser == addOrUpdate)
            {
                Models.ComputeNodeUser protoUser = new Models.ComputeNodeUser()
                        {
                            Name = this.Name, 
                            Password = this.Password,
                        };
                protoUser.ExpiryTime = this.ExpiryTime;
                protoUser.IsAdmin = this.IsAdmin;
                protoUser.SshPublicKey = this.SshPublicKey;

                // begin the adduser call
                asyncTask = this.parentBatchClient.ProtocolLayer.AddComputeNodeUser(this.parentPoolId, this.parentNodeId, protoUser, bhMgr, cancellationToken);
            }
            else
            {
                // begin the update call
                asyncTask = this.parentBatchClient.ProtocolLayer.UpdateComputeNodeUser(
                    this.parentPoolId, 
                    this.parentNodeId, 
                    this.Name, 
                    this.Password, 
                    this.ExpiryTime, 
                    this.SshPublicKey,
                    bhMgr, 
                    cancellationToken);
            }

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to create or update a user account on the compute node.
        /// </summary>
        /// <param name="addOrUpdate">Selects the type of commit operation to perform.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Commit(ComputeNodeUserCommitSemantics addOrUpdate = ComputeNodeUserCommitSemantics.AddUser, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CommitAsync(addOrUpdate, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asyncrhonous call to delete the current user from the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteComputeNodeUser(this.parentPoolId, this.parentNodeId, this.Name, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// call to delete the current user from the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }
    }
}
