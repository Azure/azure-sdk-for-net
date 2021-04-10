// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;

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
            : this(LocationData.Default, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClientOptions"/> class.
        /// </summary>
        /// <param name="defaultLocation"> The default location to use if can't be inherited from parent. </param>
        public ArmClientOptions(LocationData defaultLocation)
            : this(defaultLocation, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmClientOptions"/> class.
        /// </summary>
        /// <param name="defaultLocation"> The default location to use if can't be inherited from parent. </param>
        /// <param name="other"> The client parameters to use in these operations. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="LocationData"/> is null. </exception>
        internal ArmClientOptions(LocationData defaultLocation, ArmClientOptions other = null)
        {
            if (defaultLocation is null)
                throw new ArgumentNullException(nameof(defaultLocation));

            // Will go away when moved into core since we will have directly access the policies and transport, so just need to set those
            if (!ReferenceEquals(other, null))
                Copy(other);
            DefaultLocation = defaultLocation;
            ApiVersions = new ApiVersions(this);
        }

        private ArmClientOptions(LocationData location, IList<HttpPipelinePolicy> perCallPolicies, IList<HttpPipelinePolicy> perRetryPolicies)
        {
            if (location is null)
                throw new ArgumentNullException(nameof(location));

            DefaultLocation = location;
            PerCallPolicies = new List<HttpPipelinePolicy>();
            foreach (var call in perCallPolicies)
            {
                PerCallPolicies.Add(call);
            }
            PerRetryPolicies = new List<HttpPipelinePolicy>();
            foreach (var retry in perRetryPolicies)
            {
                PerCallPolicies.Add(retry);
            }
            ApiVersions = new ApiVersions(this);
        }

        /// <summary>
        /// Gets the default location to use if can't be inherited from parent.
        /// </summary>
        public LocationData DefaultLocation { get; }

        /// <summary>
        /// Gets each http call policies.
        /// </summary>
        /// <returns> A collection of http pipeline policy that may take multiple service requests to iterate over. </returns>
        internal IList<HttpPipelinePolicy> PerCallPolicies { get; } = new List<HttpPipelinePolicy>();

        /// <summary>
        /// Gets each http retry call policies.
        /// </summary>
        /// <returns> A collection of http pipeline policy that may take multiple service requests to iterate over. </returns>
        internal IList<HttpPipelinePolicy> PerRetryPolicies { get; } = new List<HttpPipelinePolicy>();

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
            foreach (var pol in PerCallPolicies)
            {
                newOptions.AddPolicy(pol, HttpPipelinePosition.PerCall);
            }

            foreach (var pol in PerRetryPolicies)
            {
                newOptions.AddPolicy(pol, HttpPipelinePosition.PerRetry);
            }

            return newOptions;
        }

        /// <summary>
        /// Adds a policy for Azure resource manager client http call.
        /// </summary>
        /// <param name="policy"> The http call policy in the pipeline. </param>
        /// <param name="position"> The position of the http call policy in the pipeline. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="HttpPipelinePolicy"/> is null. </exception>
        public new void AddPolicy(HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            if (policy is null)
                throw new ArgumentNullException(nameof(policy));

            // TODO policy lists are internal hence we don't have access to them by inheriting ClientOptions in this Assembly, this is a wrapper for now to convert to the concrete
            // policy options.
            switch (position)
            {
                case HttpPipelinePosition.PerCall:
                    PerCallPolicies.Add(policy);
                    break;
                case HttpPipelinePosition.PerRetry:
                    PerRetryPolicies.Add(policy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }

            base.AddPolicy(policy, position);
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

        // Will be removed like AddPolicy when we move to azure core
        private void Copy(ArmClientOptions other)
        {
            Transport = other.Transport;
            foreach (var pol in other.PerCallPolicies)
            {
                AddPolicy(pol, HttpPipelinePosition.PerCall);
            }

            foreach (var pol in other.PerRetryPolicies)
            {
                AddPolicy(pol, HttpPipelinePosition.PerRetry);
            }
        }

        internal ArmClientOptions Clone()
        {
            ArmClientOptions copy = new ArmClientOptions(DefaultLocation, PerCallPolicies, PerRetryPolicies);
            copy.ApiVersions = ApiVersions.Clone();
            copy.Transport = Transport;
            return copy;
        }
    }
}
