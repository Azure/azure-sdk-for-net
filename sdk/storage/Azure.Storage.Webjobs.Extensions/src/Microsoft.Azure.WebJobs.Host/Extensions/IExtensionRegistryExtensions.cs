// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Provides extension methods for <see cref="IExtensionRegistry"/>./>
    /// </summary>
    public static class IExtensionRegistryExtensions
    {
        private static readonly Type[] ExtensionTypes = new Type[]
            {
                typeof(ITriggerBindingProvider), 
                typeof(IBindingProvider), 
                typeof(IExtensionConfigProvider), 
                typeof(IArgumentBindingProvider<>)
            };

        /// <summary>
        /// Register a set of binding rules for a given type. The rules are applied in order, first one wins.  
        /// An catch-all error binding is automatically placed at the end that will raise a binding error if no binder claims it. 
        /// </summary>
        /// <param name="registry">The registry instance.</param>
        /// <param name="bindingProviders">binding rules for a parameter.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void RegisterBindingRules<TAttribute>(this IExtensionRegistry registry, params IBindingProvider[] bindingProviders)
            where TAttribute : Attribute
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            var all = new GenericCompositeBindingProvider<TAttribute>(bindingProviders);
            registry.RegisterExtension<IBindingProvider>(all);
        }

        /// <summary>
        /// Register a set of binding rules for a given type. The rules are applied in order, first one wins.  
        /// An catch-all error binding is automatically placed at the end that will raise a binding error if no binder claims it. 
        /// </summary>
        /// <param name="registry">The registry instance.</param>
        /// <param name="validator">Validator function to be called at indexing time for catching upfront errors. </param>
        /// <param name="nameResolver">NameResolver to pass to validator.</param>
        /// <param name="bindingProviders">binding rules for a parameter.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void RegisterBindingRules<TAttribute>(
            this IExtensionRegistry registry, 
            Action<TAttribute, Type> validator,
            IConfiguration configuration,
            INameResolver nameResolver, 
            params IBindingProvider[] bindingProviders)
            where TAttribute : Attribute
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            var all = new GenericCompositeBindingProvider<TAttribute>(validator, configuration, nameResolver, bindingProviders);
            registry.RegisterExtension<IBindingProvider>(all);
        }

        /// <summary>
        /// Registers the specified instance. 
        /// </summary>
        /// <typeparam name="TExtension">The service type to register the instance for.</typeparam>
        /// <param name="registry">The registry instance.</param>
        /// <param name="extension">The instance to register.</param>
        public static void RegisterExtension<TExtension>(this IExtensionRegistry registry, TExtension extension)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            registry.RegisterExtension(typeof(TExtension), extension);
        }

        /// <summary>
        /// Returns the collection of extension instances registered for the specified type.
        /// </summary>
        /// <typeparam name="TExtension">The service type to get extensions for.</typeparam>
        /// <param name="registry">The registry instance.</param>
        /// <returns>The collection of extension instances.</returns>
        public static IEnumerable<TExtension> GetExtensions<TExtension>(this IExtensionRegistry registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            return registry.GetExtensions(typeof(TExtension)).Cast<TExtension>();
        }

        /// <summary>
        /// Returns the collection of all registered <see cref="IFunctionFilter"/> types
        /// or subtypes.
        /// </summary>
        /// <param name="registry">The registry instance.</param>
        /// <returns>The collection of filters.</returns>
        internal static IEnumerable<IFunctionFilter> GetFunctionFilters(this IExtensionRegistry registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            // form a list of all filters of the specified type (including subclasses)
            var filters = new List<IFunctionFilter>(registry.GetExtensions<IFunctionInvocationFilter>());
            filters.AddRange(registry.GetExtensions<IFunctionExceptionFilter>());

            return filters.Distinct();
        }

        /// <summary>
        /// Returns the set of assemblies that have registered extensions.
        /// </summary>
        /// <param name="registry">The registry instance.</param>
        /// <returns>The unique set of assemblies.</returns>
        internal static IEnumerable<Assembly> GetExtensionAssemblies(this IExtensionRegistry registry)
        {
            HashSet<Assembly> assemblies = new HashSet<Assembly>();
            foreach (Type extensionType in ExtensionTypes)
            {
                var currAssemblies = registry.GetExtensions(extensionType).Select(p => p.GetType().Assembly);
                assemblies.UnionWith(currAssemblies);
            }

            return assemblies;
        }
    }
}
