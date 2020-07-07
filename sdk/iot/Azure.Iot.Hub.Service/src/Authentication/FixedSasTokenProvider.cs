// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// Implementation of a shared access signature provider with a fixed token.
    /// </summary>
    internal class FixedSasTokenProvider : ISasTokenProvider
    {
        private readonly string _sharedAccessSignature;

        // Protected constructor, to allow mocking
        protected FixedSasTokenProvider()
        {
        }

        internal FixedSasTokenProvider(string sharedAccessSignature)
        {
            _sharedAccessSignature = sharedAccessSignature;
        }

        public string GetSasToken()
        {
            return _sharedAccessSignature;
        }
    }
}
