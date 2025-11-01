// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Files;

#pragma warning disable CS0618

namespace Azure.AI.Agents;

public static partial class OpenAIFileExtensions
{
    public static string GetAzureFileStatus(this OpenAIFile file)
    {
        if (AdditionalPropertyHelpers.GetAdditionalProperty<OpenAIFile, string>(file, "_sdk_status") is string extraStatusValue
            && extraStatusValue.Length > 2)
        {
            return extraStatusValue.Substring(1, extraStatusValue.Length - 2);
        }
        return null;
    }
}
