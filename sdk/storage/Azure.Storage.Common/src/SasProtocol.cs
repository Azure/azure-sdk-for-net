// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Common
{
    public struct SasProtocol : IEquatable<SasProtocol>
    {
        public string Value { get; }
        SasProtocol(string v) => this.Value = v;
        public static SasProtocol None => new SasProtocol(null);
        public static SasProtocol Https => new SasProtocol("https");
        public static SasProtocol HttpsAndHttp => new SasProtocol("https,http");
        public override string ToString() => this.Value ?? "";
        public static bool operator ==(SasProtocol o1, SasProtocol o2) => o1.Value == o2.Value;
        public static bool operator !=(SasProtocol o1, SasProtocol o2) => o1.Value != o2.Value;
        public override int GetHashCode() => this.Value.GetHashCode();
        public override bool Equals(object obj) => obj is SasProtocol other && this.Equals(other);

        public static SasProtocol Parse(string v)
        {
            switch (v)
            {
                case null:
                    return None;
                case "https":
                    return Https;
                case "https,http":
                    return HttpsAndHttp;
                default:
                    throw new ArgumentOutOfRangeException(nameof(v), "Invalid SasProtocol value");
            }
        }

        public bool Equals(SasProtocol other)
            => this.Value == other.Value;
    }
}
