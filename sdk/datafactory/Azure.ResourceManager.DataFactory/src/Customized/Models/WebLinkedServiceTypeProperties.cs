// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    public abstract partial class WebLinkedServiceTypeProperties
    {
        /// <summary> Initializes a new instance of <see cref="WebLinkedServiceTypeProperties"/>. </summary>
        /// <param name="uri"> The URL of the web service endpoint, e.g. https://www.microsoft.com . Type: string (or Expression with resultType string). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="uri"/> is null. </exception>
        protected WebLinkedServiceTypeProperties(DataFactoryElement<string> uri)
        {
            Argument.AssertNotNull(uri, nameof(uri));

            Uri = uri;
        }
    }
}
