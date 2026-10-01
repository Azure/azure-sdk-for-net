// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("GenerateAgent", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("GenerateAgentAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("GenerateAgent", typeof(BinaryData), typeof(CancellationToken))]
[CodeGenSuppress("GenerateAgentAsync", typeof(BinaryData), typeof(CancellationToken))]
public partial class AgentAdministrationClient
{
    /// <summary> Generates and creates an agent from kind-specific high-level inputs. </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options for this call. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult GenerateAgent(BinaryContent content, RequestOptions options = null)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AgentAdministrationClient.GenerateAgent");
        scope.Start();
        try
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateGenerateAgentRequest(content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Generates and creates an agent from kind-specific high-level inputs. </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options for this call. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult> GenerateAgentAsync(BinaryContent content, RequestOptions options = null)
    {
        using DiagnosticScope scope = ClientDiagnostics.CreateScope("AgentAdministrationClient.GenerateAgent");
        scope.Start();
        try
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateGenerateAgentRequest(content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    /// <summary> Generates and creates an agent from kind-specific high-level inputs. </summary>
    /// <param name="body"> The kind-specific inputs for generating and creating an agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<ProjectsAgentRecord> GenerateAgent(BinaryData body, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(body, nameof(body));

        using BinaryContent content = BinaryContent.Create(body);
        ClientResult result = GenerateAgent(content, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((ProjectsAgentRecord)result, result.GetRawResponse());
    }

    /// <summary> Generates and creates an agent from kind-specific high-level inputs. </summary>
    /// <param name="body"> The kind-specific inputs for generating and creating an agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<ProjectsAgentRecord>> GenerateAgentAsync(BinaryData body, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(body, nameof(body));

        using BinaryContent content = BinaryContent.Create(body);
        ClientResult result = await GenerateAgentAsync(content, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((ProjectsAgentRecord)result, result.GetRawResponse());
    }

    /// <summary>
    /// Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// </summary>
    /// <param name="body"> The kind-specific inputs for generating and creating an agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="body"/> is null. </exception>
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
    /// <exception cref="System.ArgumentNullException"> <paramref name="body"/> is null. </exception>
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
