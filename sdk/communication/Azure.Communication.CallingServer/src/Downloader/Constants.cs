// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    internal static class Constants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;

        /// <summary>
        /// ContentDownloader values.
        /// </summary>
        internal static class ContentDownloader
        {
            public const int RetriableStreamRetries = 4;

            internal static class Partition
            {
                public const int DefaultConcurrentTransfersCount = 5;
                public const int MaxDownloadBytes = 256 * MB;
                public const int DefaultInitalDownloadRangeSize = 256 * MB;
            }
        }

        /// <summary>
        /// Header Name constant values.
        /// </summary>
        internal static class HeaderNames
        {
            public const string XMsPrefix = "x-ms-";
            public const string ContentLength = "Content-Length";
            public const string ContentType = "Content-Type";
            public const string Range = "Range";
            public const string ContentRange = "Content-Range";
            public const string XMsHost = XMsPrefix + "host";
        }
    }
}
