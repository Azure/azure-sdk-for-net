//-----------------------------------------------------------------------
// <copyright file="EventHelper.cs" company="Microsoft">
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
//    Contains code for the EventHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using Protocol;

    /// <summary>
    /// Contains methods for dealing with events.
    /// </summary>
    internal static class EventHelper
    {
        /// <summary>
        /// This sets the event handler with request and response data and 
        /// translates storage exceptions.
        /// </summary>
        /// <param name="req">The request.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <returns>The processed response.</returns>
        internal static WebResponse ProcessWebResponseSync(WebRequest req,  EventHandler<ResponseReceivedEventArgs> handler, object sender)
        {
            WebResponse response = null;
            Exception exception = null;
            try
            {
                response = req.GetResponse();
                return response as HttpWebResponse;
            }
            catch (WebException e)
            {
                response = e.Response;
                exception = Utilities.TranslateWebException(e);
                throw exception;
            }
            finally
            {
                EventHelper.OnResponseReceived(req, response, handler, sender, exception);
            }
        }        
        
        /// <summary>
        /// This sets the event handler with request and response data and 
        /// translates storage exceptions.
        /// </summary>
        /// <param name="req">The request.</param>
        /// <param name="asyncResult">The async result.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <returns>The processed response.</returns>
        internal static WebResponse ProcessWebResponse(WebRequest req, IAsyncResult asyncResult, EventHandler<ResponseReceivedEventArgs> handler, object sender)
        {
            WebResponse response = null;
            Exception exception = null;
            try
            {
                response = req.EndGetResponse(asyncResult);
                return response as HttpWebResponse;
            }
            catch (WebException e)
            {
                response = e.Response;
                exception = Utilities.TranslateWebException(e);
                throw exception;
            }
            finally
            {
                EventHelper.OnResponseReceived(req, response, handler, sender, exception);
            }
        }

        /// <summary>
        /// Set the event handler.
        /// </summary>
        /// <param name="req">The request.</param>
        /// <param name="webResponse">The web response.</param>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The exception.</param>
        private static void OnResponseReceived(
            WebRequest req,
            WebResponse webResponse, 
            EventHandler<ResponseReceivedEventArgs> eventHandler,
            object sender,
            Exception e)
        {
            // Get a Thread safe refence. May be not necessary given that its a function argument.            
            EventHandler<ResponseReceivedEventArgs> temp = eventHandler;

            if (temp != null)
            {
                if (webResponse != null)
                {
                    HttpWebResponse response = webResponse as HttpWebResponse;

                    if (response != null)
                    {
                        string requestId = BlobResponse.GetRequestId(response);
                        var eventArgs = new ResponseReceivedEventArgs()
                        {
                            RequestId = requestId,
                            RequestHeaders = req.Headers,
                            RequestUri = req.RequestUri,
                            ResponseHeaders = response.Headers,
                            StatusCode = response.StatusCode,
                            StatusDescription = response.StatusDescription,
                            Exception = e
                        };

                        temp(sender, eventArgs);
                    }
                }
            }
        }
    }
}

