// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hyak.Common.Internals
{
    public static class PortablePlatformAbstraction
    {
        private static readonly Dictionary<string,string> PlatformNamesAndAssemblies = new Dictionary<string,string>
        {
            {"NetFramework","Microsoft.Azure.Common.NetFramework"}
        };

        private static object _lock = new object();
        private static IDictionary<Assembly, Assembly> _platformAssemblies = new Dictionary<Assembly, Assembly>();
        private static IDictionary<Type, Type> _platformAbstractions = new Dictionary<Type, Type>();

        public static T Get<T>(bool hasDefaultImplementation = false)
        {
            if (!typeof(T).GetTypeInfo().IsInterface)
            {
                throw new ArgumentException();
            }
            else if (!typeof(T).Name.StartsWith("I", StringComparison.Ordinal))
            {
                throw new ArgumentException();
            }

            Type platformType = null;
            lock (_lock)
            {
                if (!_platformAbstractions.TryGetValue(typeof(T), out platformType))
                {
                    Assembly callingAssembly = typeof(T).GetTypeInfo().Assembly;
                    Assembly platformAssembly = GetPlatformAssembly(callingAssembly);
                    platformType = GetPlatformTypeFullName<T>(platformAssembly);

                    if (platformType == null && hasDefaultImplementation)
                    {
                        platformType = GetPlatformTypeFullName<T>(callingAssembly);
                    }

                    if (platformType != null)
                    {
                        _platformAbstractions[typeof(T)] = platformType;
                    }
                }
                if (platformType == null)
                {
                    throw new PlatformNotSupportedException();
                }
            }

            try
            {
                return (T)Activator.CreateInstance(platformType);
            }
            catch (Exception ex)
            {
                throw new PlatformNotSupportedException("...", ex);
            }
        }

        private static Assembly GetPlatformAssembly(Assembly callingAssembly)
        {
            Debug.Assert(callingAssembly != null, "callingAssembly cannot be null.");

            Assembly platformAssembly = null;
            if (!_platformAssemblies.TryGetValue(callingAssembly, out platformAssembly))
            {
                foreach (var entry in PlatformNamesAndAssemblies)
                {
                    try
                    {
                        string platformAssemblyName = entry.Value;
                        platformAssembly = Assembly.Load(new AssemblyName(platformAssemblyName));
                        _platformAssemblies[callingAssembly] = platformAssembly;
                        break;
                    }
                    catch (FileNotFoundException)
                    {
                    }
                }
            }

            if (platformAssembly == null)
            {
                return callingAssembly;
            }

            return platformAssembly;
        }

        private static Type GetPlatformTypeFullName<T>(Assembly platformAssembly)
        {
            return platformAssembly
                .DefinedTypes
                .Where(p => typeof(T).GetTypeInfo().IsAssignableFrom(p) && !p.IsInterface)
                .Single()
                .AsType();
        }
    }
}
