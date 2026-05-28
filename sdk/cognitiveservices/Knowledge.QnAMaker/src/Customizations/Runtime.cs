namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{    
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Customized Runtime operations - using V5.0-preivew.1 Knowledgebase operations for generateAnswer and train APIs.
    /// </summary>
    public class Runtime
    {
        /// <summary>
        /// Initializes a new instance of the Runtime class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal Runtime(QnAMakerClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the QnAMakerRuntimeClient
        /// </summary>
        private QnAMakerClient Client { get; set; }

        /// <summary>
        /// GenerateAnswer call to query the knowledgebase.
        /// </summary>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='generateAnswerPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<QnASearchResultList> GenerateAnswerAsync(string kbId, QueryDTO generateAnswerPayload, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.Knowledgebase.GenerateAnswerAsync(kbId, generateAnswerPayload, cancellationToken);
        }

        /// <summary>
        /// Train call to add suggestions to the knowledgebase.
        /// </summary>
        /// <param name='kbId'>
        /// Knowledgebase id.
        /// </param>
        /// <param name='trainPayload'>
        /// Post body of the request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task TrainAsync(string kbId, FeedbackRecordsDTO trainPayload, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Client.Knowledgebase.TrainAsync(kbId, trainPayload, cancellationToken);
        }

    }
}
