// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.ContentSafety.Tests
{
    public class ContentSafetyClientTestEnvironment
        : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTENT_SAFETY_ENDPOINT");

        public string Key => GetRecordedVariable("CONTENT_SAFETY_KEY", options => options.IsSecret());

        public string SignedMediaUri => GetRecordedVariable("CONTENT_SAFETY_SIGNED_MEDIA_URI", options => options.IsSecret(SignedMediaPlaceholder));

        public string UnsignedMediaUri => GetRecordedVariable("CONTENT_SAFETY_UNSIGNED_MEDIA_URI", options => options.IsSecret(UnsignedMediaPlaceholder));

        public const string SignedMediaPlaceholder = "https://fake_storage.blob.core.windows.net/provenance-test/signed.png";

        public const string UnsignedMediaPlaceholder = "https://fake_storage.blob.core.windows.net/provenance-test/unsigned.png";
    }
}
