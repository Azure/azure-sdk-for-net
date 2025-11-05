// <copyright file="IUtf8JsonSerializable.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

using System.Text.Json;

namespace Azure.AI.AgentServer.Contracts.Generated.Common
{
    public interface IUtf8JsonSerializable
    {
        void Write(Utf8JsonWriter writer);
    }
}
