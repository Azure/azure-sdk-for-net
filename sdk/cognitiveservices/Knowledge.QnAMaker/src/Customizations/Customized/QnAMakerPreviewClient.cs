using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    public partial class QnAMakerClient
    {
        public QnAMakerClient(ServiceClientCredentials credentials, bool isPreview = false, params DelegatingHandler[] handlers) : this(credentials, handlers)
        {
            if (isPreview)
            {
                BaseUri = "{Endpoint}/qnamaker/v5.0-preview.1";
            }
        }
    }
}
