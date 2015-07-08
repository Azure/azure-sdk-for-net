namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    /// This class contains helper functions for the retry policies.
    /// </summary>
    internal class RetryUtils
    {
        /// <summary>
        /// Determines whether the web exception is transient.
        /// </summary>
        /// <param name="webEx">The web ex.</param>
        /// <returns>Whether or not the exception is transient.</returns>
        public static bool IsTransientWebException(WebException webEx)
        {
            var resp = webEx.Response as HttpWebResponse;
            if (resp.IsNotNull())
            {
                return IsTransientHttpStatusCode(resp.StatusCode);
            }

            switch (webEx.Status)
            {
                case WebExceptionStatus.TrustFailure:
                case WebExceptionStatus.NameResolutionFailure:
                case WebExceptionStatus.ProxyNameResolutionFailure:
                case WebExceptionStatus.MessageLengthLimitExceeded:
                case WebExceptionStatus.RequestProhibitedByCachePolicy:
                case WebExceptionStatus.RequestCanceled:
                case WebExceptionStatus.RequestProhibitedByProxy:
                case WebExceptionStatus.SecureChannelFailure:
                    return false;

                case WebExceptionStatus.ConnectFailure:
                    var socketeEx = FindFirstExceptionOfType<SocketException>(webEx);
                    if (socketeEx.IsNotNull())
                    {
                        return IsTransientSocketException(socketeEx);
                    }
                    return true;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Determines whether the socket exception is transient.
        /// </summary>
        /// <param name="socketeEx">The sockete ex.</param>
        /// <returns>Whether or not the exception is transient.</returns>
        public static bool IsTransientSocketException(SocketException socketeEx)
        {
            switch (socketeEx.SocketErrorCode)
            {
                case SocketError.AlreadyInProgress:
                case SocketError.ConnectionAborted:
                case SocketError.ConnectionReset:
                case SocketError.DestinationAddressRequired:
                case SocketError.Disconnecting:
                case SocketError.Fault:
                case SocketError.InProgress:
                case SocketError.Interrupted:
                case SocketError.IOPending:
                case SocketError.NetworkReset:
                case SocketError.SocketError:
                case SocketError.SystemNotReady:
                case SocketError.TimedOut:
                case SocketError.TryAgain:
                case SocketError.Success:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines whether the HTTP status code is transient.
        /// </summary>
        /// <param name="responseStatusCode">The response status code.</param>
        /// <returns>Whether or not the exception is transient.</returns>
        public static bool IsTransientHttpStatusCode(HttpStatusCode responseStatusCode)
        {
            int statusCode = (int)responseStatusCode;
            if (statusCode >= 500 || statusCode == 409 || statusCode == 449)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Finds the first type of the exception of specified type.
        /// </summary>
        /// <typeparam name="T">The type of exception to look for.</typeparam>
        /// <param name="e">The exception.</param>
        /// <returns>The first instance of the specified exception type or null.</returns>
        public static T FindFirstExceptionOfType<T>(Exception e)
            where T : Exception
        {
            if (e == null)
            {
                return null;
            }
            for (Exception ex = e; ex != null; ex = ex.InnerException)
            {
                if (ex is T)
                {
                    return (T)ex;
                }
            }
            return null;
        }
    }
}
