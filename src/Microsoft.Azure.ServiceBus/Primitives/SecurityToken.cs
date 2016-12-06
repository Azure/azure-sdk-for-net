// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;

    public class SecurityToken
    {
        // per Simple Web Token draft specification
        public const string TokenAudience = "Audience";
        public const string TokenExpiresOn = "ExpiresOn";
        public const string TokenIssuer = "Issuer";
        public const string TokenDigest256 = "HMACSHA256";

        const string InternalExpiresOnFieldName = "ExpiresOn";
        const string InternalAudienceFieldName = TokenAudience;
        const string InternalKeyValueSeparator = "=";
        const string InternalPairSeparator = "&";
        static readonly Func<string, string> Decoder = WebUtility.UrlDecode;
        static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        readonly string token;
        readonly DateTime expiresAtUtc;
        readonly string audience;

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

        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Existing public class, changes will be breaking. Current usage is safe.")]
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

        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Existing public class, changes will be breaking. Current usage is safe.")]
        public SecurityToken(string tokenString)
        {
            if (tokenString == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(tokenString));
            }

            this.token = tokenString;
            this.GetExpirationDateAndAudienceFromToken(tokenString, out this.expiresAtUtc, out this.audience);
        }

        public string Audience
        {
            get
            {
                return this.audience;
            }
        }

        public DateTime ExpiresAtUtc
        {
            get
            {
                return this.expiresAtUtc;
            }
        }

        public object TokenValue
        {
            get { return this.token; }
        }

        protected virtual string ExpiresOnFieldName
        {
            get
            {
                return InternalExpiresOnFieldName;
            }
        }

        protected virtual string AudienceFieldName
        {
            get
            {
                return InternalAudienceFieldName;
            }
        }

        protected virtual string KeyValueSeparator
        {
            get
            {
                return InternalKeyValueSeparator;
            }
        }

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