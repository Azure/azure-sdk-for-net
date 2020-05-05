// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    //TODO temp until we merge 73 updates
    internal class UploadFileOptions
    {
        public PathHttpHeaders HttpHeaders { get; set; }
        public Metadata Metadata { get; set; }
        public string Permissions { get; set; }
        public string Umask { get; set; }
        public DataLakeRequestConditions Conditions { get; set; }
    }
}
