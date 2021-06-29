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
            : this(LocationData.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClientOptions"/> class.
        /// </summary>
        /// <param name="defaultLocation"> The default location to use if can't be inherited from parent. </param>
        public ArmClientOptions(LocationData defaultLocation)
        {
            if (defaultLocation is null)
                throw new ArgumentNullException(nameof(defaultLocation));

            DefaultLocation = defaultLocation;
            ApiVersions = new ApiVersions(this);
        }

        /// <summary>
        /// Gets the default location to use if can't be inherited from parent.
        /// </summary>
        public LocationData DefaultLocation { get; }

        /// <summary>
        /// Converts client options.
        /// </summary>
        /// <typeparam name="T"> The type of the underlying model this class wraps. </typeparam>
        /// <returns> The converted client options. </returns>
        public T Convert<T>()
            where T : ClientOptions, new()
        {
            var newOptions = new T();
            newOptions.Transport = Transport;

            return newOptions;
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
            ArmClientOptions copy = new ArmClientOptions(DefaultLocation);

            copy.ApiVersions = ApiVersions.Clone();
            copy.Transport = Transport;
            return copy;
        }
    }
}
