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
    /// The various types of items that the Json parser can parse.
    /// </summary>
#if Non_Public_SDK
    public enum JsonParseType
#else
    internal enum JsonParseType
#endif
    {
        /// <summary>
        /// The start of a json stream.  Content should either be an object or an array.
        /// </summary>
        JsonStream,

        /// <summary>
        /// A Json object.
        /// </summary>
        Object,

        /// <summary>
        /// A Json Array.
        /// </summary>
        Array,

        /// <summary>
        /// A Json number.
        /// </summary>
        Number,

        /// <summary>
        /// A Json string.
        /// </summary>
        String,

        /// <summary>
        /// A Json Boolean value.
        /// </summary>
        Boolean,

        /// <summary>
        /// A Json null value.
        /// </summary>
        Null,

        /// <summary>
        /// A Json value (could be any of the above except JsonStream).
        /// </summary>
        Value
    }

    /// <summary>
    /// Represents a parsing error coming out of the Json Parser.
    /// </summary>
#if Non_Public_SDK
    public class JsonParseError : JsonItem
#else
    internal class JsonParseError : JsonItem
#endif
    {
        /// <summary>
        /// Initializes a new instance of the JsonParseError class.
        /// </summary>
        /// <param name="type">
        /// The type of item that was attempting to be parsed.
        /// </param>
        /// <param name="typeStart">
        /// The starting location for the type of item that was being parsed.
        /// </param>
        /// <param name="errorLocation">
        /// The location where the error occurred.
        /// </param>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public JsonParseError(JsonParseType type, int typeStart, int errorLocation, string message)
        {
            this.ParseType = type;
            this.ParseTypeStart = typeStart;
            this.ParseErrorLocation = errorLocation;
            this.Message = message;
        }

        /// <inheritdoc />
        public override bool IsError
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the type of item that was being parsed.
        /// </summary>
        public JsonParseType ParseType { get; set; }

        /// <summary>
        /// Gets or sets the location where the item being parsed started.
        /// </summary>
        public int ParseTypeStart { get; set; }
        
        /// <summary>
        /// Gets or sets the location where the error occurred.
        /// </summary>
        public int ParseErrorLocation { get; set; }
        
        /// <summary>
        /// Gets or sets the message representing the error.
        /// </summary>
        public string Message { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "Unable to parse the Json data.  The Json parser encountered the following error '{0}' at offset {1} while parsing the {2} that started at location {3}.",
                this.Message,
                this.ParseErrorLocation,
                this.ParseType,
                this.ParseTypeStart);
        }
    }
}
