// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    internal static class DiagnosticUtilities
    {
        internal static string GenerateIdentifier(string entityPath) =>
            $"{entityPath}-{Guid.NewGuid()}";
    }
}
