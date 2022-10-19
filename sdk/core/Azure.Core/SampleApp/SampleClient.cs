using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SampleApp
{
    public class SampleClient
    {
        private readonly HttpPipeline _pipeline;

        internal static int MyServiceSLAMinutes;

        public SampleClient(Uri endpoint, TokenCredential credential, ClientOptions options)
        {
            // Pipeline author can add retry conditions or override the default retry policy
            HttpPipelineOptions pipelineOptions = new HttpPipelineOptions(options);
            pipelineOptions.RetryConditions.Add(new GlobalTimeoutRetryCondition(TimeSpan.FromMinutes(MyServiceSLAMinutes)));

            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);
        }

        public Response GetWithSpecialRetries(RequestContent content, RequestContext context = default)
        {
            HttpMessage message = _pipeline.CreateMessage(context);

            // In reality, we would use the protocol method send that takes context, but it's not in Core yet.
            _pipeline.Send(message, context.CancellationToken);
            return message.Response;
        }
    }

    public class GlobalTimeoutRetryCondition : RetryCondition
    {
        private TimeSpan _maxTime;

        public GlobalTimeoutRetryCondition(TimeSpan maxTime)
        {
            _maxTime = maxTime;
        }

        public override bool TryGetShouldRetry(HttpMessage message, out bool shouldRetry)
        {
            if ((message.PipelineContext.CreatedOn + _maxTime) >= DateTimeOffset.UtcNow)
            {
                shouldRetry = false;
                return true;
            }

            shouldRetry = true;
            return false;
        }
    }
}
