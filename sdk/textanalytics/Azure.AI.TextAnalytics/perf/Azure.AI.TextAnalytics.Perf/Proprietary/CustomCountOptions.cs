// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.AI.TextAnalytics.Perf
{
    public class CustomCountOptions
        : CountOptions
    {
        public CustomCountOptions()
        {
            Count = 1000;
        }
    }
}
