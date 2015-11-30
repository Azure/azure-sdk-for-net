// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Headers
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    internal class CookieState : ICloneable
    {
        private string _name;
        private NameValueCollection _values = HttpValueCollection.Create();

        public CookieState(string name)
            : this(name, String.Empty)
        {
        }

        public CookieState(string name, string value)
        {
            CheckNameFormat(name, "name");
            this._name = name;

            CheckValueFormat(value, "value");
            this.Value = value;
        }

        public CookieState(string name, NameValueCollection values)
        {
            CheckNameFormat(name, "name");
            this._name = name;

            if (values == null)
            {
                throw Error.ArgumentNull("values");
            }
            this.Values.Add(values);
        }

        private CookieState(CookieState source)
        {
            Contract.Requires(source != null);

            this._name = source._name;
            if (source._values != null)
            {
                this.Values.Add(source._values);
            }
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                CheckNameFormat(value, "value");
                this._name = value;
            }
        }

        /// <summary>
        /// If the cookie data is a simple string value then set or retrieve it using the <see cref="Value"/> property.
        /// If the cookie data is structured then use the <see cref="Values"/> property.
        /// </summary>
        public string Value
        {
            get
            {
                return this.Values.Count > 0 ? this.Values.AllKeys[0] : String.Empty;
            }

            set
            {
                CheckValueFormat(value, "value");
                if (this.Values.Count > 0)
                {
                    this.Values.AllKeys[0] = value;
                }
                else
                {
                    this.Values.Add(value, String.Empty);
                }
            }
        }

        /// <summary>
        /// If the cookie data is structured then use the <see cref="Values"/> property for setting and getting individual sub-name/value pairs.
        /// If the cookie data is a simple string value then set or retrieve it using the <see cref="Value"/> property.
        /// </summary>
        public NameValueCollection Values
        {
            get { return this._values; }
        }

        public string this[string subName]
        {
            get { return this.Values[subName]; }
            set { this.Values[subName] = value; }
        }

        public override string ToString()
        {
            return this._name + "=" + (this._values != null ? this._values.ToString() : String.Empty);
        }

        public object Clone()
        {
            return new CookieState(this);
        }

        private static void CheckNameFormat(string name, string parameterName)
        {
            if (name == null)
            {
                throw Error.ArgumentNull("name");
            }

            if (!FormattingUtilities.ValidateHeaderToken(name))
            {
                throw Error.Argument(parameterName, Resources.CookieInvalidName);
            }
        }

        private static void CheckValueFormat(string value, string parameterName)
        {
            // Empty string is a valid cookie value
            if (value == null)
            {
                throw Error.ArgumentNull(parameterName);
            }
        }
    }
}