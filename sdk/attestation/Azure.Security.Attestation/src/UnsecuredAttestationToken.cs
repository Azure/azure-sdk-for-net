// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.Attestation.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a Secured JSON Web Token object. See http://tools.ietf.org/html/rfc7515 for more information.
    /// </summary>
    public class UnsecuredAttestationToken : AttestationToken
    {
        /// <summary>
        /// Creates a new Attestation token based on the supplied body.
        /// </summary>
        /// <param name="body">Body for the newly created token.</param>
        /// <returns></returns>
        public UnsecuredAttestationToken(object body) : base(CreateUnsealedJwt(body))
        {
        }

        /// <summary>
        /// Creates a new unsecured attestation token with an empty body. This is a string constant.
        /// </summary>
        public UnsecuredAttestationToken() : base("eyJhbGciOiJub25lIn0..")
        {
        }

        private static string CreateUnsealedJwt(object body)
        {
            string returnValue = "eyJhbGciOiJub25lIn0.";

            string encodedDocument;
            if (body != null)
            {
                string bodyString = JsonSerializer.Serialize(body);

                // Either base64 or json encode the policy depending on the setting of the encodePolicyBody parameter.
                encodedDocument = Base64Url.EncodeString(bodyString);
            }
            else
            {
                encodedDocument = string.Empty;
            }

            returnValue += encodedDocument;
            returnValue += ".";

            return returnValue;
        }
    }
}
