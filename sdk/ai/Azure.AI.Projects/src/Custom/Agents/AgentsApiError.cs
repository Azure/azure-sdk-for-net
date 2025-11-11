// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Azure.AI.Projects;

/// <summary> The ApiError. </summary>
[CodeGenType("ApiError")]
public partial class AgentsApiError
{
    internal static AgentsApiError TryCreateFromResponse(PipelineResponse response)
    {
        try
        {
            using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
            AgentsApiError result = DeserializeAgentsApiError(errorDocument.RootElement, ModelSerializationExtensions.WireOptions);
            if (string.IsNullOrEmpty(result.Code) && string.IsNullOrEmpty(result.Target) && result.Details?.Count > 0 != true)
            {
                // Empty or uninteresting JSON documents should be treated like incomplete deserializations
                return null;
            }
            return result;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
        catch (NullReferenceException)
        {
            return null;
        }
    }

    public string ToExceptionMessage(int httpStatus)
    {
        StringBuilder messageBuilder = new();
        messageBuilder.Append("HTTP ").Append(httpStatus).Append(" (").Append(Code).AppendLine(")");
        //if (!string.IsNullOrEmpty(Param))
        //{
        //    messageBuilder.Append("Parameter: ").AppendLine(Param);
        //}
        messageBuilder.AppendLine();
        messageBuilder.Append(Message);
        if (!string.IsNullOrEmpty(Target))
        {
            messageBuilder.AppendLine().AppendLine().Append(Target);
        }
        if (Details?.Count > 0 == true)
        {
            messageBuilder.AppendLine().AppendLine();
            messageBuilder.Append(GetExceptionMessageRecursive());
            foreach (AgentsApiError error in Details)
            {
                messageBuilder.AppendLine($"{error.Target ?? "<empty>"}:");
                messageBuilder.AppendLine().Append($"  - {error.ToExceptionMessage(httpStatus)}");
            }
        }
        return messageBuilder.ToString();
    }

    private string GetExceptionMessageRecursive()
    {
        StringBuilder messageBuilder = new();
        foreach (AgentsApiError error in Details)
        {
            messageBuilder.AppendLine($"{error.Target ?? "<empty>"}: {error.Message}");
            messageBuilder.AppendLine().Append($"  - {error.GetExceptionMessageRecursive()}");
        }
        return messageBuilder.ToString();
    }

    /// <summary>
    /// Converts this <see cref="AgentsApiError"/> instance payload into a formatted, equivalent response payload that conforms to the
    /// expected schema in the OpenAI library. This will allow mechanisms like automatic exception message propagation to function as
    /// intended.
    /// </summary>
    /// <returns></returns>
    public BinaryData ToOpenAIError()
    {
        StringBuilder messageBuilder = new(Message);
        string parameterDetails = null;
        if (Details?.Count > 0)
        {
            messageBuilder.Append(" (");
            foreach (AgentsApiError error in Details)
            {
                messageBuilder.Append(error.GetExceptionMessageRecursive());
                messageBuilder.Append("; ");
            }
            messageBuilder.Remove(messageBuilder.Length - 2, 2);
            messageBuilder.Append(')');
            parameterDetails = string.Join(";", Details.Select(x => x.Target));
        }
        BinaryData newErrorBytes = BinaryData.FromString($$"""
            {
              "error": {
                "message": "{{messageBuilder}}",
                "type": "{{nameof(AgentsApiError)}}",
                "param": "{{(parameterDetails ?? string.Empty)}}",
                "code": "{{(Code ?? string.Empty)}}"
              }
            }
            """);
        return newErrorBytes;
    }
}
