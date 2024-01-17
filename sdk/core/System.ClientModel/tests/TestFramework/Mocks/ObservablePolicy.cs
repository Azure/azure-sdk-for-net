// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class ObservablePolicy : PipelinePolicy
{
    public string Id { get; }
    protected bool IsLastPolicy { get; set; } = false;

    public ObservablePolicy(string id)
    {
        Id = id;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Stamp(message, "Request");

        if (!IsLastPolicy)
        {
            ProcessNext(message, pipeline, currentIndex);
        }

        Stamp(message, "Response");
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Stamp(message, "Request");

        if (!IsLastPolicy)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }

        Stamp(message, "Response");
    }

    private void Stamp(PipelineMessage message, string prefix)
    {
        List<string> values;

        if (message.TryGetProperty(typeof(ObservablePolicy), out object? prop) &&
            prop is List<string> list)
        {
            values = list;
        }
        else
        {
            values = new List<string>();
            message.SetProperty(typeof(ObservablePolicy), values);
        }

        values.Add($"{prefix}:{Id}");
    }

    public static List<string> GetData(PipelineMessage message)
    {
        message.TryGetProperty(typeof(ObservablePolicy), out object? prop);

        return prop is List<string> list ? list : new List<string>();
    }

    public override string ToString() => $"ObservablePolicy:{Id}";
}
