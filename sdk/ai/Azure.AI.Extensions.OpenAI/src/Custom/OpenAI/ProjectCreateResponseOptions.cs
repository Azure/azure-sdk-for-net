// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;
# pragma warning disable SCME0001

/// <summary>
/// The project extension for OpenAI CreateResponseOptions.
/// </summary>
public partial class ProjectCreateResponseOptions : CreateResponseOptions
{
    /// <summary>
    /// Session used to get the response.
    /// </summary>
    public string SessionId { get => Patch.GetStringEx("$.agent_session_id"u8) ; set => Patch.SetOrClearEx("$.agent_session_id"u8, "$.agent_session_id"u8, value); }
}
