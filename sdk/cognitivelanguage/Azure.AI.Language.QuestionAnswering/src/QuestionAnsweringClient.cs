// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Models;
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

        private readonly QuestionAnsweringKnowledgeBaseRestClient _knowledgebaseRestClient;
        private readonly QuestionAnsweringTextRestClient _textRestClient;

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

            _knowledgebaseRestClient = new(Diagnostics, Pipeline, Endpoint, Options.Version);
            _textRestClient = new(Diagnostics, Pipeline, Endpoint, Options.Version);
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
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "prod".</param>
        /// <param name="question">The question to answer.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="question"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<KnowledgeBaseAnswers>> QueryKnowledgeBaseAsync(string projectName, string deploymentName, string question, CancellationToken cancellationToken = default) =>
            QueryKnowledgeBaseAsync(new QueryKnowledgeBaseOptions(projectName, deploymentName, question), cancellationToken);

        /// <summary>Answers the specified question using your knowledge base.</summary>
        /// <param name="options">
        /// An <see cref="QueryKnowledgeBaseOptions"/> containing the <see cref="QueryKnowledgeBaseOptions.ProjectName"/>,
        /// <see cref="QueryKnowledgeBaseOptions.DeploymentName"/>, <see cref="QueryKnowledgeBaseOptions.Question"/>, and other options to answer a question.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<KnowledgeBaseAnswers>> QueryKnowledgeBaseAsync(QueryKnowledgeBaseOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(QueryKnowledgeBase)}");
            scope.AddAttribute("projectName", options.ProjectName);
            scope.AddAttribute("deploymentName", options.DeploymentName);
            scope.Start();

            try
            {
                return await _knowledgebaseRestClient.QueryAsync(options.ProjectName, options.DeploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using your knowledge base.</summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "prod".</param>
        /// <param name="question">The question to answer.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="question"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<KnowledgeBaseAnswers> QueryKnowledgeBase(string projectName, string deploymentName, string question, CancellationToken cancellationToken = default) =>
            QueryKnowledgeBase(new QueryKnowledgeBaseOptions(projectName, deploymentName, question), cancellationToken);

        /// <summary>Answers the specified question using your knowledge base.</summary>
        /// <param name="options">
        /// An <see cref="QueryKnowledgeBaseOptions"/> containing the <see cref="QueryKnowledgeBaseOptions.ProjectName"/>,
        /// <see cref="QueryKnowledgeBaseOptions.DeploymentName"/>, <see cref="QueryKnowledgeBaseOptions.Question"/>, and other options to answer a question.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<KnowledgeBaseAnswers> QueryKnowledgeBase(QueryKnowledgeBaseOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(QueryKnowledgeBase)}");
            scope.AddAttribute("projectName", options.ProjectName);
            scope.AddAttribute("deploymentName", options.DeploymentName);
            scope.Start();

            try
            {
                return _knowledgebaseRestClient.Query(options.ProjectName, options.DeploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using the text <paramref name="records"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="records">The text records to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="TextAnswers"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<TextAnswers>> QueryTextAsync(string question, IEnumerable<string> records, string language = default, CancellationToken cancellationToken = default) =>
            QueryTextAsync(QueryTextOptions.From(question, records, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="records"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="records">The text records to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="TextAnswers"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<TextAnswers> QueryText(string question, IEnumerable<string> records, string language = default, CancellationToken cancellationToken = default) =>
            QueryText(QueryTextOptions.From(question, records, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="records"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="records">A collection of <see cref="TextRecord"/> to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="TextAnswers"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<TextAnswers>> QueryTextAsync(string question, IEnumerable<TextRecord> records, string language = default, CancellationToken cancellationToken = default) =>
            QueryTextAsync(QueryTextOptions.From(question, records, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the text <paramref name="records"/>.</summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="records">A collection of <see cref="TextRecord"/> to query.</param>
        /// <param name="language">
        /// The language of the text records. This is the BCP-47 representation of a language.
        /// For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, uses <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> as the default.
        /// If <see cref="QuestionAnsweringClientOptions.DefaultLanguage"/> is not set, the service default, "en" for English, is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="TextAnswers"/> containing answers to the <paramref name="question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="records"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<TextAnswers> QueryText(string question, IEnumerable<TextRecord> records, string language = default, CancellationToken cancellationToken = default) =>
            QueryText(QueryTextOptions.From(question, records, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the provided text in the body.</summary>
        /// <param name="options">The question to answer.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="TextAnswers"/> containing answers to the <see cref="QueryTextOptions.Question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<TextAnswers>> QueryTextAsync(QueryTextOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(QueryText)}");
            scope.Start();

            try
            {
                options = options.Clone(Options.DefaultLanguage);
                return await _textRestClient.QueryAsync(options, cancellationToken).ConfigureAwait(false);
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
        /// <returns><see cref="TextAnswers"/> containing answers to the <see cref="QueryTextOptions.Question"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<TextAnswers> QueryText(QueryTextOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(QueryText)}");
            scope.Start();

            try
            {
                options = options.Clone(Options.DefaultLanguage);
                return _textRestClient.Query(options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
