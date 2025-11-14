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
    /// Extensions for QuestionAnsweringClient to provide convenient overloads and enhanced diagnostics.
    /// </summary>
    public partial class QuestionAnsweringClient
    {
        private const string OTelProjectNameKey = "az.cognitivelanguage.project.name";
        private const string OTelDeploymentNameKey = "az.cognitivelanguage.deployment.name";

        /// <summary>Get the service endpoint.</summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Answers the specified question using your knowledge base.
        /// </summary>
        /// <param name="question">The question to ask of the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(
            string question,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default
        ) =>
            GetAnswersInternalAsync(
                project,
                (options ?? new()).WithQuestion(question),
                cancellationToken
            );

        /// <summary>
        /// Gets the specified QnA by ID using your knowledge base.
        /// </summary>
        /// <param name="qnaId">The exact QnA ID to fetch from the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(
            int qnaId,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default
        ) =>
            GetAnswersInternalAsync(
                project,
                (options ?? new()).WithQnaId(qnaId),
                cancellationToken
            );

        /// <summary>
        /// Answers the specified question using your knowledge base (synchronous).
        /// </summary>
        /// <param name="question">The question to ask of the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base to the specified question.</returns>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersResult> GetAnswers(
            string question,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default
        ) =>
            GetAnswersInternal(
                project,
                (options ?? new()).WithQuestion(question),
                cancellationToken
            );

        /// <summary>
        /// Gets the specified QnA by ID using your knowledge base (synchronous).
        /// </summary>
        /// <param name="qnaId">The exact QnA ID to fetch from the knowledge base.</param>
        /// <param name="project">The <see cref="QuestionAnsweringProject"/> to query.</param>
        /// <param name="options">Optional <see cref="AnswersOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>An <see cref="AnswersResult"/> containing answers from the knowledge base.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="project"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersResult> GetAnswers(
            int qnaId,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNull(project, nameof(project));

            return GetAnswersInternal(
                project,
                (options ?? new()).WithQnaId(qnaId),
                cancellationToken
            );
        }

        /// <summary>
        /// Answers the specified question using the provided text documents (async).
        /// </summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">The text documents to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(
            string question,
            IEnumerable<string> textDocuments,
            string language = default,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            return GetAnswersFromTextInternalAsync(
                AnswersFromTextOptions.From(question, textDocuments, language),
                cancellationToken
            );
        }

        /// <summary>
        /// Answers the specified question using the provided text documents (async, with TextDocument collection).
        /// </summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">A collection of <see cref="TextDocument"/> to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(
            string question,
            IEnumerable<TextDocument> textDocuments,
            string language = default,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            return GetAnswersFromTextInternalAsync(
                AnswersFromTextOptions.From(question, textDocuments, language),
                cancellationToken
            );
        }

        /// <summary>
        /// Answers the specified question using the provided text documents (synchronous).
        /// </summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">The text documents to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(
            string question,
            IEnumerable<string> textDocuments,
            string language = default,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            return GetAnswersFromTextInternal(
                AnswersFromTextOptions.From(question, textDocuments, language),
                cancellationToken
            );
        }

        /// <summary>
        /// Answers the specified question using the provided text documents (synchronous, with TextDocument collection).
        /// </summary>
        /// <param name="question">The question to answer.</param>
        /// <param name="textDocuments">A collection of <see cref="TextDocument"/> to query.</param>
        /// <param name="language">
        /// The language of the text documents.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default is used.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns><see cref="AnswersFromTextResult"/> containing answers to the question.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="question"/> or <paramref name="textDocuments"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(
            string question,
            IEnumerable<TextDocument> textDocuments,
            string language = default,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(textDocuments, nameof(textDocuments));

            return GetAnswersFromTextInternal(
                AnswersFromTextOptions.From(question, textDocuments, language),
                cancellationToken
            );
        }

        // ===== Internal helper methods with diagnostics =====

        private async Task<Response<AnswersResult>> GetAnswersInternalAsync(
            QuestionAnsweringProject project,
            AnswersOptions options,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                $"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}"
            );
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return await GetAnswersAsync(
                        project.ProjectName,
                        project.DeploymentName,
                        options,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Response<AnswersResult> GetAnswersInternal(
            QuestionAnsweringProject project,
            AnswersOptions options,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                $"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}"
            );
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return GetAnswers(
                    project.ProjectName,
                    project.DeploymentName,
                    options,
                    cancellationToken
                );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response<AnswersFromTextResult>> GetAnswersFromTextInternalAsync(
            AnswersFromTextOptions options,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                $"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}"
            );
            scope.Start();

            try
            {
                return await GetAnswersFromTextAsync(options, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Response<AnswersFromTextResult> GetAnswersFromTextInternal(
            AnswersFromTextOptions options,
            CancellationToken cancellationToken = default
        )
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope(
                $"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}"
            );
            scope.Start();

            try
            {
                return GetAnswersFromText(options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
