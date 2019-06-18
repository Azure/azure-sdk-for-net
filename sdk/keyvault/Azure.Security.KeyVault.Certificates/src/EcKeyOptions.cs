// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class EcKeyOptions : KeyOptions
    {
        public KeyCurveName Curve { get; set; }
        public bool HSM { get; set; }

        public EcKeyOptions(bool hsm)
        {
            if(hsm)
            {
                KeyType = KeyType.EllipticCurveHsm;
            }
            else
            {
                KeyType = KeyType.EllipticCurve;
            }
        }
    }
}
