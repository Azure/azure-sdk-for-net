//-----------------------------------------------------------------------
// <copyright file="TableResponse.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the TableResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System.IO;
    using System.Net;

    /// <summary>
    /// Provides a set of methods for parsing responses from table operations.
    /// </summary>
    public static class TableResponse
    {
        /// <summary>
        /// Returns extended error information from the storage service, that is in addition to the HTTP status code returned with the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object containing extended error information returned with the response.</returns>
        public static StorageExtendedErrorInformation GetError(HttpWebResponse response)
        {
            return Response.GetError(response);
        }

        /// <summary>
        /// Gets the request ID from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A unique value associated with the request.</returns>
        public static string GetRequestId(HttpWebResponse response)
        {
            return Response.GetRequestId(response);
        }

        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        public static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            return Response.ReadServiceProperties(inputStream);
        }
    }
}
