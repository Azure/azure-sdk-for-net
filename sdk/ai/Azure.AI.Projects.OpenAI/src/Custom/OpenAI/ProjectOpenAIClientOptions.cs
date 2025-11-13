// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIClientOptions : OpenAIClientOptions
{
    private string _apiVersion;

    public string ApiVersion
    {
        get => _apiVersion;
        set
        {
            AssertNotFrozen();
            _apiVersion = value;
        }
    }

    public ProjectOpenAIClientOptions() : base()
    {
        _apiVersion = "2025-11-15-preview";
    }
}
