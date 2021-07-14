// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
    public sealed class ArmClientOptions : ClientOptions
    {
        private readonly ConcurrentDictionary<Type, object> _overrides = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Gets the ApiVersions object
        /// </summary>
        public ApiVersions ApiVersions { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClientOptions"/> class.
        /// </summary>
        public ArmClientOptions()
        {
            ApiVersions = new ApiVersions(this);
        }

        /// <summary>
        /// Gets override object.
        /// </summary>
        /// <typeparam name="T"> The type of the underlying model this class wraps. </typeparam>
        /// <param name="objectConstructor"> A function used to construct a new object if none was found. </param>
        /// <returns> The override object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object GetOverrideObject<T>(Func<object> objectConstructor)
        {
            if (objectConstructor is null)
                throw new ArgumentNullException(nameof(objectConstructor));

            return _overrides.GetOrAdd(typeof(T), objectConstructor());
        }

        internal ArmClientOptions Clone()
        {
            ArmClientOptions copy = new ArmClientOptions();

            copy.ApiVersions = ApiVersions.Clone();
            copy.Transport = Transport;
            return copy;
        }
    }
}
