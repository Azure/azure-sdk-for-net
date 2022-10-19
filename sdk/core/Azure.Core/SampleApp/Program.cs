// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Polly;
using SampleApp;

Console.WriteLine("Hello, World!");

// User can replace pipeline policy
var options = ClientOptions.Default;
options.ReplacePolicy(new PollyPolicy(), PipelinePolicyReplacement.RetryPolicy);

var client = new SampleClient(new Uri("endpoint"), new DefaultAzureCredential(), options);

// User can sub out RetryPolicy per-invocation
RequestContext context = new();
context.ReplacePolicy(new CustomRetryPolicy(), PipelinePolicyReplacement.RetryPolicy);
client.GetWithSpecialRetries(RequestContent.Create("value"), context);

public class PollyPolicy : HttpPipelinePolicy
{
    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        Policy.HandleResult<Response>(r => r.Status >= 400)
            .WaitAndRetry(3, retryAttempt => {
                message.PipelineContext.RetryAttempt = retryAttempt;
                return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))})
            .Execute(() => ProcessWithResponse(message, pipeline));
    }

    private Response ProcessWithResponse(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ProcessNext(message, pipeline);
        return message.Response;
    }

    public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }
}

public class CustomRetryPolicy : HttpPipelineSynchronousPolicy
{
}
