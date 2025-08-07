// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;

namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Summarizes the state of a compute node.
    /// </summary>
    public partial class ComputeNode : IRefreshable
    {

        #region ComputeNode

        /// <summary>
        /// Instantiates an unbound ComputeNodeUser object to be populated by the caller and used to create a user account on the compute node in the Azure Batch service.
        /// </summary>
        /// <returns>An <see cref="ComputeNodeUser"/> object.</returns>
        public ComputeNodeUser CreateComputeNodeUser()
        {
            ComputeNodeUser newUser = new ComputeNodeUser(this.parentBatchClient, this.CustomBehaviors, this.parentPoolId, this.Id);

            return newUser;
        }

        /// <summary>
        /// Begins an asynchronous call to delete the specified ComputeNodeUser.
        /// </summary>
        /// <param name="userName">The name of the ComputeNodeUser to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task DeleteComputeNodeUserAsync(
            string userName, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteComputeNodeUser(this.parentPoolId, this.Id, userName, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to delete the specified ComputeNodeUser.
        /// </summary>
        /// <param name="userName">The name of the ComputeNodeUser to be deleted.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>

        public void DeleteComputeNodeUser(string userName, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteComputeNodeUserAsync(userName, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The get remote login settings operation runs asynchronously.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="VirtualMachineConfiguration"/> property. </para>
        /// </remarks>
        public System.Threading.Tasks.Task<RemoteLoginSettings> GetRemoteLoginSettingsAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null,  CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task<RemoteLoginSettings> asyncTask = this.parentBatchClient.PoolOperations.GetRemoteLoginSettingsImpl(
                    this.parentPoolId,
                    this.Id,
                    bhMgr,
                    cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Gets the settings required for remote login to a compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="Microsoft.Azure.Batch.ComputeNode.GetRemoteLoginSettingsAsync"/>.</para>
        /// <para>This method can be invoked only if the pool is created with a <see cref="Microsoft.Azure.Batch.VirtualMachineConfiguration"/> property. </para>
        /// </remarks>
        public RemoteLoginSettings GetRemoteLoginSettings(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<RemoteLoginSettings> asyncTask = GetRemoteLoginSettingsAsync(additionalBehaviors);
            RemoteLoginSettings rls = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            return rls;
        }

        /// <summary>
        /// Begins an asynchronous call to remove the compute node from the pool.
        /// </summary>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">The maximum amount of time which the RemoveFromPool operation can take before being terminated by the Azure Batch system.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task RemoveFromPoolAsync(
            Common.ComputeNodeDeallocationOption? deallocationOption = null, 
            TimeSpan? resizeTimeout = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            List<string> computeNodeIds = new List<string> {this.Id};

            Task asyncTask = this.parentBatchClient.PoolOperations.RemoveFromPoolAsyncImpl(this.parentPoolId, computeNodeIds, deallocationOption, resizeTimeout, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to remove the compute node from the pool.
        /// </summary>
        /// <param name="deallocationOption">
        /// Specifies how to handle tasks already running, and when the nodes running them may be removed from the pool. The default is <see cref="Common.ComputeNodeDeallocationOption.Requeue"/>.
        /// </param>
        /// <param name="resizeTimeout">The maximum amount of time which the RemoveFromPool operation can take before being terminated by the Azure Batch system.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void RemoveFromPool(Common.ComputeNodeDeallocationOption? deallocationOption = null, TimeSpan? resizeTimeout = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RemoveFromPoolAsync(deallocationOption, resizeTimeout, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Blocking call to reboot the compute node.
        /// </summary>
        /// <param name="rebootOption">The reboot option associated with the reboot.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Reboot(Common.ComputeNodeRebootOption? rebootOption = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RebootAsync(rebootOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asynchronous call to reboot the compute node.
        /// </summary>
        /// <param name="rebootOption">The reboot option associated with the reboot.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task RebootAsync(
            Common.ComputeNodeRebootOption? rebootOption = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.RebootComputeNode(this.parentPoolId, this.Id, rebootOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to start the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Start( IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = StartAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asynchronous call to start the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task StartAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.StartComputeNode(this.parentPoolId, this.Id, bhMgr, cancellationToken);

            return asyncTask;
        }


        /// <summary>
        /// Blocking call to deallocate the compute node.
        /// </summary>
        /// <param name="deallocateOption">The deallocate option associated with the deallocate.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Deallocate(Common.ComputeNodeDeallocateOption? deallocateOption = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeallocateAsync(deallocateOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asynchronous call to deallocate the compute node.
        /// </summary>
        /// <param name="deallocateOption">The deallocate option associated with the deallocate.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task DeallocateAsync(
            Common.ComputeNodeDeallocateOption? deallocateOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.DeallocateComputeNode(this.parentPoolId, this.Id, deallocateOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Begins an asynchronous call to reimage the compute node.
        /// </summary>
        /// <param name="reimageOption">The reimage option associated with the reimage.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task ReimageAsync(
            Common.ComputeNodeReimageOption? reimageOption = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.parentBatchClient.ProtocolLayer.ReimageComputeNode(this.parentPoolId, this.Id, reimageOption, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to reimage the compute node.
        /// </summary>
        /// <param name="reimageOption">The reimage option associated with the reimage.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public void Reimage(Common.ComputeNodeReimageOption? reimageOption = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = ReimageAsync(reimageOption, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asynchronous request to get the specified NodeFile.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public System.Threading.Tasks.Task<NodeFile> GetNodeFileAsync(
            string filePath, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task<NodeFile> asyncTask = this.parentBatchClient.PoolOperations.GetNodeFileAsyncImpl(this.parentPoolId, this.Id, filePath, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Blocking call to get the specified NodeFile.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>A bound <see cref="NodeFile"/> object.</returns>
        public NodeFile GetNodeFile(string filePath, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<NodeFile> asyncTask = this.GetNodeFileAsync(filePath, additionalBehaviors);
            return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Copies the contents of a file from the node to the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="stream">The stream to copy the file contents to.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task CopyNodeFileContentToStreamAsync(
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            Task asyncTask = this.parentBatchClient.PoolOperations.CopyNodeFileContentToStreamAsyncImpl(
                this.parentPoolId,
                this.Id,
                filePath,
                stream,
                byteRange,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Copies the contents of a file from the node to the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="stream">The stream to copy the file contents to.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>A bound <see cref="NodeFile"/> object.</returns>
        public void CopyNodeFileContentToStream(
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = this.CopyNodeFileContentToStreamAsync(filePath, stream, byteRange, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Reads the contents of a file from the specified node into a string.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="encoding">The encoding to use. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task<string> CopyNodeFileContentToStringAsync(
            string filePath,
            Encoding encoding = null,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            return this.parentBatchClient.PoolOperations.CopyNodeFileContentToStringAsyncImpl(
                this.parentPoolId,
                this.Id,
                filePath,
                encoding,
                byteRange,
                bhMgr,
                cancellationToken);
        }

        /// <summary>
        /// Reads the contents of a file from the specified node into a string.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="encoding">The encoding to use. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">A byte range defining what section of the file to copy. If omitted, the entire file is downloaded.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>A bound <see cref="NodeFile"/> object.</returns>
        public string CopyNodeFileContentToString(
            string filePath,
            Encoding encoding = null,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<string> asyncTask = this.CopyNodeFileContentToStringAsync(filePath, encoding, byteRange, additionalBehaviors);
            return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Exposes synchronous and asynchronous enumeration of the files for the node.
        /// </summary>
        /// <param name="recursive">If true, performs a recursive list of all files of the node. If false, returns only the files at the node directory root.</param>
        /// <param name="detailLevel">Controls the detail level of the data returned by a call to the Azure Batch Service.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object and after the behavior implementing the DetailLevel.</param>
        /// <returns>An instance of IPagedEnumerable that can be used to enumerate objects using either synchronous or asynchronous patterns.</returns>
        public IPagedEnumerable<NodeFile> ListNodeFiles(bool? recursive = null, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<NodeFile> enumerator = this.parentBatchClient.PoolOperations.ListNodeFilesImpl(this.parentPoolId, this.Id, recursive, bhMgr, detailLevel);

            return enumerator;
        }

        /// <summary>
        /// Enables task scheduling on the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task EnableSchedulingAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.EnableComputeNodeSchedulingAsync(this.parentPoolId, this.Id, additionalBehaviors, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables task scheduling on the compute node.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableScheduling"/>.</remarks>
        public void EnableScheduling(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = EnableSchedulingAsync(additionalBehaviors, CancellationToken.None);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Disables task scheduling on the compute node.
        /// </summary>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>This operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task DisableSchedulingAsync(
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.PoolOperations.DisableComputeNodeSchedulingAsync(this.parentPoolId, this.Id, disableComputeNodeSchedulingOption, additionalBehaviors, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables task scheduling on the compute node.
        /// </summary>
        /// <param name="disableComputeNodeSchedulingOption">Specifies what to do with currently running tasks. The default is <see cref="Common.DisableComputeNodeSchedulingOption.Requeue"/>.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableSchedulingAsync"/>.</remarks>
        public void DisableScheduling(
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DisableSchedulingAsync(disableComputeNodeSchedulingOption, additionalBehaviors, CancellationToken.None);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Upload Azure Batch service log files from the compute node.
        /// </summary>
        /// <param name="containerUrl">
        /// The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s). The URL must include a Shared Access Signature (SAS) granting write permissions to the container.
        /// </param>
        /// <param name="startTime">
        /// The start of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded.
        /// </param>
        /// <param name="endTime">
        /// The end of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded. If this is omitted, the default is the current time.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// This is for gathering Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support.
        /// The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service.
        /// </remarks>
        public System.Threading.Tasks.Task<UploadBatchServiceLogsResult> UploadComputeNodeBatchServiceLogsAsync(
            string containerUrl,
            DateTime startTime,
            DateTime? endTime = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            return this.parentBatchClient.PoolOperations.UploadComputeNodeBatchServiceLogsAsyncImpl(
                this.parentPoolId,
                this.Id,
                containerUrl,
                startTime,
                endTime,
                null,
                bhMgr,
                cancellationToken);
        }

        /// <summary>
        /// Upload Azure Batch service log files from the compute node.
        /// </summary>
        /// <param name="containerUrl">
        /// The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s). The URL must include a Shared Access Signature (SAS) granting write permissions to the container.
        /// </param>
        /// <param name="identityReference">A managed identity to use for writing to the container.</param>
        /// <param name="startTime">
        /// The start of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded.
        /// </param>
        /// <param name="endTime">
        /// The end of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded. If this is omitted, the default is the current time.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// This is for gathering Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support.
        /// The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service.
        /// </remarks>
        public System.Threading.Tasks.Task<UploadBatchServiceLogsResult> UploadComputeNodeBatchServiceLogsAsync(
            string containerUrl,
            ComputeNodeIdentityReference identityReference,
            DateTime startTime,
            DateTime? endTime = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            return this.parentBatchClient.PoolOperations.UploadComputeNodeBatchServiceLogsAsyncImpl(
                this.parentPoolId,
                this.Id,
                containerUrl,
                startTime,
                endTime,
                identityReference,
                bhMgr,
                cancellationToken);
        }

        /// <summary>
        /// Upload Azure Batch service log files from the specified compute node.
        /// </summary>
        /// <param name="containerUrl">
        /// The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s). The URL must include a Shared Access Signature (SAS) granting write permissions to the container.
        /// </param>
        /// <param name="startTime">
        /// The start of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded.
        /// </param>
        /// <param name="endTime">
        /// The end of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded. If this is omitted, the default is the current time.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// This is for gathering Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support.
        /// The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service.
        /// </remarks>
        /// <returns>The result of uploading the batch service logs.</returns>
        public UploadBatchServiceLogsResult UploadComputeNodeBatchServiceLogs(
            string containerUrl,
            DateTime startTime,
            DateTime? endTime = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            var asyncTask = this.UploadComputeNodeBatchServiceLogsAsync(
                containerUrl,
                startTime,
                endTime,
                additionalBehaviors);
            return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Upload Azure Batch service log files from the specified compute node.
        /// </summary>
        /// <param name="containerUrl">
        /// The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s). The URL must include a Shared Access Signature (SAS) granting write permissions to the container.
        /// </param>
        /// <param name="identityReference">A managed identity to use for writing to the container.</param>
        /// <param name="startTime">
        /// The start of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded.
        /// </param>
        /// <param name="endTime">
        /// The end of the time range from which to upload Batch Service log file(s). Any log file containing a log message in the time range will be uploaded.
        /// This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded. If this is omitted, the default is the current time.
        /// </param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// This is for gathering Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support.
        /// The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service.
        /// </remarks>
        /// <returns>The result of uploading the batch service logs.</returns>
        public UploadBatchServiceLogsResult UploadComputeNodeBatchServiceLogs(
            string containerUrl,
            ComputeNodeIdentityReference identityReference,
            DateTime startTime,
            DateTime? endTime = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            var asyncTask = this.UploadComputeNodeBatchServiceLogsAsync(
                containerUrl,
                identityReference,
                startTime,
                endTime,
                additionalBehaviors);
            return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        #endregion ComputeNode

        #region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="ComputeNode"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh. If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous refresh operation.</returns>
        public async Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders>> asyncTask = 
                this.parentBatchClient.ProtocolLayer.GetComputeNode(this.parentPoolId, this.Id, bhMgr, cancellationToken);

            AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get pool from response
            Models.ComputeNode newProtocolComputeNode = response.Body;

            this.propertyContainer = new PropertyContainer(newProtocolComputeNode);
        }

        /// <summary>
        /// Refreshes the <see cref="ComputeNode"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh. If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

#endregion
    }

}
