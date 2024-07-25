// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <remarks>
    /// See <see href="https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring"/> for more information about models you can pass to this client.
    /// </remarks>
    /// <seealso href="https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring"/>
    [Obsolete("This client is no longer supported as part of the Conversations SDK. This will be released independently.")]
    public class ConversationAuthoringClient
    {
        public ConversationAuthoringClient(Uri endpoint, TokenCredential credential) 
        {
            throw new NotSupportedException();
        }

        public ConversationAuthoringClient(Uri endpoint, TokenCredential credential, ConversationsClientOptions options)
        {
            throw new NotSupportedException();
        }

        public virtual Uri Endpoint => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Operation<BinaryData>> ExportProjectAsync(WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, RequestContext context)
        {
            throw new NotSupportedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Operation<BinaryData> ExportProject(WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, RequestContext context)
        {
            throw new NotSupportedException();
        }
        public virtual HttpPipeline Pipeline { get; }

        protected ConversationAuthoringClient()
        {
        }

        public ConversationAuthoringClient(Uri endpoint, AzureKeyCredential credential)
        {
        }

        public ConversationAuthoringClient(Uri endpoint, AzureKeyCredential credential, ConversationsClientOptions options)
        {
        }

        public virtual Task<Response> CreateProjectAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response CreateProject(string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetProjectAsync(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetProject(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetDeploymentAsync(string projectName, string deploymentName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetDeployment(string projectName, string deploymentName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetDeploymentJobStatusAsync(string projectName, string deploymentName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetDeploymentJobStatus(string projectName, string deploymentName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetSwapDeploymentsJobStatusAsync(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetSwapDeploymentsJobStatus(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetExportProjectJobStatusAsync(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetExportProjectJobStatus(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetImportProjectJobStatusAsync(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetImportProjectJobStatus(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetTrainedModelAsync(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetTrainedModel(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> DeleteTrainedModelAsync(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response DeleteTrainedModel(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetModelEvaluationSummaryAsync(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetModelEvaluationSummary(string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetLoadSnapshotJobStatusAsync(string projectName, string trainedModelLabel, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetLoadSnapshotJobStatus(string projectName, string trainedModelLabel, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetTrainingJobStatusAsync(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetTrainingJobStatus(string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Response> GetProjectDeletionJobStatusAsync(string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Response GetProjectDeletionJobStatus(string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetProjectsAsync(RequestContext context = null)
        {
            throw new NotSupportedException();
        }
        public virtual Pageable<BinaryData> GetProjects(RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetDeploymentsAsync(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetDeployments(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetTrainedModelsAsync(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetTrainedModels(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetModelEvaluationResultsAsync(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetModelEvaluationResults(string projectName, string trainedModelLabel, string stringIndexType = "Utf16CodeUnit", RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetTrainingJobsAsync(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetTrainingJobs(string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetSupportedLanguagesAsync(string projectKind, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetSupportedLanguages(string projectKind, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetSupportedPrebuiltEntitiesAsync(string language = null, bool? multilingual = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetSupportedPrebuiltEntities(string language = null, bool? multilingual = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual AsyncPageable<BinaryData> GetTrainingConfigVersionsAsync(string projectKind, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Pageable<BinaryData> GetTrainingConfigVersions(string projectKind, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> DeleteProjectAsync(WaitUntil waitUntil, string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> DeleteProject(WaitUntil waitUntil, string projectName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> ExportProjectAsync(WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> ExportProject(WaitUntil waitUntil, string projectName, string exportedProjectFormat = null, string assetKind = null, string stringIndexType = "Utf16CodeUnit", string trainedModelLabel = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> ImportProjectAsync(WaitUntil waitUntil, string projectName, RequestContent content, string exportedProjectFormat = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> ImportProject(WaitUntil waitUntil, string projectName, RequestContent content, string exportedProjectFormat = null, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> TrainAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> Train(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> SwapDeploymentsAsync(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> SwapDeployments(WaitUntil waitUntil, string projectName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> DeployProjectAsync(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> DeployProject(WaitUntil waitUntil, string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> DeleteDeploymentAsync(WaitUntil waitUntil, string projectName, string deploymentName, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation<BinaryData> DeleteDeployment(WaitUntil waitUntil, string projectName, string deploymentName, RequestContext context = null)
        {
            throw new NotSupportedException();

        }

        public virtual Task<Operation> LoadSnapshotAsync(WaitUntil waitUntil, string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Operation LoadSnapshot(WaitUntil waitUntil, string projectName, string trainedModelLabel, RequestContext context = null)
        {
            throw new NotSupportedException();
        }

        public virtual Task<Operation<BinaryData>> CancelTrainingJobAsync(WaitUntil waitUntil, string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();

        }

        public virtual Operation<BinaryData> CancelTrainingJob(WaitUntil waitUntil, string projectName, string jobId, RequestContext context = null)
        {
            throw new NotSupportedException();
        }
    }
}
