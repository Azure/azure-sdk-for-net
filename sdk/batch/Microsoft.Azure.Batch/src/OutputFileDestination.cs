// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    public partial class OutputFileDestination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFileDestination"/> class.
        /// </summary>
        /// <param name="container">A location in Azure blob storage to which files are uploaded.</param>
        public OutputFileDestination(OutputFileBlobContainerDestination container)
        {
            this.Container = container;
        }
    }
}
