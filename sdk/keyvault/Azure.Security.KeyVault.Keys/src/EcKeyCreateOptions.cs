// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    public class EcKeyCreateOptions : KeyCreateOptions
    {
        public JsonWebKeyCurveName Curve { get; set; }

        public EcKeyCreateOptions(string name)
            : base(name)
        {
            KeyType = JsonWebKeyType.EllipticCurve;
        }

        public EcKeyCreateOptions(JsonWebKeyCurveName curve, string name, List<string> keyOps, DateTime? notBefore, DateTime? expires, Dictionary<string, string> tags)
            : base(name)
        {
            Curve = curve;
            KeyOps = keyOps;
            KeyType = JsonWebKeyType.EllipticCurve;
            NotBefore = notBefore;
            Expires = expires;
            Tags = new Dictionary<string, string>(tags);
        }
    }
}
