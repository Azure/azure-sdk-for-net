// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward compatibility: RegistryTasks operations (AgentPool, Run, Task, TaskRun, ScheduleRun, GetBuildSourceUploadUrl)
    // have been moved to the separate Azure.ResourceManager.ContainerRegistryTasks package.
    // These deprecated method stubs preserve the old API surface so existing callers get a clear
    // NotSupportedException directing them to the new package, rather than a compile-time break.
    public partial class ContainerRegistryResource
    {
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools()
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string agentPoolName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string agentPoolName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunCollection GetContainerRegistryRuns()
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> GetContainerRegistryRun(string runId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string runId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskCollection GetContainerRegistryTasks()
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskResource> GetContainerRegistryTask(string taskName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string taskName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns()
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string taskRunName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string taskRunName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> ScheduleRun(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> ScheduleRunAsync(ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SourceUploadDefinition> GetBuildSourceUploadUrl(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");
    }
}
