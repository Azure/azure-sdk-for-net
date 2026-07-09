// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Automation
{
    internal static class DscCompilationJobCompatibilityHelpers
    {
        internal const string ObsoleteMessage = "This DscCompilationJob compatibility API is not supported in the TypeSpec-based SDK and always throws NotSupportedException.";

        internal static Exception CreateException()
        {
            return new NotSupportedException(ObsoleteMessage);
        }
    }
}
