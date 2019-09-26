// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of information describing the active version of the
    ///   client library.
    /// </summary>
    ///
    internal sealed class ClientLibraryInformation
    {
        /// <summary>
        ///   The current set of information.
        /// </summary>
        ///
        public static ClientLibraryInformation Current { get; } = new ClientLibraryInformation();

        /// <summary>
        ///   The name of the client library product.
        ///  </summary>
        ///
        public string Product { get; }

        /// <summary>
        ///   The version of the client library.
        /// </summary>
        ///
        public string Version { get; }

        /// <summary>
        ///   The version of the framework on which the client library was
        ///   built.
        /// </summary>
        ///
        public string Framework { get; }

        /// <summary>
        ///  The name of the platform on which the client library is currently running.
        /// </summary>
        ///
        public string Platform { get; }

        /// <summary>
        ///   Prevents a default instance of the <see cref="ClientLibraryInformation"/> class from being created.
        /// </summary>
        ///
        private ClientLibraryInformation()
        {
            Assembly assembly = typeof(ClientLibraryInformation).Assembly;

            Product = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            Version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            Framework = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

#if FullNetFx
            Platform = Environment.OSVersion.VersionString;
#else
            Platform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#endif
        }

        /// <summary>
        ///   Enumerates the client library properties, normalizing the property names.
        /// </summary>
        ///
        /// <returns>An enumerable set of the properties, with name and value.</returns>
        ///
        public IEnumerable<KeyValuePair<string, string>> EnumerateProperties() =>
            typeof(ClientLibraryInformation)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(property => new KeyValuePair<string, string>(property.Name.ToLower(CultureInfo.InvariantCulture), (string)property.GetValue(this, null)));

    }
}
