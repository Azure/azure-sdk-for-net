// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary> Error response for API failures. </summary>
public partial class ApiErrorResponse
{
    internal ApiErrorResponse(Error error, IDictionary<string, BinaryData>? additionalBinaryDataProperties)
        : this(error)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ApiErrorResponse"/>. </summary>
    /// <param name="error">The error object.</param>
    public ApiErrorResponse(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        Error = error;
    }

    /// <summary> Gets or sets the error object. </summary>
    [JsonPropertyName("error")]
    public Error Error { get; set; }
}

/// <summary> The API error details. </summary>
public partial class Error
{
    internal Error(
        string code,
        string message,
        string param,
        string type,
        IList<Error> details,
        IDictionary<string, BinaryData> additionalInfo,
        IDictionary<string, BinaryData> debugInfo,
        IDictionary<string, BinaryData>? additionalBinaryDataProperties)
        : this(code, message)
    {
        Param = param;
        Type = type;
        Details = details;
        AdditionalInfo = additionalInfo;
        DebugInfo = debugInfo;
    }

    /// <summary> Initializes a new instance of <see cref="Error"/>. </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    public Error(string code, string message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Code = code;
        Details = new List<Error>();
        AdditionalInfo = new Dictionary<string, BinaryData>();
        DebugInfo = new Dictionary<string, BinaryData>();
    }

    /// <summary> Gets or sets the error code. </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary> Gets or sets the error message. </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary> Gets or sets the parameter that caused the error. </summary>
    [JsonPropertyName("param")]
    public string? Param { get; set; }

    /// <summary> Gets or sets the error type. </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary> Gets nested error details. </summary>
    [JsonPropertyName("details")]
    public IList<Error> Details { get; }

    /// <summary> Gets additional structured error information. </summary>
    [JsonPropertyName("additional_info")]
    public IDictionary<string, BinaryData> AdditionalInfo { get; }

    /// <summary> Gets internal debug information. </summary>
    [JsonIgnore]
    public IDictionary<string, BinaryData> DebugInfo { get; }
}

/// <summary> The response data for a requested list of items. </summary>
public partial class AgentsPagedResultOutputItem
{
    internal AgentsPagedResultOutputItem(
        IList<OutputItem> data,
        string firstId,
        string lastId,
        bool hasMore,
        IDictionary<string, BinaryData>? additionalBinaryDataProperties)
    {
        Data = data;
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    /// <summary> The object type, which is always <c>list</c>. </summary>
    [JsonPropertyName("object")]
    public string Object => "list";

    /// <summary> The requested list of items. </summary>
    [JsonPropertyName("data")]
    public IList<OutputItem> Data { get; }

    /// <summary> The first ID represented in this list. </summary>
    [JsonPropertyName("first_id")]
    public string FirstId { get; }

    /// <summary> The last ID represented in this list. </summary>
    [JsonPropertyName("last_id")]
    public string LastId { get; }

    /// <summary> A value indicating whether there are additional values available not captured in this list. </summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; }
}

/// <summary> Conversation object. </summary>
public partial class ConversationParam
{
    internal ConversationParam(string id, IDictionary<string, BinaryData>? additionalBinaryDataProperties)
        : this(id)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ConversationParam"/>. </summary>
    /// <param name="id">The unique ID of the conversation.</param>
    public ConversationParam(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }

    /// <summary> The unique ID of the conversation. </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
