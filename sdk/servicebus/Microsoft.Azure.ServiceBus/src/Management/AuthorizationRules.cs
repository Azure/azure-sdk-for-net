// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class AuthorizationRules : List<AuthorizationRule>, IEquatable<AuthorizationRules>
    {
        private bool RequiresEncryption => this.Count > 0;

        internal XElement Serialize()
        {
            var rules = new XElement(
                XName.Get("AuthorizationRules", ManagementClientConstants.ServiceBusNamespace),
                this.Select(rule => rule.Serialize()));

            return rules;
        }

        internal static AuthorizationRules ParseFromXElement(XElement xElement)
        {
            var rules = new AuthorizationRules();
            var xRules = xElement.Elements(XName.Get("AuthorizationRule", ManagementClientConstants.ServiceBusNamespace));
            rules.AddRange(xRules.Select(rule => AuthorizationRule.ParseFromXElement(rule)));
            return rules;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            unchecked
            {    
                foreach (var rule in this)
                {
                    hash = (hash * 7) + rule.GetHashCode();
                } 
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as AuthorizationRules;
            return this.Equals(other);
        }

        public bool Equals(AuthorizationRules other)
        {
            if (ReferenceEquals(other, null) || this.Count != other.Count)
            {
                return false;
            }

            var cnt = new Dictionary<string, AuthorizationRule>();
            foreach (AuthorizationRule rule in this)
            {
                cnt[rule.KeyName] = rule;
            }

            foreach (AuthorizationRule otherRule in other)
            {
                if (!cnt.TryGetValue(otherRule.KeyName, out var rule) || !rule.Equals(otherRule))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(AuthorizationRules o1, AuthorizationRules o2)
        {
            if (ReferenceEquals(o1, o2))
            {
                return true;
            }

            if (ReferenceEquals(o1, null) || ReferenceEquals(o2, null))
            {
                return false;
            }

            return o1.Equals(o2);
        }

        public static bool operator !=(AuthorizationRules o1, AuthorizationRules o2)
        {
            return !(o1 == o2);
        }
    }
}
