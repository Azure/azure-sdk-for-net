// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#nullable enable

namespace Azure.Core
{
    internal enum OperationFinalStateVia
    {
        AzureAsyncOperation,
        Location,
        OriginalUri
    }
}
