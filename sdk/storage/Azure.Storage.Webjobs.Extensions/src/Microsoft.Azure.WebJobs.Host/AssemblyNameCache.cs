// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Caches a mapping of Assembly objects to their corresponding AssemblyNames.
    /// </summary>
    public static class AssemblyNameCache
    {
        private static readonly ConcurrentDictionary<Assembly, AssemblyName> AssemblyToNameCache = new ConcurrentDictionary<Assembly, AssemblyName>();

        /// <summary>
        /// Returns a cached copy of the given Assembly's AssemblyName if available, otherwise, retrieves the AssemblyName, caches it and returns it.
        /// </summary>
        /// <param name="assembly">The Assembly</param>
        /// <returns>The AssemblyName</returns>
        public static AssemblyName GetName(Assembly assembly)
        {
            return AssemblyToNameCache.GetOrAdd(assembly, asm => asm.GetName());
        }
    }
}
