// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Common.Models.Esrp
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class ScanFileResponse : EsrpServiceModelBase<ScanFileResponse>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("EsrpClientSessionGuid")]
        public string EsrpClientSessionGuid { get; set; }

        [JsonProperty("SubmissionResponses")]
        public List<SubmissionResponse> SubmissionResponses { get; set; }

        public ScanFileResponse() { }
    }

    public partial class SubmissionResponse
    {
        [JsonProperty("FileHash")]
        public string FileHash { get; set; }

        [JsonProperty("FileHashType")]
        public string FileHashType { get; set; }

        [JsonProperty("OperationId")]
        public string OperationId { get; set; }

        [JsonProperty("CustomerCorrelationId")]
        public string CustomerCorrelationId { get; set; }

        [JsonProperty("StatusCode", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusCode { get; set; }

        [JsonProperty("ErrorInfo")]
        public ErrorInfo ErrorInfo { get; set; }
    }

    public partial class ErrorInfo
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("innerError")]
        public ErrorInfo InnerError { get; set; }
    }

    public partial class Details
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("keyCode")]
        public string KeyCode { get; set; }
    }
}
