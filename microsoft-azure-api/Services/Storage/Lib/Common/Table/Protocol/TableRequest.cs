//-----------------------------------------------------------------------
// <copyright file="TableRequest.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.IO;

    /// <summary>
    /// Provides a set of helper methods for constructing a request against the Table service.
    /// </summary>
#if WINDOWS_RT
    internal
#else
    public
#endif
        static class TableRequest
    {
        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        public static void WriteSharedAccessIdentifiers(SharedAccessTablePolicies sharedAccessPolicies, Stream outputStream)
        {
            Request.WriteSharedAccessIdentifiers(
                sharedAccessPolicies,
                outputStream,
                (policy, writer) =>
                {
                    writer.WriteElementString(
                        Constants.Start,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessStartTime));
                    writer.WriteElementString(
                        Constants.Expiry,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessExpiryTime));
                    writer.WriteElementString(
                        Constants.Permission,
                        SharedAccessTablePolicy.PermissionsToString(policy.Permissions));
                });
        }

        internal static string ExtractEntityIndexFromExtendedErrorInformation(RequestResult result)
        {
            if (result != null && result.ExtendedErrorInformation != null && !string.IsNullOrEmpty(result.ExtendedErrorInformation.ErrorMessage))
            {
                int semiDex = result.ExtendedErrorInformation.ErrorMessage.IndexOf(":");

                if (semiDex > 0 && semiDex < 3)
                {
                    return result.ExtendedErrorInformation.ErrorMessage.Substring(0, semiDex);
                }
            }

            return null;
        }
    }
}
