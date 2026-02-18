// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Specifies the properties for connecting to a user-defined vectorizer. </summary>
    public partial class WebApiVectorizerParameters
    {
        /// <summary> Applies to custom endpoints that connect to external code in an Azure function or some other application that provides the transformations. This value should be the application ID created for the function or app when it was registered with Azure Active Directory. When specified, the vectorization connects to the function or app using a managed ID (either system or user-assigned) of the search service and the access token of the function or app, using this value as the resource id for creating the scope of the access token. </summary>
        [CodeGenMember("AuthResourceId")]
        public Core.ResourceIdentifier AuthResourceId { get; set; }
    }
}
