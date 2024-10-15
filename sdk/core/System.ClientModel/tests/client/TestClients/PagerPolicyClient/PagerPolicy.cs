// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.ReferenceClients.PagerPolicyClient;

public class PagerPolicy : PipelinePolicy
{
    private readonly PagerPolicyOptions _options;

    public PagerPolicy(PagerPolicyOptions options)
    {
        _options = options;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Console.WriteLine(_options.PhoneNumber?.ToString());

        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Console.WriteLine(_options.PhoneNumber?.ToString());

        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
