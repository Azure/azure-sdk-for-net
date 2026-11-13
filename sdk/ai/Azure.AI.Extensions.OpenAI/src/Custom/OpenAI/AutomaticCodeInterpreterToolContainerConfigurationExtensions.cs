// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Diagnostics.CodeAnalysis;
using OpenAI;
using OpenAI.Containers;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

#pragma warning disable SCME0001

/// <summary>
/// Extension properties for configuring automatic code interpreter containers.
/// </summary>
[Experimental("AAIP001")]
public static partial class AutomaticCodeInterpreterToolContainerConfigurationExtensions
{
    extension(AutomaticCodeInterpreterToolContainerConfiguration configuration)
    {
        /// <summary> Gets or sets the memory limit for the container. </summary>
        [Experimental("SCME0001")]
        public ContainerMemoryLimit? MemoryLimit
        {
            get
            {
                string? value = configuration.Patch.GetStringEx("$.memory_limit"u8);
                return value is null ? null : new ContainerMemoryLimit(value);
            }
            set => configuration.Patch.SetOrClearEx(
                "$.memory_limit"u8,
                "$.memory_limit"u8,
                value?.ToString());
        }

        /// <summary> Gets or sets the network access policy for the container. </summary>
        [Experimental("SCME0001")]
        public ContainerNetworkPolicy? NetworkPolicy
        {
            get => configuration.Patch.GetJsonModelEx<ContainerNetworkPolicy>(
                "$.network_policy"u8,
                OpenAIContext.Default);
            set => configuration.Patch.SetOrClearEx(
                "$.network_policy"u8,
                "$.network_policy"u8,
                value,
                OpenAIContext.Default);
        }
    }
}
