// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring.Models;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    [CodeGenClient("AuthoringClient")]
    [CodeGenSuppress("GetConversationAuthoringDeploymentResourcesClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringDeploymentsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringProjectsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringTrainingClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringModelsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringPrebuiltsClient", typeof(string))]
    [CodeGenSuppress("GetConversationAuthoringExportedModelsClient", typeof(string))]
    public partial class ConversationAnalysisAuthoringClient
    {
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of AnalyzeConversationAuthoringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint e.g., https://&lt;resource-name&gt;.api.cognitiveservices.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisAuthoringClient(Uri endpoint, AzureKeyCredential credential, ConversationAnalysisAuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationAnalysisAuthoringClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of ConversationAuthoringDeployments. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        public virtual ConversationAuthoringDeployments GetDeployments(string projectName, string deploymentName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringDeployments(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName, deploymentName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringProjects. </summary>
        public virtual ConversationAuthoringProjects GetProjects(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringProjects(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringTraining. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringTraining GetTraining(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringTraining(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringModels GetModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringModels(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringPrebuilts. </summary>
        public virtual ConversationAuthoringPrebuilts GetPrebuilts()
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringPrebuilts(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringExportedModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringExportedModels GetExportedModels(string projectName)
        {
            var resolvedApiVersion = _apiVersion ?? "2024-11-15-preview"; // Use _apiVersion if it exists, otherwise default to the latest version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ConversationAuthoringExportedModels(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion, projectName);
        }

        /// <summary> Lists the deployments belonging to a project. </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeploymentsAsync(string,int?,int?,int?,CancellationToken)']/*" />
        public virtual AsyncPageable<ProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => ProjectDeployment.DeserializeProjectDeployment(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeployments.GetDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments belonging to a project. </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringDeployments.xml" path="doc/members/member[@name='GetDeployments(string,int?,int?,int?,CancellationToken)']/*" />
        public virtual Pageable<ProjectDeployment> GetDeployments(string projectName, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => ProjectDeployment.DeserializeProjectDeployment(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeployments.GetDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments to which an Azure resource is assigned. This doesn't return deployments belonging to projects owned by this resource. It only returns deployments belonging to projects owned by other resources. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringDeploymentResources.xml" path="doc/members/member[@name='GetAssignedResourceDeploymentsAsync(int?,int?,int?,CancellationToken)']/*" />
        public virtual AsyncPageable<AssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAssignedResourceDeploymentsRequest(maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetAssignedResourceDeploymentsNextPageRequest(nextLink, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => AssignedProjectDeploymentsMetadata.DeserializeAssignedProjectDeploymentsMetadata(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetAssignedResourceDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments to which an Azure resource is assigned. This doesn't return deployments belonging to projects owned by this resource. It only returns deployments belonging to projects owned by other resources. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringDeploymentResources.xml" path="doc/members/member[@name='GetAssignedResourceDeployments(int?,int?,int?,CancellationToken)']/*" />
        public virtual Pageable<AssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAssignedResourceDeploymentsRequest(maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetAssignedResourceDeploymentsNextPageRequest(nextLink, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => AssignedProjectDeploymentsMetadata.DeserializeAssignedProjectDeploymentsMetadata(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetAssignedResourceDeployments", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments resources assigned to the project. </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringDeploymentResources.xml" path="doc/members/member[@name='GetDeploymentResourcesAsync(string,int?,int?,int?,CancellationToken)']/*" />
        public virtual AsyncPageable<AssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentResourcesRequest(projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentResourcesNextPageRequest(nextLink, projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => AssignedDeploymentResource.DeserializeAssignedDeploymentResource(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetDeploymentResources", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the deployments resources assigned to the project. </summary>
        /// <param name="projectName"> The new project name. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/ConversationAuthoringDeploymentResources.xml" path="doc/members/member[@name='GetDeploymentResources(string,int?,int?,int?,CancellationToken)']/*" />
        public virtual Pageable<AssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentResourcesRequest(projectName, maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentResourcesNextPageRequest(nextLink, projectName, maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => AssignedDeploymentResource.DeserializeAssignedDeploymentResource(e), ClientDiagnostics, _pipeline, "ConversationAuthoringDeploymentResources.GetDeploymentResources", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the supported prebuilt entities that can be used while creating composed entities. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="language"> The language to get supported prebuilt entities for. Required if multilingual is false. This is BCP-47 representation of a language. For example, use "en" for English, "en-gb" for English (UK), "es" for Spanish etc. </param>
        /// <param name="multilingual"> Whether to get the support prebuilt entities for multilingual or monolingual projects. If true, the language parameter is ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringPrebuilts.xml" path="doc/members/member[@name='GetSupportedPrebuiltEntitiesAsync(int?,int?,int?,string,string,CancellationToken)']/*" />
        public virtual AsyncPageable<PrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, string language = null, string multilingual = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedPrebuiltEntitiesRequest(maxCount, skip, pageSizeHint, language, multilingual, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedPrebuiltEntitiesNextPageRequest(nextLink, maxCount, skip, pageSizeHint, language, multilingual, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => PrebuiltEntity.DeserializePrebuiltEntity(e), ClientDiagnostics, _pipeline, "ConversationAuthoringPrebuilts.GetSupportedPrebuiltEntities", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the supported prebuilt entities that can be used while creating composed entities. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="language"> The language to get supported prebuilt entities for. Required if multilingual is false. This is BCP-47 representation of a language. For example, use "en" for English, "en-gb" for English (UK), "es" for Spanish etc. </param>
        /// <param name="multilingual"> Whether to get the support prebuilt entities for multilingual or monolingual projects. If true, the language parameter is ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringPrebuilts.xml" path="doc/members/member[@name='GetSupportedPrebuiltEntities(int?,int?,int?,string,string,CancellationToken)']/*" />
        public virtual Pageable<PrebuiltEntity> GetSupportedPrebuiltEntities(int? maxCount = null, int? skip = null, int? maxpagesize = null, string language = null, string multilingual = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedPrebuiltEntitiesRequest(maxCount, skip, pageSizeHint, language, multilingual, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedPrebuiltEntitiesNextPageRequest(nextLink, maxCount, skip, pageSizeHint, language, multilingual, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => PrebuiltEntity.DeserializePrebuiltEntity(e), ClientDiagnostics, _pipeline, "ConversationAuthoringPrebuilts.GetSupportedPrebuiltEntities", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the support training config version for a given project type. </summary>
        /// <param name="projectKind"> The project kind. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringTraining.xml" path="doc/members/member[@name='GetTrainingConfigVersionsAsync(AnalyzeConversationAuthoringProjectKind,int?,int?,int?,CancellationToken)']/*" />
        public virtual AsyncPageable<TrainingConfigVersion> GetTrainingConfigVersionsAsync(AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(projectKind.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, projectKind.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => TrainingConfigVersion.DeserializeTrainingConfigVersion(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTraining.GetTrainingConfigVersions", "value", "nextLink", maxpagesize, context);
        }

        /// <summary> Lists the support training config version for a given project type. </summary>
        /// <param name="projectKind"> The project kind. </param>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConversationAuthoringTraining.xml" path="doc/members/member[@name='GetTrainingConfigVersions(AnalyzeConversationAuthoringProjectKind,int?,int?,int?,CancellationToken)']/*" />
        public virtual Pageable<TrainingConfigVersion> GetTrainingConfigVersions(AnalyzeConversationAuthoringProjectKind projectKind, int? maxCount = null, int? skip = null, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(projectKind.ToString(), maxCount, skip, pageSizeHint, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, projectKind.ToString(), maxCount, skip, pageSizeHint, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => TrainingConfigVersion.DeserializeTrainingConfigVersion(e), ClientDiagnostics, _pipeline, "ConversationAuthoringTraining.GetTrainingConfigVersions", "value", "nextLink", maxpagesize, context);
        }
    }
}
