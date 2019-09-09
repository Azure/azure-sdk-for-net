// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public struct Action
    {
        private string _value;
        internal const string AutoRenewValue = "AutoRenew";
        internal const string EmailContactsValue = "EmailContacts";

        public Action(string Action)
        {
            _value = Action;
        }

        public static readonly Action AutoRenew = new Action(AutoRenewValue);

        public static readonly Action EmailContacts = new Action(EmailContactsValue);

        public override bool Equals(object obj)
        {
            return obj is Action && this.Equals((CertificateKeyType)obj);
        }

        public bool Equals(Action other)
        {
            return string.CompareOrdinal(_value, other._value) == 0;
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(Action a, Action b) => a.Equals(b);

        public static bool operator !=(Action a, Action b) => !a.Equals(b);

        public static implicit operator Action(string value) => new Action(value);

        public static implicit operator string(Action o) => o._value;
    }
}
