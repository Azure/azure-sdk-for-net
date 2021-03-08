// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Web;
using System.Collections.Generic;
using System.Text.Json;
using System.Runtime.Serialization;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// TODO.
    /// </summary>
    [Serializable]
    public class ManagementException : RequestFailedException, System.Runtime.Serialization.ISerializable
    {
        /// <summary>
        /// Gets and set the Code of the response.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets and set the Target of the response.
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// Gets and set the Details of the response.
        /// </summary>
        public System.Collections.IDictionary Details { get; }

        /// <summary>
        /// Gets and set the AdditionalInfo of the response.
        /// </summary>
        public System.Collections.IDictionary AdditionalInfo { get; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        public ManagementException(string message) : this(0, message)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        /// <param name="innerException"></param>
        public ManagementException(string message, Exception? innerException) : this(0, message, innerException)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="message"> TODO. </param>
        /// <param name="status"></param>
        public ManagementException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"> TODO. </param>
        /// <param name="innerException"></param>
        public ManagementException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="errorCode"> TODO. </param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ManagementException(int status, string message, string? errorCode, Exception? innerException)
            : base(status, message, errorCode, innerException)
        {
            Code = errorCode;
            Target = "";
            Details = GetResponseDetails(message);
            AdditionalInfo = this.Data;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"> TODO. </param>
        protected ManagementException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="streamingContext"> TODO. </param>
        public static System.Collections.IDictionary GetResponseDetails(string streamingContext)
        {
            string rawContent = System.IO.File.ReadAllText(@"C:\Users\v-minghc\Desktop\testdata.json");
            Console.WriteLine(rawContent);
            var jsonObject = JsonSerializer.Deserialize<ManagementException>(rawContent);

            Console.WriteLine(streamingContext);
            return jsonObject.AdditionalInfo;
        }
    }
}
