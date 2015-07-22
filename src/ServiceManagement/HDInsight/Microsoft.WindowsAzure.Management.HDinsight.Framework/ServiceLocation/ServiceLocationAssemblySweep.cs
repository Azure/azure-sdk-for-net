// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class ServiceLocationAssemblySweep : IServiceLocationAssemblySweep
    {
        private List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> knownRegistrars = new List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();
        private Dictionary<Type, IServiceLocationRegistrarProxyFactory> proxies = new Dictionary<Type, IServiceLocationRegistrarProxyFactory>();

        public void RegisterRegistrarProxy<T>(IServiceLocationRegistrarProxyFactory proxy)
        {
            this.proxies.Add(typeof(T), proxy);
        }

        public bool NewAssembliesPresent()
        {
            var registrars = this.GetRegistrarTypes().ToList();
            this.knownRegistrars.All(r => registrars.Remove(r));
            return registrars.Any();
        }

        public IEnumerable<IServiceLocationRegistrar> GetRegistrars()
        {
            var registrars = this.GetRegistrarTypes().ToList();
            this.knownRegistrars.All(registrars.Remove);
            this.knownRegistrars.AddRange(registrars);

            var objects = (from t in registrars
                         select t.Value.Create(t.Key)).ToList();
            return objects;
        }

        private class AssemblyNameEqualityComparer : IEqualityComparer<AssemblyName>
        {
            public bool Equals(AssemblyName x, AssemblyName y)
            {
                if (x.IsNull() && y.IsNull())
                {
                    return true;
                }
                if (x.IsNull() || y.IsNull())
                {
                    return false;
                }
                if (x.Name.Equals(y.Name, StringComparison.Ordinal) && 
                    x.Version.Equals(y.Version) && 
                    x.CultureInfo.Equals(y.CultureInfo) && 
                    (ReferenceEquals(x.KeyPair, y.KeyPair) || 
                     (x.KeyPair.IsNotNull() && y.KeyPair.IsNotNull() &&
                      x.KeyPair.PublicKey.SequenceEqual(y.KeyPair.PublicKey))))
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(AssemblyName obj)
            {
                if (obj.IsNotNull())
                {
                    return obj.GetHashCode();
                }
                return 0;
            }
        }

        internal IEnumerable<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> GetRegistrarTypes()
        {
            var comparer = new AssemblyNameEqualityComparer();
            List<Type> types = new List<Type>();
            var scansedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var proxyAssemblies = (from p in this.proxies select p.Value.GetType().Assembly.GetName()).ToList();
            var workingAssemblies = (from s in scansedAssemblies
                                     from r in proxyAssemblies
                                    where s.GetReferencedAssemblies().Contains(r, comparer)
                                   select s).ToList();
            workingAssemblies.Add(this.GetType().Assembly);
            foreach (var assembly in workingAssemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes());
                }
                catch (ReflectionTypeLoadException loadEx)
                {
                    var foundTypes = (from t in loadEx.Types where t.IsNotNull() select t).ToList();
                    types.AddRange(foundTypes);
                }
            }
            Queue<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>> preOrdered = new Queue<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();
            foreach (var type in types)
            {
                if (type.IsInterface)
                {
                    continue;
                }
                foreach (var proxy in this.proxies)
                {
                    if (proxy.Key.IsAssignableFrom(type) && !ReferenceEquals(type.GetConstructor(new Type[0]), null))
                    {
                        preOrdered.Add(new KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>(type, proxy.Value));
                    }
                }
            }

            var orderedList = new List<KeyValuePair<Type, IServiceLocationRegistrarProxyFactory>>();
            while (preOrdered.Count > 0)
            {
                var type = preOrdered.Remove();
                bool addToList = true;
                foreach (var stackType in preOrdered)
                {
                    if (type.Key.Assembly.GetReferencedAssemblies().Contains(stackType.Key.Assembly.GetName(), comparer))
                    {
                        addToList = false;
                        preOrdered.Add(type);
                        break;
                    }
                }
                if (addToList)
                {
                    orderedList.Add(type);
                }
            }

            return orderedList;
        }
    }
}
