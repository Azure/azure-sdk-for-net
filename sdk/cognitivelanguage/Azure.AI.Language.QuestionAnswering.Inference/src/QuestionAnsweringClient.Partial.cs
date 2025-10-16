// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class QuestionAnsweringClient
    {
        private const string OTelProjectNameKey = "az.cognitivelanguage.project.name";
        private const string OTelDeploymentNameKey = "az.cognitivelanguage.deployment.name";

        private protected QuestionAnsweringClientOptions Options { get; private set; }

        /// <summary> Gets the configured service endpoint. </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary> Gets the underlying pipeline. </summary>
        public virtual HttpPipeline HttpPipeline => _pipeline;

        partial void OnCreated(QuestionAnsweringClientOptions options)
        {
            Options = options;
        }

        /// <summary>Answers the specified question using your knowledge base.</summary>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(string question, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswersAsync(project, (options ?? new AnswersOptions()).WithQuestion(question), cancellationToken);

        /// <summary>Gets the specified QnA from your knowledge base.</summary>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(int qnaId, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswersAsync(project, (options ?? new AnswersOptions()).WithQnaId(qnaId), cancellationToken);

        /// <summary>Answers the specified question using your knowledge base.</summary>
        public virtual Response<AnswersResult> GetAnswers(string question, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswers(project, (options ?? new AnswersOptions()).WithQuestion(question), cancellationToken);

        /// <summary>Gets the specified QnA from your knowledge base.</summary>
        public virtual Response<AnswersResult> GetAnswers(int qnaId, QuestionAnsweringProject project, AnswersOptions options = null, CancellationToken cancellationToken = default) =>
            GetAnswers(project, (options ?? new AnswersOptions()).WithQnaId(qnaId), cancellationToken);

        private async Task<Response<AnswersResult>> GetAnswersAsync(QuestionAnsweringProject project, AnswersOptions options, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}");
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return await GetAnswersAsync(project.ProjectName, project.DeploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Response<AnswersResult> GetAnswers(QuestionAnsweringProject project, AnswersOptions options, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswers)}");
            scope.AddAttribute(OTelProjectNameKey, project.ProjectName);
            scope.AddAttribute(OTelDeploymentNameKey, project.DeploymentName);
            scope.Start();

            try
            {
                return GetAnswers(project.ProjectName, project.DeploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Answers the specified question using the provided text input.</summary>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(string question, IEnumerable<string> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextInternalAsync(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the provided text input.</summary>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(string question, IEnumerable<string> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextInternal(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the provided text input.</summary>
        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(string question, IEnumerable<TextDocument> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextInternalAsync(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        /// <summary>Answers the specified question using the provided text input.</summary>
        public virtual Response<AnswersFromTextResult> GetAnswersFromText(string question, IEnumerable<TextDocument> textDocuments, string language = default, CancellationToken cancellationToken = default) =>
            GetAnswersFromTextInternal(AnswersFromTextOptions.From(question, textDocuments, language ?? Options.DefaultLanguage), cancellationToken);

        private async Task<Response<AnswersFromTextResult>> GetAnswersFromTextInternalAsync(AnswersFromTextOptions options, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}");
            scope.Start();

            try
            {
                return await GetAnswersFromTextAsync(options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Response<AnswersFromTextResult> GetAnswersFromTextInternal(AnswersFromTextOptions options, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(QuestionAnsweringClient)}.{nameof(GetAnswersFromText)}");
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

        partial void CustomizeAnswersFromTextOptions(ref AnswersFromTextOptions options)
        {
            options = options?.Clone(Options.DefaultLanguage);
        }
    }
}
