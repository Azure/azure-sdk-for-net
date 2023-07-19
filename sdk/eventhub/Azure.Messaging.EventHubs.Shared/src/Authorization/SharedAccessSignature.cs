// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;

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
        private const int MaximumKeyNameLength = 256;

        /// <summary>The maximum allowed length of the SAS key.</summary>
        private const int MaximumKeyLength = 256;

        /// <summary>The token that represents the type of authentication used.</summary>
        private const string AuthenticationTypeToken = "SharedAccessSignature";

        /// <summary>The token that identifies the signed component of the shared access signature.</summary>
        private const string SignedResourceToken = "sr";

        /// <summary>The token that identifies the signature component of the shared access signature.</summary>
        private const string SignatureToken = "sig";

        /// <summary>The token that identifies the signed SAS key component of the shared access signature.</summary>
        private const string SignedKeyNameToken = "skn";

        /// <summary>The token that identifies the signed expiration time of the shared access signature.</summary>
        private const string SignedExpiryToken = "se";

        /// <summary>The token that fully identifies the signed resource within the signature.</summary>
        private const string SignedResourceFullIdentifierToken = AuthenticationTypeToken + " " + SignedResourceToken;

        /// <summary>The character used to separate a token and its value in the connection string.</summary>
        private const char TokenValueSeparator = '=';

        /// <summary>The character used to mark the beginning of a new token/value pair in the signature.</summary>
        private const char TokenValuePairDelimiter = '&';

        /// <summary>The default length of time to consider a signature valid, if not otherwise specified.</summary>
        private static readonly TimeSpan DefaultSignatureValidityDuration = TimeSpan.FromMinutes(30);

        /// <summary>Represents the Unix epoch time value, January 1, 1970 12:00:00, UTC.</summary>
        private static readonly DateTimeOffset Epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        ///   The name of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; private set; }

        /// <summary>
        ///   The value of the shared access key, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string SharedAccessKey { get; private set; }

        /// <summary>
        ///   The date and time that the shared access signature expires, in UTC.
        /// </summary>
        ///
        public DateTimeOffset SignatureExpiration { get; private set; }

        /// <summary>
        ///   The resource to which the shared access signature is intended to serve as
        ///   authorization.
        /// </summary>
        ///
        public string Resource { get; private set; }

        /// <summary>
        ///   The shared access signature to be used for authorization, either for the Event Hubs namespace
        ///   or the Event Hub.
        /// </summary>
        ///
        public string Value { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature" /> class.
        /// </summary>
        ///
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signature.</param>
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid; if not specified, a default will be assumed.</param>
        ///
        public SharedAccessSignature(string eventHubResource,
                                     string sharedAccessKeyName,
                                     string sharedAccessKey,
                                     TimeSpan? signatureValidityDuration = default)
        {
            signatureValidityDuration ??= DefaultSignatureValidityDuration;

            Argument.AssertNotNullOrEmpty(eventHubResource, nameof(eventHubResource));
            Argument.AssertNotNullOrEmpty(sharedAccessKeyName, nameof(sharedAccessKeyName));
            Argument.AssertNotNullOrEmpty(sharedAccessKey, nameof(sharedAccessKey));

            Argument.AssertNotTooLong(sharedAccessKeyName, MaximumKeyNameLength, nameof(sharedAccessKeyName));
            Argument.AssertNotTooLong(sharedAccessKey, MaximumKeyLength, nameof(sharedAccessKey));
            Argument.AssertNotNegative(signatureValidityDuration.Value, nameof(signatureValidityDuration));

            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
            SignatureExpiration = DateTimeOffset.UtcNow.Add(signatureValidityDuration.Value);
            Resource = eventHubResource;
            Value = BuildSignature(Resource, sharedAccessKeyName, sharedAccessKey, SignatureExpiration);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature" /> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature that will be parsed as the basis of this instance.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signature.</param>
        ///
        public SharedAccessSignature(string sharedAccessSignature,
                                     string sharedAccessKey)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessSignature, nameof(sharedAccessSignature));
            Argument.AssertNotTooLong(sharedAccessKey, MaximumKeyLength, nameof(sharedAccessKey));

            (SharedAccessKeyName, Resource, SignatureExpiration) = ParseSignature(sharedAccessSignature);

            SharedAccessKey = sharedAccessKey;
            Value = sharedAccessSignature;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SharedAccessSignature" /> class.
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
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signature.</param>
        /// <param name="value">The shared access signature to be used for authorization.</param>
        /// <param name="signatureExpiration">The date and time that the shared access signature expires, in UTC.</param>
        ///
        public SharedAccessSignature(string eventHubResource,
                                     string sharedAccessKeyName,
                                     string sharedAccessKey,
                                     string value,
                                     DateTimeOffset signatureExpiration)
        {
            Argument.AssertNotNullOrEmpty(eventHubResource, nameof(eventHubResource));
            Argument.AssertNotNullOrEmpty(sharedAccessKeyName, nameof(sharedAccessKeyName));
            Argument.AssertNotNullOrEmpty(sharedAccessKey, nameof(sharedAccessKey));

            Argument.AssertNotTooLong(sharedAccessKeyName, MaximumKeyNameLength, nameof(sharedAccessKeyName));
            Argument.AssertNotTooLong(sharedAccessKey, MaximumKeyLength, nameof(sharedAccessKey));

            Resource = eventHubResource;
            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
            Value = value;
            SignatureExpiration = signatureExpiration;
        }

        /// <summary>
        ///   Creates a new signature with the specified period for which the shared access signature is considered valid.
        /// </summary>
        ///
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid.</param>
        ///
        /// <returns>A new <see cref="SharedAccessSignature" /> based on the same key, but with a new expiration time.</returns>
        ///
        public SharedAccessSignature CloneWithNewExpiration(TimeSpan signatureValidityDuration)
        {
            Argument.AssertNotNegative(signatureValidityDuration, nameof(signatureValidityDuration));

            // The key must have been provided at construction in order to manipulate the signature.

            if (string.IsNullOrEmpty(SharedAccessKey))
            {
                throw new InvalidOperationException(Resources.SharedAccessKeyIsRequired);
            }

            return new SharedAccessSignature(Resource, SharedAccessKeyName, SharedAccessKey, signatureValidityDuration);
        }

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        public override string ToString() => Value;

        /// <summary>
        ///   Parses a shared access signature into its component parts.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature to parse.</param>
        ///
        /// <returns>The set of composite properties parsed from the signature.</returns>
        ///
        private static (string KeyName, string Resource, DateTimeOffset ExpirationTime) ParseSignature(string sharedAccessSignature)
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
                ExpirationTime: default(DateTimeOffset)
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

                    if ((!string.IsNullOrEmpty(token)) && (char.IsWhiteSpace(token[0])) || char.IsWhiteSpace(token[token.Length - 1]))
                    {
                        token = token.Trim();
                    }

                    if ((!string.IsNullOrEmpty(value)) && (char.IsWhiteSpace(value[0]) || char.IsWhiteSpace(value[value.Length - 1])))
                    {
                        value = value.Trim();
                    }

                    // If there was no value for a key, then consider the signature to be malformed.

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                    }

                    // Compare the token against the known signature properties and capture the
                    // pair if they are a known attribute.

                    if (string.Compare(SignedResourceFullIdentifierToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.Resource = WebUtility.UrlDecode(value);
                    }
                    else if (string.Compare(SignedKeyNameToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        parsedValues.KeyName = WebUtility.UrlDecode(value);
                    }
                    else if (string.Compare(SignedExpiryToken, token, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (!long.TryParse(WebUtility.UrlDecode(value), NumberStyles.Integer, CultureInfo.InvariantCulture, out var unixTime))
                        {
                            throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                        }

                        parsedValues.ExpirationTime = ConvertFromUnixTime(unixTime);
                    }
                }
                else if ((slice.Length != 1) || (slice[0] != TokenValuePairDelimiter))
                {
                    // This wasn't a legal pair and it is not simply a trailing delimiter; consider
                    // the signature to be malformed.

                    throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
                }

                tokenPositionModifier = 0;
                lastPosition = currentPosition;
            }

            // Validate that the required components were able to be parsed from the
            // signature.

            if ((string.IsNullOrEmpty(parsedValues.Resource))
                || (string.IsNullOrEmpty(parsedValues.KeyName))
                || (parsedValues.ExpirationTime == default))
            {
                throw new ArgumentException(Resources.InvalidSharedAccessSignature, nameof(sharedAccessSignature));
            }

            return parsedValues;
        }

        /// <summary>
        ///   Builds the shared access signature value, which can be used as a token for
        ///   access to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="audience">The audience scope to which this signature applies.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="sharedAccessKey">The value of the shared access key for the signature.</param>
        /// <param name="expirationTime">The date/time, in UTC, that the signature expires.</param>
        ///
        /// <returns>The value of the shared access signature.</returns>
        ///
        private static string BuildSignature(string audience,
                                             string sharedAccessKeyName,
                                             string sharedAccessKey,
                                             DateTimeOffset expirationTime)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(sharedAccessKey)))
            {
                var encodedAudience = WebUtility.UrlEncode(audience);
                var expiration = Convert.ToString(ConvertToUnixTime(expirationTime), CultureInfo.InvariantCulture);
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes($"{ encodedAudience }\n{ expiration }")));

                return string.Format(CultureInfo.InvariantCulture, "{0} {1}={2}&{3}={4}&{5}={6}&{7}={8}",
                    AuthenticationTypeToken,
                    SignedResourceToken, encodedAudience,
                    SignatureToken, WebUtility.UrlEncode(signature),
                    SignedExpiryToken, WebUtility.UrlEncode(expiration),
                    SignedKeyNameToken, WebUtility.UrlEncode(sharedAccessKeyName));
            }
        }

        /// <summary>
        ///   Converts a Unix-style timestamp into the corresponding <see cref="DateTimeOffset" />
        ///   value.
        /// </summary>
        ///
        /// <param name="unixTime">The timestamp to convert.</param>
        ///
        /// <returns>The date/time, in UTC, which corresponds to the specified timestamp.</returns>
        ///
        private static DateTimeOffset ConvertFromUnixTime(long unixTime) =>
            Epoch.AddSeconds(unixTime);

        /// <summary>
        ///   Converts a <see cref="DateTimeOffset" /> value to the corresponding Unix-style timestamp.
        /// </summary>
        ///
        /// <param name="dateTimeOffset">The date/time to convert.</param>
        ///
        /// <returns>The Unix-style timestamp which corresponds to the specified date/time.</returns>
        ///
        private static long ConvertToUnixTime(DateTimeOffset dateTimeOffset) =>
            Convert.ToInt64((dateTimeOffset - Epoch).TotalSeconds);
    }
}
