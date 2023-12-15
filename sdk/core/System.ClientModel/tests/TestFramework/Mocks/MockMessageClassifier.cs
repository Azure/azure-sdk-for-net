// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockMessageClassifier : PipelineMessageClassifier
{
    public MockMessageClassifier() : this(string.Empty)
    {
    }

    public MockMessageClassifier(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
