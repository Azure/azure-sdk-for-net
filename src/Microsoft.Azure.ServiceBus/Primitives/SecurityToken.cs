// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;

    /// <summary>
    /// Provides information about a security token such as audience, expiry time, and the string token value.
    /// </summary>
    internal class SecurityToken
    {
        // per Simple Web Token draft specification
        private const string TokenAudience = "Audience";
        private const string TokenExpiresOn = "ExpiresOn";
        private const string TokenIssuer = "Issuer";
        private const string TokenDigest256 = "HMACSHA256";

        const string InternalExpiresOnFieldName = "ExpiresOn";
        const string InternalAudienceFieldName = TokenAudience;
        const string InternalKeyValueSeparator = "=";
        const string InternalPairSeparator = "&";
        static readonly Func<string, string> Decoder = WebUtility.UrlDecode;
        static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        readonly string token;
        readonly DateTime expiresAtUtc;
        readonly string audience;

        /// <summary>
        /// Creates a new instance of the <see cref="SecurityToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        /// <param name="expiresAtUtc">The expiration time</param>
        /// <param name="audience">The audience</param>
        public SecurityToken(string tokenString, DateTime expiresAtUtc, string audience)
        {
            if (tokenString == null || audience == null)
            {
                throw Fx.Exception.ArgumentNull(tokenString == null ? nameof(tokenString) : nameof(audience));
            }

            this.token = tokenString;
            this.expiresAtUtc = expiresAtUtc;
            this.audience = audience;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SecurityToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        /// <param name="expiresAtUtc">The expiration time</param>
        public SecurityToken(string tokenString, DateTime expiresAtUtc)
        {
            if (tokenString == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(tokenString));
            }

            this.token = tokenString;
            this.expiresAtUtc = expiresAtUtc;
            this.audience = this.GetAudienceFromToken(tokenString);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SecurityToken"/> class.
        /// </summary>
        /// <param name="tokenString">The token</param>
        public SecurityToken(string tokenString)
        {
            if (tokenString == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(tokenString));
            }

            this.token = tokenString;
            this.GetExpirationDateAndAudienceFromToken(tokenString, out this.expiresAtUtc, out this.audience);
        }

        /// <summary>
        /// Gets the audience of this token.
        /// </summary>
        public string Audience
        {
            get
            {
                return this.audience;
            }
        }

        /// <summary>
        /// Gets the expiration time of this token.
        /// </summary>
        public DateTime ExpiresAtUtc
        {
            get
            {
                return this.expiresAtUtc;
            }
        }

        /// <summary>
        /// Gets the actual token.
        /// </summary>
        public object TokenValue
        {
            get { return this.token; }
        }

        /// <summary></summary>
        protected virtual string ExpiresOnFieldName
        {
            get
            {
                return InternalExpiresOnFieldName;
            }
        }

        /// <summary></summary>
        protected virtual string AudienceFieldName
        {
            get
            {
                return InternalAudienceFieldName;
            }
        }

        /// <summary></summary>
        protected virtual string KeyValueSeparator
        {
            get
            {
                return InternalKeyValueSeparator;
            }
        }

        /// <summary></summary>
        protected virtual string PairSeparator
        {
            get
            {
                return InternalPairSeparator;
            }
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

        string GetAudienceFromToken(string token)
        {
            string audience;
            IDictionary<string, string> decodedToken = Decode(token, Decoder, Decoder, this.KeyValueSeparator, this.PairSeparator);
            if (!decodedToken.TryGetValue(this.AudienceFieldName, out audience))
            {
                throw new FormatException(Resources.TokenMissingAudience);
            }

            return audience;
        }

        void GetExpirationDateAndAudienceFromToken(string token, out DateTime expiresOn, out string audience)
        {
            string expiresIn;
            IDictionary<string, string> decodedToken = Decode(token, Decoder, Decoder, this.KeyValueSeparator, this.PairSeparator);
            if (!decodedToken.TryGetValue(this.ExpiresOnFieldName, out expiresIn))
            {
                throw new FormatException(Resources.TokenMissingExpiresOn);
            }

            if (!decodedToken.TryGetValue(this.AudienceFieldName, out audience))
            {
                throw new FormatException(Resources.TokenMissingAudience);
            }

            expiresOn = (EpochTime + TimeSpan.FromSeconds(double.Parse(expiresIn, CultureInfo.InvariantCulture)));
        }
    }
}