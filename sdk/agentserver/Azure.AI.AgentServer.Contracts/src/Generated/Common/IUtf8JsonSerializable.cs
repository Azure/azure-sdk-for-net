// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Contracts.Generated.Common
{
    public interface IUtf8JsonSerializable
    {
        void Write(Utf8JsonWriter writer);
    }
}
