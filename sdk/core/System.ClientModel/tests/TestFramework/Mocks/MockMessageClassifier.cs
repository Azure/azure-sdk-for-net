// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockMessageClassifier : PipelineMessageClassifier
{
    private readonly int[]? _successCodes;

    public MockMessageClassifier() : this(string.Empty)
    {
    }

    public MockMessageClassifier(string id) : this(id, default)
    {
    }

    public MockMessageClassifier(int[] successCodes) : this(string.Empty, successCodes)
    {
    }

    public MockMessageClassifier(string id, int[]? successCodes)
    {
        Id = id;
        _successCodes = successCodes;
    }

    public string Id { get; set; }

    public override bool TryClassify(PipelineMessage message, out bool isError)
    {
        if (_successCodes is not null)
        {
            foreach (var code in _successCodes)
            {
                if (message.Response!.Status == code)
                {
                    isError = true;
                    return true;
                }
            }

            isError = false;
            return true;
        }

        return Default.TryClassify(message, out isError);
    }

    public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
    {
        return Default.TryClassify(message, exception, out isRetriable);
    }
}
