// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Search.Documents
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AzureSearchDocumentsContext
    {
        private AzureSearchDocumentsContext _azureSearchDocumentsContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureSearchDocumentsContext Default => _azureSearchDocumentsContext ??= new();
    }
}
