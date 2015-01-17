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
    /// Represents an object (class) in Json.
    /// </summary>
#if Non_Public_SDK
    public class JsonObject : JsonItem
#else
    internal class JsonObject : JsonItem
#endif
    {
        private IDictionary<string, JsonItem> data;

        /// <inheritdoc />
        public override JsonItem GetProperty(string name)
        {
            JsonItem item;
            if (this.data.TryGetValue(name, out item))
            {
                return item;
            }
            return JsonMissing.Singleton;
        }

        /// <summary>
        /// Gets the properties of this object.
        /// </summary>
        public IDictionary<string, JsonItem> Properties
        {
            get
            {
                return this.data;
            }
        }

        /// <inheritdoc />
        public override bool IsObject
        {
            get { return true; }
        }

        /// <inheritdoc />
        public override bool IsNull
        {
            get { return this.data.IsNull(); }
        }

        /// <inheritdoc />
        public override bool IsMissing
        {
            get { return !this.data.Any(); }
        }

        /// <summary>
        /// Initializes a new instance of the JsonObject class.
        /// </summary>
        /// <param name="data">
        /// The property bag that represents the object.
        /// </param>
        public JsonObject(IDictionary<string, JsonItem> data)
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
            builder.Append(" { ");
            bool first = true;
            foreach (var item in this.data)
            {
                if (!first)
                {
                    builder.Append(" , ");
                }
                builder.Append(JsonEncodeString(item.Key));
                builder.Append(" : ");
                builder.Append(item.Value);
                first = false;
            }
            builder.Append(" } ");
            return builder.ToString();
        }
    }
}
