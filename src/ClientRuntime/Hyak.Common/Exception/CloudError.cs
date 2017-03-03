// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Hyak.Common
{
    /// <summary>
    /// Representation of the error object from the server.
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// Parsed error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Parsed error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Original error body
        /// </summary>
        public string OriginalMessage { get; set; }

        /// <summary>
        /// Original response message body 
        /// </summary>
        public object ResponseBody { get; set; }
    }
}
