// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class SamplesBase : ProjectsClientTestBase
{
    public SamplesBase(bool isAsync) : base(isAsync)
    { }
}
