// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework.TestProxy;

/// <summary>
/// Provides configuration options for the test proxy client used in recorded test scenarios.
/// This class extends <see cref="ClientPipelineOptions"/> to configure the HTTP pipeline
/// used when communicating with the test proxy service.
/// </summary>
/// <seealso cref="ClientPipelineOptions"/>
public class TestProxyClientOptions : ClientPipelineOptions
{
}
