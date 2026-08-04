// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ScVmm
{
    public partial class ScVmmVirtualMachineInstanceResource
    {
        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Creates a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> CreateCheckpointAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return CreateCheckpointAsync(waitUntil, content: null, cancellationToken);
        }

        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Creates a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation CreateCheckpoint(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return CreateCheckpoint(waitUntil, content: null, cancellationToken);
        }

        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Deletes a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> DeleteCheckpointAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return DeleteCheckpointAsync(waitUntil, content: null, cancellationToken);
        }

        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Deletes a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation DeleteCheckpoint(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return DeleteCheckpoint(waitUntil, content: null, cancellationToken);
        }

        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Restores to a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> RestoreCheckpointAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return RestoreCheckpointAsync(waitUntil, content: null, cancellationToken);
        }

        // The TypeSpec action body is optional, but the C# generator currently emits the content
        // parameter as required. AutoRest shipped source-compatible calls with omitted content.
        /// <summary> Restores to a checkpoint in virtual machine instance. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation RestoreCheckpoint(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return RestoreCheckpoint(waitUntil, content: null, cancellationToken);
        }
    }
}
