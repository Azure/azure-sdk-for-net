// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The SharedAccessSignatureTokenProvider generates tokens using a shared access key or existing signature.
    /// </summary>
    internal class SharedAccessSignatureTokenProvider : TokenProvider
    {
        /// <summary>
        /// Represents 00:00:00 UTC Thursday 1, January 1970.
        /// </summary>
        public static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        readonly byte[] encodedSharedAccessKey;
        readonly string keyName;
        readonly TimeSpan tokenTimeToLive;
        readonly string sharedAccessSignature;

        internal SharedAccessSignatureTokenProvider(string sharedAccessSignature)
            : base(TokenScope.Entity)
        {
            SharedAccessSignatureToken.Validate(sharedAccessSignature);
            this.sharedAccessSignature = sharedAccessSignature;
        }

        internal SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive)
            : this(keyName, sharedAccessKey, tokenTimeToLive, TokenScope.Entity)
        {
        }

        internal SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive, TokenScope tokenScope)
            : this(keyName, sharedAccessKey, TokenProvider.MessagingTokenProviderKeyEncoder, tokenTimeToLive, tokenScope)
        {
        }

        protected SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, Func<string, byte[]> customKeyEncoder, TimeSpan tokenTimeToLive, TokenScope tokenScope)
            : base(tokenScope)
        {
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (keyName.Length > SharedAccessSignatureToken.MaxKeyNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(keyName),
                    Resources.ArgumentStringTooBig.FormatForUser(nameof(keyName), SharedAccessSignatureToken.MaxKeyNameLength));
            }

            if (string.IsNullOrEmpty(sharedAccessKey))
            {
                throw new ArgumentNullException(nameof(sharedAccessKey));
            }

            if (sharedAccessKey.Length > SharedAccessSignatureToken.MaxKeyLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(sharedAccessKey),
                    Resources.ArgumentStringTooBig.FormatForUser(nameof(sharedAccessKey), SharedAccessSignatureToken.MaxKeyLength));
            }

            this.keyName = keyName;
            this.tokenTimeToLive = tokenTimeToLive;
            this.encodedSharedAccessKey = customKeyEncoder != null ?
                customKeyEncoder(sharedAccessKey) :
                TokenProvider.MessagingTokenProviderKeyEncoder(sharedAccessKey);
        }

        protected override Task<SecurityToken> OnGetTokenAsync(string appliesTo, string action, TimeSpan timeout)
        {
            var tokenString = this.BuildSignature(appliesTo);
            var sharedAccessSignatureToken = new SharedAccessSignatureToken(tokenString);
            return Task.FromResult<SecurityToken>(sharedAccessSignatureToken);
        }

        protected virtual string BuildSignature(string targetUri)
        {
            return string.IsNullOrWhiteSpace(this.sharedAccessSignature)
                ? SharedAccessSignatureBuilder.BuildSignature(
                    this.keyName,
                    this.encodedSharedAccessKey,
                    targetUri,
                    this.tokenTimeToLive)
                : this.sharedAccessSignature;
        }

        static class SharedAccessSignatureBuilder
        {
            [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Uris are normalized to lowercase")]
            public static string BuildSignature(
                string keyName,
                byte[] encodedSharedAccessKey,
                string targetUri,
                TimeSpan timeToLive)
            {
                // Note that target URI is not normalized because in IoT scenario it
                // is case sensitive.
                string expiresOn = BuildExpiresOn(timeToLive);
                string audienceUri = WebUtility.UrlEncode(targetUri);
                var fields = new List<string> { audienceUri, expiresOn };

                // Example string to be signed:
                // http://mynamespace.servicebus.windows.net/a/b/c?myvalue1=a
                // <Value for ExpiresOn>
                var signature = Sign(string.Join("\n", fields), encodedSharedAccessKey);

                // Example returned string:
                // SharedAccessKeySignature
                // sr=ENCODED(http://mynamespace.servicebus.windows.net/a/b/c?myvalue1=a)&sig=<Signature>&se=<ExpiresOnValue>&skn=<KeyName>
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} {1}={2}&{3}={4}&{5}={6}&{7}={8}",
                    SharedAccessSignatureToken.SharedAccessSignature,
                    SharedAccessSignatureToken.SignedResource,
                    audienceUri,
                    SharedAccessSignatureToken.Signature,
                    WebUtility.UrlEncode(signature),
                    SharedAccessSignatureToken.SignedExpiry,
                    WebUtility.UrlEncode(expiresOn),
                    SharedAccessSignatureToken.SignedKeyName,
                    WebUtility.UrlEncode(keyName));
            }

            static string BuildExpiresOn(TimeSpan timeToLive)
            {
                var expiresOn = DateTime.UtcNow.Add(timeToLive);
                var secondsFromBaseTime = expiresOn.Subtract(EpochTime);
                var seconds = Convert.ToInt64(secondsFromBaseTime.TotalSeconds, CultureInfo.InvariantCulture);
                return Convert.ToString(seconds, CultureInfo.InvariantCulture);
            }

            static string Sign(string requestString, byte[] encodedSharedAccessKey)
            {
                using (var hmac = new HMACSHA256(encodedSharedAccessKey))
                {
                    return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestString)));
                }
            }
        }

        /// <summary>
        /// A WCF SecurityToken that wraps a Shared Access Signature
        /// </summary>
        class SharedAccessSignatureToken : SecurityToken
        {
            public const int MaxKeyNameLength = 256;
            public const int MaxKeyLength = 256;
            public const string SharedAccessSignature = "SharedAccessSignature";
            public const string SignedResource = "sr";
            public const string Signature = "sig";
            public const string SignedKeyName = "skn";
            public const string SignedExpiry = "se";
            public const string SignedResourceFullFieldName = SharedAccessSignature + " " + SignedResource;
            public const string SasKeyValueSeparator = "=";
            public const string SasPairSeparator = "&";

            public SharedAccessSignatureToken(string tokenString)
                : base(tokenString)
            {
            }

            protected override string AudienceFieldName
            {
                get
                {
                    return SignedResourceFullFieldName;
                }
            }

            protected override string ExpiresOnFieldName
            {
                get
                {
                    return SignedExpiry;
                }
            }

            protected override string KeyValueSeparator
            {
                get
                {
                    return SasKeyValueSeparator;
                }
            }

            protected override string PairSeparator
            {
                get
                {
                    return SasPairSeparator;
                }
            }

            internal static void Validate(string sharedAccessSignature)
            {
                if (string.IsNullOrEmpty(sharedAccessSignature))
                {
                    throw new ArgumentNullException(nameof(sharedAccessSignature));
                }

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
        }
    }
}