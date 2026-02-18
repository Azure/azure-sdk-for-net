// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Typespec = Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class WebApiSkill
    {
        /// <summary> Applies to custom skills that connect to external code in an Azure function or some other application that provides the transformations. This value should be the application ID created for the function or app when it was registered with Azure Active Directory. When specified, the custom skill connects to the function or app using a managed ID (either system or user-assigned) of the search service and the access token of the function or app, using this value as the resource id for creating the scope of the access token. </summary>
        [Typespec.CodeGenMember("AuthResourceId")]
        public ResourceIdentifier AuthResourceId { get; set; }

        /// <summary> The headers required to make the http request. </summary>
        public IDictionary<string, string> HttpHeaders { get; }

        /// <summary> The URI of the Web API providing the vectorizer. </summary>
        [Typespec.CodeGenMember("Url")]
        public string Uri { get; set; }
    }
}
