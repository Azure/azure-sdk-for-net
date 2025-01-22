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
    public partial class AnalyzeConversationClient
    {
        private readonly string _apiVersion;

        public AnalyzeConversationClient(Uri endpoint, AzureKeyCredential credential, AnalyzeConversationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AnalyzeConversationClientOptions();

            _apiVersion = options.Version; // Store version from options
            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        // New GetCopyProjectConversationAuthoringAnalysisClient method
        public virtual CopyProjectConversationAuthoringAnalysis GetCopyProjectConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new CopyProjectConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual DeploymentsConversationAuthoringAnalysis GetDeploymentsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new DeploymentsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ProjectsConversationAuthoringAnalysis GetProjectsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ProjectFilesConversationAuthoringAnalysis GetProjectFilesConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ProjectFilesConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual TrainingConversationAuthoringAnalysis GetTrainingConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new TrainingConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ModelsConversationAuthoringAnalysis GetModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual PrebuiltsConversationAuthoringAnalysis GetPrebuiltsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new PrebuiltsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }

        public virtual ExportedModelsConversationAuthoringAnalysis GetExportedModelsConversationAuthoringAnalysisClient(string apiVersion = null)
        {
            var resolvedApiVersion = apiVersion ?? _apiVersion ?? "2024-11-15-preview"; // Use the provided, stored, or default version
            Argument.AssertNotNull(resolvedApiVersion, nameof(resolvedApiVersion));

            return new ExportedModelsConversationAuthoringAnalysis(ClientDiagnostics, _pipeline, _keyCredential, _tokenCredential, _endpoint, resolvedApiVersion);
        }
    }
}
