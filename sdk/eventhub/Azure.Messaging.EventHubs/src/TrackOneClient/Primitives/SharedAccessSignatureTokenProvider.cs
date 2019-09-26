// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrackOne.Primitives;

namespace TrackOne
{
    /// <summary>
    /// The SharedAccessSignatureTokenProvider generates tokens using a shared access key or existing signature.
    /// </summary>
    internal class SharedAccessSignatureTokenProvider : TokenProvider
    {
        internal static readonly TimeSpan s_defaultTokenTimeout = TimeSpan.FromMinutes(60);

        /// <summary>
        /// Represents 00:00:00 UTC Thursday 1, January 1970.
        /// </summary>
        public static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private readonly byte[] _encodedSharedAccessKey;
        private readonly string _keyName;
        private readonly TimeSpan _tokenTimeToLive;
        private readonly TokenScope _tokenScope;
        private readonly string _sharedAccessSignature;
        internal static readonly Func<string, byte[]> s_messagingTokenProviderKeyEncoder = Encoding.UTF8.GetBytes;

        internal SharedAccessSignatureTokenProvider(string sharedAccessSignature)
        {
            SharedAccessSignatureToken.Validate(sharedAccessSignature);
            _sharedAccessSignature = sharedAccessSignature;
        }

        internal SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TokenScope tokenScope = TokenScope.Entity)
            : this(keyName, sharedAccessKey, s_messagingTokenProviderKeyEncoder, s_defaultTokenTimeout, tokenScope)
        {
        }

        internal SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, TimeSpan tokenTimeToLive, TokenScope tokenScope = TokenScope.Entity)
            : this(keyName, sharedAccessKey, s_messagingTokenProviderKeyEncoder, tokenTimeToLive, tokenScope)
        {
        }

        /// <summary></summary>
        /// <param name="keyName"></param>
        /// <param name="sharedAccessKey"></param>
        /// <param name="customKeyEncoder"></param>
        /// <param name="tokenTimeToLive"></param>
        /// <param name="tokenScope"></param>
        protected SharedAccessSignatureTokenProvider(string keyName, string sharedAccessKey, Func<string, byte[]> customKeyEncoder, TimeSpan tokenTimeToLive, TokenScope tokenScope)
        {
            Guard.ArgumentNotNullOrWhiteSpace(nameof(keyName), keyName);

            if (keyName.Length > SharedAccessSignatureToken.MaxKeyNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(keyName),
                    Resources.ArgumentStringTooBig.FormatForUser(nameof(keyName), SharedAccessSignatureToken.MaxKeyNameLength));
            }

            Guard.ArgumentNotNullOrWhiteSpace(nameof(sharedAccessKey), sharedAccessKey);

            if (sharedAccessKey.Length > SharedAccessSignatureToken.MaxKeyLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(sharedAccessKey),
                    Resources.ArgumentStringTooBig.FormatForUser(nameof(sharedAccessKey), SharedAccessSignatureToken.MaxKeyLength));
            }

            _keyName = keyName;
            _tokenTimeToLive = tokenTimeToLive;
            _encodedSharedAccessKey = customKeyEncoder != null ?
                customKeyEncoder(sharedAccessKey) :
                s_messagingTokenProviderKeyEncoder(sharedAccessKey);
            _tokenScope = tokenScope;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            TimeoutHelper.ThrowIfNegativeArgument(timeout);
            appliesTo = NormalizeAppliesTo(appliesTo);
            string tokenString = BuildSignature(appliesTo);
            var securityToken = new SharedAccessSignatureToken(tokenString);
            return Task.FromResult<SecurityToken>(securityToken);
        }

        /// <summary></summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        protected virtual string BuildSignature(string targetUri)
        {
            return string.IsNullOrWhiteSpace(_sharedAccessSignature)
                ? SharedAccessSignatureBuilder.BuildSignature(
                    _keyName,
                    _encodedSharedAccessKey,
                    targetUri,
                    _tokenTimeToLive)
                : _sharedAccessSignature;
        }

        private string NormalizeAppliesTo(string appliesTo)
        {
            return EventHubsUriHelper.NormalizeUri(appliesTo, "http", true, stripPath: _tokenScope == TokenScope.Namespace, ensureTrailingSlash: true);
        }

        private static class SharedAccessSignatureBuilder
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
                List<string> fields = new List<string> { audienceUri, expiresOn };

                // Example string to be signed:
                // http://mynamespace.servicebus.windows.net/a/b/c?myvalue1=a
                // <Value for ExpiresOn>
                string signature = Sign(string.Join("\n", fields), encodedSharedAccessKey);

                // Example returned string:
                // SharedAccessKeySignature
                // sr=ENCODED(http://mynamespace.servicebus.windows.net/a/b/c?myvalue1=a)&sig=<Signature>&se=<ExpiresOnValue>&skn=<KeyName>

                return string.Format(CultureInfo.InvariantCulture, "{0} {1}={2}&{3}={4}&{5}={6}&{7}={8}",
                    SharedAccessSignatureToken.SharedAccessSignature,
                    SharedAccessSignatureToken.SignedResource, audienceUri,
                    SharedAccessSignatureToken.Signature, WebUtility.UrlEncode(signature),
                    SharedAccessSignatureToken.SignedExpiry, WebUtility.UrlEncode(expiresOn),
                    SharedAccessSignatureToken.SignedKeyName, WebUtility.UrlEncode(keyName));
            }

            private static string BuildExpiresOn(TimeSpan timeToLive)
            {
                DateTime expiresOn = DateTime.UtcNow.Add(timeToLive);
                TimeSpan secondsFromBaseTime = expiresOn.Subtract(EpochTime);
                long seconds = Convert.ToInt64(secondsFromBaseTime.TotalSeconds, CultureInfo.InvariantCulture);
                return Convert.ToString(seconds, CultureInfo.InvariantCulture);
            }

            private static string Sign(string requestString, byte[] encodedSharedAccessKey)
            {
                using (var hmac = new HMACSHA256(encodedSharedAccessKey))
                {
                    return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestString)));
                }
            }
        }
    }
}
