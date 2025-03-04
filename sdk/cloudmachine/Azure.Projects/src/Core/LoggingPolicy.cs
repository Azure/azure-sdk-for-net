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

    public List<string> AllowedHeaders { get; } = ["Content-Type", "Accept", "User-Agent", "x-ms-client-request-id"];
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        LogRequest(message);
        if (currentIndex < pipeline.Count - 1)
        {
            pipeline[currentIndex + 1].Process(message, pipeline, currentIndex + 1);
        }
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        LogRequest(message);
        if (currentIndex < pipeline.Count - 1)
        {
            await pipeline[currentIndex + 1].ProcessAsync(message, pipeline, currentIndex + 1).ConfigureAwait(false);
        }
        LogResponse(message);
    }

    protected virtual void LogRequest(PipelineMessage message)
    {
        string logMessage = FormatRequestLog(message);
        Console.WriteLine(logMessage);
    }
    protected virtual void LogResponse(PipelineMessage message)
    {
        string logMessage = FormatResponseLog(message);
        Console.WriteLine(logMessage);
    }

    protected virtual string FormatRequestLog(PipelineMessage message) {
        StringBuilder logMessage = new();
        FormatRequestLine(message, logMessage);
        FormatHeaders(message, logMessage);
        FormatContent(message, logMessage);
        return logMessage.ToString();
    }
    protected virtual string FormatResponseLog(PipelineMessage message)
    {
        StringBuilder logMessage = new();
        PipelineResponse response = message.Response!;
        logMessage.Append(response.Status);
        logMessage.Append(' ');
        logMessage.AppendLine(response.ReasonPhrase);
        FormatHeaders(message, logMessage);
        FormatContent(message, logMessage);
        return logMessage.ToString();
    }

    protected virtual void FormatRequestLine(PipelineMessage message, StringBuilder logMessage)
    {
        PipelineRequest request = message.Request;
        logMessage.Append(request.Method);
        logMessage.Append(' ');
        logMessage.AppendLine(request.Uri!.AbsoluteUri);
    }
    protected virtual void FormatHeaders(PipelineMessage message, StringBuilder logMessage)
    {
        foreach (KeyValuePair<string, string> header in message.Request.Headers)
        {
            if (AllowedHeaders.Contains(header.Key))
            {
                logMessage.AppendLine($"{header.Key} : {header.Value}");
            }
            else
            {
                logMessage.AppendLine($"{header.Key} : [REDACTED ...{header.Value.Length} characters]");
            }
        }
    }
    protected virtual void FormatContent(PipelineMessage message, StringBuilder logMessage)
    {
        var stream = new MemoryStream();
        message.Request.Content!.WriteTo(stream);
        stream.Position = 0;
        var content = BinaryData.FromStream(stream);
        logMessage.AppendLine(content.ToString());
    }
}
