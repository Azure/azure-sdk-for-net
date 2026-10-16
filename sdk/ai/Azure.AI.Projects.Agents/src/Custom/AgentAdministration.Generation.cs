// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

public partial class AgentAdministrationClient
{
    /// <summary>
    /// [Protocol Method] Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult GenerateAgent(BinaryContent content, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNull(content, nameof(content));
            return CreateGenerateAgentRequest(content, options);
        }, "AgentAdministrationClient.GenerateAgent", options);
    }

    /// <summary>
    /// [Protocol Method] Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual Task<ClientResult> GenerateAgentAsync(BinaryContent content, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNull(content, nameof(content));
            return CreateGenerateAgentRequest(content, options);
        }, "AgentAdministrationClient.GenerateAgent", options);
    }
}
