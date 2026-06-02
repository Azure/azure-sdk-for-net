// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class MachineRunCommandData
    {
        // Backward-compat justification: TypeSpec uses IsAsyncExecution for boolean naming guidance, while this alias preserves the AutoRest GA-compatible property name.
        /// <summary> Optional. If set to true, provisioning will complete as soon as script starts and will not wait for script to complete. </summary>
        [SuppressMessage("Azure.ClientSdk.Analyzers", "AZC0032", Justification = "Backward-compat justification: the migrated SDK preserves the AutoRest GA-compatible asyncExecution property name.")]
        [WirePath("properties.asyncExecution")]
        public bool? AsyncExecution
        {
            get => IsAsyncExecution;
            set => IsAsyncExecution = value;
        }
    }
}