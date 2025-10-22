// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureOpenAIDalleError")]
internal partial class AzureOpenAIDalleError
{
    internal static AzureOpenAIDalleError TryCreateFromResponse(PipelineResponse response)
    {
        try
        {
            using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
            AzureOpenAIDalleErrorResponse errorResponse
                = AzureOpenAIDalleErrorResponse.DeserializeAzureOpenAIDalleErrorResponse(errorDocument.RootElement, ModelSerializationExtensions.WireOptions);
            return errorResponse.Error;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public string ToExceptionMessage(int httpStatus)
    {
        StringBuilder messageBuilder = new();
        messageBuilder.Append($"HTTP {httpStatus}");
        messageBuilder.Append(!string.IsNullOrEmpty(Kind) || !string.IsNullOrEmpty(Code) ? " (" : string.Empty);
        messageBuilder.Append(Kind);
        messageBuilder.Append(!string.IsNullOrEmpty(Kind) ? ": " : string.Empty);
        messageBuilder.Append(Code);
        messageBuilder.Append(!string.IsNullOrEmpty(Kind) || !string.IsNullOrEmpty(Code) ? ")" : string.Empty);
        messageBuilder.AppendLine();

        if (!string.IsNullOrEmpty(Param))
        {
            messageBuilder.AppendLine($"Parameter: {Param}");
        }

        messageBuilder.AppendLine();
        messageBuilder.Append(Message);
        return messageBuilder.ToString();
    }
}
