// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.Authentication
{
    [CodeGenModel("TokenRequestOptions")]
    internal partial class MixedRealityTokenRequestOptions
    {
        public static MixedRealityTokenRequestOptions GenerateNew()
        {
            return new MixedRealityTokenRequestOptions
            {
                ClientRequestId = GenerateCv()
            };
        }

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');
    }
}
