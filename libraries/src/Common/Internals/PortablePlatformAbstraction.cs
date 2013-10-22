//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public static class PortablePlatformAbstraction
    {
        private static readonly string[] PlatformNames =
            new string[]
            {
                "NetFramework",
                "WindowsStore",                
                "WindowsPhone",
                "Silverlight",
            };

        private static object _lock = new object();
        private static IDictionary<Assembly, Assembly> _platformAssemblies = new Dictionary<Assembly, Assembly>();
        private static IDictionary<Type, Type> _platformAbstractions = new Dictionary<Type, Type>();

        public static T Get<T>(bool hasDefaultImplementation = false)
        {
            if (!typeof(T).IsInterface)
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
                    Assembly callingAssembly = Assembly.GetCallingAssembly();
                    Assembly platformAssembly = GetPlatformAssembly(callingAssembly);
                    string typeName = GetPlatformTypeFullName<T>();
                    platformType = platformAssembly.GetType(typeName, false);

                    if (platformType == null && hasDefaultImplementation)
                    {
                        platformType = callingAssembly.GetType(typeName, false);
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
                string assemblyName = callingAssembly.FullName.Split(',').FirstOrDefault();
                if (string.IsNullOrEmpty(assemblyName))
                {
                    throw new PlatformNotSupportedException();
                }

                foreach (string platformName in PlatformNames)
                {
                    try
                    {
                        string platformAssemblyName = assemblyName + "." + platformName;
                        platformAssembly = Assembly.Load(platformAssemblyName);
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
                throw new PlatformNotSupportedException();
            }

            return platformAssembly;
        }

        private static string GetPlatformTypeFullName<T>()
        {
            return typeof(T).Namespace + "." + typeof(T).Name.Substring(1);
        }
    }
}
