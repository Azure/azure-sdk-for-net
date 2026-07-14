// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Files;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Provides file operations for an Azure AI project through the OpenAI file API. </summary>
public partial class ProjectFilesClient : OpenAIFileClient
{
    internal ProjectFilesClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ProjectFilesClient"/> for mocking. </summary>
    protected ProjectFilesClient()
    { }
}
