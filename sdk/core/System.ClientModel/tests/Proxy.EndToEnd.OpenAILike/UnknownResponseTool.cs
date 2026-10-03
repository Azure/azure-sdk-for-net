// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.OpenAILike
{
    /// <summary>
    /// Terminal fallback the base library returns when it does not recognize the "type"
    /// discriminator. This is exactly the gap a third-party conditional proxy fills.
    /// </summary>
    public sealed class UnknownResponseTool : ResponseTool
    {
        public UnknownResponseTool() : base("unknown")
        {
        }

        public UnknownResponseTool(string type) : base(type)
        {
        }

        protected override void WriteProperties(Utf8JsonWriter writer)
        {
            // Unknown subtype has no additional known properties.
        }
    }
}
