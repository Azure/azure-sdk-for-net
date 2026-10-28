// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAILike.Responses
{
    /// <summary>
    /// Terminal fallback the base library returns when it does not recognize the "type"
    /// discriminator. This is exactly the gap a conditional proxy from another library fills.
    /// </summary>
    public sealed class UnknownResponseTool : ResponseTool
    {
        public UnknownResponseTool() : base("unknown")
        {
        }

        public UnknownResponseTool(string type) : base(type)
        {
        }
    }
}
