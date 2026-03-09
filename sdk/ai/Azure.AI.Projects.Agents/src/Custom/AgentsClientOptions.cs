// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;

namespace Azure.AI.Projects.Agents;

public class AgentsClientOptions : OpenAIClientOptions
{
    private string _apiVersion;
    public AgentsClientOptions() : base() { _apiVersion = (new InternalProjectsClientOptions()).Version; }

    public string ApiVersion
    {
        get => _apiVersion;
        set
        {
            AssertNotFrozen();
            _apiVersion = value;
        }
    }
}
