//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the Utilities class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;
    using System.Xml.Linq;
    using Protocol;

    /// <summary>
    /// General purpose utility methods.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// This is the limit where we allow for the error message returned by the server.
        /// Messages longer than that will be truncated. 
        /// </summary>
        private const int ErrorTextSizeLimit = 16 * 1024;

        /// <summary>
        /// Processes the unexpected status code.
        /// </summary>
        /// <param name="response">The response.</param>
        internal static void ProcessUnexpectedStatusCode(HttpWebResponse response)
        {
            throw new StorageServerException(
                        StorageErrorCode.ServiceBadResponse,
                        response.StatusDescription,
                        response.StatusCode,
                        null);
        }

        /// <summary>
        /// Translates the data service client exception.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>The translated exception.</returns>
        internal static Exception TranslateDataServiceClientException(InvalidOperationException e)
        {
            var dsce = CommonUtils.FindInnerDataServiceClientException(e);

            if (dsce == null)
            {
                return e;
            }

            return TranslateFromHttpStatus(
                (HttpStatusCode)dsce.StatusCode,
                null,
                GetExtendedErrorFromXmlMessage(dsce.Message),
                e);
        }

        /// <summary>
        /// Translates the web exception.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>The translated exception.</returns>
        internal static Exception TranslateWebException(Exception e)
        {
            WebException we = e as WebException;
            if (null == we)
            {
                return e;
            }

            // If the response is not null, let's first see what the status code is.
            if (we.Response != null)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;

                StorageExtendedErrorInformation extendedError =
                    GetExtendedErrorDetailsFromResponse(
                            response.GetResponseStream(),
                            response.ContentLength);
                Exception translatedException = null;
                if (extendedError != null)
                {
                    translatedException = TranslateExtendedError(
                                                    extendedError,
                                                    response.StatusCode,
                                                    response.StatusDescription,
                                                    e);

                    if (translatedException != null)
                    {
                        return translatedException;
                    }
                }

                translatedException = TranslateFromHttpStatus(
                                            response.StatusCode,
                                            response.StatusDescription,
                                            extendedError,
                                            we);

                if (translatedException != null)
                {
                    return translatedException;
                }
            }

            switch (we.Status)
            {
                case WebExceptionStatus.RequestCanceled:
                    return new StorageServerException(
                        StorageErrorCode.ServiceTimeout,
                        "The server request did not complete within the specified timeout",
                        HttpStatusCode.GatewayTimeout,
                        we);

                case WebExceptionStatus.ConnectFailure:
                    return we;

                default:
                    return new StorageServerException(
                        StorageErrorCode.ServiceInternalError,
                        "The server encountered an unknown failure: " + e.Message,
                        HttpStatusCode.InternalServerError,
                        we);
            }
        }

        /// <summary>
        /// Gets the extended error details from response.
        /// </summary>
        /// <param name="httpResponseStream">The HTTP response stream.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <returns>The extended error information.</returns>
        internal static StorageExtendedErrorInformation GetExtendedErrorDetailsFromResponse(
            Stream httpResponseStream,
            long contentLength)
        {
            try
            {
                if (contentLength < 0)
                {
                    contentLength = ErrorTextSizeLimit;
                }

                int bytesToRead = (int)Math.Min((long)contentLength, (long)ErrorTextSizeLimit);
                byte[] responseBuffer = new byte[bytesToRead];
                int bytesRead = CopyStreamToBuffer(httpResponseStream, responseBuffer, (int)bytesToRead);

                using (var ms = new MemoryStream(responseBuffer, 0, bytesRead, false))
                {
                    return GetErrorDetailsFromStream(ms);
                }
            }
            catch (WebException)
            {
                // Ignore network errors when reading error details.
                return null;
            }
            catch (IOException)
            {
                return null;
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the extended error from XML message.
        /// </summary>
        /// <param name="xmlErrorMessage">The XML error message.</param>
        /// <returns>The extended error information.</returns>
        internal static StorageExtendedErrorInformation GetExtendedErrorFromXmlMessage(string xmlErrorMessage)
        {
            string message = null;
            string errorCode = null;

            XName errorCodeName = XName.Get(
                Constants.TableErrorCodeElement,
                Constants.DataWebMetadataNamespace);
            XName messageName = XName.Get(
                Constants.TableErrorMessageElement,
                Constants.DataWebMetadataNamespace);

            using (StringReader reader = new StringReader(xmlErrorMessage))
            {
                XDocument xDocument = null;

                try
                {
                    xDocument = XDocument.Load(reader);
                }
                catch (XmlException)
                {
                    // The XML could not be parsed. This could happen either because the connection 
                    // could not be made to the server, or if the response did not contain the
                    // error details (for example, if the response status code was neither a failure
                    // nor a success, but a 3XX code such as NotModified.
                    return null;
                }

                XElement errorCodeElement = xDocument.Descendants(errorCodeName).FirstOrDefault();

                if (errorCodeElement == null)
                {
                    return null;
                }

                errorCode = errorCodeElement.Value;

                XElement messageElement = xDocument.Descendants(messageName).FirstOrDefault();

                if (messageElement != null)
                {
                    message = messageElement.Value;
                }
            }

            StorageExtendedErrorInformation errorDetails = new StorageExtendedErrorInformation();
            errorDetails.ErrorMessage = message;
            errorDetails.ErrorCode = errorCode;
            return errorDetails;
        }

        /// <summary>
        /// Copies the stream to buffer.
        /// </summary>
        /// <param name="sourceStream">The source stream.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bytesToRead">The bytes to read.</param>
        /// <returns>The number of bytes copied.</returns>
        internal static int CopyStreamToBuffer(Stream sourceStream, byte[] buffer, int bytesToRead)
        {
            int n = 0;
            int amountLeft = bytesToRead;

            do
            {
                n = sourceStream.Read(buffer, bytesToRead - amountLeft, amountLeft);
                amountLeft -= n;
            }
            while (n > 0);

            return bytesToRead - amountLeft;
        }

        /// <summary>
        /// Translates from HTTP status.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="statusDescription">The status description.</param>
        /// <param name="details">The details.</param>
        /// <param name="inner">The inner.</param>
        /// <returns>The translated exception.</returns>
        internal static Exception TranslateFromHttpStatus(
                    HttpStatusCode statusCode,
                    string statusDescription,
                    StorageExtendedErrorInformation details,
                    Exception inner)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Forbidden:
                    return new StorageClientException(
                        StorageErrorCode.AccessDenied,
                        statusDescription,
                        HttpStatusCode.Forbidden,
                        details,
                        inner);

                case HttpStatusCode.Gone:
                case HttpStatusCode.NotFound:
                    return new StorageClientException(
                        StorageErrorCode.ResourceNotFound,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.BadRequest:
                    return new StorageClientException(
                        StorageErrorCode.BadRequest,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.PreconditionFailed:
                case HttpStatusCode.NotModified:
                    return new StorageClientException(
                        StorageErrorCode.ConditionFailed,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.Conflict:
                    return new StorageClientException(
                        StorageErrorCode.ResourceAlreadyExists,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.GatewayTimeout:
                    return new StorageServerException(
                        StorageErrorCode.ServiceTimeout,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    return new StorageClientException(
                        StorageErrorCode.BadRequest,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.InternalServerError:
                    return new StorageServerException(
                        StorageErrorCode.ServiceInternalError,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.NotImplemented:
                    return new StorageServerException(
                        StorageErrorCode.NotImplemented,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.BadGateway:
                    return new StorageServerException(
                        StorageErrorCode.BadGateway,
                        statusDescription,
                        statusCode,
                        details,
                        inner);

                case HttpStatusCode.HttpVersionNotSupported:
                    return new StorageServerException(
                        StorageErrorCode.HttpVersionNotSupported,
                        statusDescription,
                        statusCode,
                        details,
                        inner);
            }

            return null;
        }

        /// <summary>
        /// Extracts an MD5 value from either an v1 or v2 block id.
        /// </summary>
        /// <param name="blockId">The block id containing an MD5.</param>
        /// <returns>MD5 value, or null if invalid format.</returns>
        internal static string ExtractMD5ValueFromBlockID(string blockId)
        {
            if (blockId == null)
            {
                return null;
            }

            if (blockId.Length == Constants.V2MD5blockIdExpectedLength && blockId.StartsWith(Constants.V2blockPrefix))
            {
                return blockId.Substring(Constants.V2MD5blockIdMD5Offset);
            }
            else if (blockId.Length == Constants.V1MD5blockIdExpectedLength && blockId.StartsWith(Constants.V1BlockPrefix))
            {
                return blockId.Substring(Constants.V1BlockPrefix.Length);
            }

            return null;
        }

        /// <summary>
        /// Generates an block id using the given MD5 hash value. The id must be Base64 compatible.
        /// </summary>
        /// <param name="hashVal">The hash value to encode in the block id.</param>
        /// <param name="seqNo">The sequence prefix value.</param>
        /// <returns>The block id.</returns>
        internal static string GenerateBlockIDWithHash(string hashVal, long seqNo)
        {
            byte[] tempArray = new byte[6];

            for (int m = 0; m < 6; m++)
            {
                tempArray[5 - m] = (byte)((seqNo >> (8 * m)) & 0xFF);
            }

            Convert.ToBase64String(tempArray);
            
            return String.Format(Protocol.Constants.V2MD5blockIdFormat, Convert.ToBase64String(tempArray), hashVal);                  
        }

        /// <summary>
        /// Translates the extended error.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="statusDescription">The status description.</param>
        /// <param name="inner">The inner exception.</param>
        /// <returns>The translated exception.</returns>
        private static Exception TranslateExtendedError(
                    StorageExtendedErrorInformation details,
                    HttpStatusCode statusCode,
                    string statusDescription,
                    Exception inner)
        {
            StorageErrorCode errorCode = default(StorageErrorCode);

            switch (details.ErrorCode)
            {
                case StorageErrorCodeStrings.UnsupportedHttpVerb:
                case StorageErrorCodeStrings.MissingContentLengthHeader:
                case StorageErrorCodeStrings.MissingRequiredHeader:
                case StorageErrorCodeStrings.UnsupportedHeader:
                case StorageErrorCodeStrings.InvalidHeaderValue:
                case StorageErrorCodeStrings.MissingRequiredQueryParameter:
                case StorageErrorCodeStrings.UnsupportedQueryParameter:
                case StorageErrorCodeStrings.InvalidQueryParameterValue:
                case StorageErrorCodeStrings.OutOfRangeQueryParameterValue:
                case StorageErrorCodeStrings.InvalidUri:
                case StorageErrorCodeStrings.InvalidHttpVerb:
                case StorageErrorCodeStrings.EmptyMetadataKey:
                case StorageErrorCodeStrings.RequestBodyTooLarge:
                case StorageErrorCodeStrings.InvalidXmlDocument:
                case StorageErrorCodeStrings.InvalidXmlNodeValue:
                case StorageErrorCodeStrings.MissingRequiredXmlNode:
                case StorageErrorCodeStrings.InvalidMd5:
                case StorageErrorCodeStrings.OutOfRangeInput:
                case StorageErrorCodeStrings.InvalidInput:
                case StorageErrorCodeStrings.InvalidMetadata:
                case StorageErrorCodeStrings.MetadataTooLarge:
                case StorageErrorCodeStrings.InvalidRange:
                    errorCode = StorageErrorCode.BadRequest;
                    break;
                case StorageErrorCodeStrings.AuthenticationFailed:
                    errorCode = StorageErrorCode.AuthenticationFailure;
                    break;
                case StorageErrorCodeStrings.ResourceNotFound:
                    errorCode = StorageErrorCode.ResourceNotFound;
                    break;
                case StorageErrorCodeStrings.ConditionNotMet:
                    errorCode = StorageErrorCode.ConditionFailed;
                    break;
                case StorageErrorCodeStrings.ContainerAlreadyExists:
                    errorCode = StorageErrorCode.ContainerAlreadyExists;
                    break;
                case StorageErrorCodeStrings.ContainerNotFound:
                    errorCode = StorageErrorCode.ContainerNotFound;
                    break;
                case BlobErrorCodeStrings.BlobNotFound:
                    errorCode = StorageErrorCode.BlobNotFound;
                    break;
                case BlobErrorCodeStrings.BlobAlreadyExists:
                    errorCode = StorageErrorCode.BlobAlreadyExists;
                    break;
            }

            if (errorCode != default(StorageErrorCode))
            {
                return new StorageClientException(
                                errorCode,
                                statusDescription,
                                statusCode,
                                details,
                                inner);
            }

            switch (details.ErrorCode)
            {
                case StorageErrorCodeStrings.InternalError:
                case StorageErrorCodeStrings.ServerBusy:
                    errorCode = StorageErrorCode.ServiceInternalError;
                    break;
                case StorageErrorCodeStrings.Md5Mismatch:
                    errorCode = StorageErrorCode.ServiceIntegrityCheckFailed;
                    break;
                case StorageErrorCodeStrings.OperationTimedOut:
                    errorCode = StorageErrorCode.ServiceTimeout;
                    break;
            }

            if (errorCode != default(StorageErrorCode))
            {
                return new StorageServerException(
                    errorCode,
                    statusDescription,
                    statusCode,
                    details,
                    inner);
            }

            return null;
        }

        /// <summary>
        /// Gets the error details from stream.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <returns>The error details.</returns>
        private static StorageExtendedErrorInformation GetErrorDetailsFromStream(Stream inputStream)
        {
            StorageExtendedErrorInformation extendedError = new StorageExtendedErrorInformation();

            try
            {
                using (XmlReader reader = XmlReader.Create(inputStream))
                {
                    reader.Read();
                    reader.ReadStartElement(Constants.ErrorRootElement);
                    extendedError.ErrorCode = reader.ReadElementString(Constants.ErrorCode);
                    extendedError.ErrorMessage = reader.ReadElementString(Constants.ErrorMessage);
                    extendedError.AdditionalDetails = new NameValueCollection();

                    // After error code and message we can have a number of additional details optionally followed
                    // by ExceptionDetails element - we'll read all of these into the additionalDetails collection
                    do
                    {
                        if (reader.IsStartElement())
                        {
                            if (string.Compare(reader.LocalName, Constants.ErrorException, StringComparison.Ordinal) == 0)
                            {
                                // Need to read exception details - we have message and stack trace
                                reader.ReadStartElement(Constants.ErrorException);

                                extendedError.AdditionalDetails.Add(
                                    Constants.ErrorExceptionMessage,
                                    reader.ReadElementString(Constants.ErrorExceptionMessage));
                                extendedError.AdditionalDetails.Add(
                                    Constants.ErrorExceptionStackTrace,
                                    reader.ReadElementString(Constants.ErrorExceptionStackTrace));

                                reader.ReadEndElement();
                            }
                            else
                            {
                                string elementName = reader.LocalName;
                                extendedError.AdditionalDetails.Add(elementName, reader.ReadString());
                            }
                        }
                    }
                    while (reader.Read());
                }
            }
            catch (XmlException)
            {
                // If there is a parsing error we cannot return extended error information
                return null;
            }

            return extendedError;
        }
    }
}
