// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.Projects.OpenAI;

internal static partial class ClientPipelineExtensions
{
    public static async ValueTask<PipelineResponse> ProcessMessageAsync(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions options)
    {
        await pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response.IsError && (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw await TryBufferResponseAndCreateErrorAsync(message).ConfigureAwait(false) switch
            {
                string errorMessage when !string.IsNullOrEmpty(errorMessage)
                    => new ClientResultException(errorMessage, message.Response),
                _ => new ClientResultException(message.Response),
            };
        }

        return message.BufferResponse ?
            message.Response :
            message.ExtractResponse();
    }

    public static PipelineResponse ProcessMessage(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions options)
    {
        pipeline.Send(message);

        if (message.Response.IsError && (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw TryBufferResponseAndCreateError(message) switch
            {
                string errorMessage when !string.IsNullOrEmpty(errorMessage)
                    => new ClientResultException(errorMessage, message.Response),
                _ => new ClientResultException(message.Response),
            };
        }

        return message.BufferResponse ?
            message.Response :
            message.ExtractResponse();
    }

    private static string TryBufferResponseAndCreateError(PipelineMessage message)
    {
        message.Response.BufferContent();
        return TryCreateErrorMessageFromResponse(message.Response);
    }

    private static async Task<string> TryBufferResponseAndCreateErrorAsync(PipelineMessage message)
    {
        await message.Response.BufferContentAsync().ConfigureAwait(false);
        return TryCreateErrorMessageFromResponse(message.Response);
    }

    private static string TryCreateErrorMessageFromResponse(PipelineResponse response)
        => FoundryOpenAIError.TryCreateFromResponse(response)?.ToExceptionMessage(response.Status)
        ?? GetFallbackExceptionMessageFromResponse(response);

    private static string GetFallbackExceptionMessageFromResponse(PipelineResponse response)
    {
        return new StringBuilder("An error was encountered while processing the request.")
            .AppendLine()
            .AppendLine($"HTTP {response.Status}: {((HttpStatusCode)response.Status)}")
            .AppendLine()
            .AppendLine(response.Content.ToString())
            .ToString();
    }
}
