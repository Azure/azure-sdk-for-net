namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Net.Http;
    using System.Threading;

    internal class CustomHeaderHandler : MessageProcessingHandler
    {
        private readonly string name;
        private readonly string value;

        internal CustomHeaderHandler(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.name = name;
            this.value = value;
        }

        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                if (!request.Headers.Contains(this.name))
                {
                    request.Headers.Add(this.name, this.value);
                }
            }
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return response;
        }
    }
}
