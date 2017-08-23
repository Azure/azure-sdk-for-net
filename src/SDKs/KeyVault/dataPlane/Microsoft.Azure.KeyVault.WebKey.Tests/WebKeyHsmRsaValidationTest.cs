// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyHsmRsaValidationTest
    {
        string keyWithoutT = "{\"kid\":\"key_id\",\"kty\":\"RSA-HSM\",\"key_ops\":[\"encrypt\",\"decrypt\"],\"n\":\"1_6ZtP288hEkKML-L6nFyZh1PD1rmAgwbbwjEvTSDK_008BYWhjp_6ULy9BhWtRIytNkPkm9gzaBTrCpp-vyDXPGa836Htp-w8u5JmxoUZchJh576m3m-8ZYWTmZSAp5SpruyKAmLSxPJHEWPXQntnmuTMjb9HBT9Ltrwc0ZDk-jsMLYunDJrNmrRUxQgb0zQ_Tl5fJjj8j-0KVx2RXtbfWFvf5fRdBYyP3m0aUpoopQPwtXszD2LcSKMJ_TnmnvMWr8MOA5aRlBaGdBk7zBgRafvDPam3Q2AvFA9mfcAVncpfZ3JFm73VARw6MofXtRqOHtZ7y4oNbY95xXwU2r6w\",\"e\":\"AQAB\"}";
        string keyWithT =    "{\"kid\":\"key_id\",\"kty\":\"RSA-HSM\",\"key_ops\":[\"encrypt\",\"decrypt\"],\"n\":\"1_6ZtP288hEkKML-L6nFyZh1PD1rmAgwbbwjEvTSDK_008BYWhjp_6ULy9BhWtRIytNkPkm9gzaBTrCpp-vyDXPGa836Htp-w8u5JmxoUZchJh576m3m-8ZYWTmZSAp5SpruyKAmLSxPJHEWPXQntnmuTMjb9HBT9Ltrwc0ZDk-jsMLYunDJrNmrRUxQgb0zQ_Tl5fJjj8j-0KVx2RXtbfWFvf5fRdBYyP3m0aUpoopQPwtXszD2LcSKMJ_TnmnvMWr8MOA5aRlBaGdBk7zBgRafvDPam3Q2AvFA9mfcAVncpfZ3JFm73VARw6MofXtRqOHtZ7y4oNbY95xXwU2r6w\",\"e\":\"AQAB\",\"key_hsm\":\"T-TOKEN\"}";

        [Fact]
        public void RsaHsmValidation()
        {
            var keyNoT = JsonConvert.DeserializeObject<JsonWebKey>(keyWithoutT);
            var keyT = JsonConvert.DeserializeObject<JsonWebKey>(keyWithT);

            Assert.True(!keyNoT.IsValid());
            Assert.False(keyNoT.HasPrivateKey());

            Assert.True(keyT.IsValid());
            Assert.False(keyT.HasPrivateKey());
        }

        [Fact]
        public void RsaHsmHashCode()
        {
            var keyNoT = JsonConvert.DeserializeObject<JsonWebKey>(keyWithoutT);
            var keyT = JsonConvert.DeserializeObject<JsonWebKey>(keyWithT);

            Assert.NotEqual(keyT.GetHashCode(), keyNoT.GetHashCode());

            // Compare hash codes for unequal JWK that would not map to the same hash
            Assert.NotEqual(keyT.GetHashCode(), new JsonWebKey() { Kid = keyT.Kid, T = keyT.T }.GetHashCode());
            Assert.NotEqual(keyT.GetHashCode(), new JsonWebKey() { Kid = keyT.Kid, Kty = keyT.Kty }.GetHashCode());
            Assert.NotEqual(keyNoT.GetHashCode(), new JsonWebKey().GetHashCode());

            // Compare hash codes for unequal JWK that would map to the same hash
            Assert.Equal(keyT.GetHashCode(),
                    new JsonWebKey() { Kid = keyT.Kid, T = keyT.T, Kty = keyT.Kty }.GetHashCode());
            Assert.Equal(keyNoT.GetHashCode(), new JsonWebKey() { Kid = keyT.Kid }.GetHashCode());
        }
    }
}
