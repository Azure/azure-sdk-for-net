// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Properties;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Provides the entry point to the retry functionality.
    /// </summary>
    public class RetryManager
    {
        private static RetryManager _defaultRetryManager;
        private readonly IDictionary<string, RetryStrategy> _defaultRetryStrategiesMap;
        private readonly IDictionary<string, RetryStrategy> _retryStrategies;
        private string _defaultRetryStrategyName;
        private RetryStrategy _defaultStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies)
            : this(retryStrategies, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class with the specified retry 
        /// strategies and default retry strategy name.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        /// <param name="defaultRetryStrategyName">The default retry strategy.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies, string defaultRetryStrategyName)
            : this(retryStrategies, defaultRetryStrategyName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryManager"/> class with the specified retry 
        /// strategies and defaults.
        /// </summary>
        /// <param name="retryStrategies">The complete set of retry strategies.</param>
        /// <param name="defaultRetryStrategyName">The default retry strategy.</param>
        /// <param name="defaultRetryStrategyNamesMap">The names of the default strategies for different technologies.</param>
        public RetryManager(IEnumerable<RetryStrategy> retryStrategies, string defaultRetryStrategyName,
            IDictionary<string, string> defaultRetryStrategyNamesMap)
        {
            _retryStrategies = retryStrategies.ToDictionary(p => p.Name);
            DefaultRetryStrategyName = defaultRetryStrategyName;

            _defaultRetryStrategiesMap = new Dictionary<string, RetryStrategy>();
            if (defaultRetryStrategyNamesMap != null)
            {
                foreach (var map in defaultRetryStrategyNamesMap.Where(x => !string.IsNullOrWhiteSpace(x.Value)))
                {
                    RetryStrategy strategy;
                    if (!_retryStrategies.TryGetValue(map.Value, out strategy))
                    {
                        throw new ArgumentOutOfRangeException(
                            "defaultRetryStrategyNamesMap",
                            string.Format(CultureInfo.CurrentCulture, Resources.DefaultRetryStrategyMappingNotFound,
                                map.Key, map.Value));
                    }

                    _defaultRetryStrategiesMap.Add(map.Key, strategy);
                }
            }
        }

        /// <summary>
        /// Gets the default <see cref="RetryManager"/> for the application.
        /// </summary>
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
        /// Gets or sets the default retry strategy name.
        /// </summary>
        public string DefaultRetryStrategyName
        {
            get { return _defaultRetryStrategyName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    RetryStrategy strategy;
                    if (_retryStrategies.TryGetValue(value, out strategy))
                    {
                        _defaultRetryStrategyName = value;
                        _defaultStrategy = strategy;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture,
                            Resources.RetryStrategyNotFound, value));
                    }
                }
                else
                {
                    _defaultRetryStrategyName = null;
                }
            }
        }

        /// <summary>
        /// Sets the specified retry manager as the default retry manager.
        /// Will throw an exception if the manager is already set.
        /// </summary>
        /// <param name="retryManager">The retry manager.</param>
        public static void SetDefault(RetryManager retryManager)
        {
            SetDefault(retryManager, true);
        }

        /// <summary>
        /// Sets the specified retry manager as the default retry manager.
        /// </summary>
        /// <param name="retryManager">The retry manager.</param>
        /// <param name="throwIfSet">true to throw an exception if the manager is already set; otherwise, false.</param>
        public static void SetDefault(RetryManager retryManager, bool throwIfSet)
        {
            if (_defaultRetryManager != null && throwIfSet && retryManager != _defaultRetryManager)
            {
                throw new InvalidOperationException(Resources.ExceptionRetryManagerAlreadySet);
            }

            _defaultRetryManager = retryManager;
        }


        /// <summary>
        /// Returns a retry policy with the specified error detection strategy and the default retry strategy 
        /// defined in the configuration. 
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> 
        /// interface that is responsible for detecting transient conditions.</typeparam>
        /// <returns>A new retry policy with the specified error detection strategy and the default retry 
        /// strategy defined in the configuration.</returns>
        public virtual RetryPolicy<T> GetRetryPolicy<T>()
            where T : ITransientErrorDetectionStrategy, new()
        {
            return new RetryPolicy<T>(GetRetryStrategy());
        }

        /// <summary>
        /// Returns a retry policy with the specified error detection strategy and retry strategy.
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> 
        /// interface that is responsible for detecting transient conditions.</typeparam>
        /// <param name="retryStrategyName">The retry strategy name, as defined in the configuration.</param>
        /// <returns>A new retry policy with the specified error detection strategy and the default retry 
        /// strategy defined in the configuration.</returns>
        public virtual RetryPolicy<T> GetRetryPolicy<T>(string retryStrategyName)
            where T : ITransientErrorDetectionStrategy, new()
        {
            return new RetryPolicy<T>(GetRetryStrategy(retryStrategyName));
        }

        /// <summary>
        /// Returns the default retry strategy defined in the configuration.
        /// </summary>
        /// <returns>The retry strategy that matches the default strategy.</returns>
        public virtual RetryStrategy GetRetryStrategy()
        {
            return _defaultStrategy;
        }

        /// <summary>
        /// Returns the retry strategy that matches the specified name.
        /// </summary>
        /// <param name="retryStrategyName">The retry strategy name.</param>
        /// <returns>The retry strategy that matches the specified name.</returns>
        public virtual RetryStrategy GetRetryStrategy(string retryStrategyName)
        {
            if (string.IsNullOrEmpty(retryStrategyName))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeEmpty,
                    "retryStrategyName"));
            }

            RetryStrategy retryStrategy;
            if (!_retryStrategies.TryGetValue(retryStrategyName, out retryStrategy))
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture,
                    Resources.RetryStrategyNotFound, retryStrategyName));
            }

            return retryStrategy;
        }

        /// <summary>
        /// Returns the retry strategy for the specified technology.
        /// </summary>
        /// <param name="technology">The technology to get the default retry strategy for.</param>
        /// <returns>The retry strategy for the specified technology.</returns>
        public virtual RetryStrategy GetDefaultRetryStrategy(string technology)
        {
            if (string.IsNullOrEmpty(technology))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.StringCannotBeEmpty,
                    "technology"));
            }


            RetryStrategy retryStrategy;
            if (!_defaultRetryStrategiesMap.TryGetValue(technology, out retryStrategy))
            {
                retryStrategy = _defaultStrategy;
            }

            if (retryStrategy == null)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture,
                    Resources.DefaultRetryStrategyNotFound, technology));
            }

            return retryStrategy;
        }
    }
}