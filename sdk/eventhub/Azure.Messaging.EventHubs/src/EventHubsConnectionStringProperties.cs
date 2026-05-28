// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of properties that comprise an Event Hubs connection string.
    /// </summary>
    ///
    public class EventHubsConnectionStringProperties
    {
        /// <summary>The token that identifies the endpoint address for the Event Hubs namespace.</summary>
        private const string EndpointToken = "Endpoint";

        /// <summary>The token that identifies the name of a specific Event Hub under the namespace.</summary>
        private const string EventHubNameToken = "EntityPath";

        /// <summary>The token that identifies the name of a shared access key.</summary>
        private const string SharedAccessKeyNameToken = "SharedAccessKeyName";

        /// <summary>The token that identifies the value of a shared access key.</summary>
        private const string SharedAccessKeyValueToken = "SharedAccessKey";

        /// <summary>The token that identifies the value of a shared access signature.</summary>
        private const string SharedAccessSignatureToken = "SharedAccessSignature";

        /// <summary>The token that identifies the intent to use a local emulator for development.</summary>
        private const string DevelopmentEmulatorToken = "UseDevelopmentEmulator";

        /// <summary>The character used to separate a token and its value in the connection string.</summary>
        private const char TokenValueSeparator = '=';

        /// <summary>The character used to mark the beginning of a new token/value pair in the connection string.</summary>
        private const char TokenValuePairDelimiter = ';';

        /// <summary>The name of the protocol used by an Event Hubs endpoint. </summary>
        private const string EventHubsEndpointSchemeName = "sb";

        /// <summary>The formatted protocol used by an Event Hubs endpoint. </summary>
        private static readonly string EventHubsEndpointScheme = $"{ EventHubsEndpointSchemeName }{ Uri.SchemeDelimiter }";

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        /// <value>The namespace of the Event Hub, as derived from the endpoint address of the connection string.</value>
        ///
        public string FullyQualifiedNamespace => Endpoint?.Host;

        /// <summary>
        ///   The endpoint to be used for connecting to the Event Hubs namespace.
        /// </summary>
        ///
        /// <value>The endpoint address, including protocol, from the connection string.</value>
        ///
        public Uri Endpoint { get; internal set; }

        /// <summary>
        ///   The name of the specific Event Hub instance under the associated Event Hubs namespace.
        /// </summary>
        ///
        public string EventHubName { get; internal set; }

        /// <summary>
        ///   The name of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; internal set; }

        /// <summary>
        ///   The value of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKey { get; internal set; }

        /// <summary>
        ///   The value of the fully-formed shared access signature, either for the Event Hubs
        ///   namespace or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessSignature { get; internal set; }

        /// <summary>
        ///   Indicates whether or not the connection string indicates that the
        ///   local development emulator is being used.
        /// </summary>
        ///
        /// <value><c>true</c> if the emulator is being used; otherwise, <c>false</c>.</value>
        ///
        internal bool UseDevelopmentEmulator { get; set; }

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
        ///   Creates an Event Hubs connection string based on this set of <see cref="EventHubsConnectionStringProperties" />.
        /// </summary>
        ///
        /// <returns>
        ///   A valid Event Hubs connection string; depending on the specified property information, this may
        ///   represent the namespace-level or Event Hub-level.
        /// </returns>
        ///
        ///
        internal string ToConnectionString()
        {
            Validate(null, null);

            var endpointBuilder = new UriBuilder(Endpoint)
            {
                Scheme = EventHubsEndpointScheme,
                Port = -1
            };

            if ((string.Compare(endpointBuilder.Scheme, EventHubsEndpointSchemeName, StringComparison.OrdinalIgnoreCase) != 0)
                || (Uri.CheckHostName(endpointBuilder.Host) == UriHostNameType.Unknown))
            {
                throw new ArgumentException(Resources.InvalidEndpointAddress);
            }

            var builder = new StringBuilder()
                .Append(EndpointToken)
                .Append(TokenValueSeparator)
                .Append(endpointBuilder.Uri.AbsoluteUri)
                .Append(TokenValuePairDelimiter);

            if (!string.IsNullOrEmpty(EventHubName))
            {
                builder
                  .Append(EventHubNameToken)
                  .Append(TokenValueSeparator)
                  .Append(EventHubName)
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

            if (UseDevelopmentEmulator)
            {
                builder
                    .Append(DevelopmentEmulatorToken)
                    .Append(TokenValueSeparator)
                    .Append("true")
                    .Append(TokenValuePairDelimiter);
            }

            return builder.ToString();
        }

        /// <summary>
        ///   Performs the actions needed to validate the set of connection string properties for connecting to the
        ///   Event Hubs service.
        /// </summary>
        ///
        /// <param name="explicitEventHubName">The name of the Event Hub that was explicitly passed independent of the connection string, allowing easier use of a namespace-level connection string.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <exception cref="ArgumentException">In the case that the properties violate an invariant or otherwise represent a combination that is not permissible, an appropriate exception will be thrown.</exception>
        ///
        internal void Validate(string explicitEventHubName,
                               string connectionStringArgumentName)
        {
            // The Event Hub name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.  If specified in both to the same
            // value, then do not consider this a failure.

            if ((!string.IsNullOrEmpty(explicitEventHubName))
                && (!string.IsNullOrEmpty(EventHubName))
                && (!string.Equals(explicitEventHubName, EventHubName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException(Resources.OnlyOneEventHubNameMayBeSpecified, connectionStringArgumentName);
            }

            // The connection string may contain a precomputed shared access signature OR a shared key name and value,
            // but not both.

            if ((!string.IsNullOrEmpty(SharedAccessSignature))
                && ((!string.IsNullOrEmpty(SharedAccessKeyName)) || (!string.IsNullOrEmpty(SharedAccessKey))))
            {
                throw new ArgumentException(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified, connectionStringArgumentName);
            }

            // Ensure that each of the needed components are present for connecting.

            var hasSharedKey = ((!string.IsNullOrEmpty(SharedAccessKeyName)) && (!string.IsNullOrEmpty(SharedAccessKey)));
            var hasSharedSignature = (!string.IsNullOrEmpty(SharedAccessSignature));

            if (string.IsNullOrEmpty(Endpoint?.Host)
                || ((string.IsNullOrEmpty(explicitEventHubName)) && (string.IsNullOrEmpty(EventHubName)))
                || ((!hasSharedKey) && (!hasSharedSignature)))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation, connectionStringArgumentName);
            }
        }

        /// <summary>
        ///   Parses the specified Event Hubs connection string into its component properties.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>The component properties parsed from the connection string.</returns>
        ///
        /// <exception cref="FormatException">The specified connection string was malformed and could not be parsed.</exception>
        ///
        public static EventHubsConnectionStringProperties Parse(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            var parsedValues = new EventHubsConnectionStringProperties();
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
                        // If this is an absolute URI, then it may have a custom port specified, which we
                        // want to preserve.  If no scheme was specified, the URI is considered relative and
                        // the default port should be used.

                        if (!Uri.TryCreate(value, UriKind.Absolute, out var endpointUri))
                        {
                            endpointUri = null;
                        }
                        else if (string.IsNullOrEmpty(endpointUri.Host) && (CountChar(':', value.AsSpan()) == 1))
                        {
                            // If the host was empty after parsing and the value has a single port/scheme separator,
                            // then the parsing likely failed to recognize the host due to the lack of a scheme.  Add
                            // an artificial scheme and try to parse again.

                            if (!Uri.TryCreate(string.Concat(EventHubsEndpointScheme, value), UriKind.Absolute, out endpointUri))
                            {
                                endpointUri = null;
                            }
                        }

                        var endpointBuilder = endpointUri switch
                        {
                            null => new UriBuilder(value)
                            {
                                Scheme = EventHubsEndpointScheme,
                                Port = -1
                            },

                            _ => new UriBuilder()
                            {
                                Scheme = EventHubsEndpointScheme,
                                Host = endpointUri.Host,
                                Port = endpointUri.IsDefaultPort ? -1 : endpointUri.Port,
                            }
                        };

                        if ((string.Compare(endpointBuilder.Scheme, EventHubsEndpointSchemeName, StringComparison.OrdinalIgnoreCase) != 0)
                            || (Uri.CheckHostName(endpointBuilder.Host) == UriHostNameType.Unknown))
                        {
                            throw new FormatException(Resources.InvalidConnectionString);
                        }

                        parsedValues.Endpoint = endpointBuilder.Uri;
                    }
                    else if (string.Compare(EventHubNameToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.EventHubName = value;
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
                    else if (string.Compare(DevelopmentEmulatorToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        // Do not enforce a value for the development emulator token. If a valid boolean, use it.
                        // Otherwise, leave the default value of false.

                        if (bool.TryParse(value, out var useEmulator))
                        {
                            parsedValues.UseDevelopmentEmulator = useEmulator;
                        }
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

        /// <summary>
        ///   Counts the number of times a character occurs in a given span.
        /// </summary>
        ///
        /// <param name="span">The span to evaluate.</param>
        /// <param name="value">The character to count.</param>
        ///
        /// <returns>The number of times the <paramref name="value"/> occurs in <paramref name="span"/>.</returns>
        ///
        private static int CountChar(char value,
                                     ReadOnlySpan<char> span)
        {
            var count = 0;

            foreach (var character in span)
            {
                if (character == value)
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
