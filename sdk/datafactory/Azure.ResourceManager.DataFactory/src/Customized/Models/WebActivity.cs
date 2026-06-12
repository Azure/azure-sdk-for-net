// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
    public partial class WebActivity
    {
        /// <summary> Represents the headers that will be sent to the request. For example, to set the language and type on a request: "headers" : { "Accept-Language": "en-us", "Content-Type": "application/json" }. Type: string (or Expression with resultType string). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, DataFactoryElement<string>> Headers { get; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public IList<DataFactoryLinkedServiceReference> LinkedServices { get; } = new List<DataFactoryLinkedServiceReference>();
    }
}
