// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client for instance management; Evaluations, Configuration, Model, Policy and Logs. </summary>
    public class PersonalizerAdministrationClient
    {
        internal LogRestClient LogRestClient { get; set; }
        internal ServiceConfigurationRestClient ServiceConfigurationRestClient { get; set; }
        internal ModelRestClient ModelRestClient { get; set; }
        internal EvaluationsRestClient EvaluationsRestClient { get; set; }
        internal PolicyRestClient PolicyRestClient { get; set; }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of Personalizer Client for mocking. </summary>
        protected PersonalizerAdministrationClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerAdministrationClient(Uri endpoint, TokenCredential credential, PersonalizerClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PersonalizerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://cognitiveservices.azure.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes));
            string stringEndpoint = endpoint.AbsoluteUri;
            LogRestClient = new LogRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ServiceConfigurationRestClient = new ServiceConfigurationRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ModelRestClient = new ModelRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EvaluationsRestClient = new EvaluationsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            PolicyRestClient = new PolicyRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerAdministrationClient(Uri endpoint, AzureKeyCredential credential, PersonalizerClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PersonalizerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "Ocp-Apim-Subscription-Key"));
            string stringEndpoint = endpoint.AbsoluteUri;
            LogRestClient = new LogRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ServiceConfigurationRestClient = new ServiceConfigurationRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ModelRestClient = new ModelRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EvaluationsRestClient = new EvaluationsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            PolicyRestClient = new PolicyRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
        }

        /// <summary> Initializes a new instance of LogClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        internal PersonalizerAdministrationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            string stringEndpoint = endpoint.AbsoluteUri;
            LogRestClient = new LogRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ServiceConfigurationRestClient = new ServiceConfigurationRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            ModelRestClient = new ModelRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            EvaluationsRestClient = new EvaluationsRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            PolicyRestClient = new PolicyRestClient(_clientDiagnostics, _pipeline, stringEndpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Delete all logs of Rank and Reward calls stored by Personalizer. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeletePersonalizerLogsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.DeletePersonalizerLogs");
            scope.Start();
            try
            {
                return await LogRestClient.DeleteAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete all logs of Rank and Reward calls stored by Personalizer. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeletePersonalizerLogs(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.DeletePersonalizerLogs");
            scope.Start();
            try
            {
                return LogRestClient.Delete(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get properties of the Personalizer logs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerLogProperties>> GetPersonalizerLogPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerLogProperties");
            scope.Start();
            try
            {
                return await LogRestClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get properties of the Personalizer logs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerLogProperties> GetPersonalizerLogProperties(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerLogProperties");
            scope.Start();
            try
            {
                return LogRestClient.GetProperties(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the Personalizer service configuration. </summary>
        /// <param name="config"> The personalizer service configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerServiceProperties >> UpdatePersonalizerPropertiesAsync(PersonalizerServiceProperties config, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.UpdatePersonalizerProperties");
            scope.Start();
            try
            {
                return await ServiceConfigurationRestClient.UpdateAsync(config, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the Personalizer service configuration. </summary>
        /// <param name="config"> The personalizer service configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerServiceProperties > UpdatePersonalizerProperties(PersonalizerServiceProperties config, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.UpdatePersonalizerProperties");
            scope.Start();
            try
            {
                return ServiceConfigurationRestClient.Update(config, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerServiceProperties >> GetPersonalizerPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerProperties");
            scope.Start();
            try
            {
                return await ServiceConfigurationRestClient.GetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerServiceProperties > GetPersonalizerProperties(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerProperties");
            scope.Start();
            try
            {
                return ServiceConfigurationRestClient.Get(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Apply Learning Settings and model from a pre-existing Offline Evaluation, making them the current online Learning Settings and model and replacing the previous ones. </summary>
        /// <param name="body"> The PolicyReferenceContract to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ApplyPersonalizerEvaluationAsync(PersonalizerPolicyReferenceOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ApplyPersonalizerEvaluation");
            scope.Start();
            try
            {
                return await ServiceConfigurationRestClient.ApplyFromEvaluationAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Apply Learning Settings and model from a pre-existing Offline Evaluation, making them the current online Learning Settings and model and replacing the previous ones. </summary>
        /// <param name="body"> The PolicyReferenceContract to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ApplyPersonalizerEvaluation(PersonalizerPolicyReferenceOptions body, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ApplyPersonalizerEvaluation");
            scope.Start();
            try
            {
                return ServiceConfigurationRestClient.ApplyFromEvaluation(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Export the current model used by Personalizer service. </summary>
        /// <param name="isSigned">True if requesting signed model zip archive, false otherwise.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Exports the Personalizer model. </remarks>
        public virtual async Task<Response<Stream>> ExportPersonalizerModelAsync(bool isSigned, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ExportPersonalizerModel");
            scope.Start();
            try
            {
                return await ModelRestClient.GetAsync(isSigned, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Export the current model used by Personalizer service. </summary>
        /// <param name="isSigned">True if requesting signed model zip archive, false otherwise.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Exports the Personalizer model. </remarks>
        public virtual Response<Stream> ExportPersonalizerModel(bool isSigned, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ExportPersonalizerModel");
            scope.Start();
            try
            {
                return ModelRestClient.Get(isSigned, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the current model used by Personalizer service with an updated model. </summary>
        /// <param name="modelBody">Stream representing the digitally signed model zip archive.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ImportPersonalizerSignedModelAsync(Stream modelBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ImportPersonalizerSignedModel");
            scope.Start();
            try
            {
                return await ModelRestClient.ImportAsync(modelBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the current model used by Personalizer service with an updated model. </summary>
        /// <param name="modelBody">Stream representing the digitally signed model zip archive.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ImportPersonalizerSignedModel(Stream modelBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ImportPersonalizerSignedModel");
            scope.Start();
            try
            {
                return ModelRestClient.Import(modelBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resets the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResetPersonalizerModelAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ResetPersonalizerModel");
            scope.Start();
            try
            {
                return await ModelRestClient.ResetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resets the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResetPersonalizerModel(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ResetPersonalizerModel");
            scope.Start();
            try
            {
                return ModelRestClient.Reset(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get properties of the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerModelProperties>> GetPersonalizerModelPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerModelProperties");
            scope.Start();
            try
            {
                return await ModelRestClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get properties of the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerModelProperties> GetPersonalizerModelProperties(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerModelProperties");
            scope.Start();
            try
            {
                return ModelRestClient.GetProperties(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Learning Settings currently used by the Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicy>> GetPersonalizerPolicyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerPolicy");
            scope.Start();
            try
            {
                return await PolicyRestClient.GetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Learning Settings currently used by the Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicy> GetPersonalizerPolicy(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerPolicy");
            scope.Start();
            try
            {
                return PolicyRestClient.Get(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the Learning Settings that the Personalizer service will use to train models. </summary>
        /// <param name="policy"> The learning settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicy>> UpdatePersonalizerPolicyAsync(PersonalizerPolicy policy, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.UpdatePersonalizerPolicy");
            scope.Start();
            try
            {
                return await PolicyRestClient.UpdateAsync(policy, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the Learning Settings that the Personalizer service will use to train models. </summary>
        /// <param name="policy"> The learning settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicy> UpdatePersonalizerPolicy(PersonalizerPolicy policy, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.UpdatePersonalizerPolicy");
            scope.Start();
            try
            {
                return PolicyRestClient.Update(policy, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resets the learning settings of the Personalizer service to default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicy>> ResetPersonalizerPolicyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ResetPersonalizerPolicy");
            scope.Start();
            try
            {
                return await PolicyRestClient.ResetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resets the learning settings of the Personalizer service to default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicy> ResetPersonalizerPolicy(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.ResetPersonalizerPolicy");
            scope.Start();
            try
            {
                return PolicyRestClient.Reset(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeletePersonalizerEvaluationAsync(string evaluationId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.DeletePersonalizerEvaluation");
            scope.Start();
            try
            {
                return await EvaluationsRestClient.DeleteAsync(evaluationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeletePersonalizerEvaluation(string evaluationId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.DeletePersonalizerEvaluation");
            scope.Start();
            try
            {
                return EvaluationsRestClient.Delete(evaluationId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerEvaluation>> GetPersonalizerEvaluationAsync(string evaluationId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerEvaluation");
            scope.Start();
            try
            {
                return await EvaluationsRestClient.GetAsync(evaluationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerEvaluation> GetPersonalizerEvaluation(string evaluationId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerEvaluation");
            scope.Start();
            try
            {
                return EvaluationsRestClient.Get(evaluationId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List of all Offline Evaluations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PersonalizerEvaluation> GetPersonalizerEvaluationsAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerEvaluations");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<IReadOnlyList<PersonalizerEvaluation>> result = await EvaluationsRestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page<PersonalizerEvaluation>.FromValues(result.Value, null, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary> List of all Offline Evaluations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PersonalizerEvaluation> GetPersonalizerEvaluations(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.GetPersonalizerEvaluations");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<IReadOnlyList<PersonalizerEvaluation>> result = EvaluationsRestClient.List(cancellationToken);
                    return Page<PersonalizerEvaluation>.FromValues(result.Value, null, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary> Submit a new Offline Evaluation job. </summary>
        /// <param name="evaluation"> The Offline Evaluation job definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<PersonalizerCreateEvaluationOperation> CreatePersonalizerEvaluationAsync(PersonalizerEvaluationOptions evaluation, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.CreatePersonalizerEvaluation");
            scope.Start();
            try
            {
                Response<PersonalizerEvaluation> result = await EvaluationsRestClient.CreateAsync(evaluation, cancellationToken).ConfigureAwait(false);
                return new PersonalizerCreateEvaluationOperation(this, result.Value.Id, result.GetRawResponse(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a new Offline Evaluation job. </summary>
        /// <param name="evaluation"> The Offline Evaluation job definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual PersonalizerCreateEvaluationOperation CreatePersonalizerEvaluation(PersonalizerEvaluationOptions evaluation, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PersonalizerAdministrationClient.CreatePersonalizerEvaluation");
            scope.Start();
            try
            {
                Response<PersonalizerEvaluation> result = EvaluationsRestClient.Create(evaluation, cancellationToken);
                return new PersonalizerCreateEvaluationOperation(this, result.Value.Id, result.GetRawResponse(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
