// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Scan
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public partial class ScanFileRequest : EsrpServiceModelBase<ScanFileRequest>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("ContextData")]
        public ContextData ContextData { get; set; }

        [JsonProperty("DriEmail")]
        public List<string> DriEmail { get; set; }

        [JsonProperty("GroupId")]
        public object GroupId { get; set; }

        [JsonProperty("CorrelationVector")]
        public object CorrelationVector { get; set; }

        [JsonProperty("ScanBatches")]
        public List<ScanBatch> ScanBatches { get; set; }


        public ScanFileRequest() { }


    }

    public partial class ContextData
    {
        [JsonProperty("mykey1")]
        public string Mykey1 { get; set; }

        [JsonProperty("myKey2")]
        public string MyKey2 { get; set; }
    }

    public partial class ScanBatch
    {
        [JsonProperty("SourceLocationType")]
        public string SourceLocationType { get; set; }

        [JsonProperty("SourceRootDirectory")]
        public string SourceRootDirectory { get; set; }

        [JsonProperty("ScanRequestFiles")]
        public List<ScanRequestFile> ScanRequestFiles { get; set; }
    }

    public partial class ScanRequestFile
    {
        [JsonProperty("CustomerCorrelationId")]
        public string CustomerCorrelationId { get; set; }

        [JsonProperty("SourceLocation")]
        public string SourceLocation { get; set; }

        [JsonProperty("SizeInBytes")]
        public long SizeInBytes { get; set; }

        [JsonProperty("HashType")]
        public string HashType { get; set; }

        [JsonProperty("SourceHash")]
        public string SourceHash { get; set; }
    }
}
