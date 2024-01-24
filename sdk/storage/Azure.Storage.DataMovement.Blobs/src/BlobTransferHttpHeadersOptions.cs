// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    ///  Represents the options for transferring HttpHeaders from the source to the destination storage resource.
    /// </summary>
    public class BlobTransferHttpHeadersOptions
    {
        /// <summary>
        /// The MIME content type of the blob.
        /// </summary>
        internal string _contentType { get; set; }

#pragma warning disable _cA1819 // Properties should not return arrays
        /// <summary>
        /// An MD5 hash of the blob content. This hash is used to verify the
        /// integrity of the blob during transport.  When this header is
        /// specified, the storage service checks the hash that has arrived
        /// with the one that was sent. If the two hashes do not match, the
        /// operation will fail with error code 400 (Bad Request).
        /// </summary>
        internal byte[] _contentHash { get; set; }

        /// <summary>
        /// Specifies which content encodings have been applied to the blob.
        /// This value is returned to the client when the Get Blob operation
        /// is performed on the blob resource. The client can use this value
        /// when returned to decode the blob content.
        /// </summary>
        internal string _contentEncoding { get; set; }

        /// <summary>
        /// Specifies the natural languages used by this resource.
        /// </summary>
        internal string _contentLanguage { get; set; }
#pragma warning restore _cA1819 // Properties should not return arrays

        /// <summary>
        /// _conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the blob name specified.
        /// </summary>
        internal string _contentDisposition { get; set; }

        /// <summary>
        /// Specify directives for caching mechanisms.
        /// </summary>
        internal string _cacheControl { get; set; }

        /// <summary>
        /// Specifies whether to preserve the HttpHeaders.
        /// </summary>
        internal bool _preserve;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected BlobTransferHttpHeadersOptions()
        {
        }

        /// <summary>
        /// Specifies whether to preserve the HttpHeaders from the source to the destination
        /// storage resource, if the source and destination supports HttpHeaders.
        /// </summary>
        /// <param name="preserve">Defines whether the preserve the HttpHeaders. True to preserve, false to not.</param>
        public BlobTransferHttpHeadersOptions(bool preserve)
        {
            _preserve = preserve;
            _cacheControl = default;
            _contentDisposition = default;
            _contentEncoding = default;
            _contentHash = default;
            _contentLanguage = default;
            _contentType = default;
        }

        /// <summary>
        /// Specifies the custom HttpHeaders to set on the destination
        /// storage resource, if destination supports HttpHeaders.
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="contentHash"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="contentLanguage"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cacheControl"></param>
        public BlobTransferHttpHeadersOptions(
            string contentType,
            byte[] contentHash,
            string contentEncoding,
            string contentLanguage,
            string contentDisposition,
            string cacheControl)
        {
            _preserve = false;
            _cacheControl = default;
            _contentDisposition = default;
            _contentEncoding = default;
            _contentHash = default;
            _contentLanguage = default;
            _contentType = default;
        }
    }
}
