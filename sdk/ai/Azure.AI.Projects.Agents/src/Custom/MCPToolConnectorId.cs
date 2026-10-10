// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI;

/// <summary>
/// Identifier for service connectors, like those available in ChatGPT. One of `server_url` or `connector_id` must be provided.
/// </summary>
[CodeGenType("MCPToolConnectorId")]
public enum MCPToolboxToolConnectorId
{
    /// <summary> ConnectorDropbox. </summary>
    ConnectorDropbox,
    /// <summary> ConnectorGmail. </summary>
    ConnectorGmail,
    /// <summary> ConnectorGooglecalendar. </summary>
    ConnectorGooglecalendar,
    /// <summary> ConnectorGoogledrive. </summary>
    ConnectorGoogledrive,
    /// <summary> ConnectorMicrosoftteams. </summary>
    ConnectorMicrosoftteams,
    /// <summary> ConnectorOutlookcalendar. </summary>
    ConnectorOutlookcalendar,
    /// <summary> ConnectorOutlookemail. </summary>
    ConnectorOutlookemail,
    /// <summary> ConnectorSharepoint. </summary>
    ConnectorSharepoint
}
