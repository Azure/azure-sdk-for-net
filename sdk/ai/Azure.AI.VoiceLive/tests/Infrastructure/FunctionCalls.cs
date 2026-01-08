// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.VoiceLive.Tests
{
    internal static class FunctionCalls
    {
        public static readonly VoiceLiveFunctionDefinition AdditionDefinition = new VoiceLiveFunctionDefinition("add_numbers")
        {
            Description = "Add two numbers together",
            Parameters = BinaryData.FromObjectAsJson(new
            {
                type = "object",
                properties = new
                {
                    a = new
                    {
                        type = "number",
                        description = "The first number to add"
                    },
                    b = new
                    {
                        type = "number",
                        description = "The second number to add"
                    }
                }
            })
        };

        public static readonly VoiceLiveFunctionDefinition SubtractionDefinition = new VoiceLiveFunctionDefinition("subtract_numbers")
        {
            Description = "Subtract two numbers",
            Parameters = BinaryData.FromObjectAsJson(new
            {
                type = "object",
                properties = new
                {
                    a = new
                    {
                        type = "number",
                        description = "The first number to subtract"
                    },
                    b = new
                    {
                        type = "number",
                        description = "The second number to subtract"
                    }
                }
            })
        };
    }
}
