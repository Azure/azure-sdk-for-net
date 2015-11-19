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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a Json array object.
    /// </summary>
#if Non_Public_SDK
    public class JsonArray : JsonItem
#else
    internal class JsonArray : JsonItem
#endif
    {
        /// <inheritdoc />
        public override JsonItem GetIndex(int index)
        {
            if (index < 0 || index >= this.data.Count())
            {
                return base.GetIndex(index);
            }
            return this.data.ElementAt(index);
        }

        /// <inheritdoc />
        public override int Count()
        {
            return this.data.Count();
        }

        private IEnumerable<JsonItem> data;

        /// <inheritdoc />
        public override bool IsArray
        {
            get { return true; }
        }

        /// <inheritdoc />
        public override bool IsNull
        {
            get { return this.data.IsNull(); }
        }

        /// <inheritdoc />
        public override bool IsEmpty
        {
            get { return !this.data.Any(); }
        }

        /// <summary>
        /// Initializes a new instance of the JsonArray class.
        /// </summary>
        /// <param name="data">
        /// The set of items that constitute the array.
        /// </param>
        public JsonArray(IEnumerable<JsonItem> data)
        {
            this.data = data;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (this.data.IsNull())
            {
                return " null ";
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(" [ ");
            foreach (var jsonItem in this.data)
            {
                if (jsonItem.IsNull())
                {
                    builder.Append(" null ");
                }
                else
                {
                    builder.Append(jsonItem);
                }
            }
            builder.Append(" ] ");
            return builder.ToString();
        }
    }
}
