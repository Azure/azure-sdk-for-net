// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Shared;

internal readonly partial struct MessagingDiagnosticOperation
{
    public static MessagingDiagnosticOperation Settle = new("settle");
}