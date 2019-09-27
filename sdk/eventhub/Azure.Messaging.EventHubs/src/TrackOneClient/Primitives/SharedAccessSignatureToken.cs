﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using TrackOne.Primitives;

namespace TrackOne
{
    /// <summary>
    /// A SecurityToken that wraps a Shared Access Signature
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
        private const string SignedResourceFullFieldName = SharedAccessSignature + " " + SignedResource;
        private const string SasPairSeparator = "&";
        private const string SasKeyValueSeparator = "=";
        private static readonly Func<string, string> s_decoder = WebUtility.UrlDecode;

        /// <summary>
        /// Creates a new instance of the <see cref="SharedAccessSignatureToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        public SharedAccessSignatureToken(string tokenString)
            : base(tokenString, GetExpirationDateTimeUtcFromToken(tokenString), GetAudienceFromToken(tokenString), ClientConstants.SasTokenType)
        {
        }

        internal static void Validate(string sharedAccessSignature)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(sharedAccessSignature), sharedAccessSignature);

            IDictionary<string, string> parsedFields = ExtractFieldValues(sharedAccessSignature);

            if (!parsedFields.TryGetValue(Signature, out _))
            {
                throw new ArgumentNullException(Signature);
            }

            if (!parsedFields.TryGetValue(SignedExpiry, out _))
            {
                throw new ArgumentNullException(SignedExpiry);
            }

            if (!parsedFields.TryGetValue(SignedKeyName, out _))
            {
                throw new ArgumentNullException(SignedKeyName);
            }

            if (!parsedFields.TryGetValue(SignedResource, out _))
            {
                throw new ArgumentNullException(SignedResource);
            }
        }

        private static IDictionary<string, string> ExtractFieldValues(string sharedAccessSignature)
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

        private static string GetAudienceFromToken(string token)
        {
            IDictionary<string, string> decodedToken = Decode(token, s_decoder, s_decoder, SasKeyValueSeparator, SasPairSeparator);
            if (!decodedToken.TryGetValue(SignedResourceFullFieldName, out string audience))
            {
                throw new FormatException(Resources.TokenMissingAudience);
            }

            return audience;
        }

        private static DateTime GetExpirationDateTimeUtcFromToken(string token)
        {
            IDictionary<string, string> decodedToken = Decode(token, s_decoder, s_decoder, SasKeyValueSeparator, SasPairSeparator);
            if (!decodedToken.TryGetValue(SignedExpiry, out string expiresIn))
            {
                throw new FormatException(Resources.TokenMissingExpiresOn);
            }

            DateTime expiresOn = (SharedAccessSignatureTokenProvider.EpochTime + TimeSpan.FromSeconds(double.Parse(expiresIn, CultureInfo.InvariantCulture)));

            return expiresOn;
        }

        private static IDictionary<string, string> Decode(string encodedString, Func<string, string> keyDecoder, Func<string, string> valueDecoder, string keyValueSeparator, string pairSeparator)
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
