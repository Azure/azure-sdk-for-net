// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate along with its current policy
    /// </summary>
    public class CertificateWithPolicy : Certificate
    {
        /// <summary>
        /// The current policy for the certificate
        /// </summary>
        public CertificatePolicy Policy { get; private set; }

        private const string PolicyPropertyName = "policy";

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case PolicyPropertyName:
                    Policy = new CertificatePolicy();
                    ((IJsonDeserializable)Policy).ReadProperties(prop.Value);
                    break;
                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }

}
