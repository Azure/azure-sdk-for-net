// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    public class EcKeyCreateOptions : KeyCreateOptions
    {
        public KeyCurveName Curve { get; set; }
        public KeyType KeyType { get; set; }

        public EcKeyCreateOptions()
        {
            KeyType = KeyType.EllipticCurve;
        }

        public EcKeyCreateOptions(KeyCurveName curve, List<KeyOperations> keyOps, DateTimeOffset? notBefore, DateTimeOffset? expires, Dictionary<string, string> tags)
        {
            Curve = curve;
            KeyOperations = keyOps;
            KeyType = KeyType.EllipticCurve;
            NotBefore = notBefore;
            Expires = expires;
            Tags = new Dictionary<string, string>(tags);
        }
    }
}
