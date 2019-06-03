﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;

    /// <summary>
    /// A WCF SecurityToken that wraps a Shared Access Signature
    /// </summary>
    internal class SharedAccessSignatureToken : SecurityToken
    {
        internal const string SharedAccessSignature = "SharedAccessSignature";
        internal const string SignedResource = "sr";
        internal const string Signature = "sig";
        internal const string SignedKeyName = "skn";
        internal const string SignedExpiry = "se";
        internal const int MaxKeyNameLength = 256;
        internal const int MaxKeyLength = 256;

        const string SignedResourceFullFieldName = SharedAccessSignature + " " + SignedResource;
        const string SasPairSeparator = "&";
        const string SasKeyValueSeparator = "=";

        static readonly Func<string, string> Decoder = WebUtility.UrlDecode;

        /// <summary>
        /// Creates a new instance of the <see cref="SharedAccessSignatureToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        public SharedAccessSignatureToken(string tokenString)
            : base(tokenString, GetExpirationDateTimeUtcFromToken(tokenString), GetAudienceFromToken(tokenString), Constants.SasTokenType)
        {
        }

        internal static void Validate(string sharedAccessSignature)
        {
            if (string.IsNullOrEmpty(sharedAccessSignature))
            {
                throw new ArgumentNullException(nameof(sharedAccessSignature));
            }

            IDictionary<string, string> parsedFields = ExtractFieldValues(sharedAccessSignature);

            string signature;
            if (!parsedFields.TryGetValue(Signature, out signature))
            {
                throw new ArgumentNullException(Signature);
            }

            string expiry;
            if (!parsedFields.TryGetValue(SignedExpiry, out expiry))
            {
                throw new ArgumentNullException(SignedExpiry);
            }

            string keyName;
            if (!parsedFields.TryGetValue(SignedKeyName, out keyName))
            {
                throw new ArgumentNullException(SignedKeyName);
            }

            string encodedAudience;
            if (!parsedFields.TryGetValue(SignedResource, out encodedAudience))
            {
                throw new ArgumentNullException(SignedResource);
            }
        }

        static IDictionary<string, string> ExtractFieldValues(string sharedAccessSignature)
        {
            string[] tokenLines = sharedAccessSignature.Split();

            if (!string.Equals(tokenLines[0].Trim(), SharedAccessSignature, StringComparison.OrdinalIgnoreCase) || tokenLines.Length != 2)
            {
                throw new ArgumentNullException(nameof(sharedAccessSignature));
            }

            IDictionary<string, string> parsedFields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] tokenFields = tokenLines[1].Trim().Split(new[] { SasPairSeparator }, StringSplitOptions.None);

            foreach (string tokenField in tokenFields)
            {
                if (tokenField != string.Empty)
                {
                    string[] fieldParts = tokenField.Split(new[] { SasKeyValueSeparator }, StringSplitOptions.None);
                    if (string.Equals(fieldParts[0], SignedResource, StringComparison.OrdinalIgnoreCase))
                    {
                        // We need to preserve the casing of the escape characters in the audience,
                        // so defer decoding the URL until later.
                        parsedFields.Add(fieldParts[0], fieldParts[1]);
                    }
                    else
                    {
                        parsedFields.Add(fieldParts[0], WebUtility.UrlDecode(fieldParts[1]));
                    }
                }
            }

            return parsedFields;
        }

        static string GetAudienceFromToken(string token)
        {
            IDictionary<string, string> decodedToken = Decode(token, Decoder, Decoder, SasKeyValueSeparator, SasPairSeparator);
            if (!decodedToken.TryGetValue(SignedResourceFullFieldName, out var audience))
            {
                throw new FormatException(Resources.TokenMissingAudience);
            }

            return audience;
        }

        static DateTime GetExpirationDateTimeUtcFromToken(string token)
        {
            IDictionary<string, string> decodedToken = Decode(token, Decoder, Decoder, SasKeyValueSeparator, SasPairSeparator);
            if (!decodedToken.TryGetValue(SignedExpiry, out var expiresIn))
            {
                throw new FormatException(Resources.TokenMissingExpiresOn);
            }

            var expiresOn = (Constants.EpochTime + TimeSpan.FromSeconds(double.Parse(expiresIn, CultureInfo.InvariantCulture)));

            return expiresOn;
        }

        static IDictionary<string, string> Decode(string encodedString, Func<string, string> keyDecoder, Func<string, string> valueDecoder, string keyValueSeparator, string pairSeparator)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            IEnumerable<string> valueEncodedPairs = encodedString.Split(new[] { pairSeparator }, StringSplitOptions.None);
            foreach (string valueEncodedPair in valueEncodedPairs)
            {
                string[] pair = valueEncodedPair.Split(new[] { keyValueSeparator }, StringSplitOptions.None);
                if (pair.Length != 2)
                {
                    throw new FormatException(Resources.InvalidEncoding);
                }

                dictionary.Add(keyDecoder(pair[0]), valueDecoder(pair[1]));
            }

            return dictionary;
        }
    }
}
