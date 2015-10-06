// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Headers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    internal class CookieHeaderValue : ICloneable
    {
        private const string ExpiresToken = "expires";
        private const string MaxAgeToken = "max-age";
        private const string DomainToken = "domain";
        private const string PathToken = "path";
        private const string SecureToken = "secure";
        private const string HttpOnlyToken = "httponly";
        private const string DefaultPath = "/";

        private static readonly char[] segmentSeparator = new char[] { ';' };
        private static readonly char[] nameValueSeparator = new char[] { '=' };

        // Use list instead of dictionary since we may have multiple parameters with the same name.
        private Collection<CookieState> _cookies;

        public CookieHeaderValue(string name, string value)
        {
            CookieState cookie = new CookieState(name, value);
            this.Cookies.Add(cookie);
        }

        public CookieHeaderValue(string name, NameValueCollection values)
        {
            CookieState cookie = new CookieState(name, values);
            this.Cookies.Add(cookie);
        }

        /// <summary>
        /// Constructor to be used by parser to create a new instance of this type.
        /// </summary>
        protected CookieHeaderValue()
        {
        }

        private CookieHeaderValue(CookieHeaderValue source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            this.Expires = source.Expires;
            this.MaxAge = source.MaxAge;
            this.Domain = source.Domain;
            this.Path = source.Path;
            this.Secure = source.Secure;
            this.HttpOnly = source.HttpOnly;

            foreach (CookieState cookie in source.Cookies)
            {
                this.Cookies.Add(cookie.Clone<CookieState>());
            }
        }

        public Collection<CookieState> Cookies
        {
            get
            {
                if (this._cookies == null)
                {
                    this._cookies = new Collection<CookieState>();
                }
                return this._cookies;
            }
        }

        public DateTimeOffset? Expires { get; set; }

        public TimeSpan? MaxAge { get; set; }

        public string Domain { get; set; }

        public string Path { get; set; }

        public bool Secure { get; set; }

        public bool HttpOnly { get; set; }

        public CookieState this[string name]
        {
            get
            {
                if (String.IsNullOrEmpty(name))
                {
                    return null;
                }

                CookieState cookie = this.Cookies.FirstOrDefault(c => String.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                if (cookie == null)
                {
                    cookie = new CookieState(name, String.Empty);
                    this.Cookies.Add(cookie);
                }
                return cookie;
            }
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            bool first = true;

            foreach (CookieState cookie in this.Cookies)
            {
                first = AppendSegment(header, first, cookie.ToString(), null);
            }

            if (this.Expires.HasValue)
            {
                first = AppendSegment(header, first, ExpiresToken, FormattingUtilities.DateToString(this.Expires.Value));
            }

            if (this.MaxAge.HasValue)
            {
                first = AppendSegment(header, first, MaxAgeToken, ((int)this.MaxAge.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo));
            }

            if (this.Domain != null)
            {
                first = AppendSegment(header, first, DomainToken, this.Domain);
            }

            if (this.Path != null)
            {
                first = AppendSegment(header, first, PathToken, this.Path);
            }

            if (this.Secure)
            {
                first = AppendSegment(header, first, SecureToken, null);
            }

            if (this.HttpOnly)
            {
                first = AppendSegment(header, first, HttpOnlyToken, null);
            }

            return header.ToString();
        }

        public object Clone()
        {
            return new CookieHeaderValue(this);
        }

        public static bool TryParse(string input, out CookieHeaderValue parsedValue)
        {
            parsedValue = null;
            if (!String.IsNullOrEmpty(input))
            {
                string[] segments = input.Split(segmentSeparator);
                CookieHeaderValue instance = new CookieHeaderValue();
                foreach (string segment in segments)
                {
                    if (!ParseCookieSegment(instance, segment))
                    {
                        return false;
                    }
                }

                // If we didn't find any cookie state name/value pairs then cookie is not valid
                if (instance.Cookies.Count == 0)
                {
                    return false;
                }

                parsedValue = instance;
                return true;
            }

            return false;
        }

        private static bool AppendSegment(StringBuilder builder, bool first, string name, string value)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append("; ");
            }

            builder.Append(name);
            if (value != null)
            {
                builder.Append("=");
                builder.Append(value);
            }
            return first;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "This is a try method where we do want to ignore errors.")]
        private static bool ParseCookieSegment(CookieHeaderValue instance, string segment)
        {
            if (String.IsNullOrWhiteSpace(segment))
            {
                return true;
            }

            string[] nameValue = segment.Split(nameValueSeparator, 2);
            if (nameValue.Length < 1 || String.IsNullOrWhiteSpace(nameValue[0]))
            {
                return false;
            }

            string name = nameValue[0].Trim();
            if (String.Equals(name, ExpiresToken, StringComparison.OrdinalIgnoreCase))
            {
                string value = GetSegmentValue(nameValue, null);
                DateTimeOffset expires;
                if (FormattingUtilities.TryParseDate(value, out expires))
                {
                    instance.Expires = expires;
                    return true;
                }
                return false;
            }
            else if (String.Equals(name, MaxAgeToken, StringComparison.OrdinalIgnoreCase))
            {
                string value = GetSegmentValue(nameValue, null);
                int maxAge;
                if (FormattingUtilities.TryParseInt32(value, out maxAge))
                {
                    instance.MaxAge = new TimeSpan(0, 0, maxAge);
                    return true;
                }
                return false;
            }
            else if (String.Equals(name, DomainToken, StringComparison.OrdinalIgnoreCase))
            {
                instance.Domain = GetSegmentValue(nameValue, null);
                return true;
            }
            else if (String.Equals(name, PathToken, StringComparison.OrdinalIgnoreCase))
            {
                instance.Path = GetSegmentValue(nameValue, DefaultPath);
                return true;
            }
            else if (String.Equals(name, SecureToken, StringComparison.OrdinalIgnoreCase))
            {
                string value = GetSegmentValue(nameValue, null);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    return false;
                }
                instance.Secure = true;
                return true;
            }
            else if (String.Equals(name, HttpOnlyToken, StringComparison.OrdinalIgnoreCase))
            {
                string value = GetSegmentValue(nameValue, null);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    return false;
                }
                instance.HttpOnly = true;
                return true;
            }
            else
            {
                string value = GetSegmentValue(nameValue, null);

                // We read the cookie segment as form data
                try
                {
                    FormDataCollection formData = new FormDataCollection(value);
                    NameValueCollection values = formData.ReadAsNameValueCollection();
                    CookieState cookie = new CookieState(name, values);
                    instance.Cookies.Add(cookie);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private static string GetSegmentValue(string[] nameValuePair, string defaultValue)
        {
            Contract.Assert(nameValuePair != null);
            return nameValuePair.Length > 1 ? FormattingUtilities.UnquoteToken(nameValuePair[1]) : defaultValue;
        }
    }
}