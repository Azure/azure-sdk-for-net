// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Resource.Fluent
{
    public interface IResourceNamer
    {
        string RandomName(string prefix, int maxLen);
    }
}
