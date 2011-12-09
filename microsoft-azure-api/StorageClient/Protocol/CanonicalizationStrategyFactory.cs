//-----------------------------------------------------------------------
// <copyright file="CanonicalizationStrategyFactory.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CanonicalizationStrategyFactory class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;

    /// <summary>
    /// Retrieve appropriate version of CanonicalizationStrategy based on the webrequest
    /// for Blob Queue and Table.
    /// </summary>
    internal static class CanonicalizationStrategyFactory
    {
        /// <summary>
        /// Stores the version 1 blob/queue full signing strategy.
        /// </summary>
        private static SharedKeyLiteCanonicalizer blobQueueFullVer1;

        /// <summary>
        /// Stores the version 1 table lite signing strategy.
        /// </summary>
        private static SharedKeyLiteTableCanonicalizer tableLiteVer1;

        /// <summary>
        /// Stores the version 2 blob/queue full signing strategy.
        /// </summary>
        private static SharedKeyCanonicalizer blobQueueFullVer2;

        /// <summary>
        /// Stores the version 1 table full signing strategy.
        /// </summary>
        private static SharedKeyTableCanonicalizer tableFullVer1;

        /// <summary>
        /// Gets the BLOB queue full ver1.
        /// </summary>
        /// <value>The BLOB queue full ver1.</value>
        private static SharedKeyLiteCanonicalizer BlobQueueFullVer1
        {
            get
            {
                if (blobQueueFullVer1 == null)
                {
                    blobQueueFullVer1 = new SharedKeyLiteCanonicalizer();
                }

                return blobQueueFullVer1;
            }
        }

        /// <summary>
        /// Gets the table lite ver1.
        /// </summary>
        /// <value>The table lite ver1.</value>
        private static SharedKeyLiteTableCanonicalizer TableLiteVer1
        {
            get
            {
                if (tableLiteVer1 == null)
                {
                    tableLiteVer1 = new SharedKeyLiteTableCanonicalizer();
                }

                return tableLiteVer1;
            }
        }

        /// <summary>
        /// Gets the table full ver1.
        /// </summary>
        /// <value>The table full ver1.</value>
        private static SharedKeyTableCanonicalizer TableFullVer1
        {
            get
            {
                if (tableFullVer1 == null)
                {
                    tableFullVer1 = new SharedKeyTableCanonicalizer();
                }

                return tableFullVer1;
            }
        }

        /// <summary>
        /// Gets the BLOB queue full ver2.
        /// </summary>
        /// <value>The BLOB queue full ver2.</value>
        private static SharedKeyCanonicalizer BlobQueueFullVer2
        {
            get
            {
                if (blobQueueFullVer2 == null)
                {
                    blobQueueFullVer2 = new SharedKeyCanonicalizer();
                }

                return blobQueueFullVer2;
            }
        }

        /// <summary>
        /// Gets canonicalization strategy for Blob and Queue SharedKey Authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The canonicalization strategy.</returns>
        public static CanonicalizationStrategy GetBlobQueueFullCanonicalizationStrategy(HttpWebRequest request)
        {
            if (IsTargetVersion2(request))
            {
                return BlobQueueFullVer2;
            }
            else
            {
                return BlobQueueFullVer1;
            }
        }

        /// <summary>
        /// Get canonicalization strategy for Tables for SharedKeyLite Authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The canonicalization strategy.</returns>
        public static CanonicalizationStrategy GetTableLiteCanonicalizationStrategy(HttpWebRequest request)
        {
            return TableLiteVer1;
        }

        /// <summary>
        /// Gets the table full canonicalization strategy.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The canonicalization strategy.</returns>
        public static CanonicalizationStrategy GetTableFullCanonicalizationStrategy(HttpWebRequest request)
        {
            return TableFullVer1;
        }

        /// <summary>
        /// Gets the BLOB queue lite canonicalization strategy.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The canonicalization strategy.</returns>
        public static CanonicalizationStrategy GetBlobQueueLiteCanonicalizationStrategy(HttpWebRequest request)
        {
            if (IsTargetVersion2(request))
            {
                // Old SharedKey Authentication is the new SharedKeyLite Authentication
                return BlobQueueFullVer1;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.BlobQSharedKeyLiteUnsuppported, request.Headers[Constants.HeaderConstants.StorageVersionHeader]);
                throw new NotSupportedException(errorMessage);
            }
        }

        /// <summary>
        /// Determines whether [is target version2] [the specified request].
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Returns <c>true</c> if [is target version2] [the specified request]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsTargetVersion2(HttpWebRequest request)
        {
            string version = request.Headers[Constants.HeaderConstants.StorageVersionHeader];
            DateTime versionTime;

            if (DateTime.TryParse(
                version,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal,
                out versionTime))
            {
                DateTime canonicalizationVer2Date = new DateTime(2009, 09, 19);

                return versionTime.Date >= canonicalizationVer2Date;
            }

            return version.Equals("2009-09-19");
        }
    }
}