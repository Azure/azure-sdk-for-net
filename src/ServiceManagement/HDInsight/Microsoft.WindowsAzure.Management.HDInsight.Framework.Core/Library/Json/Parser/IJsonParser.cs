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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.Parser
{
    /// <summary>
    /// The internal interface for the Json parser and it's various associate parsers.
    /// </summary>
#if Non_Public_SDK
    public interface IJsonParser
#else
    internal interface IJsonParser
#endif
    {
        /// <summary>
        /// Consumes the next JsonItem in the stream and returns it.
        /// </summary>
        /// <returns>
        /// The next item in the stream or a parse error if no item could be parsed.
        /// </returns>
        JsonItem ParseNext();
    }
}
