// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Path
{
    /// <summary>
    /// Support for adding built-in values to binding data.
    /// Don't add new resolvers here. Instead, add it to <see cref="SystemBindingData"/>
    /// </summary>
    [Obsolete("Use SystemBindingData instead")]
    internal abstract class BindingParameterResolver
    {
        private static Collection<BindingParameterResolver> _resolvers = new Collection<BindingParameterResolver>()
        {
            new RandGuidResolver(),
            new DateTimeResolver(),
        };

        public abstract string Name { get; }

        public static bool IsSystemParameter(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            BindingParameterResolver resolver = null;
            return TryGetResolver(value, out resolver);
        }

        public static bool TryGetResolver(string value, out BindingParameterResolver resolver)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            resolver = _resolvers.FirstOrDefault(p => value.StartsWith(p.Name, StringComparison.OrdinalIgnoreCase));
            return resolver != null;
        }

        public abstract string Resolve(string value);

        protected string GetFormatOrNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!value.StartsWith(Name, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The value specified is not a '{0}' binding parameter.", Name), nameof(value));
            }

            if (value.Length > Name.Length && value[Name.Length] == ':')
            {
                // we have a value of format <Name>:<Format>
                // parse out everything after the first colon
                int idx = Name.Length;
                return value.Substring(idx + 1);
            }

            return null;
        }

        // This is an alias for 'sys.randguid'
        private class RandGuidResolver : BindingParameterResolver
        {
            public override string Name
            {
                get
                {
                    return "rand-guid";
                }
            }

            public override string Resolve(string value)
            {
                string format = GetFormatOrNull(value);
                var val = SystemBindingData.RandGuid;
                return BindingDataPathHelper.ConvertParameterValueToString(val, format);
            }
        }

        // This can't be aliases to 'sys.UtcNow' because
        // 'sys.UtcNow' always resolves to DateTime.UtcNow.
        // But 'datetime' may either resolve to user bidning data or to DateTime.UtcNow.
        private class DateTimeResolver : BindingParameterResolver
        {
            public override string Name
            {
                get
                {
                    return "datetime";
                }
            }

            public override string Resolve(string value)
            {
                string format = GetFormatOrNull(value);
                var val = SystemBindingData.UtcNow;
                return BindingDataPathHelper.ConvertParameterValueToString(val, format);
            }
        }
    }
}
