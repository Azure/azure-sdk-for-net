// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Test.Shared
{
    public class HttpHeaderParameters
    {
        public string ContentType { get; set; }
        public byte[] ContentHash { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentLanguage { get; set; }
        public string ContentDisposition { get; set; }
        public string CacheControl { get; set; }
    }
}
