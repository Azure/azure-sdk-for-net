// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Indexers
{
    // Default policy for locating types. 
    internal class DefaultTypeLocator : ITypeLocator
    {
        private static readonly string WebJobsAssemblyName = AssemblyNameCache.GetName(typeof(FunctionNameAttribute).Assembly).Name;

        private readonly ILogger _logger;

        public DefaultTypeLocator(ILoggerFactory loggerFactory)
        {            
            _logger = loggerFactory.CreateLogger(LogCategories.Startup);
        }

        // Helper to filter out assemblies that don't reference the SDK or
        // binding extension assemblies (i.e. possible sources of binding attributes, etc.)
        private static bool AssemblyReferencesSdkOrExtension(Assembly assembly, IEnumerable<Assembly> extensionAssemblies)
        {
            // Don't index methods in our assemblies.
            if (typeof(DefaultTypeLocator).Assembly == assembly)
            {
                return false;
            }

            AssemblyName[] referencedAssemblyNames = assembly.GetReferencedAssemblies();
            foreach (var referencedAssemblyName in referencedAssemblyNames)
            {
                if (String.Equals(referencedAssemblyName.Name, WebJobsAssemblyName, StringComparison.OrdinalIgnoreCase))
                {
                    // the assembly references our core SDK assembly
                    // containing our built in attribute types
                    return true;
                }

                if (extensionAssemblies.Any(p => string.Equals(referencedAssemblyName.Name, AssemblyNameCache.GetName(p).Name, StringComparison.OrdinalIgnoreCase)))
                {
                    // the assembly references an extension assembly that may
                    // contain extension attributes
                    return true;
                }
            }

            return false;
        }

        public IReadOnlyList<Type> GetTypes()
        {
            List<Type> allTypes = new List<Type>();

            var assemblies = GetUserAssemblies();

            // $$$ Previously - this would include all extension assemblies (any assembly that referenced an extension)
            // but it's hard to determine that; and an extension assembly would also reference webjobs; so can we just include that? 
            IEnumerable<Assembly> extensionAssemblies = new Assembly[] { this.GetType().Assembly } ; // $$$ breaking change 
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = FindTypes(assembly, extensionAssemblies);
                if (assemblyTypes != null)
                {
                    allTypes.AddRange(assemblyTypes.Where(IsJobClass));
                }
            }

            return allTypes;
        }

        public static bool IsJobClass(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.IsClass
                // For C# static keyword classes, IsAbstract and IsSealed both return true. Include C# static keyword
                // classes but not C# abstract keyword classes.
                && (!type.IsAbstract || type.IsSealed)
                // We only consider public top-level classes as job classes. IsPublic returns false for nested classes,
                // regardless of visibility modifiers. 
                && type.IsPublic
                && !type.ContainsGenericParameters;
        }

        private static IEnumerable<Assembly> GetUserAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        private Type[] FindTypes(Assembly assembly, IEnumerable<Assembly> extensionAssemblies)
        {
            // Only try to index assemblies that reference the core SDK assembly containing
            // binding attributes (or any registered extension assemblies). This ensures we
            // don't do more inspection work that is necessary during function indexing.
            if (!AssemblyReferencesSdkOrExtension(assembly, extensionAssemblies))
            {
                return null;
            }

            Type[] types = null;

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                var builder = new StringBuilder();

                builder.AppendLine($"Warning: Only got partial types from assembly: {assembly.FullName}");

                if (ex.LoaderExceptions != null)
                {
                    builder.AppendLine($"The following loader failures occured when trying to load the assembly:");
                    string loaderFailuresMessage = string.Join(Environment.NewLine, ex.LoaderExceptions.Select(e => $"   - {e.Message}"));
                    builder.AppendLine(loaderFailuresMessage);

                    builder.AppendLine("This can occur if the assemblies listed above are missing, outdated or mismatched.");
                }

                builder.AppendLine($"Exception message: {ex.ToString()}");

                _logger.LogWarning(builder.ToString());
                // In case of a type load exception, at least get the types that did succeed in loading
                types = ex.Types.Where(t => t != null).ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Warning: Failed to get types from assembly: {0}", assembly.FullName);
                _logger.LogInformation("Exception message: {0}", ex.ToString());
            }

            return types;
        }
    }
}
