// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> The details of the HTTP request. </summary>
    public partial class ResourceHttpRequest
    {
        [CodeGenMember("Method")]
        internal string MethodString { get; }

        /// <summary> The request method. </summary>
        public RequestMethod Method
        {
            get
            {
                _method ??= new RequestMethod(MethodString);
                return _method.Value;
            }
        }
        private RequestMethod? _method;
    }
}