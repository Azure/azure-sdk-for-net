// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> WebHook activity. </summary>
    public partial class WebHookActivity : ControlActivity
    {
        /// <summary> Represents the headers that will be sent to the request. For example, to set the language and type on a request: "headers" : { "Accept-Language": "en-us", "Content-Type": "application/json" }. Type: string (or Expression with resultType string). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, DataFactoryElement<string>> Headers { get; }
    }
}
