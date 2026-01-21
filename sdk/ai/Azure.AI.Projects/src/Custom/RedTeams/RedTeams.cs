// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.AI.Projects;

public partial class RedTeams
{
    /// <summary>
    /// [Protocol Method] Creates a redteam run.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="redTeam"> Redteam to be run. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="redTeam"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<RedTeam> Create(RedTeam redTeam, RequestOptions options = null)
    {
        Argument.AssertNotNull(redTeam, nameof(redTeam));

        using PipelineMessage message = CreateCreateRequest(redTeam, options);
        ClientResult result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        return ClientResult.FromValue((RedTeam)result, result.GetRawResponse());
    }

    /// <summary>
    /// [Protocol Method] Creates a redteam run.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="redTeam"> Redteam to be run. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="redTeam"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<RedTeam>> CreateAsync(RedTeam redTeam, RequestOptions options = null)
    {
        Argument.AssertNotNull(redTeam, nameof(redTeam));

        using PipelineMessage message = CreateCreateRequest(redTeam, options);
        ClientResult result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        return ClientResult.FromValue((RedTeam)result, result.GetRawResponse());
    }
}
