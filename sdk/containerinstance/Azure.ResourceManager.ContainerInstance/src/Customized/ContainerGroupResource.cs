// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupResource
    {
        /// <summary> Attach to the output of a specific container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerAttachResult> AttachContainer(string containerName, CancellationToken cancellationToken = default)
        {
            var response = Attach(containerName, cancellationToken);
            return Response.FromValue(new ContainerAttachResult(response.Value), response.GetRawResponse());
        }

        /// <summary> Attach to the output of a specific container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerAttachResult>> AttachContainerAsync(string containerName, CancellationToken cancellationToken = default)
        {
            var response = await AttachAsync(containerName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerAttachResult(response.Value), response.GetRawResponse());
        }

        /// <summary> Executes a command for a specific container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerExecResult> ExecuteContainerCommand(string containerName, ContainerExecContent containerExecRequest, CancellationToken cancellationToken = default)
        {
            var response = ExecuteCommand(containerName, containerExecRequest, cancellationToken);
            return Response.FromValue(new ContainerExecResult(response.Value), response.GetRawResponse());
        }

        /// <summary> Executes a command for a specific container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerExecResult>> ExecuteContainerCommandAsync(string containerName, ContainerExecContent containerExecRequest, CancellationToken cancellationToken = default)
        {
            var response = await ExecuteCommandAsync(containerName, containerExecRequest, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerExecResult(response.Value), response.GetRawResponse());
        }

        /// <summary> Get the logs for a specified container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerLogs> GetContainerLogs(string containerName, int? tail = null, bool? timestamps = null, CancellationToken cancellationToken = default)
        {
            var response = GetLogs(containerName, tail, timestamps, cancellationToken);
            return Response.FromValue(new ContainerLogs(response.Value), response.GetRawResponse());
        }

        /// <summary> Get the logs for a specified container instance in a specified resource group and container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerLogs>> GetContainerLogsAsync(string containerName, int? tail = null, bool? timestamps = null, CancellationToken cancellationToken = default)
        {
            var response = await GetLogsAsync(containerName, tail, timestamps, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerLogs(response.Value), response.GetRawResponse());
        }
    }
}
