// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables
{
    internal static class TablesExceptionParser
    {
        /// <summary>
        /// Parses a table service exception and populates the ErrorCode and Message, if possible.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static RequestFailedException Parse(RequestFailedException ex)
        {
            if (TryParseOdataError(ex.Message, out string code))
            {
                var parsedException = new RequestFailedException(ex.Status, ex.Message, code, ex);
                foreach (var key in ex.Data.Keys)
                {
                    parsedException.Data[key] = ex.Data[key];
                }
                return parsedException;
            }
            else
            {
                return ex;
            }
        }

        /// <summary>
        /// Parses an odata.error for its 'code'.
        /// </summary>
        private static bool TryParseOdataError(string error, out string errorCode)
        {
            // odaa.error payloads look like this:
            // {"odata.error":{"code":"SomeErrorCode","message":{"lang":"en-US","value":"Some error message.\nRequestId:00000000-0000-0000-0000-000000000000\nTime:2021-01-01T12:00:00.0000000Z"}}}

            var odataProp = "\"odata.error\":{".AsSpan();
            var codeProp = "\"code\":\"".AsSpan();
            var quote = "\"".AsSpan();

            errorCode = null;
            var errorSpan = error.AsSpan();

            // Find the odata.error property
            var i = errorSpan.IndexOf(odataProp);
            if (i < 0)
            {
                return false;
            }

            // Slice the odataProp
            errorSpan = errorSpan.Slice(i + odataProp.Length);

            // Find the code
            i = errorSpan.IndexOf(codeProp);
            if (i < 0)
            {
                return false;
            }

            // Slice the codeProp
            errorSpan = errorSpan.Slice(i + codeProp.Length);

            // Grab the code
            errorCode = errorSpan.Slice(0, errorSpan.IndexOf(quote)).ToString();

            return true;
        }
    }
}
