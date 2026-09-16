// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[CodeGenType("BetaAgents")]
[Experimental("AAIP001")]
public partial class BetaAgents
{
    /// <summary>
    /// Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// </summary>
    /// <param name="body"> The kind-specific inputs for generating and creating an agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<ProjectsAgentRecord> GenerateAgent(GenerateVoiceAgentRequest body, CancellationToken cancellationToken = default)
    {
        return GenerateAgent(
            body: ModelReaderWriter.Write(body, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default),
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// </summary>
    /// <param name="body"> The kind-specific inputs for generating and creating an agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<ProjectsAgentRecord>> GenerateAgentAsync(GenerateVoiceAgentRequest body, CancellationToken cancellationToken = default)
    {
        return await GenerateAgentAsync(
            body: ModelReaderWriter.Write(body, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default),
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }
}
