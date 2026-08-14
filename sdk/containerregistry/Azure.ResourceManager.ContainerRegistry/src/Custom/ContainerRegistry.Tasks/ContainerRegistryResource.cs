// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    /// <summary>
    /// Provides backward-compatible task-related operations on a container registry resource.
    /// </summary>
    public partial class ContainerRegistryResource
    {
        /// <summary>
        /// Gets a collection of AgentPools in the resource group
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <returns> An object representing collection of AgentPools and their operations over a AgentPoolResource. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools() => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given agent pool.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string agentPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given agent pool.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string agentPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets a collection of Runs in the resource group
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <returns> An object representing collection of Runs and their operations over a RunResource. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunCollection GetContainerRegistryRuns() => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> GetContainerRegistryRun(string runId, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given run.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="runId"> The run ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string runId, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets a collection of Tasks in the resource group
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <returns> An object representing collection of Tasks and their operations over a TaskResource. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskCollection GetContainerRegistryTasks() => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Get the properties of a specified task.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskResource> GetContainerRegistryTask(string taskName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Get the properties of a specified task.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string taskName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets a collection of TaskRuns in the resource group
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <returns> An object representing collection of TaskRuns and their operations over a TaskRunResource. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns() => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given task run.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string taskRunName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets the detailed information for a given task run.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string taskRunName, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryRunResource> ScheduleRun(ContainerRegistryRunContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Schedules a new run based on the request parameters and add it to the run queue.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryRunResource>> ScheduleRunAsync(ContainerRegistryRunContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Get the upload location for the user to be able to upload the source.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SourceUploadDefinition> GetBuildSourceUploadUrl(CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Get the upload location for the user to be able to upload the source.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock the corresponding method on MockableContainerRegistryTasksResourceGroupResource instead. </description>
        /// </item>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
    }
}
