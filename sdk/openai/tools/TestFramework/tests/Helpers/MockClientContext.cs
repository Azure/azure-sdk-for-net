// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Tests.Helpers;

public class MockClientContext
{
    public string Id { get; } = Guid.NewGuid().ToString();
}
