// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Tests;

internal class UserIdentityHeaderPolicy(string userIdentity) : PipelinePolicy
{
    private const string _imageDeploymentHeader = "x-ms-user-identity";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_imageDeploymentHeader, userIdentity);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        message.Request.Headers.Add(_imageDeploymentHeader, userIdentity);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
