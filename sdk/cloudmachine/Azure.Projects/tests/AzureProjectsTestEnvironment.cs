// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Projects.Tests;
public class AzureProjectsTestEnvironment : TestEnvironment
{
    public string AzureAICONNECTIONSTRING => GetRecordedVariable("PROJECT_CONNECTION_STRING");
}
