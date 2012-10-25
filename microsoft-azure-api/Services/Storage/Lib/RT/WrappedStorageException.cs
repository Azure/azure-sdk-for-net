// -----------------------------------------------------------------------------------------
// <copyright file="WrappedStorageException.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    internal class WrappedStorageException : COMException
    {
        public WrappedStorageException(string msg, Exception inner, int hres) : base(msg, inner)
        {
            this.HResult = hres;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        internal static int GenerateHResult(Exception ex, RequestResult reqResult)
        {
            int hResult = WindowsAzureErrorCode.UnknownException;

            if (ex is StorageException)
            {
                int statusCode = (int)reqResult.HttpStatusCode;
                if (statusCode >= 400 && statusCode < 600)
                {
                    hResult = WindowsAzureErrorCode.HttpErrorMask | statusCode;
                }
                else if (ex.InnerException != null)
                {
                    hResult = ex.InnerException.HResult;
                }
            }

            return hResult;
        }
    }
}
