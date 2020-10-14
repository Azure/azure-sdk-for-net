namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Knowledgebase.
    /// </summary>
    public static partial class KnowledgebaseExtensions
    {        
        /// <summary>
        /// GenerateAnswer call to query knowledgebase (QnA Maker Managed).
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='generateAnswerPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<QnASearchResultList> GenerateAnswerAsync(this IKnowledgebase operations, string kbId, QueryDTO generateAnswerPayload, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GenerateAnswerWithHttpMessagesAsync(kbId, generateAnswerPayload, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Train call to add suggestions to knowledgebase (QnAMaker Managed).
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='trainPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task TrainAsync(this IKnowledgebase operations, string kbId, FeedbackRecordsDTO trainPayload, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.TrainWithHttpMessagesAsync(kbId, trainPayload, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
}
