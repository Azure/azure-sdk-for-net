// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF;
using CoreWCF.Security.Tokens;
using System;
using System.Globalization;
using System.Text;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    // If/when CoreWCF implementation is made public, this internal implementation can be removed
    internal sealed class InitiatorServiceModelSecurityTokenRequirement : ServiceModelSecurityTokenRequirement
    {
        public InitiatorServiceModelSecurityTokenRequirement() : base()
        {
            Properties.Add(IsInitiatorProperty, (object)true);
        }

        public EndpointAddress TargetAddress
        {
            get
            {
                return GetPropertyOrDefault<EndpointAddress>(TargetAddressProperty, null);
            }
            set
            {
                Properties[TargetAddressProperty] = value;
            }
        }

        public Uri Via
        {
            get
            {
                return GetPropertyOrDefault<Uri>(ViaProperty, null);
            }
            set
            {
                Properties[ViaProperty] = value;
            }
        }

        internal TValue GetPropertyOrDefault<TValue>(string propertyName, TValue defaultValue)
        {
            if (!TryGetProperty<TValue>(propertyName, out TValue result))
            {
                result = defaultValue;
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}:", GetType().ToString()));
            foreach (string propertyName in Properties.Keys)
            {
                object propertyValue = Properties[propertyName];
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "PropertyName: {0}", propertyName));
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "PropertyValue: {0}", propertyValue));
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "---"));
            }
            return sb.ToString().Trim();
        }
    }
}
