using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    public class QnAMakerRuntimeClient
    {
        public Runtime Runtime { get; set; }
        private QnAMakerClient client { get; set; }

        public string RuntimeEndpoint { 
            set
            {
                if (client != null)
                {
                    client.Endpoint = value;
                }
            }

            get 
            {
                if (client != null && client.Endpoint != null)
                {
                    return client.Endpoint;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the QnAMakerRuntimeClient class. 
        /// An adapter class for supporting (hosted) Runtime operations using Knowledgebase operations (generateAnswer and train) from QnAMakerClient V5.preview.1.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public QnAMakerRuntimeClient(EndpointKeyServiceClientCredentials credentials, params DelegatingHandler[] handlers)
        {
            this.client = new QnAMakerClient(credentials, handlers);
            Runtime = new Runtime(this.client);            
        }
    }
}