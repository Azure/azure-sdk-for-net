using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    public partial class QnAMakerRuntimeClient
    {
        /// <summary>
        /// Initializes a new instance of the QnAMakerClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name="isPreview">
        /// Optional. The flag used to change BaseUri if it is true.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public QnAMakerRuntimeClient(ServiceClientCredentials credentials, bool isPreview = false, params DelegatingHandler[] handlers) : this(credentials, handlers)
        {
            if (isPreview)
            {
                BaseUri = "{RuntimeEndpoint}/qnamaker/v5.0-preview.1";
            }
        }
    }
}