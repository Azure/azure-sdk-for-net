// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;

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

            CopyPolicies(this, newOptions);

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

        private static void CopyPolicies(ClientOptions source, ClientOptions dest)
        {
            var perCallPoliciesProperty = source.GetType().GetProperty("PerCallPolicies", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            var perCallPolicies = perCallPoliciesProperty.GetValue(source) as IList<HttpPipelinePolicy>;

            foreach (var policy in perCallPolicies)
            {
                dest.AddPolicy(policy, HttpPipelinePosition.PerCall);
            }

            var perRetryPoliciesProperty = source.GetType().GetProperty("PerRetryPolicies", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            var perRetryPolicies = perRetryPoliciesProperty.GetValue(source) as IList<HttpPipelinePolicy>;

            foreach (var policy in perRetryPolicies)
            {
                dest.AddPolicy(policy, HttpPipelinePosition.PerRetry);
            }
        }

        internal ArmClientOptions Clone()
        {
            ArmClientOptions copy = new ArmClientOptions(DefaultLocation);

            CopyPolicies(this, copy);

            copy.ApiVersions = ApiVersions.Clone();
            copy.Transport = Transport;
            return copy;
        }
    }
}
