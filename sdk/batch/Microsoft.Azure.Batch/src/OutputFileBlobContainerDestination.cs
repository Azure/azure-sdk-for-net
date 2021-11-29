using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
	public partial class OutputFileBlobContainerDestination
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFileBlobContainerDestination"/> class.
        /// </summary>
        /// <param name='containerUrl'>The URL of the container within Azure Blob Storage to which to upload the file(s).</param>
        /// <param name='identityReference'>The reference to the user assigned identity to use to access Azure Blob Storage specified by containerUrl</param>
        /// <param name='path'>The destination blob or virtual directory within the Azure Storage container to which to upload the file(s).</param>
        public OutputFileBlobContainerDestination(
            string containerUrl,
            ComputeNodeIdentityReference identityReference,
            string path = default(string))
            : this(containerUrl, path)
        {
            IdentityReference = identityReference;
        }
    }
}
