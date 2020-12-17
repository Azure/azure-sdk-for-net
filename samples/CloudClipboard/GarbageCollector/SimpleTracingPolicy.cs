using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading.Tasks;

namespace GarbageCollector
{
    public class SimpleTracingPolicy : HttpPipelinePolicy
    {
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Console.WriteLine($">> Request: {message.Request.Method} {message.Request.Uri}");
            await ProcessNextAsync(message, pipeline);
            Console.WriteLine($">> Response: {message.Response.Status} from {message.Request.Method} {message.Request.Uri}\n");
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Console.WriteLine($">> Request: {message.Request.Uri}");
            ProcessNext(message, pipeline);
            Console.WriteLine($">> Response: {message.Response.Status} {message.Request.Method} {message.Request.Uri}");
        }
    }
}
