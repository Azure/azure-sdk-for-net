// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal static class ScopeUtilities
    {
        private const string DefaultSuffix = "/.default";


        public static string ScopesToResource(string[] scopes)
        {
            if (scopes == null)
            {
                throw new ArgumentNullException(nameof(scopes));
            }

            if (scopes.Length != 1)
            {
                throw new ArgumentException("To convert to a resource string the specified array must be exactly length 1", nameof(scopes));
            }

            if (!scopes[0].EndsWith(DefaultSuffix, StringComparison.Ordinal))
            {
                return scopes[0];
            }

            return scopes[0].Remove(scopes[0].LastIndexOf(DefaultSuffix, StringComparison.Ordinal));
        }

        public static string[] ResourceToScopes(string resource)
        {
            return new string[] { resource + "/.default" };
        }

    }
}
