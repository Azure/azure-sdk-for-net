//-----------------------------------------------------------------------
// <copyright file="StorageExtendedErrorInformation.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the StorageExtendedErrorInformation class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents extended error information returned by the Windows Azure storage services.
    /// </summary>
    [Serializable]
    public class StorageExtendedErrorInformation
    {
        /// <summary>
        /// Gets the storage service error code.
        /// </summary>
        /// <value>The storage service error code.</value>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Gets the storage service error message.
        /// </summary>
        /// <value>The storage service error message.</value>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets additional error details.
        /// </summary>
        /// <value>The additional error details.</value>
        public NameValueCollection AdditionalDetails { get; internal set; }
    }
}