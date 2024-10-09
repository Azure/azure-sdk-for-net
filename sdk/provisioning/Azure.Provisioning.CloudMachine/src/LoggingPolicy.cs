// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel;

internal class LoggingPolicy : PipelinePolicy
{
    public LoggingPolicy() {}

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Log(message);
        if (currentIndex < pipeline.Count - 1)
        {
            pipeline[currentIndex + 1].Process(message, pipeline, currentIndex + 1);
        }
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Log(message);
        if (currentIndex < pipeline.Count - 1)
        {
            await pipeline[currentIndex + 1].ProcessAsync(message, pipeline, currentIndex + 1).ConfigureAwait(false);
        }
    }

    protected virtual void Log(PipelineMessage message)
    {
        string logMessage = ComposeLog(message);
        Console.WriteLine(logMessage);
    }

    protected string ComposeLog(PipelineMessage message) {
        StringBuilder logMessage = new StringBuilder();
        ComposeRequestLine(message, logMessage);
        ComposeHeaders(message, logMessage);
        ComposeContent(message, logMessage);
        return logMessage.ToString();
    }
    protected virtual void ComposeRequestLine(PipelineMessage message, StringBuilder logMessage)
    {
        logMessage.AppendLine(message.Request.Uri!.AbsoluteUri);
    }
    protected virtual void ComposeHeaders(PipelineMessage message, StringBuilder logMessage)
    {
        foreach (var header in message.Request.Headers)
        {
            if (header.Key == "Authorization" || header.Key == "api-key")
                Console.WriteLine($"{header.Key} : [REDACTED ...{header.Value.Length} characters]");
            else
                Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }
    protected virtual void ComposeContent(PipelineMessage message, StringBuilder logMessage)
    {
        var stream = new MemoryStream();
        message.Request.Content!.WriteTo(stream);
        stream.Position = 0;
        var content = BinaryData.FromStream(stream);
        logMessage.AppendLine(content.ToString());
    }
}
