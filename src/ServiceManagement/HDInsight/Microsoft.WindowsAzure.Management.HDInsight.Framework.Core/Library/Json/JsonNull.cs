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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json
{
    /// <summary>
    /// Represents as null value in Json.
    /// </summary>
#if Non_Public_SDK
    public class JsonNull : JsonItem
#else
    internal class JsonNull : JsonItem
#endif
    {
        private static JsonNull singleton = new JsonNull();

        /// <summary>
        /// Gets the single standard instance of a JsonNull.
        /// </summary>
        public static JsonNull Singleton
        {
            get { return singleton;  }
        }

        /// <inheritdoc />
        public override bool IsNull
        {
            get { return true; }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return " null ";
        }
    }
}
