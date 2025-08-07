// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Assistants.Tests;
public class OpenAITestEnvironment : TestEnvironment
{
    public string NonAzureOpenAIApiKey => GetOptionalVariable("OPENAI_API_KEY");

    public string AzureOpenAIResourceUri => GetOptionalVariable("AZURE_OPENAI_RESOURCE_URI");

    public string AzureOpenAIApiKey => GetOptionalVariable("AZURE_OPENAI_API_KEY");
}
