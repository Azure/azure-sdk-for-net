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
    using System.Text;

    /// <summary>
    /// Represents a base JsonItem, all Json parts are derrived from this class.
    /// </summary>
#if Non_Public_SDK
    public abstract class JsonItem
#else
    internal abstract class JsonItem
#endif
    {
        /// <summary>
        /// Returns a property of a Json class if avalalbe.
        /// Other implementations will simply return JsonMissing.
        /// </summary>
        /// <param name="name">
        /// The name of the property.
        /// </param>
        /// <returns>
        /// The JsonItem associated with the property if the implementation
        /// is a class and the property exists, otherwise JsonMissing.
        /// </returns>
        public virtual JsonItem GetProperty(string name)
        {
            return JsonMissing.Singleton;
        }

        /// <summary>
        /// Returns the offset into an array index if the implementation
        /// is a JsonArray.  Other implementations return JsonMissing.
        /// </summary>
        /// <param name="index">
        /// The index into the array.
        /// </param>
        /// <returns>
        /// The JsonItem associated with that index or JsonMissing if this
        /// is not an array or the array is out of bounds.
        /// </returns>
        public virtual JsonItem GetIndex(int index)
        {
            return JsonMissing.Singleton;
        }

        /// <summary>
        /// Gets the number of items in the array.
        /// </summary>
        /// <returns>The number of items in the array.</returns>
        public virtual int Count()
        {
            return 0;
        }

        /// <summary>
        /// Gets a value indicating whether this object represents a parser error.
        /// </summary>
        public virtual bool IsError
        {
            get { return false; }
        }

        /// <summary>
        /// Tries to get the underlying value of a property as a 
        /// Boolean type.
        /// </summary>
        /// <param name="asBool">
        /// The value to set.
        /// </param>
        /// <returns>
        /// True if the method succeeded, otherwise false.
        /// </returns>
        public virtual bool TryGetValue(out bool asBool)
        {
            asBool = false;
            return false;
        }

        /// <summary>
        /// Tries to get the underlying value of a property as a 
        /// long integer type.
        /// </summary>
        /// <param name="asLong">
        /// The value to set.
        /// </param>
        /// <returns>
        /// True if the method succeeded, otherwise false.
        /// </returns>
        public virtual bool TryGetValue(out long asLong)
        {
            asLong = default(long);
            return false;
        }

        /// <summary>
        /// Tries to get the underlying value of a property as a 
        /// double precision floating point type.
        /// </summary>
        /// <param name="asDouble">
        /// The value to set.
        /// </param>
        /// <returns>
        /// True if the method succeeded, otherwise false.
        /// </returns>
        public virtual bool TryGetValue(out double asDouble)
        {
            asDouble = default(double);
            return false;
        }

        /// <summary>
        /// Tries to get the underlying value of a property as a 
        /// string.
        /// </summary>
        /// <param name="asString">
        /// The value to set.
        /// </param>
        /// <returns>
        /// True if the method succeeded, otherwise false.
        /// </returns>
        public virtual bool TryGetValue(out string asString)
        {
            asString = string.Empty;
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this property is a Boolean.
        /// </summary>
        public virtual bool IsBoolean
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is an array.
        /// </summary>
        public virtual bool IsArray
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is an object.
        /// </summary>
        public virtual bool IsObject
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is an integer.
        /// </summary>
        public virtual bool IsInteger
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is a float.
        /// </summary>
        public virtual bool IsFloat
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is a number (either float or integer).
        /// </summary>
        public bool IsNumber
        {
            get
            {
                return this.IsInteger || this.IsFloat;
            }
        }

        /// <summary>
        /// Encodes a string for json consumption.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// A string encoded for Json.
        /// </returns>
        public static string JsonEncodeString(string input)
        {
            if (input.IsNull())
            {
                input = string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append('"');
            foreach (var character in input)
            {
                switch (character)
                {
                    case '"':
                    case '\\':
                    case '/':
                        builder.Append('\\');
                        builder.Append(character);
                        break;
                    case '\b':
                        builder.Append(@"\b");
                        break;
                    case '\f':
                        builder.Append(@"\f");
                        break;
                    case '\n':
                        builder.Append(@"\n");
                        break;
                    case '\r':
                        builder.Append(@"\r");
                        break;
                    case '\t':
                        builder.Append(@"\t");
                        break;
                    default:
                        builder.Append(character);
                        break;
                }
            }
            builder.Append('"');
            return builder.ToString();
        }

        /// <summary>
        /// Gets a value indicating whether this property is a string.
        /// </summary>
        public virtual bool IsString
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property was missing.
        /// </summary>
        public virtual bool IsMissing
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this property is null.
        /// </summary>
        public virtual bool IsNull
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether property is empty (either empty string or empty array).
        /// </summary>
        public virtual bool IsEmpty
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether property is either null or missing.
        /// </summary>
        public bool IsNullOrMissing
        {
            get
            {
                return this.IsMissing || this.IsNull;
            }
        }

        /// <summary>
        /// Gets a value indicating whether property is null, missing or empty.
        /// </summary>
        public bool IsNullMissingOrEmpty
        {
            get
            {
                return this.IsNullOrMissing || this.IsEmpty;
            }
        }

        /// <summary>
        /// Returns the Json representation of this item.
        /// </summary>
        /// <returns>
        /// Json content string representing the item.
        /// </returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
