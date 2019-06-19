// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Text;

namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// An Azure Batch task.  A task is a piece of work that is associated with a job and runs on a compute node.
    /// </summary>
    public partial class CloudTask : IRefreshable
    {
#region // Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTask"/> class.
        /// </summary>
        /// <param name="id">The id of the task.</param>
        /// <param name="commandline">The command line of the task.</param>
        /// <remarks>The newly created CloudTask is initially not associated with any task in the Batch service.
        /// To associate it with a job and submit it to the Batch service, use <see cref="JobOperations.AddTaskAsync(string, IEnumerable{CloudTask}, BatchClientParallelOptions, ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}}, TimeSpan?, IEnumerable{BatchClientBehavior})"/>.</remarks>
        public CloudTask(string id, string commandline)
        {
            this.propertyContainer = new PropertyContainer();

            // set initial conditions
            this.Id = id;
            this.CommandLine = commandline;

            // set up custom behaviors
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, null);
        }

#endregion // Constructors

        internal BindingState BindingState
        {
            get { return this.propertyContainer.BindingState; }
        }

        /// <summary>
        /// Stages the files listed in the <see cref="FilesToStage"/> list.
        /// </summary>
        /// <param name="allFileStagingArtifacts">An optional collection to customize and receive information about the file staging process.
        /// For more information see <see cref="IFileStagingArtifact"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The staging operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task StageFilesAsync(ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = null)
        {
            // stage all these files
            // TODO: align this copy with threadsafe implementation of the IList<>
            List<IFileStagingProvider> allFiles = this.FilesToStage == null ? new List<IFileStagingProvider>() : new List<IFileStagingProvider>(this.FilesToStage);

            //TODO: There is a threading issue doing this - expose a change tracking box directly and use a lock?
            if (this.FilesToStage != null && this.ResourceFiles == null)
            {
                this.ResourceFiles = new List<ResourceFile>(); //We're about to have some resource files
            }

            // now we have all files, send off to file staging machine
            System.Threading.Tasks.Task fileStagingTask = FileStagingUtils.StageFilesAsync(allFiles, allFileStagingArtifacts);

            // wait for file staging async task
            await fileStagingTask.ConfigureAwait(continueOnCapturedContext: false);

            // now update Task with its new ResourceFiles
            foreach (IFileStagingProvider curFile in allFiles)
            {
                IEnumerable<ResourceFile> curStagedFiles = curFile.StagedFiles;

                foreach (ResourceFile curStagedFile in curStagedFiles)
                {
                    this.ResourceFiles.Add(curStagedFile);
                }
            }
        }

        /// <summary>
        /// Stages the files listed in the <see cref="FilesToStage"/> list.
        /// </summary>
        /// <returns>A collection of information about the file staging process.
        /// For more information see <see cref="IFileStagingArtifact"/>.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="StageFilesAsync"/>.</remarks>
        public ConcurrentDictionary<Type, IFileStagingArtifact> StageFiles()
        {
            ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts = new ConcurrentDictionary<Type,IFileStagingArtifact>();

            Task asyncTask = StageFilesAsync(allFileStagingArtifacts);
            asyncTask.WaitAndUnaggregateException();

            return allFileStagingArtifacts;
        }

        /// <summary>
        /// Enumerates the files in the <see cref="CloudTask"/>'s directory on its compute node.
        /// </summary>
        /// <param name="recursive">If true, performs a recursive list of all files of the task. If false, returns only the files in the root task directory.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{NodeFile}"/> that can be used to enumerate files asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the file data is retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; file data is retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<NodeFile> ListNodeFiles(bool? recursive = null, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<NodeFile> enumerator = this.parentBatchClient.JobOperations.ListNodeFilesImpl(this.parentJobId, this.Id, recursive, bhMgr, detailLevel);

            return enumerator;
        }

        /// <summary>
        /// Enumerates the subtasks of the multi-instance <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{SubtaskInformation}"/> that can be used to enumerate files asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the file data is retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; file data is retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<SubtaskInformation> ListSubtasks(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<SubtaskInformation> enumerator = this.parentBatchClient.JobOperations.ListSubtasksImpl(this.parentJobId, this.Id, bhMgr, detailLevel);

            return enumerator;
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudTask" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The commit operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task CommitAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.propertyContainer.IsReadOnly = true;

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            if (BindingState.Unbound == this.propertyContainer.BindingState)
            {
                //TODO: Implement task submission via .Commit here
                UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);
            }
            else
            {
                Models.TaskConstraints protoTaskConstraints = UtilitiesInternal.CreateObjectWithNullCheck(this.Constraints, o => o.GetTransportObject());

                System.Threading.Tasks.Task<AzureOperationHeaderResponse<Models.TaskUpdateHeaders>> asyncTaskUpdate = 
                    this.parentBatchClient.ProtocolLayer.UpdateTask(
                        this.parentJobId,
                        this.Id,
                        protoTaskConstraints,
                        bhMgr,
                        cancellationToken);

                await asyncTaskUpdate.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudTask" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitAsync"/>.</para>
        /// </remarks>
        public void Commit(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CommitAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Terminates this <see cref="CloudTask"/>, marking it as completed.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        /// <remarks>The terminate operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task TerminateAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.TerminateTask(
                this.parentJobId,
                this.Id,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Terminates this <see cref="CloudTask"/>, marking it as completed.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="TerminateAsync"/>.</remarks>
        public void Terminate(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = TerminateAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }


        /// <summary>
        /// Deletes this <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>The delete operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteTask(
                this.parentJobId,
                this.Id,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Deletes this <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteAsync"/>.</remarks>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Reactivates this <see cref="CloudTask"/>, allowing it to run again even if its retry count has been exhausted.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Reactivation makes a task eligible to be retried again up to its maximum retry count.
        /// </para> 
        /// <para>
        /// This operation will fail for tasks that are not completed or that previously completed successfully (with an exit code of 0).
        /// Additionally, this will fail if the job is in the <see cref="JobState.Completed"/> or <see cref="JobState.Terminating"/> or <see cref="JobState.Deleting"/> state.
        /// </para>
        /// <para>
        /// The reactivate operation runs asynchronously.
        /// </para>
        /// </remarks>
        public System.Threading.Tasks.Task ReactivateAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.ReactivateTask(
                this.parentJobId,
                this.Id,
                bhMgr,
                cancellationToken); 

            return asyncTask;
        }

        /// <summary>
        /// Reactivates this <see cref="CloudTask"/>, allowing it to run again even if its retry count has been exhausted.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>
        /// Reactivation makes a task eligible to be retried again up to its maximum retry count.
        /// </para> 
        /// <para>
        /// This operation will fail for tasks that are not completed or that previously completed successfully (with an exit code of 0).
        /// Additionally, this will fail if the job is in the <see cref="JobState.Completed"/> or <see cref="JobState.Terminating"/> or <see cref="JobState.Deleting"/> state.
        /// </para>
        /// <para>
        /// This is a blocking operation. For a non-blocking equivalent, see <see cref="ReactivateAsync"/>.
        /// </para>
        /// </remarks>
        public void Reactivate(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = ReactivateAsync(additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Gets the specified <see cref="NodeFile"/> from the <see cref="CloudTask"/>'s directory on its compute node.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="NodeFile"/> representing the specified file.</returns>
        /// <remarks>The get file operation runs asynchronously.</remarks>
        public System.Threading.Tasks.Task<NodeFile> GetNodeFileAsync(
            string filePath,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            //create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            //make the call
            System.Threading.Tasks.Task<NodeFile> asyncTask = this.parentBatchClient.JobOperations.GetNodeFileAsyncImpl(this.parentJobId, this.Id, filePath, bhMgr, cancellationToken);

            return asyncTask;
        }


        /// <summary>
        /// Gets the specified <see cref="NodeFile"/> from the <see cref="CloudTask"/>'s directory on its compute node.
        /// </summary>
        /// <param name="filePath">The path of the file to retrieve.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="NodeFile"/> representing the specified file.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetNodeFileAsync"/>.</remarks>
        public NodeFile GetNodeFile(string filePath, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<NodeFile> asyncTask = this.GetNodeFileAsync(filePath, additionalBehaviors);
            NodeFile file = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            return file;
        }

        /// <summary>
        /// Copies the contents of a file in the task's directory from the node to the given <see cref="Stream"/>.
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
                this.parentJobId,
                this.Id,
                filePath,
                stream,
                byteRange,
                bhMgr,
                cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Copies the contents of a file in the task's directory from the node to the given <see cref="Stream"/>.
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
        /// Reads the contents of a file in the task's directory on its compute node into a string.
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
                this.parentJobId,
                this.Id,
                filePath,
                encoding,
                byteRange,
                bhMgr,
                cancellationToken);
        }

        /// <summary>
        /// Reads the contents of a file in the task's directory on its compute node into a string.
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

        #region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        public async System.Threading.Tasks.Task RefreshAsync(
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // create the behavior managaer
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            System.Threading.Tasks.Task<AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>> asyncTask = 
                this.parentBatchClient.ProtocolLayer.GetTask(
                    this.parentJobId,
                    this.Id,
                    bhMgr,
                    cancellationToken);

            AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get task from response
            Models.CloudTask newProtocolTask = response.Body;

            // immediately available to all threads
            this.propertyContainer = new PropertyContainer(newProtocolTask);
        }

        /// <summary>
        /// Refreshes the current <see cref="CloudTask"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        #endregion IRefreshable
    }
}
