// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;

/// <summary> Details of an error returned by the service. </summary>
[CodeGenType("Error")]
public partial class FoundryOpenAIError
{
    // Preserve upstream diagnostics in serialization without exposing their internal model hierarchy.
    [CodeGenMember("Misalignment")]
    internal MisalignmentErrorDetailsResource Misalignment { get; }

    internal static FoundryOpenAIError TryCreateFromResponse(PipelineResponse response)
    {
        try
        {
            using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
            FoundryOpenAIError result = DeserializeFoundryOpenAIError(errorDocument.RootElement, ModelSerializationExtensions.WireOptions);
            if (string.IsNullOrEmpty(result.Code) && string.IsNullOrEmpty(result.Param) && result.Details?.Count > 0 != true)
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

    internal string ToExceptionMessage(int httpStatus)
    {
        StringBuilder messageBuilder = new();
        messageBuilder.Append("HTTP ").Append(httpStatus).Append(" (").Append(Code).AppendLine(")");
        if (!string.IsNullOrEmpty(Param))
        {
            messageBuilder.Append("Parameter: ").AppendLine(Param);
        }
        messageBuilder.AppendLine();
        messageBuilder.Append(Message);
        if (Details?.Count > 0 == true)
        {
            messageBuilder.AppendLine().AppendLine();
            messageBuilder.Append(GetExceptionMessageRecursive());
            foreach (FoundryOpenAIError error in Details)
            {
                messageBuilder.AppendLine($"{error.Param ?? "<empty>"}:");
                messageBuilder.AppendLine().Append($"  - {error.ToExceptionMessage(httpStatus)}");
            }
        }
        return messageBuilder.ToString();
    }

    private string GetExceptionMessageRecursive()
    {
        StringBuilder messageBuilder = new();
        foreach (FoundryOpenAIError error in Details)
        {
            messageBuilder.AppendLine($"{error.Param ?? "<empty>"}: {error.Message}");
            messageBuilder.AppendLine().Append($"  - {error.GetExceptionMessageRecursive()}");
        }
        return messageBuilder.ToString();
    }

    /// <summary>
    /// Converts this <see cref="FoundryOpenAIError"/> instance payload into a formatted, equivalent response payload that conforms to the
    /// expected schema in the OpenAI library. This will allow mechanisms like automatic exception message propagation to function as
    /// intended.
    /// </summary>
    /// <returns></returns>
    internal BinaryData ToOpenAIError()
    {
        StringBuilder messageBuilder = new(Message);
        string parameterDetails = null;
        if (Details?.Count > 0)
        {
            messageBuilder.Append(" (");
            foreach (FoundryOpenAIError error in Details)
            {
                messageBuilder.Append(error.Message);
                if (error.Details?.Count > 0 == true)
                {
                    messageBuilder.AppendLine().Append(error.GetExceptionMessageRecursive());
                }
                messageBuilder.Append("; ");
            }
            messageBuilder.Remove(messageBuilder.Length - 2, 2);
            messageBuilder.Append(')');
            parameterDetails = string.Join(";", Details.Select(x => x.Param));
        }
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteStartObject();
            writer.WriteStartObject("error");
            writer.WriteString("message", messageBuilder.ToString());
            writer.WriteString("type", nameof(FoundryOpenAIError));
            writer.WriteString("param", parameterDetails ?? string.Empty);
            writer.WriteString("code", Code ?? string.Empty);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        return BinaryData.FromBytes(stream.ToArray());
    }
}
