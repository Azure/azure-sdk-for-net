//-----------------------------------------------------------------------
// <copyright file="RecoveryActions.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core.Executor
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.IO;

    internal static class RecoveryActions
    {
        internal static void RewindStream<T>(StorageCommandBase<T> cmd, Exception ex, OperationContext ctx)
        {
            RecoveryActions.SeekStream(cmd, 0);
        }

        internal static void SeekStream<T>(StorageCommandBase<T> cmd, long offset)
        {
            CommonUtility.AssertNotNull("cmd", cmd);
            RESTCommand<T> restCMD = (RESTCommand<T>)cmd;
            restCMD.SendStream.Seek(offset, SeekOrigin.Begin);
        }
    }
}
