// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using OpenAI;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("A2ATool")]
public partial class A2ATool
{
    /// <summary> Base URL of the agent. </summary>
    [CodeGenMember("BaseUrl")]
    public Uri BaseUri { get; set; }

    /// <summary> Initializes a new instance of <see cref="A2ATool"/>. </summary>
    internal A2ATool() : base(ToolType.A2aPreview)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="A2ATool"/>.
    /// </summary>
    /// <param name="baseUri"></param>
    public A2ATool(Uri baseUri) : this()
    {
        BaseUri = baseUri;
    }
}
