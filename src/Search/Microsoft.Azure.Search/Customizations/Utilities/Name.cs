// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;

    internal static class Name
    {
        public static void ThrowIfNullOrEmpty(string name, string paramName, string nameKind)
        {
            Throw.IfArgumentNullOrEmpty(
                name,
                paramName,
                String.Format("Invalid {0} name. Name cannot be null or an empty string.", nameKind));
        }
    }
}
