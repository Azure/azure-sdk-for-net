//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.WindowsAzure.Common.Properties;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// Provides the entry point to the retry functionality.
    /// </summary>
    public class RetryManager
    {
        private static RetryManager _defaultRetryManager;

        private readonly IDictionary<string, RetryStrategy> _retryStrategies;
        private string _defaultRetryStrategyName;
        private readonly IDictionary<string, string> _defaultRetryStrategyNamesMap;
        private readonly IDictionary<string, RetryStrategy> _defaultRetryStrategiesMap;
        private RetryStrategy _defaultStrategy;

        /// <summary>
        /// Sets the specified retry manager as the default retry manager.
        /// </summary>
        /// <param name="retryManager">The retry manager.</param>
        /// <param name="throwIfSet">true to throw an exception if the manager is already set; otherwise, false. Defaults to <see langword="true"/>.</param>
        /// <exception cref="InvalidOperationException">The singleton is already set and <paramref name="throwIfSet"/> is true.</exception>
        public static void SetDefault(RetryManager retryManager, bool throwIfSet = true)
        {
            if (_defaultRetryManager != null && throwIfSet && retryManager != _defaultRetryManager)
            {
                throw new InvalidOperationException(Resources.ExceptionRetryManagerAlreadySet);
            }

            _defaultRetryManager = retryManager;
        }

        /// <summary>
        /// Gets the default <see cref="RetryManager"/> for the application.
        /// </summary>
        /// <remarks>You can update the default retry manager by calling the <see cref="RetryManager.SetDefault"/> method.</remarks>
        public static RetryManager Instance
        {
            get
            {
                var instance = _defaultRetryManager;
                if (instance == null)
                {
                    throw new InvalidOperationException(Resources.ExceptionRetryManagerNotSet);
                }

                return instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies)
            : this(retryStrategies, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class with the specified retry strategies and default retry strategy name.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        /// <param name="defaultRetryStrategyName">The default retry strategy.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies, string defaultRetryStrategyName)
            : this(retryStrategies, defaultRetryStrategyName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class with the specified retry strategies and defaults.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        /// <param name="defaultRetryStrategyName">The default retry strategy.</param>
        /// <param name="defaultRetryStrategyNamesMap">The names of the default strategies for different technologies.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies, string defaultRetryStrategyName, IDictionary<string, string> defaultRetryStrategyNamesMap)
        {
            this._retryStrategies = retryStrategies.ToDictionary(p => p.Name);
            this._defaultRetryStrategyNamesMap = defaultRetryStrategyNamesMap;
            this.DefaultRetryStrategyName = defaultRetryStrategyName;

            this._defaultRetryStrategiesMap = new Dictionary<string, RetryStrategy>();
            if (this._defaultRetryStrategyNamesMap != null)
            {
                foreach (var map in this._defaultRetryStrategyNamesMap.Where(x => !string.IsNullOrWhiteSpace(x.Value)))
                {
                    RetryStrategy strategy;
                    if (!this._retryStrategies.TryGetValue(map.Value, out strategy))
                    {
                        throw new ArgumentOutOfRangeException(
                            "defaultRetryStrategyNamesMap",
                            string.Format(CultureInfo.CurrentCulture, Resources.DefaultRetryStrategyMappingNotFound, map.Key, map.Value));
                    }

                    this._defaultRetryStrategiesMap.Add(map.Key, strategy);
                }
            }
        }

        /// <summary>
        /// Gets or sets the default retry strategy name.
        /// </summary>
        public string DefaultRetryStrategyName
        {
            get { return this._defaultRetryStrategyName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    RetryStrategy strategy;
                    if (this._retryStrategies.TryGetValue(value, out strategy))
                    {
                        this._defaultRetryStrategyName = value;
                        this._defaultStrategy = strategy;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture, Resources.RetryStrategyNotFound, value));
                    }
                }
                else
                {
                    this._defaultRetryStrategyName = null;
                }
            }
        }

        /// <summary>
        /// Returns a retry policy with the specified error detection strategy and the default retry strategy defined in the configuration. 
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> interface that is responsible for detecting transient conditions.</typeparam>
        /// <returns>A new retry policy with the specified error detection strategy and the default retry strategy defined in the configuration.</returns>
        public virtual RetryPolicy<T> GetRetryPolicy<T>()
            where T : ITransientErrorDetectionStrategy, new()
        {
            return new RetryPolicy<T>(this.GetRetryStrategy());
        }

        /// <summary>
        /// Returns a retry policy with the specified error detection strategy and retry strategy.
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> interface that is responsible for detecting transient conditions.</typeparam>
        /// <param name="retryStrategyName">The retry strategy name, as defined in the configuration.</param>
        /// <returns>A new retry policy with the specified error detection strategy and the default retry strategy defined in the configuration.</returns>
        public virtual RetryPolicy<T> GetRetryPolicy<T>(string retryStrategyName)
            where T : ITransientErrorDetectionStrategy, new()
        {
            return new RetryPolicy<T>(this.GetRetryStrategy(retryStrategyName));
        }

        /// <summary>
        /// Returns the default retry strategy defined in the configuration.
        /// </summary>
        /// <returns>The retry strategy that matches the default strategy.</returns>
        public virtual RetryStrategy GetRetryStrategy()
        {
            return this._defaultStrategy;
        }

        /// <summary>
        /// Returns the retry strategy that matches the specified name.
        /// </summary>
        /// <param name="retryStrategyName">The retry strategy name.</param>
        /// <returns>The retry strategy that matches the specified name.</returns>
        public virtual RetryStrategy GetRetryStrategy(string retryStrategyName)
        {
            Guard.ArgumentNotNullOrEmptyString(retryStrategyName, "retryStrategyName");

            RetryStrategy retryStrategy;
            if (!this._retryStrategies.TryGetValue(retryStrategyName, out retryStrategy))
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.RetryStrategyNotFound, retryStrategyName));
            }

            return retryStrategy;
        }

        /// <summary>
        /// Returns the retry strategy for the specified technology.
        /// </summary>
        /// <param name="technology">The techonolgy to get the default retry strategy for.</param>
        /// <returns>The retry strategy for the specified technology.</returns>
        public virtual RetryStrategy GetDefaultRetryStrategy(string technology)
        {
            Guard.ArgumentNotNullOrEmptyString(technology, "techonology");

            RetryStrategy retryStrategy;
            if (!this._defaultRetryStrategiesMap.TryGetValue(technology, out retryStrategy))
            {
                retryStrategy = this._defaultStrategy;
            }

            if (retryStrategy == null)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.DefaultRetryStrategyNotFound, technology));
            }

            return retryStrategy;
        }
    }
}
