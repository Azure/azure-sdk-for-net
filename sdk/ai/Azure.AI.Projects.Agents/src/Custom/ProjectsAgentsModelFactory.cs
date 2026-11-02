// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("FoundryOpenAIError", typeof(string), typeof(string), typeof(string), typeof(string),
    typeof(MisalignmentErrorDetailsResource), typeof(IEnumerable<FoundryOpenAIError>),
    typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
public partial class ProjectsAgentsModelFactory
{
    /// <summary> Creates service error details for mocking. </summary>
    /// <param name="code"> The service error code. </param>
    /// <param name="message"> The error message. </param>
    /// <param name="param"> The input parameter associated with the error. </param>
    /// <param name="type"> The error type. </param>
    /// <param name="details"> Additional errors that contributed to the failure. </param>
    /// <param name="additionalInfo"> Additional structured error information. </param>
    /// <param name="debugInfo"> Diagnostic information supplied by the service. </param>
    /// <returns> Service error details for mocking. </returns>
    public static FoundryOpenAIError FoundryOpenAIError(string code = default, string message = default,
        string param = default, string type = default, IEnumerable<FoundryOpenAIError> details = default,
        IDictionary<string, BinaryData> additionalInfo = default, IDictionary<string, BinaryData> debugInfo = default)
    {
        details ??= new ChangeTrackingList<FoundryOpenAIError>();
        return new FoundryOpenAIError(code, message, param, type, misalignment: default,
            details.ToList(),
            additionalInfo ?? new ChangeTrackingDictionary<string, BinaryData>(),
            debugInfo ?? new ChangeTrackingDictionary<string, BinaryData>(), additionalBinaryDataProperties: null);
    }

    /// <summary> Creates a new instance of <see cref="Agents.ProjectsAgentRecord"/> for mocking. </summary>
    /// <param name="id">The agent identifier.</param>
    /// <param name="name">The agent name.</param>
    /// <param name="state">The agent state.</param>
    public static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default)
    {
        return new ProjectsAgentRecord(
            @object: "agent",
            id: id,
            name: name,
            state: state,
            configurationState: default,
            stateSource: default,
            versions: new AgentObjectVersions(),
            agentEndpoint: default,
            digitalWorkerType: default,
            instanceIdentity: default,
            blueprint: default,
            blueprintReference: default,
            agentCard: default,
            additionalBinaryDataProperties: null);
    }

    internal static ProjectsAgentRecord ProjectsAgentRecord(string id = default, string name = default, AgentState state = default, AgentState configurationState = default, AgentStateSource? stateSource = default, AgentObjectVersions versions = default, AgentEndpointConfiguration agentEndpoint = default, DigitalWorkerType? digitalWorkerType = default, AgentIdentity instanceIdentity = default, AgentIdentity blueprint = default, AgentBlueprintReference blueprintReference = default, AgentCard agentCard = default)
    {
        return new ProjectsAgentRecord(
                @object: "agent",
                id: id,
                name: name,
                state: state,
                configurationState: configurationState,
                stateSource: stateSource,
                versions: versions,
                agentEndpoint: agentEndpoint,
                digitalWorkerType: digitalWorkerType,
                instanceIdentity: instanceIdentity,
                blueprint: blueprint,
                blueprintReference: blueprintReference,
                agentCard: agentCard,
                additionalBinaryDataProperties: null);
    }
}
