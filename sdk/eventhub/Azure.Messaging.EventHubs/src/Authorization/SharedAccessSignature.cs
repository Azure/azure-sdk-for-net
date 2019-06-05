// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    ///   A shared access signature, which can be used for authorization to an Event Hubs namespace
    ///   or a specific Event Hub.
    /// </summary>
    ///
    internal class SharedAccessSignature
    {
        /// <summary>The maximum allowed length of the SAS key name.</summary>
        protected const int MaximumKeyNameLength = 256;

        /// <summary>The maximum allowed lenght of the SAS key.</summary>
        protected const int MaximumKeyLength = 256;

        /// <summary>The token that represents the type of authentication used.</summary>
        protected const string AuthenticationTypeToken = "SharedAccessSignature";

        /// <summary>The token that identifies the signed component of the shared access signature.</summary>
        protected const string SignedResourceToken = "sr";

        /// <summary>The token that identifies that signature component of the shared access signature.</summary>
        protected const string SignatureToken = "sig";

        /// <summary>The token that identifies that signed SAS key component of the shared access signature.</summary>
        protected const string SignedKeyNameToken = "skn";

        /// <summary>The token that identifies that signed expiration time of the shared access signature.</summary>
        protected const string SignedExpiryToken = "se";

        /// <summary>The token that fully identifies the signed resource within the signature.</summary>
        protected const string SignedResourceFullIdentifierToken = AuthenticationTypeToken + " " + SignedResourceToken;

        /// <summary>The character used to separate a token and its value in the connection string.</summary>
        protected const char TokenValueSeparator = '=';

        /// <summary>The character used to mark the beginning of a new token/value pair in the signature.</summary>
        protected const char TokenValuePairDelimiter = '&';

        /// <summary>Represents the Unix epoch time value, January 1, 1970 12:00:00, UTC.</summary>
        protected static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///   The name of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; protected set; }

        /// <summary>
        ///   The value of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKey { get; protected set; }

        /// <summary>
        ///   The date and time that the shared access signature expires, in UTC.
        /// </summary>
        ///
        public DateTime ExpirationUtc { get; protected set; }

        /// <summary>
        ///   The resource to which the shared access signature is intended to serve as
        ///   authorization.
        /// </summary>
        ///
        public string Resource { get; protected set; }

        /// <summary>
        ///   The shared access signature to be used for authorization, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string Value { get; protected set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature"/> class.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection that will be used for communicating with the Event Hubs service.</param>
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signagure.</param>
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid.</param>
        ///
        public SharedAccessSignature(ConnectionType connectionType,
                                     string host,
                                     string eventHubPath,
                                     string sharedAccessKeyName,
                                     string sharedAccessKey,
                                     TimeSpan signatureValidityDuration)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNullOrEmpty(nameof(sharedAccessKeyName), sharedAccessKeyName);
            Guard.ArgumentNotNullOrEmpty(nameof(sharedAccessKey), sharedAccessKey);

            Guard.ArgumentNotTooLong(nameof(sharedAccessKeyName), sharedAccessKeyName, MaximumKeyNameLength);
            Guard.ArgumentNotTooLong(nameof(sharedAccessKey), sharedAccessKey, MaximumKeyLength);
            Guard.ArgumentNotNegative(nameof(signatureValidityDuration), signatureValidityDuration);

            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
            ExpirationUtc = DateTime.UtcNow.Add(signatureValidityDuration);
            Resource = BuildAudience(connectionType, host, eventHubPath);
            Value = BuildSignature(Resource, sharedAccessKeyName, sharedAccessKey, ExpirationUtc);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature that will be parsed as the basis of this instance.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signature.</param>
        ///
        public SharedAccessSignature(string sharedAccessSignature,
                                     string sharedAccessKey)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(sharedAccessSignature), sharedAccessSignature);
            Guard.ArgumentNotTooLong(nameof(sharedAccessKey), sharedAccessKey, MaximumKeyLength);

            (SharedAccessKeyName, Resource, ExpirationUtc) = ParseSignature(sharedAccessSignature);

            SharedAccessKey = sharedAccessKey;
            Value = sharedAccessSignature;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature that will be parsed as the basis of this instance.</param>
        ///
        public SharedAccessSignature(string sharedAccessSignature) : this(sharedAccessSignature, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature" /> class.
        /// </summary>
        ///
        /// <remarks>
        ///   This constructor is primarily intended for testing scenarios, where the default behavior
        ///   for constructing or parsing a signature is intended to be bypassed.  In other cases, it is
        ///   recommended to override the <see cref="BuildSignature"/> or <see cref="ParseSignature"/> methods directly.
        /// </remarks>
        ///
        protected SharedAccessSignature()
        {
        }

        /// <summary>
        ///   Extends the period for which the shared access signature is considered valid by adjusting the
        ///   calculated expiration time.  Upon successful extension, the <see cref="Value" /> of the signature will
        ///   be updated with the new expiration.
        /// </summary>
        ///
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid.</param>
        ///
        public void ExtendExpiration(TimeSpan signatureValidityDuration)
        {
            Guard.ArgumentNotNegative(nameof(signatureValidityDuration), signatureValidityDuration);

            // The key must have been provided at construction in order to manipulate the signature.

            if (String.IsNullOrEmpty(SharedAccessKey))
            {
                throw new InvalidOperationException(Resources.SharedAccessKeyIsRequired);
            }

            ExpirationUtc = DateTime.UtcNow.Add(signatureValidityDuration);
            Value = BuildSignature(Resource, SharedAccessKeyName, SharedAccessKey, ExpirationUtc);
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        public override string ToString() => Value;

        /// <summary>
        ///   Creates a new copy of the current <see cref="SharedAccessSignature" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SharedAccessSignature" />.</returns>
        ///
        internal SharedAccessSignature Clone() =>
            new SharedAccessSignature()
            {
                Resource = this.Resource,
                SharedAccessKeyName = this.SharedAccessKeyName,
                SharedAccessKey = this.SharedAccessKey,
                ExpirationUtc = this.ExpirationUtc,
                Value = this.Value
            };

        /// <summary>
        ///   Builds the shared accesss signature value, which can be used as a token for
        ///   access to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="audience">The audience scope to which this signature applies.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signagure.</param>
        /// <param name="expirationUtc">The date/time, in UTC, that the signature expires.</param>
        ///
        /// <returns>The value of the shared access signature.</returns>
        ///
        protected string BuildSignature(string audience,
                                        string sharedAccessKeyName,
                                        string sharedAccessKey,
                                        DateTime expirationUtc)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(sharedAccessKey)))
            {
                var encodedAudience = WebUtility.UrlEncode(audience);
                var expiration = Convert.ToString(ConvertToUnixTime(expirationUtc), CultureInfo.InvariantCulture);
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes($"{ encodedAudience }\n{ expiration }")));

                return String.Format(CultureInfo.InvariantCulture, "{0} {1}={2}&{3}={4}&{5}={6}&{7}={8}",
                    AuthenticationTypeToken,
                    SignedResourceToken, encodedAudience,
                    SignatureToken, WebUtility.UrlEncode(signature),
                    SignedExpiryToken, WebUtility.UrlEncode(expiration),
                    SignedKeyNameToken, WebUtility.UrlEncode(sharedAccessKeyName));
            }
        }

        /// <summary>
        ///   Parses a shared access signature into its component parts.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature to parse.</param>
        ///
        /// <returns>The set of composite properties parsed from the signature.</returns>
        ///
        protected (string KeyName, string Resource, DateTime ExpirationUtc) ParseSignature(string sharedAccessSignature)
        {
            int tokenPositionModifier = (sharedAccessSignature[0] == TokenValuePairDelimiter) ? 0 : 1;
            int lastPosition = 0;
            int currentPosition = 0;
            int valueStart;

            string slice;
            string token;
            string value;

            var parsedValues =
            (
                KeyName: default(string),
                Resource: default(string),
                ExpirationUtc: default(DateTime)
            );

            while (currentPosition != -1)
            {
                // Slice the string into the next token/value pair.

                currentPosition = sharedAccessSignature.IndexOf(TokenValuePairDelimiter, lastPosition + 1);

                if (currentPosition >= 0)
                {
                    slice = sharedAccessSignature.Substring(lastPosition, (currentPosition - lastPosition));
                }
                else
                {
                    slice = sharedAccessSignature.Substring(lastPosition);
                }

                // Break the token and value apart, if this is a legal pair.

                valueStart = slice.IndexOf(TokenValueSeparator);

                if (valueStart >= 0)
                {
                    token = slice.Substring((1 - tokenPositionModifier), (valueStart - 1 + tokenPositionModifier));
                    value = slice.Substring(valueStart + 1);

                    // Guard against leading and trailing spaces, only trimming if there is a need.

                    if ((!String.IsNullOrEmpty(token)) && (Char.IsWhiteSpace(token[0])) || Char.IsWhiteSpace(token[token.Length - 1]))
                    {
                        token = token.Trim();
                    }

                    if ((!String.IsNullOrEmpty(value)) && (Char.IsWhiteSpace(value[0]) || Char.IsWhiteSpace(value[value.Length - 1])))
                    {
                        value = value.Trim();
                    }

                    // If there was no value for a key, then consider the signature to be malformed.

                    if (String.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                    }

                    // Compare the token against the known signature properties and capture the
                    // pair if they are a known attribute.

                    if (String.Compare(SignedResourceFullIdentifierToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.Resource = WebUtility.UrlDecode(value);
                    }
                    else if (String.Compare(SignedKeyNameToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.KeyName = WebUtility.UrlDecode(value);
                    }
                    else if (String.Compare(SignedExpiryToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (!Int64.TryParse(WebUtility.UrlDecode(value), out var unixTime))
                        {
                            throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                        }

                        parsedValues.ExpirationUtc = ConvertFromUnixTime(unixTime);
                    }
                }
                else if ((slice.Length != 1) || (slice[0] != TokenValuePairDelimiter))
                {
                    // This wasn't a legal pair and it is not simply a trailing delmieter; consider
                    // the signature to be malformed.

                    throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                }

                tokenPositionModifier = 0;
                lastPosition = currentPosition;
            }

            // Validate that the required components were able to be parsed from the
            // signature.

            if ((String.IsNullOrEmpty(parsedValues.Resource))
                || (String.IsNullOrEmpty(parsedValues.KeyName))
                || (parsedValues.ExpirationUtc == default))
            {
                throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
            }

            return parsedValues;
        }


        /// <summary>
        ///   Builds the audience for use in the signature.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection that will be used for communicating with the Event Hubs service.</param>
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        ///
        private string BuildAudience(ConnectionType connectionType,
                                     string host,
                                     string eventHubPath)
        {
            var builder = new UriBuilder(host)
            {
                Scheme = connectionType.GetUriScheme(),
                Path = eventHubPath,
                Port = -1,
                Fragment = String.Empty,
                Password = String.Empty,
                UserName = String.Empty,
            };

            if (!builder.Path.EndsWith("/"))
            {
                builder.Path += "/";
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }

        /// <summary>
        ///   Converts a Unix-style timestamp into the corresponding <see cref="DateTime" />
        ///   value.
        /// </summary>
        ///
        /// <param name="unixTime">The timestamp to convert.</param>
        ///
        /// <returns>The date/time, in UTC, which corresponds to the specified timestamp.</returns>
        ///
        private DateTime ConvertFromUnixTime(long unixTime) =>
            Epoch.AddSeconds(unixTime);

        /// <summary>
        ///   Converts a <see cref="DateTime" /> value to the corresponding Unix-style timestamp.
        /// </summary>
        ///
        /// <param name="dateTime">The date/time to convert.</param>
        ///
        /// <returns>The Unix-style timestamp which corresponds to the specified date/time.</returns>
        ///
        private long ConvertToUnixTime(DateTime dateTime) =>
            Convert.ToInt64((dateTime.ToUniversalTime() - Epoch).TotalSeconds);
    }
}
