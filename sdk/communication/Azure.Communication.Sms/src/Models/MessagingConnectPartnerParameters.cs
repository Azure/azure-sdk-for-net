// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// Represents partner-specific parameters for MessagingConnect that automatically supports any partner
    /// without requiring SDK changes. This class implements the serialization interface required by the SDK.
    /// </summary>
    public class MessagingConnectPartnerParameters : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly Dictionary<string, object> _parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingConnectPartnerParameters"/> class.
        /// </summary>
        /// <param name="parameters">The partner-specific parameters as key-value pairs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameters"/> is empty or contains invalid keys.</exception>
        public MessagingConnectPartnerParameters(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            _parameters = new Dictionary<string, object>();
            foreach (var parameter in parameters)
            {
                if (string.IsNullOrWhiteSpace(parameter.Key))
                {
                    throw new ArgumentException("Parameter keys cannot be null, empty, or whitespace.", nameof(parameters));
                }
                _parameters[parameter.Key] = parameter.Value;
            }

            if (_parameters.Count == 0)
            {
                throw new ArgumentException("At least one parameter must be provided.", nameof(parameters));
            }
        }

        /// <summary>
        /// Creates partner parameters from a collection of key-value tuples.
        /// This provides a clean syntax for specifying partner parameters.
        /// </summary>
        /// <param name="parameters">The partner parameters as key-value tuples.</param>
        /// <returns>A new <see cref="MessagingConnectPartnerParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameters"/> is empty or contains invalid keys.</exception>
        /// <example>
        /// <code>
        /// var parameters = PartnerParameters.Create(
        ///     ("ApiKey", "your-api-key"),
        ///     ("ServicePlanId", "your-service-plan-id"));
        /// </code>
        /// </example>
        public static MessagingConnectPartnerParameters Create(params (string Key, object Value)[] parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            var keyValuePairs = parameters.Select(p => new KeyValuePair<string, object>(p.Key, p.Value));
            return new MessagingConnectPartnerParameters(keyValuePairs);
        }

        /// <summary>
        /// Creates partner parameters from an anonymous object.
        /// This provides a convenient syntax similar to the original approach but with proper serialization support.
        /// </summary>
        /// <param name="anonymousObject">An anonymous object containing the partner parameters.</param>
        /// <returns>A new <see cref="MessagingConnectPartnerParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="anonymousObject"/> is null.</exception>
        /// <exception cref="ArgumentException">The object contains no properties.</exception>
        /// <example>
        /// <code>
        /// var parameters = PartnerParameters.FromObject(new {
        ///     ApiKey = "your-api-key",
        ///     ServicePlanId = "your-service-plan-id"
        /// });
        /// </code>
        /// </example>
        public static MessagingConnectPartnerParameters FromObject(object anonymousObject)
        {
            Argument.AssertNotNull(anonymousObject, nameof(anonymousObject));

            var properties = anonymousObject.GetType().GetProperties();
            if (properties.Length == 0)
            {
                throw new ArgumentException("The provided object must have at least one property.", nameof(anonymousObject));
            }

            var keyValuePairs = properties.Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(anonymousObject)));
            return new MessagingConnectPartnerParameters(keyValuePairs);
        }

        /// <summary>
        /// Creates partner parameters from a dictionary.
        /// </summary>
        /// <param name="dictionary">A dictionary containing the partner parameters.</param>
        /// <returns>A new <see cref="MessagingConnectPartnerParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionary"/> is empty.</exception>
        public static MessagingConnectPartnerParameters FromDictionary(IDictionary<string, object> dictionary)
        {
            Argument.AssertNotNull(dictionary, nameof(dictionary));
            return new MessagingConnectPartnerParameters(dictionary);
        }

        /// <summary>
        /// Gets the value of a parameter by key.
        /// </summary>
        /// <param name="key">The parameter key.</param>
        /// <returns>The parameter value, or null if the key is not found.</returns>
        public object GetValue(string key)
        {
            return _parameters.TryGetValue(key, out var value) ? value : null;
        }

        /// <summary>
        /// Gets the value of a parameter by key, cast to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to cast the value to.</typeparam>
        /// <param name="key">The parameter key.</param>
        /// <returns>The parameter value cast to the specified type, or the default value if the key is not found.</returns>
        public T GetValue<T>(string key)
        {
            var value = GetValue(key);
            return value is T typedValue ? typedValue : default(T);
        }

        /// <summary>
        /// Checks if a parameter with the specified key exists.
        /// </summary>
        /// <param name="key">The parameter key.</param>
        /// <returns>True if the parameter exists, false otherwise.</returns>
        public bool ContainsKey(string key)
        {
            return _parameters.ContainsKey(key);
        }

        /// <summary>
        /// Gets the number of parameters.
        /// </summary>
        public int Count => _parameters.Count;

        /// <summary>
        /// Gets an enumerable of all parameter keys.
        /// </summary>
        public IEnumerable<string> Keys => _parameters.Keys;

        /// <summary>
        /// Returns an enumerator that iterates through the partner parameters.
        /// This implementation enables serialization by the Azure SDK infrastructure.
        /// </summary>
        /// <returns>An enumerator for the partner parameters.</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the partner parameters.
        /// </summary>
        /// <returns>An enumerator for the partner parameters.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a string representation of the partner parameters for debugging.
        /// </summary>
        /// <returns>A string containing all parameter keys (values are omitted for security).</returns>
        public override string ToString()
        {
            return $"PartnerParameters[{string.Join(", ", _parameters.Keys)}]";
        }
    }
}
