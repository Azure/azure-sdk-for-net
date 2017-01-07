// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    public static class SharedSettings
    {
        public delegate IResourceNamer ResourceNamerCreator(string name);
        public static ResourceNamerCreator CreateResourceNamer { get; set; } = new ResourceNamerCreator((name) => new ResourceNamer(name));

        public static string RandomResourceName(string prefix, int maxLen)
        {
            var namer = CreateResourceNamer("");
            return namer.RandomName(prefix, maxLen);
        }
    }
}
