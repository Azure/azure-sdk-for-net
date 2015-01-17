// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client.Data
{
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;

    /// <summary>
    /// Class that provides extension methods for parsing jobDetails Submission response payloads. 
    /// </summary>
    internal static class PayloadParsingExtensions
    {
        /// <summary>
        /// Method that determines if a json item is a valid json object.
        /// </summary>
        /// <param name="item">The json item to validate.</param>
        /// <returns>A value indicating if the json item is an json object.</returns>
        public static bool IsValidObject(this JsonItem item)
        {
            return item != null && !item.IsError && !item.IsNullMissingOrEmpty && item.IsObject;
        }

        /// <summary>
        /// Method that determins if a json item is a valid json array.
        /// </summary>
        /// <param name="item">The json item to validate.</param>
        /// <returns>A value indicating if the json item is an array.</returns>
        public static bool IsValidArray(this JsonItem item)
        {
            return item != null && !item.IsError && !item.IsNullOrMissing && item.IsArray;
        }
    }
}
