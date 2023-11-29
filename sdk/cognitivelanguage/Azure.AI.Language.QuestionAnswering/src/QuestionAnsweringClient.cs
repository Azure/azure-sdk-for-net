// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// The <see cref="QuestionAnsweringClient"/> allows you to ask questions of a custom or built-in knowledge base.
    /// </summary>
    public class QuestionAnsweringClient
    {
        internal const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private const string OTelProjectNameKey = "az.cognitivelanguage.project.name";
        private const string OTelDeploymentNameKey = "az.cognitivelanguage.deployment.name";

        private readonly QuestionAnsweringRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <param name="options">Optional <see cref="QuestionAnsweringClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringClient(Uri endpoint, AzureKeyCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            Options = options ?? new QuestionAnsweringClientOptions();

            Diagnostics = new ClientDiagnostics(Options);
            Pipeline = HttpPipelineBuilder.Build(
                Options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            _restClient = new(Diagnostics, Pipeline, Endpoint, Options.Version);
        }

        /// <summary> Initializes a new instance of QuestionAnsweringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public QuestionAnsweringClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new QuestionAnsweringClientOptions())
        {
        }

        /// <summary> Initializes a new instance of QuestionAnsweringClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public QuestionAnsweringClient(Uri endpoint, TokenCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Options = options ?? new QuestionAnsweringClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(Options.Audience?.ToString()) ? QuestionAnsweringAudience.AzurePublicCloud : Options.Audience)}/.default";

            Diagnostics = new ClientDiagnostics(Options, true);
            Pipeline = HttpPipelineBuilder.Build(Options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            Endpoint = endpoint;

            _restClient = new(Diagnostics, Pipeline, Endpoint, Options.Version);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected QuestionAnsweringClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the <see cref="QuestionAnsweringClientOptions"/> for this client.
        /// </summary>
        private protected virtual QuestionAnsweringClientOptions Options { get; }

        /// <summary>
        /// Gets the <see cref="ClientDiagnostics"/> for this client.
        /// </summary>
        private protected virtual ClientDiagnostics Diagnostics { get; }

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> for this client.
        /// </summary>
        private protected virtual HttpPipeline Pipeline { get; }

        /// <summary>Answers the specified question using your knowledge base.</summary>
        /// <param name="question">The question to ask of the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(string question, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswersAsync(project, (options ?? new()).WithQuestion(question), cancellationToken);

        /// <summary>Gets the specified QnA.</summary>
        /// <param name="qnaId">The exact QnA ID to fetch from the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(int qnaId, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswersAsync(project, (options ?? new()).WithQnaId(qnaId), cancellationToken);

        private async Task<Response<AnswersResult>> GetAnswersAsync(QuestionAnsweringProject project, AnswersOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}");
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return await _restClient.GetAnswersAsync(project.ProjectName, project.DeploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using your knowledge base.</summary>
        /// <param name="question">The question to ask of the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersResult> GetAnswers(string question, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswers(project, (options ?? new()).WithQuestion(question), cancellationToken);

        /// <summary>Gets the specified QnA.</summary>
        /// <param name="qnaId">The exact QnA ID to fetch from the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersResult> GetAnswers(int qnaId, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswers(project, (options ?? new()).WithQnaId(qnaId), cancellationToken);

        private Response<AnswersResult> GetAnswers(QuestionAnsweringProject project, AnswersOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}");
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return _restClient.GetAnswers(project.ProjectName, project.DeploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using the text <paramref name="textDocuments"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">The text documents to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(string question, IEnumerable<string> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextAsync(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="textDocuments"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">The text documents to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(string question, IEnumerable<string> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromText(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="textDocuments"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">A collection of <see cref="TextDocument"/> to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(string question, IEnumerable<TextDocument> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextAsync(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="textDocuments"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">A collection of <see cref="TextDocument"/> to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// See <see href="https://docs.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(string question, IEnumerable<TextDocument> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromText(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the provided text in the body.</summary>
        /// <param name="options">The question to answer.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <see cref="AnswersFromTextOptions.Question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(AnswersFromTextOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}");
            scope.Start();

            try
            {
                options = options.Clone(Options.DefaultLanguage);
                return await _restClient.GetAnswersFromTextAsync(options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using the provided text in the body.</summary>
        /// <param name="options">The question to answer.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the <see cref="AnswersFromTextOptions.Question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(AnswersFromTextOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}");
            scope.Start();

            try
            {
                options = options.Clone(Options.DefaultLanguage);
                return _restClient.GetAnswersFromText(options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
