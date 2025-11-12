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

    internal ProjectOpenAIClientOptions GetClone()
    {
        return new ProjectOpenAIClientOptions()
        {
            ApiVersion = ApiVersion,
            ClientLoggingOptions = ClientLoggingOptions,
            EnableDistributedTracing = EnableDistributedTracing,
            Endpoint = Endpoint,
            MessageLoggingPolicy = MessageLoggingPolicy,
            NetworkTimeout = NetworkTimeout,
            OrganizationId = OrganizationId,
            ProjectId = ProjectId,
            RetryPolicy = RetryPolicy,
            Transport = Transport,
            UserAgentApplicationId = UserAgentApplicationId,
        };
    }
}
