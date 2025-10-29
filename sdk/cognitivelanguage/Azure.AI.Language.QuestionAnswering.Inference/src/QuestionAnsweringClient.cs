using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// Hand-authored convenience overloads for <see cref="QuestionAnsweringClient"/>.
    /// </summary>
    public partial class QuestionAnsweringClient
    {
        private const string OTelProjectNameKey = "az.cognitivelanguage.project.name";
        private const string OTelDeploymentNameKey = "az.cognitivelanguage.deployment.name";
        private const string DefaultLanguageFallback = "en";

        #region Knowledge base convenience overloads

        /// <summary>
        /// Answers the specified <paramref name="question"/> using the provided <paramref name="project"/>.
        /// </summary>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(
            string question,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNullOrEmpty(question, nameof(question));

            var effective = (options ?? new AnswersOptions()).WithQuestion(question);
            return InvokeGetAnswersAsync(project.ProjectName, project.DeploymentName, effective, cancellationToken);
        }

        /// <summary>
        /// Gets the exact QnA specified by <paramref name="qnaId"/> from the knowledge base in <paramref name="project"/>.
        /// </summary>
        public virtual Task<Response<AnswersResult>> GetAnswersAsync(
            int qnaId,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));

            var effective = (options ?? new AnswersOptions()).WithQnaId(qnaId);
            return InvokeGetAnswersAsync(project.ProjectName, project.DeploymentName, effective, cancellationToken);
        }

        /// <summary>
        /// Answers the specified <paramref name="question"/> using the provided <paramref name="project"/>.
        /// </summary>
        public virtual Response<AnswersResult> GetAnswers(
            string question,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));
            Argument.AssertNotNullOrEmpty(question, nameof(question));

            var effective = (options ?? new AnswersOptions()).WithQuestion(question);
            return InvokeGetAnswers(project.ProjectName, project.DeploymentName, effective, cancellationToken);
        }

        /// <summary>
        /// Gets the exact QnA specified by <paramref name="qnaId"/> from the knowledge base in <paramref name="project"/>.
        /// </summary>
        public virtual Response<AnswersResult> GetAnswers(
            int qnaId,
            QuestionAnsweringProject project,
            AnswersOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(project, nameof(project));

            var effective = (options ?? new AnswersOptions()).WithQnaId(qnaId);
            return InvokeGetAnswers(project.ProjectName, project.DeploymentName, effective, cancellationToken);
        }

        #endregion

        #region Text QA convenience overloads (raw string documents)

        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(
            string question,
            IEnumerable<string> textDocuments,
            string language = null,
            CancellationToken cancellationToken = default)
        {
            var options = CreateAnswersFromTextOptions(question, textDocuments, language);
            return GetAnswersFromTextAsync(options, cancellationToken);
        }

        public virtual Response<AnswersFromTextResult> GetAnswersFromText(
            string question,
            IEnumerable<string> textDocuments,
            string language = null,
            CancellationToken cancellationToken = default)
        {
            var options = CreateAnswersFromTextOptions(question, textDocuments, language);
            return GetAnswersFromText(options, cancellationToken);
        }

        #endregion

        #region Text QA convenience overloads (TextDocument collection)

        public virtual Task<Response<AnswersFromTextResult>> GetAnswersFromTextAsync(
            string question,
            IEnumerable<TextDocument> textDocuments,
            string language = null,
            CancellationToken cancellationToken = default)
        {
            var options = CreateAnswersFromTextOptions(question, textDocuments, language);
            return GetAnswersFromTextAsync(options, cancellationToken);
        }

        public virtual Response<AnswersFromTextResult> GetAnswersFromText(
            string question,
            IEnumerable<TextDocument> textDocuments,
            string language = null,
            CancellationToken cancellationToken = default)
        {
            var options = CreateAnswersFromTextOptions(question, textDocuments, language);
            return GetAnswersFromText(options, cancellationToken);
        }

        #endregion

        #region Internal invocation helpers (adds diagnostic attributes)

        private Task<Response<AnswersResult>> InvokeGetAnswersAsync(
            string projectName,
            string deploymentName,
            AnswersOptions options,
            CancellationToken cancellationToken)
        {
            using var scope = ClientDiagnostics.CreateScope("QuestionAnsweringClient.GetAnswers");
            scope.AddAttribute(OTelProjectNameKey, projectName);
            scope.AddAttribute(OTelDeploymentNameKey, deploymentName);
            scope.Start();
            try
            {
                return GetAnswersAsync(projectName, deploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private Response<AnswersResult> InvokeGetAnswers(
            string projectName,
            string deploymentName,
            AnswersOptions options,
            CancellationToken cancellationToken)
        {
            using var scope = ClientDiagnostics.CreateScope("QuestionAnsweringClient.GetAnswers");
            scope.AddAttribute(OTelProjectNameKey, projectName);
            scope.AddAttribute(OTelDeploymentNameKey, deploymentName);
            scope.Start();
            try
            {
                return GetAnswers(projectName, deploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion

        #region Options builders

        private static AnswersFromTextOptions CreateAnswersFromTextOptions(
            string question,
            IEnumerable<string> texts,
            string language)
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(texts, nameof(texts));

            int id = 1;
            var docs = texts.Select(t => new TextDocument(id++.ToString(CultureInfo.InvariantCulture), t)).ToList();
            return new AnswersFromTextOptions(question, docs)
            {
                Language = language ?? DefaultLanguageFallback
            };
        }

        private static AnswersFromTextOptions CreateAnswersFromTextOptions(
            string question,
            IEnumerable<TextDocument> docs,
            string language)
        {
            Argument.AssertNotNullOrEmpty(question, nameof(question));
            Argument.AssertNotNull(docs, nameof(docs));

            return new AnswersFromTextOptions(question, docs.ToList())
            {
                Language = language ?? DefaultLanguageFallback
            };
        }

        #endregion
    }
}