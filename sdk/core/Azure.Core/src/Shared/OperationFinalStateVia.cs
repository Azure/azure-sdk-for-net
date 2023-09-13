// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core.Shared
{
    internal enum OperationFinalStateVia
    {
        AzureAsyncOperation,
        Location,
        OriginalUri,
        OperationLocation,
        LocationOverride,
    }
}
