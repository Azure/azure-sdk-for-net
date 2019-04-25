using System;
namespace Microsoft.Azure.CognitiveServices.Vision.FormRecognizer
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class FormHttpMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // XXX: if endpoint is /Analyze add these request headers
            if (request.RequestUri.ToString().ToLower().Contains("analyze")) {
                request.Content.Headers.Clear();
                request.Content.Headers.Add("Content-Type", "application/pdf");
            }

            // Call the inner handler.
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
