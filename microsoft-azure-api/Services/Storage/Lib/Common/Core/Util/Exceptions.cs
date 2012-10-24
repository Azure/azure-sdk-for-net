//-----------------------------------------------------------------------
// <copyright file="Exceptions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if RT
    using System.Runtime.InteropServices;
    using System.Net.Http;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Globalization;
#endif

    internal class Exceptions
    {
#if RT
        internal async static Task<StorageException> PopulateStorageExceptionFromHttpResponseMessage(HttpResponseMessage response, RequestResult currentResult)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    currentResult.HttpStatusMessage = response.ReasonPhrase;
                    currentResult.HttpStatusCode = (int)response.StatusCode;
                    currentResult.ServiceRequestID = HttpResponseMessageUtils.GetHeaderSingleValueOrDefault(response.Headers, Constants.HeaderConstants.RequestIdHeader);
                    
                    string tempDate = HttpResponseMessageUtils.GetHeaderSingleValueOrDefault(response.Headers, Constants.HeaderConstants.Date);
                    currentResult.RequestDate = string.IsNullOrEmpty(tempDate) ? DateTime.Now.ToString("R", CultureInfo.InvariantCulture) : tempDate;
                    
                    if (response.Headers.ETag != null)
                    {
                        currentResult.Etag = response.Headers.ETag.ToString();
                    }

                    if (response.Content != null && response.Content.Headers.ContentMD5 != null)
                    {
                        currentResult.ContentMd5 = Convert.ToBase64String(response.Content.Headers.ContentMD5);
                    }
                }
                catch (Exception)
                {
                    // no op
                }

                try
                {
                    Stream errStream = await response.Content.ReadAsStreamAsync();
                    currentResult.ExtendedErrorInformation = StorageExtendedErrorInformation.ReadFromStream(errStream.AsInputStream());
                }
                catch (Exception)
                {
                    // no op
                }

                return new StorageException(currentResult, response.ReasonPhrase, null);
            }
            else
            {
                return null;
            }
        }
#endif

        internal static StorageException GenerateTimeoutException(RequestResult res, Exception inner)
        {
            res.HttpStatusCode = 408; // RequestTimeout
            Exception timeoutEx = new TimeoutException(SR.TimeoutExceptionMessage, inner);

            return new StorageException(res, timeoutEx.Message, timeoutEx)
            {
                IsRetryable = false
            };
        }

#if DNCP
        internal static StorageException GenerateCancellationException(RequestResult res, Exception inner)
        {
            res.HttpStatusCode = 306;
            res.HttpStatusMessage = "Unused";

            OperationCanceledException cancelEx = new OperationCanceledException(SR.OperationCanceled, inner);
            return new StorageException(res, cancelEx.Message, inner) { IsRetryable = false };
        }
#endif
    }
}
