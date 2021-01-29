using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    public class DynamicRequest : Request
    {
        private Request Request { get; }
        private HttpPipeline HttpPipeline { get; }

        private static readonly Encoding Utf8NoBom = new UTF8Encoding(false, true);

        public override RequestContent Content 
        { 
            get => DynamicContent.Create(Body); 

            set {
                MemoryStream ms = new MemoryStream();
                value.WriteTo(ms, default);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms, Utf8NoBom))
                {
                    Body = new DynamicJson(sr.ReadToEnd());
                }
                Request.Content = value;
            }
        }

        // TODO(matell): How does the initialization here play into the ability to send a request with an "empty" body?
        public dynamic Body { get; set; } = DynamicJson.Object();

        // TODO(matell): In Krzysztof's prototype we also took DiagnosticScope as a parameter, do we still need that? 
        public DynamicRequest(Request request, HttpPipeline pipeline)
        {
            Request = request;
            HttpPipeline = pipeline;
        }

        public async Task<DynamicResponse> SendAsync(CancellationToken cancellationToken = default)
        {
            // Since we are sending the underlying request, we need to copy the Content on to it, or we'll lose the body.
            Request.Content = Content;

            Response res = await HttpPipeline.SendRequestAsync(Request, cancellationToken).ConfigureAwait(false);
            DynamicJson dynamicContent = null;

            if (res.ContentStream != null)
            {
                using (StreamReader sr = new StreamReader(res.ContentStream, encoding: Utf8NoBom, leaveOpen: true))
                {
                    dynamicContent = new DynamicJson(await sr.ReadToEndAsync());
                }
            }

            return new DynamicResponse(res, dynamicContent);
        }

        public DynamicResponse Send(CancellationToken cancellationToken = default) => SendAsync().GetAwaiter().GetResult();

        public override string ClientRequestId { get => Request.ClientRequestId; set => Request.ClientRequestId = value; }

        public override void Dispose() => Request.Dispose();

        protected override void AddHeader(string name, string value) => Request.Headers.Add(name, value);

        protected override bool ContainsHeader(string name) => Request.Headers.Contains(name);

        protected override IEnumerable<HttpHeader> EnumerateHeaders() => Request.Headers;

        protected override bool RemoveHeader(string name) => Request.Headers.Remove(name);

        protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string value) => Request.Headers.TryGetValue(name, out value);

        protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string> values) => Request.Headers.TryGetValues(name, out values);
    }
}
