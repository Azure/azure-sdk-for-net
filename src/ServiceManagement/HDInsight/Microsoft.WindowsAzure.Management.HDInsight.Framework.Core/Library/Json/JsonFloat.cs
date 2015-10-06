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
    using System.Globalization;

    /// <summary>
    /// Represents a floating point value in Json.
    /// </summary>
#if Non_Public_SDK
    public class JsonFloat : JsonItem
#else
    internal class JsonFloat : JsonItem
#endif
    {
        private double data;

        /// <inheritdoc />
        public override bool TryGetValue(out double asDouble)
        {
            asDouble = this.data;
            return true;
        }

        /// <inheritdoc />
        public override bool TryGetValue(out string asString)
        {
            asString = this.data.ToString(CultureInfo.InvariantCulture);
            return true;
        }

        /// <inheritdoc />
        public override bool IsFloat
        {
            get { return true; }
        }

        /// <summary>
        /// Initializes a new instance of the JsonFloat class.
        /// </summary>
        /// <param name="data">
        /// The floating point value of the item.
        /// </param>
        public JsonFloat(double data)
        {
            this.data = data;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return " " + this.data.ToString(CultureInfo.InvariantCulture) + " ";
        }
    }
}
