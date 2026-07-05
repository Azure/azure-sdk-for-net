// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using OpenAI;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.Agents;

[CodeGenType("A2ATool")]
public partial class A2APreviewTool
{
    /// <summary> Base URL of the agent. </summary>
    [CodeGenMember("BaseUrl")]
    public Uri BaseUri { get; set; }

    /// <summary>
    /// The uri of agent card.
    /// If not provided, defaults to  `${base_url}/.well-known/agent-card.json`
    /// </summary>
    public Uri AgentCardUri { get => new(BaseUri, AgentCardPath); set => AgentCardPath = value.AbsolutePath; }
    /// <summary>
    /// The path to the agent card relative to the `base_url`.
    /// If not provided, defaults to  `/.well-known/agent-card.json`
    /// </summary>
    internal string AgentCardPath { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="A2APreviewTool"/>.
    /// </summary>
    /// <param name="baseUri"></param>
    public A2APreviewTool(Uri baseUri) : this()
    {
        BaseUri = baseUri;
    }
}
