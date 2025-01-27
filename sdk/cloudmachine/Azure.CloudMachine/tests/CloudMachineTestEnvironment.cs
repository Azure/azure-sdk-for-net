// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.CloudMachine.Tests;
public class CloudMachineTestEnvironment : TestEnvironment
{
    public string AzureAICONNECTIONSTRING => GetRecordedVariable("PROJECT_CONNECTION_STRING");
}
