using System;
namespace Microsoft.Azure.CognitiveServices.FormRecognizer
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public enum FormContentType { pdf, images };

    public class FormHttpMessageHandler : DelegatingHandler
    {
        
        public string contentTypeHeader;

        public FormHttpMessageHandler(FormContentType type)
        {
            if (type == FormContentType.pdf)
            {
                contentTypeHeader = "application/pdf";
            }
            else
            {
                contentTypeHeader = "image/*";
            }
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // XXX: if endpoint is /Analyze add these request headers
            if (request.RequestUri.ToString().ToLower().Contains("analyze")) {
                request.Content.Headers.Clear();
                request.Content.Headers.Add("Content-Type", contentTypeHeader);
            }

            // Call the inner handler.
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
