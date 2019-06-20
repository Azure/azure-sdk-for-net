// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Inherits HttpRequestException adding HttpStatusCode to the exception.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Design",
        "CA1032:ImplementStandardExceptionConstructors"),
     System.Diagnostics.CodeAnalysis.SuppressMessage(
         "Microsoft.Usage",
         "CA2237:MarkISerializableTypesWithSerializable",
         Justification = "HttpRequestException hides the constructor needed for serialization.")]
    public class HttpRequestWithStatusException : HttpRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestWithStatusException"/> class.
        /// </summary>
        public HttpRequestWithStatusException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestWithStatusException"/> class
        /// with a specific message that describes the current exception.
        /// </summary>
        /// <param name="message">A message that describes the current exception.</param>
        public HttpRequestWithStatusException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestWithStatusException"/> class
        /// with a specific message that describes the current exception and an inner
        /// exception.
        /// </summary>
        /// <param name="message">A message that describes the current exception.</param>
        /// <param name="inner">The inner exception.</param>
        public HttpRequestWithStatusException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}