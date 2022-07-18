// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace Azure.Messaging.ServiceBus.Core
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
        ///  The client library information, formatted in the standard form used by SDK
        ///  user agents when interacting with Azure services.
        /// </summary>
        ///
        [Description("user-agent")]
        public string UserAgent => $"azsdk-net-{ Product }/{ Version } ({ Framework }; { Platform })";

        /// <summary>
        ///   Client Information properties serialized with normalized names
        /// </summary>
        ///
        public KeyValuePair<string, string>[] SerializedProperties { get; }

        /// <summary>
        ///   Prevents a default instance of the <see cref="ClientLibraryInformation"/> class from being created.
        /// </summary>
        ///
        private ClientLibraryInformation()
        {
            Assembly assembly = typeof(ClientLibraryInformation).Assembly;

            Product = $"{ nameof(Messaging) }.{ nameof(ServiceBus) }";
            Version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            Framework = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

#if FullNetFx
            Platform = Environment.OSVersion.VersionString;
#else
            Platform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#endif
            SerializedProperties = SerializeProperties(this);
        }

        /// <summary>
        ///   Enumerates the client library properties, normalizing the property names.
        /// </summary>
        ///
        /// <returns>An enumerable set of the properties, with name and value.</returns>
        ///
        private static KeyValuePair<string, string>[] SerializeProperties(ClientLibraryInformation self) =>
            typeof(ClientLibraryInformation)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(static property => property.Name != nameof(SerializedProperties))
                .Select(property => new KeyValuePair<string, string>(GetTelemetryName(property), (string)property.GetValue(self, null)))
                .ToArray();

        /// <summary>
        ///   Gets the name of the property, as it should appear in telemetry
        ///   information.
        /// </summary>
        ///
        /// <param name="property">The property to consider.</param>
        ///
        /// <returns>The name of the property for use as telemetry for the client library.</returns>
        ///
        private static string GetTelemetryName(MemberInfo property)
        {
            string name = property.GetCustomAttribute<DescriptionAttribute>(false)?.Description;
            return (string.IsNullOrEmpty(name) ? property.Name : name).ToLowerInvariant();
        }
    }
}
