namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial interface IKnowledgebase
    {
        /// <summary>
        /// GenerateAnswer call to query knowledgebase (QnA Maker Managed).
        /// </summary>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='generateAnswerPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<QnASearchResultList>> GenerateAnswerWithHttpMessagesAsync(string kbId, QueryDTO generateAnswerPayload, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Train call to add suggestions to knowledgebase (QnAMaker Managed).
        /// </summary>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='trainPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> TrainWithHttpMessagesAsync(string kbId, FeedbackRecordsDTO trainPayload, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
