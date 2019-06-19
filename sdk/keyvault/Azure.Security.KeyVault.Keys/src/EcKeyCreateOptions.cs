// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    public class EcKeyCreateOptions : KeyCreateOptions
    {
        public string Name { get; set; }
        public KeyType KeyType { get; private set; }
        public KeyCurveName? Curve { get; set; }
        public bool Hsm { get; private set; }

        public EcKeyCreateOptions(string name, bool hsm, KeyCurveName? curveName = null)
        {
            Name = name;

            if(hsm)
            {
                KeyType = KeyType.EllipticCurveHsm;
            }
            else
            {
                KeyType = KeyType.EllipticCurve;
            }

            if (curveName.HasValue)
            {
                Curve = curveName.Value;
            }
        }
    }
}
