// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.AI.Agents.Telemetry;

namespace Azure.AI.Agents;

public partial class AgentsClient
{
    /// <summary>
    /// [Protocol Method] Creates the agent.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CreateAgent(BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgent(_endpoint, content, options);
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentRequest(content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordCreateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Creates the agent.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CreateAgentAsync(BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgent(_endpoint, content, options);
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentRequest(content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordCreateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Create a new agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to create/modify. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CreateAgentVersion(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgentVersion(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentVersionRequest(agentName, content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordCreateAgentVersionResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Create a new agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to create/modify. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CreateAgentVersionAsync(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgentVersion(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentVersionRequest(agentName, content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordCreateAgentVersionResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Create a new agent version from a manifest.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to create a version for. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CreateAgentVersionFromManifest(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgentVersion(_endpoint, agentName, content, options);

        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentVersionFromManifestRequest(agentName, content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordCreateAgentVersionResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Create a new agent version from a manifest.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to create a version for. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CreateAgentVersionFromManifestAsync(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgentVersion(_endpoint, agentName, content, options);

        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentVersionFromManifestRequest(agentName, content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordCreateAgentVersionResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Creates an agent from a manifest.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CreateAgentFromManifest(BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgent(_endpoint, content, options);

        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentFromManifestRequest(content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordCreateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Creates an agent from a manifest.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CreateAgentFromManifestAsync(BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartCreateAgent(_endpoint, content, options);

        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateCreateAgentFromManifestRequest(content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordCreateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Updates the agent by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to retrieve. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult UpdateAgent(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartUpdateAgent(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateUpdateAgentRequest(agentName, content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordUpdateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Updates the agent by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to retrieve. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> UpdateAgentAsync(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartUpdateAgent(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateUpdateAgentRequest(agentName, content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordUpdateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Updates the agent from a manifest by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to update. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult UpdateAgentFromManifest(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartUpdateAgent(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateUpdateAgentFromManifestRequest(agentName, content, options);
            var result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            otelScope?.RecordUpdateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }

    /// <summary>
    /// [Protocol Method] Updates the agent from a manifest by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the agent to update. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> UpdateAgentFromManifestAsync(string agentName, BinaryContent content, RequestOptions options = null)
    {
        using var otelScope = OpenTelemetryScope.StartUpdateAgent(_endpoint, agentName, content, options);
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(content, nameof(content));

        try
        {
            using PipelineMessage message = CreateUpdateAgentFromManifestRequest(agentName, content, options);
            var result = ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            otelScope?.RecordUpdateAgentResponse(result);
            return result;
        }
        catch (Exception ex)
        {
            otelScope?.RecordError(ex);
            throw;
        }
    }
}
