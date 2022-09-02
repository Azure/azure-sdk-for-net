// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Template
{
    internal interface IVersionValidatable<TServiceVersion>
    {
        bool IsValidInput(TServiceVersion version, out string message);
    }
}
