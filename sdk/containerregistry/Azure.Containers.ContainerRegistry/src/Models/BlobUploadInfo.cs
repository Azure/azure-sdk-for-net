// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Models
{
    public class BlobUploadInfo
    {
        internal BlobUploadInfo(string blobLocation)
        {
            // From docstring comments: /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
            // TODO: is there a way to rejig this in the swagger file rather than doing it in code?
            BlobLocation = new Uri(blobLocation.Substring(1));
        }

        public Uri BlobLocation { get; }
    }
}
