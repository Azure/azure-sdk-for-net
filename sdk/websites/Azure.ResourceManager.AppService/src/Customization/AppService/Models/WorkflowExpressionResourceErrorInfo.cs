// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class WorkflowExpressionResourceErrorInfo : WebAppErrorInfo
    {
        // Generator bug: for a self-referencing collection property
        // (TypeSpec `details?: AzureResourceErrorInfo[]` inside model `AzureResourceErrorInfo`),
        // the generator emits the constructor parameter and JSON (de)serialization for
        // `details`/`Details`, but omits the public property declaration on the model class.
        // The generated `Serialization.cs` references `Details` directly, so without this
        // partial the project would not compile.
        // Tracked by https://github.com/Azure/azure-sdk-for-net/issues/60374 — remove this
        // customization once the generator emits the property correctly.
        /// <summary> The error details. </summary>
        [WirePath("details")]
        public IReadOnlyList<WorkflowExpressionResourceErrorInfo> Details { get; }
    }
}
