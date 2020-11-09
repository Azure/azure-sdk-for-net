﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   The set of properties that comprise a Service Bus connection string.
    /// </summary>
    ///
    public class ServiceBusConnectionStringProperties
    {
        /// <summary>The character used to separate a token and its value in the connection string.</summary>
        private const char TokenValueSeparator = '=';

        /// <summary>The character used to mark the beginning of a new token/value pair in the connection string.</summary>
        private const char TokenValuePairDelimiter = ';';

        /// <summary>The name of the protocol used by an Service Bus endpoint. </summary>
        private const string ServiceBusEndpointSchemeName = "sb";

        /// <summary>The token that identifies the endpoint address for the Service Bus namespace.</summary>
        private const string EndpointToken = "Endpoint";

        /// <summary>The token that identifies the name of a specific Service Bus entity under the namespace.</summary>
        private const string EntityPathToken = "EntityPath";

        /// <summary>The token that identifies the name of a shared access key.</summary>
        private const string SharedAccessKeyNameToken = "SharedAccessKeyName";

        /// <summary>The token that identifies the value of a shared access key.</summary>
        private const string SharedAccessKeyValueToken = "SharedAccessKey";

        /// <summary>The token that identifies the value of a shared access signature.</summary>
        private const string SharedAccessSignatureToken = "SharedAccessSignature";

        /// <summary>The formatted protocol used by an Service Bus endpoint. </summary>
        private static readonly string ServiceBusEndpointScheme = $"{ ServiceBusEndpointSchemeName }{ Uri.SchemeDelimiter }";

        /// <summary>
        ///   The fully qualified Service Bus namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        /// <value>The namespace of the Service Bus, as derived from the endpoint address of the connection string.</value>
        ///
        public string FullyQualifiedNamespace => Endpoint?.Host;

        /// <summary>
        ///   The endpoint to be used for connecting to the Service Bus namespace.
        /// </summary>
        ///
        /// <value>The endpoint address, including protocol, from the connection string.</value>
        ///
        public Uri Endpoint { get; internal set; }

        /// <summary>
        ///   The name of the specific Service Bus entity instance under the associated Service Bus namespace.
        /// </summary>
        ///
        public string EntityPath { get; internal set; }

        /// <summary>
        ///   The name of the shared access key, either for the Service Bus namespace
        ///   or the Service Bus entity.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; internal set; }

        /// <summary>
        ///   The value of the shared access key, either for the Service Bus namespace
        ///   or the Service Bus entity.
        /// </summary>
        ///
        public string SharedAccessKey { get; internal set; }

        /// <summary>
        ///   The value of the fully-formed shared access signature, either for the Service Bus
        ///   namespace or the Service Bus entity.
        /// </summary>
        ///
        public string SharedAccessSignature { get; internal set; }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Creates an Service Bus connection string based on this set of <see cref="ServiceBusConnectionStringProperties" />.
        /// </summary>
        ///
        /// <returns>
        ///   A valid Service Bus connection string; depending on the specified property information, this may
        ///   represent the namespace-level or Event Hub-level.
        /// </returns>
        ///
        ///
        internal string ToConnectionString()
        {
            // Ensure that there was an endpoint specified and, if so, that it
            // either is in the correct format or can be safely coerced.

            if (Endpoint == null)
            {
                throw new ArgumentException(Resources.MissingConnectionInformation);
            }

            var endpointBuilder = new UriBuilder(Endpoint)
            {
                Scheme = ServiceBusEndpointScheme,
                Port = -1
            };

            if ((string.Compare(endpointBuilder.Scheme, ServiceBusEndpointSchemeName, StringComparison.OrdinalIgnoreCase) != 0)
                || (Uri.CheckHostName(endpointBuilder.Host) == UriHostNameType.Unknown))
            {
                throw new ArgumentException(Resources.InvalidEndpointAddress);
            }

            // The connection string may contain a precomputed shared access signature OR a shared key name and value,
            // but not both.

            if ((!string.IsNullOrEmpty(SharedAccessSignature))
                && ((!string.IsNullOrEmpty(SharedAccessKeyName)) || (!string.IsNullOrEmpty(SharedAccessKey))))
            {
                throw new ArgumentException(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified);
            }

            // Ensure that each of the needed components are present for connecting.

            var hasSharedKey = ((!string.IsNullOrEmpty(SharedAccessKeyName)) && (!string.IsNullOrEmpty(SharedAccessKey)));
            var hasSharedSignature = (!string.IsNullOrEmpty(SharedAccessSignature));

            if (string.IsNullOrEmpty(Endpoint?.Host)
                || ((!hasSharedKey) && (!hasSharedSignature)))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation);
            }

            var builder = new StringBuilder()
                .Append(EndpointToken)
                .Append(TokenValueSeparator)
                .Append(endpointBuilder.Uri.AbsoluteUri)
                .Append(TokenValuePairDelimiter);

            if (!string.IsNullOrEmpty(EntityPath))
            {
                builder
                  .Append(EntityPathToken)
                  .Append(TokenValueSeparator)
                  .Append(EntityPath)
                  .Append(TokenValuePairDelimiter);
            }

            if (!string.IsNullOrEmpty(SharedAccessSignature))
            {
                builder
                    .Append(SharedAccessSignatureToken)
                    .Append(TokenValueSeparator)
                    .Append(SharedAccessSignature)
                    .Append(TokenValuePairDelimiter);
            }
            else
            {
                builder
                    .Append(SharedAccessKeyNameToken)
                    .Append(TokenValueSeparator)
                    .Append(SharedAccessKeyName)
                    .Append(TokenValuePairDelimiter)
                    .Append(SharedAccessKeyValueToken)
                    .Append(TokenValueSeparator)
                    .Append(SharedAccessKey)
                    .Append(TokenValuePairDelimiter);
            }

            return builder.ToString();
        }

        /// <summary>
        ///   Parses the specified Service Bus connection string into its component properties.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>The component properties parsed from the connection string.</returns>
        ///
        /// <exception cref="FormatException">The specified connection string was malformed and could not be parsed.</exception>
        ///
        public static ServiceBusConnectionStringProperties Parse(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            var parsedValues = new ServiceBusConnectionStringProperties();
            var tokenPositionModifier = (connectionString[0] == TokenValuePairDelimiter) ? 0 : 1;
            var lastPosition = 0;
            var currentPosition = 0;

            int valueStart;
            string slice;
            string token;
            string value;

            while (currentPosition != -1)
            {
                // Slice the string into the next token/value pair.

                currentPosition = connectionString.IndexOf(TokenValuePairDelimiter, lastPosition + 1);

                if (currentPosition >= 0)
                {
                    slice = connectionString.Substring(lastPosition, (currentPosition - lastPosition));
                }
                else
                {
                    slice = connectionString.Substring(lastPosition);
                }

                // Break the token and value apart, if this is a legal pair.

                valueStart = slice.IndexOf(TokenValueSeparator);

                if (valueStart >= 0)
                {
                    token = slice.Substring((1 - tokenPositionModifier), (valueStart - 1 + tokenPositionModifier));
                    value = slice.Substring(valueStart + 1);

                    // Guard against leading and trailing spaces, only trimming if there is a need.

                    if ((!string.IsNullOrEmpty(token)) && (char.IsWhiteSpace(token[0])) || char.IsWhiteSpace(token[token.Length - 1]))
                    {
                        token = token.Trim();
                    }

                    if ((!string.IsNullOrEmpty(value)) && (char.IsWhiteSpace(value[0]) || char.IsWhiteSpace(value[value.Length - 1])))
                    {
                        value = value.Trim();
                    }

                    // If there was no value for a key, then consider the connection string to
                    // be malformed.

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new FormatException(Resources.InvalidConnectionString);
                    }

                    // Compare the token against the known connection string properties and capture the
                    // pair if they are a known attribute.

                    if (string.Compare(EndpointToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        var endpointBuilder = new UriBuilder(value)
                        {
                            Scheme = ServiceBusEndpointScheme,
                            Port = -1
                        };

                        if ((string.Compare(endpointBuilder.Scheme, ServiceBusEndpointSchemeName, StringComparison.OrdinalIgnoreCase) != 0)
                            || (Uri.CheckHostName(endpointBuilder.Host) == UriHostNameType.Unknown))
                        {
                            throw new FormatException(Resources.InvalidConnectionString);
                        }

                        parsedValues.Endpoint = endpointBuilder.Uri;
                    }
                    else if (string.Compare(EntityPathToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.EntityPath = value;
                    }
                    else if (string.Compare(SharedAccessKeyNameToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.SharedAccessKeyName = value;
                    }
                    else if (string.Compare(SharedAccessKeyValueToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.SharedAccessKey = value;
                    }
                    else if (string.Compare(SharedAccessSignatureToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.SharedAccessSignature = value;
                    }
                }
                else if ((slice.Length != 1) || (slice[0] != TokenValuePairDelimiter))
                {
                    // This wasn't a legal pair and it is not simply a trailing delimiter; consider
                    // the connection string to be malformed.

                    throw new FormatException(Resources.InvalidConnectionString);
                }

                tokenPositionModifier = 0;
                lastPosition = currentPosition;
            }

            return parsedValues;
        }
    }
}
