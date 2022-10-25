// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    /// <remarks>
    /// See <see href="https://docs.microsoft.com/rest/api/language/conversation-analysis-runtime"/> for more information about models you can pass to this client.
    /// </remarks>
    /// <seealso href="https://docs.microsoft.com/rest/api/language/conversation-analysis-runtime"/>
    public partial class ConversationAnalysisClient
    {
        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ConversationsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential, ConversationsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, suppressNestedClientActivities: true);

            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29506
            _keyCredential = credential;

            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ConversationsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAnalysisClient(Uri endpoint, TokenCredential credential, ConversationsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationsClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? ConversationsAudience.AzurePublicCloud : options.Audience)}/.default";

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary> Submit a collection of conversations for analysis. Specify one or more unique tasks to be executed. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="BinaryData"/> object once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        ///
        /// Request Body:
        ///
        /// Schema for <c>AnalyzeConversationJobsInput</c>:
        /// <code>{
        ///   displayName: string, # Optional. Optional display name for the analysis job.
        ///   analysisInput: {
        ///     conversations: [
        ///       {
        ///         id: string, # Required. Unique identifier for the conversation.
        ///         language: string, # Required. The language of the conversation item in BCP-47 format.
        ///         modality: &quot;transcript&quot; | &quot;text&quot;, # Required. Enumeration of supported conversational modalities.
        ///         domain: &quot;finance&quot; | &quot;healthcare&quot; | &quot;generic&quot;, # Optional. Enumeration of supported conversational domains.
        ///       }
        ///     ], # Required.
        ///   }, # Required.
        ///   tasks: [
        ///     {
        ///       taskName: string, # Optional.
        ///       kind: &quot;ConversationalPIITask&quot; | &quot;ConversationalSummarizationTask&quot;, # Required. Enumeration of supported analysis tasks on a collection of conversations.
        ///     }
        ///   ], # Required. The set of tasks to execute on the input conversation.
        /// }
        /// </code>
        ///
        /// Response Body:
        ///
        /// Schema for <c>AnalyzeConversationJobState</c>:
        /// <code>{
        ///   displayName: string, # Optional.
        ///   createdDateTime: string (ISO 8601 Format), # Required.
        ///   expirationDateTime: string (ISO 8601 Format), # Optional.
        ///   jobId: string, # Required.
        ///   lastUpdatedDateTime: string (ISO 8601 Format), # Required.
        ///   status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;partiallyCompleted&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot;, # Required.
        ///   errors: [
        ///     {
        ///       code: &quot;InvalidRequest&quot; | &quot;InvalidArgument&quot; | &quot;Unauthorized&quot; | &quot;Forbidden&quot; | &quot;NotFound&quot; | &quot;ProjectNotFound&quot; | &quot;OperationNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchIndexNotFound&quot; | &quot;TooManyRequests&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;AzureCognitiveSearchIndexLimitReached&quot; | &quot;InternalServerError&quot; | &quot;ServiceUnavailable&quot; | &quot;Timeout&quot; | &quot;QuotaExceeded&quot; | &quot;Conflict&quot; | &quot;Warning&quot;, # Required. One of a server-defined set of error codes.
        ///       message: string, # Required. A human-readable representation of the error.
        ///       target: string, # Optional. The target of the error.
        ///       details: [Error], # Optional. An array of details about specific errors that led to this reported error.
        ///       innererror: {
        ///         code: &quot;InvalidRequest&quot; | &quot;InvalidParameterValue&quot; | &quot;KnowledgeBaseNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;ExtractionFailure&quot; | &quot;InvalidRequestBodyFormat&quot; | &quot;EmptyRequest&quot; | &quot;MissingInputDocuments&quot; | &quot;InvalidDocument&quot; | &quot;ModelVersionIncorrect&quot; | &quot;InvalidDocumentBatch&quot; | &quot;UnsupportedLanguageCode&quot; | &quot;InvalidCountryHint&quot;, # Required. One of a server-defined set of error codes.
        ///         message: string, # Required. Error message.
        ///         details: Dictionary&lt;string, string&gt;, # Optional. Error details.
        ///         target: string, # Optional. Error target.
        ///         innererror: InnerErrorModel, # Optional. An object containing more specific information than the current object about the error.
        ///       }, # Optional. An object containing more specific information than the current object about the error.
        ///     }
        ///   ], # Optional.
        ///   nextLink: string, # Optional.
        ///   tasks: {
        ///     completed: number, # Required. Count of tasks completed successfully.
        ///     failed: number, # Required. Count of tasks that failed.
        ///     inProgress: number, # Required. Count of tasks in progress currently.
        ///     total: number, # Required. Total count of tasks submitted as part of the job.
        ///     items: [
        ///       {
        ///         lastUpdateDateTime: string (ISO 8601 Format), # Required. The last updated time in UTC for the task.
        ///         status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot;, # Required. The status of the task at the mentioned last update time.
        ///         taskName: string, # Optional.
        ///         kind: &quot;ConversationalPIIResults&quot; | &quot;ConversationalSummarizationResults&quot;, # Required. Enumeration of supported Conversation Analysis task results.
        ///       }
        ///     ], # Optional. List of results from tasks (if available).
        ///   }, # Required.
        ///   statistics: {
        ///     transactionsCount: number, # Required. Number of transactions for the request.
        ///     conversationsCount: number, # Required. Number of conversations submitted in the request.
        ///     validConversationsCount: number, # Required. Number of conversations documents. This excludes empty, over-size limit or non-supported languages documents.
        ///     erroneousConversationsCount: number, # Required. Number of invalid documents. This includes empty, over-size limit or non-supported languages documents.
        ///   }, # Optional. if showStats=true was specified in the request this field will contain information about the request payload.
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual async Task<Operation<BinaryData>> AnalyzeConversationAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.Start();

            return await StartAnalyzeConversationAsync(waitUntil, content, context).ConfigureAwait(false);
        }

        /// <summary> Submit a collection of conversations for analysis. Specify one or more unique tasks to be executed. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="BinaryData"/> object once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        ///
        /// Request Body:
        ///
        /// Schema for <c>AnalyzeConversationJobsInput</c>:
        /// <code>{
        ///   displayName: string, # Optional. Optional display name for the analysis job.
        ///   analysisInput: {
        ///     conversations: [
        ///       {
        ///         id: string, # Required. Unique identifier for the conversation.
        ///         language: string, # Required. The language of the conversation item in BCP-47 format.
        ///         modality: &quot;transcript&quot; | &quot;text&quot;, # Required. Enumeration of supported conversational modalities.
        ///         domain: &quot;finance&quot; | &quot;healthcare&quot; | &quot;generic&quot;, # Optional. Enumeration of supported conversational domains.
        ///       }
        ///     ], # Required.
        ///   }, # Required.
        ///   tasks: [
        ///     {
        ///       taskName: string, # Optional.
        ///       kind: &quot;ConversationalPIITask&quot; | &quot;ConversationalSummarizationTask&quot;, # Required. Enumeration of supported analysis tasks on a collection of conversations.
        ///     }
        ///   ], # Required. The set of tasks to execute on the input conversation.
        /// }
        /// </code>
        ///
        /// Response Body:
        ///
        /// Schema for <c>AnalyzeConversationJobState</c>:
        /// <code>{
        ///   displayName: string, # Optional.
        ///   createdDateTime: string (ISO 8601 Format), # Required.
        ///   expirationDateTime: string (ISO 8601 Format), # Optional.
        ///   jobId: string, # Required.
        ///   lastUpdatedDateTime: string (ISO 8601 Format), # Required.
        ///   status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;partiallyCompleted&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot;, # Required.
        ///   errors: [
        ///     {
        ///       code: &quot;InvalidRequest&quot; | &quot;InvalidArgument&quot; | &quot;Unauthorized&quot; | &quot;Forbidden&quot; | &quot;NotFound&quot; | &quot;ProjectNotFound&quot; | &quot;OperationNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchIndexNotFound&quot; | &quot;TooManyRequests&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;AzureCognitiveSearchIndexLimitReached&quot; | &quot;InternalServerError&quot; | &quot;ServiceUnavailable&quot; | &quot;Timeout&quot; | &quot;QuotaExceeded&quot; | &quot;Conflict&quot; | &quot;Warning&quot;, # Required. One of a server-defined set of error codes.
        ///       message: string, # Required. A human-readable representation of the error.
        ///       target: string, # Optional. The target of the error.
        ///       details: [Error], # Optional. An array of details about specific errors that led to this reported error.
        ///       innererror: {
        ///         code: &quot;InvalidRequest&quot; | &quot;InvalidParameterValue&quot; | &quot;KnowledgeBaseNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;ExtractionFailure&quot; | &quot;InvalidRequestBodyFormat&quot; | &quot;EmptyRequest&quot; | &quot;MissingInputDocuments&quot; | &quot;InvalidDocument&quot; | &quot;ModelVersionIncorrect&quot; | &quot;InvalidDocumentBatch&quot; | &quot;UnsupportedLanguageCode&quot; | &quot;InvalidCountryHint&quot;, # Required. One of a server-defined set of error codes.
        ///         message: string, # Required. Error message.
        ///         details: Dictionary&lt;string, string&gt;, # Optional. Error details.
        ///         target: string, # Optional. Error target.
        ///         innererror: InnerErrorModel, # Optional. An object containing more specific information than the current object about the error.
        ///       }, # Optional. An object containing more specific information than the current object about the error.
        ///     }
        ///   ], # Optional.
        ///   nextLink: string, # Optional.
        ///   tasks: {
        ///     completed: number, # Required. Count of tasks completed successfully.
        ///     failed: number, # Required. Count of tasks that failed.
        ///     inProgress: number, # Required. Count of tasks in progress currently.
        ///     total: number, # Required. Total count of tasks submitted as part of the job.
        ///     items: [
        ///       {
        ///         lastUpdateDateTime: string (ISO 8601 Format), # Required. The last updated time in UTC for the task.
        ///         status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot;, # Required. The status of the task at the mentioned last update time.
        ///         taskName: string, # Optional.
        ///         kind: &quot;ConversationalPIIResults&quot; | &quot;ConversationalSummarizationResults&quot;, # Required. Enumeration of supported Conversation Analysis task results.
        ///       }
        ///     ], # Optional. List of results from tasks (if available).
        ///   }, # Required.
        ///   statistics: {
        ///     transactionsCount: number, # Required. Number of transactions for the request.
        ///     conversationsCount: number, # Required. Number of conversations submitted in the request.
        ///     validConversationsCount: number, # Required. Number of conversations documents. This excludes empty, over-size limit or non-supported languages documents.
        ///     erroneousConversationsCount: number, # Required. Number of invalid documents. This includes empty, over-size limit or non-supported languages documents.
        ///   }, # Optional. if showStats=true was specified in the request this field will contain information about the request payload.
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual Operation<BinaryData> AnalyzeConversation(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.Start();

            return StartAnalyzeConversation(waitUntil, content, context);
        }
    }
}
