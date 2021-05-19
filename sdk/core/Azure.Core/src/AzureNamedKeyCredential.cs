// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Credential allowing a named key to be used for authenticating to an Azure Service.
    /// It provides the ability to update the key without creating a new client.
    /// </summary>
    public class AzureNamedKeyCredential
    {
        private Tuple<string, string> _namedKey;

        /// <summary>
        /// Name of the key used to authenticate to an Azure service.
        /// </summary>
        public string Name => Volatile.Read(ref _namedKey).Item1;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureNamedKeyCredential"/> class.
        /// </summary>
        /// <param name="name">The name of the <paramref name="key"/>.</param>
        /// <param name="key">The key to use for authenticating with the Azure service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="name"/> or <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="name"/> or <paramref name="key"/> is empty.
        /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public AzureNamedKeyCredential(string name, string key) => Update(name, key);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Updates the named key.  This is intended to be used when you've regenerated your
        /// service key and want to update long-lived clients.
        /// </summary>
        /// <param name="name">The name of the <paramref name="key"/>.</param>
        /// <param name="key">The key to use for authenticating with the Azure service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="name"/> or <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="name"/> or <paramref name="key"/> is empty.
        /// </exception>
        public void Update(string name, string key)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            Volatile.Write(ref _namedKey, Tuple.Create(name, key));
        }

        /// <summary>
        /// Allows deconstruction of the credential into the associated name and key as an atomic operation.
        /// </summary>
        /// <param name="name">The name of the <paramref name="key"/>.</param>
        /// <param name="key">The key to use for authenticating with the Azure service.</param>
        /// <example>
        /// <code snippet="Snippet:AzureNamedKeyCredential_Deconstruct">
        /// var credential = new AzureNamedKeyCredential(&quot;SomeName&quot;, &quot;SomeKey&quot;);
        /// (string name, string key) = credential;
        /// </code>
        /// </example>
        /// <seealso href="https://docs.microsoft.com/dotnet/csharp/deconstruct">Deconstructing tuples and other types</seealso>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out string name, out string key)
        {
            var namedKey = Volatile.Read(ref _namedKey);

            name = namedKey.Item1;
            key = namedKey.Item2;
        }
    }
}
