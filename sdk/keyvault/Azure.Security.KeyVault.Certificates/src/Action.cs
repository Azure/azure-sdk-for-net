// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An action that will be executed.
    /// </summary>
    public struct Action
    {
        private readonly string _value;
        internal const string AutoRenewValue = "AutoRenew";
        internal const string EmailContactsValue = "EmailContacts";

        /// <summary>
        /// Initializes a new instance of the Action struct with the specfied value.
        /// </summary>
        public Action(string Action)
        {
            _value = Action;
        }

        /// <summary>
        /// An action that will auto-renew a certificate
        /// </summary>
        public static readonly Action AutoRenew = new Action(AutoRenewValue);

        /// <summary>
        /// An action that will email certificate contacts
        /// </summary>
        public static readonly Action EmailContacts = new Action(EmailContactsValue);

        public override bool Equals(object obj)
        {
            return obj is Action && Equals((CertificateKeyType)obj);
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
