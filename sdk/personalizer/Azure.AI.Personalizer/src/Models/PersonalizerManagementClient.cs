// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> The Personalizer service client for instance management; Evaluations, Configuration, Model, Policy and Logs. </summary>
    public class PersonalizerManagementClient
    {
        /// <summary> The Log service client. </summary>
        internal LogClient LogClient { get; set; }
        /// <summary> The ServiceConfiguration service client. </summary>
        internal ServiceConfigurationClient ServiceConfigurationClient { get; set; }
        /// <summary> The Model service client. </summary>
        internal ModelClient ModelClient { get; set; }
        /// <summary> The Evaluations service client. </summary>
        internal EvaluationsClient EvaluationsClient { get; set; }
        /// <summary> The Policy service client. </summary>
        internal PolicyClient PolicyClient { get; set; }

        /// <summary> Initializes a new instance of Personalizer Client for mocking. </summary>
        protected PersonalizerManagementClient()
        {
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerManagementClient(string endpoint, TokenCredential credential, PersonalizerClientOptions options = null)
        {
            LogClient = new LogClient(endpoint, credential, options);
            ServiceConfigurationClient = new ServiceConfigurationClient(endpoint, credential, options);
            ModelClient = new ModelClient(endpoint, credential, options);
            PolicyClient = new PolicyClient(endpoint, credential, options);
        }

        /// <summary> Initializes a new instance of PersonalizerClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PersonalizerManagementClient(string endpoint, AzureKeyCredential credential, PersonalizerClientOptions options = null)
        {
            LogClient = new LogClient(endpoint, credential, options);
            ServiceConfigurationClient = new ServiceConfigurationClient(endpoint, credential, options);
            ModelClient = new ModelClient(endpoint, credential, options);
            PolicyClient = new PolicyClient(endpoint, credential, options);
        }

        /// <summary> Delete all logs of Rank and Reward calls stored by Personalizer. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeletePersonalizerLogsAsync(CancellationToken cancellationToken = default)
        {
            return await LogClient.DeleteAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete all logs of Rank and Reward calls stored by Personalizer. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeletePersonalizerLogs(CancellationToken cancellationToken = default)
        {
            return LogClient.Delete(cancellationToken);
        }

        /// <summary> Get properties of the Personalizer logs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerLogProperties>> GetPersonalizerLogPropertiesAsync(CancellationToken cancellationToken = default)
        {
            return await LogClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get properties of the Personalizer logs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerLogProperties> GetPersonalizerLogProperties(CancellationToken cancellationToken = default)
        {
            return LogClient.GetProperties(cancellationToken);
        }

        /// <summary> Update the Personalizer service configuration. </summary>
        /// <param name="config"> The personalizer service configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerServiceConfiguration>> UpdatePersonalizerConfigurationAsync(PersonalizerServiceConfiguration config, CancellationToken cancellationToken = default)
        {
            return await ServiceConfigurationClient.UpdateAsync(config, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update the Personalizer service configuration. </summary>
        /// <param name="config"> The personalizer service configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerServiceConfiguration> UpdatePersonalizerConfiguration(PersonalizerServiceConfiguration config, CancellationToken cancellationToken = default)
        {
            return ServiceConfigurationClient.Update(config, cancellationToken);
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerServiceConfiguration>> GetPersonalizerConfigurationAsync(CancellationToken cancellationToken = default)
        {
            return await ServiceConfigurationClient.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the Personalizer service configuration. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerServiceConfiguration> GetPersonalizerConfiguration(CancellationToken cancellationToken = default)
        {
            return ServiceConfigurationClient.Get(cancellationToken);
        }

        /// <summary> Apply Learning Settings and model from a pre-existing Offline Evaluation, making them the current online Learning Settings and model and replacing the previous ones. </summary>
        /// <param name="body"> The PolicyReferenceContract to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ApplyPersonalizerEvaluationAsync(PersonalizerPolicyReferenceOptions body, CancellationToken cancellationToken = default)
        {
            return await ServiceConfigurationClient.ApplyFromEvaluationAsync(body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Apply Learning Settings and model from a pre-existing Offline Evaluation, making them the current online Learning Settings and model and replacing the previous ones. </summary>
        /// <param name="body"> The PolicyReferenceContract to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ApplyPersonalizerEvaluation(PersonalizerPolicyReferenceOptions body, CancellationToken cancellationToken = default)
        {
            return ServiceConfigurationClient.ApplyFromEvaluation(body, cancellationToken);
        }

        /// <summary> Get the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> GetPersonalizerModelAsync(CancellationToken cancellationToken = default)
        {
            return await ModelClient.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> GetPersonalizerModel(CancellationToken cancellationToken = default)
        {
            return ModelClient.Get(cancellationToken);
        }

        /// <summary> Resets the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ResetPersonalizerModelAsync(CancellationToken cancellationToken = default)
        {
            return await ModelClient.ResetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Resets the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ResetPersonalizerModel(CancellationToken cancellationToken = default)
        {
            return ModelClient.Reset(cancellationToken);
        }

        /// <summary> Get properties of the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerModelProperties>> GetPersonalizerModelPropertiesAsync(CancellationToken cancellationToken = default)
        {
            return await ModelClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get properties of the model file generated by Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerModelProperties> GetPersonalizerModelProperties(CancellationToken cancellationToken = default)
        {
            return ModelClient.GetProperties(cancellationToken);
        }

        /// <summary> Get the Learning Settings currently used by the Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicyOptions>> GetPersonalizerPolicyAsync(CancellationToken cancellationToken = default)
        {
            return await PolicyClient.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the Learning Settings currently used by the Personalizer service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicyOptions> GetPersonalizerPolicy(CancellationToken cancellationToken = default)
        {
            return PolicyClient.Get(cancellationToken);
        }

        /// <summary> Update the Learning Settings that the Personalizer service will use to train models. </summary>
        /// <param name="policy"> The learning settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicyOptions>> UpdatePersonalizerPolicyAsync(PersonalizerPolicyOptions policy, CancellationToken cancellationToken = default)
        {
            return await PolicyClient.UpdateAsync(policy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update the Learning Settings that the Personalizer service will use to train models. </summary>
        /// <param name="policy"> The learning settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicyOptions> UpdatePersonalizerPolicy(PersonalizerPolicyOptions policy, CancellationToken cancellationToken = default)
        {
            return PolicyClient.Update(policy, cancellationToken);
        }

        /// <summary> Resets the learning settings of the Personalizer service to default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerPolicyOptions>> ResetPersonalizerPolicyAsync(CancellationToken cancellationToken = default)
        {
            return await PolicyClient.ResetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Resets the learning settings of the Personalizer service to default. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerPolicyOptions> ResetPersonalizerPolicy(CancellationToken cancellationToken = default)
        {
            return PolicyClient.Reset(cancellationToken);
        }

        /// <summary> Delete the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeletePersonalizerEvaluationAsync(string evaluationId, CancellationToken cancellationToken = default)
        {
            return await EvaluationsClient.DeleteAsync(evaluationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeletePersonalizerEvaluation(string evaluationId, CancellationToken cancellationToken = default)
        {
            return EvaluationsClient.Delete(evaluationId, cancellationToken);
        }

        /// <summary> Get the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerEvaluation>> GetPersonalizerEvaluationAsync(string evaluationId, CancellationToken cancellationToken = default)
        {
            return await EvaluationsClient.GetAsync(evaluationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the Offline Evaluation associated with the Id. </summary>
        /// <param name="evaluationId"> Id of the Offline Evaluation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerEvaluation> GetPersonalizerEvaluation(string evaluationId, CancellationToken cancellationToken = default)
        {
            return EvaluationsClient.Get(evaluationId, cancellationToken);
        }

        /// <summary> List of all Offline Evaluations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<PersonalizerEvaluation>>> GetPersonalizerEvaluationsAsync(CancellationToken cancellationToken = default)
        {
            return await EvaluationsClient.ListAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> List of all Offline Evaluations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<PersonalizerEvaluation>> GetPersonalizerEvaluations(CancellationToken cancellationToken = default)
        {
            return EvaluationsClient.List(cancellationToken);
        }

        /// <summary> Submit a new Offline Evaluation job. </summary>
        /// <param name="evaluation"> The Offline Evaluation job definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersonalizerEvaluation>> CreatePersonalizerEvaluationAsync(EvaluationContract evaluation, CancellationToken cancellationToken = default)
        {
            return await EvaluationsClient.CreateAsync(evaluation, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Submit a new Offline Evaluation job. </summary>
        /// <param name="evaluation"> The Offline Evaluation job definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersonalizerEvaluation> CreatePersonalizerEvaluation(EvaluationContract evaluation, CancellationToken cancellationToken = default)
        {
            return EvaluationsClient.Create(evaluation, cancellationToken);
        }
    }
}
