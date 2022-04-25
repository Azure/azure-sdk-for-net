// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The <see cref="ConversationAnalysisClient"/> allows you analyze conversations.
    /// </summary>
    public class ConversationAnalysisClient
    {
        internal const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        private readonly ConversationAnalysisRestClient _analysisRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Conversation Analysis endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Conversation Analysis endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <param name="options">Optional <see cref="ConversationAnalysisClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential, ConversationAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            options ??= new ConversationAnalysisClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            _analysisRestClient = new(Diagnostics, Pipeline, Endpoint, options.Version);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected ConversationAnalysisClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the <see cref="ClientDiagnostics"/> for this client.
        /// </summary>
        private protected virtual ClientDiagnostics Diagnostics { get; }

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> for this client.
        /// </summary>
        private protected virtual HttpPipeline Pipeline { get; }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="utterance">The conversation utterance to be analyzed.</param>
        /// <param name="project">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">Optional <see cref="AnalyzeConversationOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="utterance"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="utterance"/> or <paramref name="project"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationTaskResult>> AnalyzeConversationAsync(string utterance, ConversationsProject project, AnalyzeConversationOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(utterance, nameof(utterance));
            Argument.AssertNotNull(project, nameof(project));

            CustomConversationTaskParameters customConversationTaskParameters = new CustomConversationTaskParameters(project.ProjectName, project.DeploymentName)
            {
                Verbose = options?.Verbose,
            };

            TextConversationItem textConversationItem = new TextConversationItem("1", "1", utterance);

            options ??= new AnalyzeConversationOptions(textConversationItem);
            CustomConversationalTask customConversationalTask = new CustomConversationalTask(options, customConversationTaskParameters);

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", project.ProjectName);
            scope.AddAttribute("deploymentName", project.DeploymentName);
            scope.Start();

            try
            {
                return await _analysisRestClient.AnalyzeConversationAsync(customConversationalTask, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="utterance">The conversation utterance to be analyzed.</param>
        /// <param name="project">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">Optional <see cref="AnalyzeConversationOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="utterance"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="utterance"/> or <paramref name="project"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationTaskResult> AnalyzeConversation(string utterance, ConversationsProject project, AnalyzeConversationOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(utterance, nameof(utterance));
            Argument.AssertNotNull(project, nameof(project));

            CustomConversationTaskParameters customConversationTaskParameters = new CustomConversationTaskParameters(project.ProjectName, project.DeploymentName)
            {
                Verbose = options?.Verbose,
            };

            TextConversationItem textConversationItem = new TextConversationItem("1", "1", utterance);

            options ??= new AnalyzeConversationOptions(textConversationItem);
            CustomConversationalTask customConversationalTask = new CustomConversationalTask(options, customConversationTaskParameters);

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", project.ProjectName);
            scope.AddAttribute("deploymentName", project.DeploymentName);
            scope.Start();

            try
            {
                return _analysisRestClient.AnalyzeConversation(customConversationalTask, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="input">The <see cref="GeneratedConversation"/> used for tasks input.</param>
        /// <param name="tasks"> <see cref="AnalyzeConversationLROTask"/> defines the tasks to be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="input"/> or <paramref name="tasks"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationJobState>> AnalyzeConversationAsync(IEnumerable<GeneratedConversation> input, IEnumerable<AnalyzeConversationLROTask> tasks, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(input, nameof(input));
            Argument.AssertNotNull(tasks, nameof(tasks));

            MultiLanguageConversationAnalysisInput multiLanguageConversationAnalysisInput = new MultiLanguageConversationAnalysisInput(input);

            var analyzeConversationJobsInput = new AnalyzeConversationJobsInput(multiLanguageConversationAnalysisInput, tasks);

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.Start();

            try
            {
                var responseHeaders = await _analysisRestClient.SubmitJobAsync(analyzeConversationJobsInput, cancellationToken).ConfigureAwait(false);
                var jobId = getJobId(responseHeaders.Headers.OperationLocation);

                await WaitForJobUntilDoneAsync(jobId).ConfigureAwait(false);

                return await _analysisRestClient.JobStatusAsync(jobId, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<bool> WaitForJobUntilDoneAsync(Guid jobId, int timeoutInSeconds = 0, int pollingIntervalInSeconds = 5)
        {
            var startTimeStamp = DateTime.Now;
            while (true)
            {
                var jobStatus = await _analysisRestClient.JobStatusAsync(jobId).ConfigureAwait(false);

                // check job status is done
                if (jobStatus.Value.Status == JobState.Succeeded || jobStatus.Value.Status == JobState.Failed || jobStatus.Value.Status == JobState.PartiallySucceeded)
                    return true;

                // check for timeouts
                if (timeoutInSeconds > 0)
                {
                    var nowTimeStamp = DateTime.Now;
                    var diff = nowTimeStamp.Subtract(startTimeStamp).TotalSeconds;
                    if (diff > timeoutInSeconds)
                    {
                        break;
                    }
                }

                // sleep for a while
                Thread.Sleep(pollingIntervalInSeconds);
            }
            return false;
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="input">The <see cref="GeneratedConversation"/> used for tasks input.</param>
        /// <param name="tasks"> <see cref="AnalyzeConversationLROTask"/> defines the tasks to be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="input"/> or <paramref name="tasks"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationJobState> AnalyzeConversation(IEnumerable<GeneratedConversation> input, IEnumerable<AnalyzeConversationLROTask> tasks, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(input, nameof(input));
            Argument.AssertNotNull(tasks, nameof(tasks));

            MultiLanguageConversationAnalysisInput multiLanguageConversationAnalysisInput = new MultiLanguageConversationAnalysisInput(input);

            var analyzeConversationJobsInput = new AnalyzeConversationJobsInput(multiLanguageConversationAnalysisInput, tasks);

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.Start();

            try
            {
                var responseHeaders = _analysisRestClient.SubmitJob(analyzeConversationJobsInput, cancellationToken);
                var jobId = getJobId(responseHeaders.Headers.OperationLocation);

                WaitForJobUntilDone(jobId);

                return _analysisRestClient.JobStatus(jobId, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private bool WaitForJobUntilDone(Guid jobId, int timeoutInSeconds = 0, int pollingIntervalInSeconds = 5)
        {
            var startTimeStamp = DateTime.Now;
            while (true)
            {
                var jobStatus = _analysisRestClient.JobStatus(jobId);

                // check job status is done
                if (jobStatus.Value.Status == JobState.Succeeded || jobStatus.Value.Status == JobState.Failed || jobStatus.Value.Status == JobState.PartiallySucceeded)
                    return true;

                // check for timeouts
                if (timeoutInSeconds > 0)
                {
                    var nowTimeStamp = DateTime.Now;
                    var diff = nowTimeStamp.Subtract(startTimeStamp).TotalSeconds;
                    if (diff > timeoutInSeconds)
                    {
                        break;
                    }
                }

                // sleep for a while
                Thread.Sleep(pollingIntervalInSeconds);
            }
            return false;
        }

        private static Guid getJobId(string operationLocationHeader)
        {
            string last = operationLocationHeader.Split('/').ToList().Last();
            string jobId = last.Split('?').ToList().First();
            return Guid.Parse(jobId);
        }
    }
}
