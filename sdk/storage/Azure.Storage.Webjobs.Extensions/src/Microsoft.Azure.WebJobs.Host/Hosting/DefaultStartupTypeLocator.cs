// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// An implementation of an <see cref="IWebJobsStartupTypeLocator"/> that locates startup types
    /// configured in the entry point assembly using the <see cref="WebJobsStartupAttribute"/>.
    /// </summary>
    internal class DefaultStartupTypeLocator : IWebJobsStartupTypeLocator
    {
        private readonly Assembly _entryAssembly;
        private readonly Lazy<Type[]> _startupTypes;

        public DefaultStartupTypeLocator()
        {
            _startupTypes = new Lazy<Type[]>(GetTypes);
        }

        internal DefaultStartupTypeLocator(Assembly entryAssembly)
            : this()
        {
            _entryAssembly = entryAssembly;
        }

        public Type[] GetStartupTypes()
        {
            return _startupTypes.Value;
        }

        private Type[] GetTypes()
        {
            Assembly entryAssembly = _entryAssembly ?? Assembly.GetEntryAssembly();
            return entryAssembly.GetCustomAttributes<WebJobsStartupAttribute>().Select(a => a.WebJobsStartupType).ToArray();
        }
    }
}
