// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient
    {
        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public AIProjectClient(string connectionString, TokenCredential credential) : this(connectionString, credential, new AIProjectClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Studio project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public AIProjectClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "ResourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "ProjectName"),
                  credential,
                  options)
        {
        }

        internal AIProjectClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string subscriptionId, string resourceGroupName, string projectName)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _projectName = projectName;
        }

        /// <summary> Initializes a new instance of EvaluationsClient. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual InferenceClient GetInferenceClient(string apiVersion = "2024-07-01-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new InferenceClient(ClientDiagnostics, _pipeline, _tokenCredential, _endpoint, _subscriptionId, _resourceGroupName, _projectName, apiVersion);
        }
    }
}
