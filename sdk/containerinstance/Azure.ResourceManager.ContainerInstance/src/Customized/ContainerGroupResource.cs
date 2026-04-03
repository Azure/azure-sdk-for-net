// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: AttachContainer convenience method from old API (ApiCompat MembersMustExist).
// Delegates to the renamed Attach method.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupResource
    {
        /// <summary> Attach to the output of a specific container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerAttachResult> AttachContainer(string containerName, CancellationToken cancellationToken = default)
        {
            return Attach(containerName, cancellationToken);
        }

        /// <summary> Attach to the output of a specific container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerAttachResult>> AttachContainerAsync(string containerName, CancellationToken cancellationToken = default)
        {
            return await AttachAsync(containerName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Executes a command for a specific container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="content"> The container exec request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerExecResult> ExecuteContainerCommand(string containerName, ContainerExecContent content, CancellationToken cancellationToken = default)
        {
            return ExecuteCommand(containerName, content, cancellationToken);
        }

        /// <summary> Executes a command for a specific container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="content"> The container exec request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerExecResult>> ExecuteContainerCommandAsync(string containerName, ContainerExecContent content, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(containerName, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the logs for a specified container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="tail"> The number of lines to show from the tail of the container instance log. </param>
        /// <param name="timestamps"> If true, adds a timestamp at the beginning of every line of log output. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerLogs> GetContainerLogs(string containerName, int? tail = default, bool? timestamps = default, CancellationToken cancellationToken = default)
        {
            return GetLogs(containerName, tail, timestamps, cancellationToken);
        }

        /// <summary> Get the logs for a specified container instance in a specified resource group and container group. </summary>
        /// <param name="containerName"> The name of the container instance. </param>
        /// <param name="tail"> The number of lines to show from the tail of the container instance log. </param>
        /// <param name="timestamps"> If true, adds a timestamp at the beginning of every line of log output. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerLogs>> GetContainerLogsAsync(string containerName, int? tail = default, bool? timestamps = default, CancellationToken cancellationToken = default)
        {
            return await GetLogsAsync(containerName, tail, timestamps, cancellationToken).ConfigureAwait(false);
        }
    }
}
