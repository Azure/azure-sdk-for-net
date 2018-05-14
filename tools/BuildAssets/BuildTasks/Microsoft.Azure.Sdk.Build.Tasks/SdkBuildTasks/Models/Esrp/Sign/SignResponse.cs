// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignResponse : EsrpServiceModelBase<SignResponse>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("EsrpClientSessionGuid")]
        public string EsrpClientSessionGuid { get; set; }

        [JsonProperty("SubmissionResponses")]
        public List<SubmissionResponse> SubmissionResponses { get; set; }



        public SignResponse()
        {

        }

        public void UpdateSignRequestWithDefaults()
        {

        }

        //public SignResponse FromJson(string json) => JsonConvert.DeserializeObject<SignResponse>(json, this.EsrpModelDeSerializerSetting);

        //public SignResponse FromJsonFile(string jsonFilePath) => FromJson(File.ReadAllText(jsonFilePath));

        //public string ToJson() => JsonConvert.SerializeObject(this, this.EsrpModelSerializerSetting);

    }
    
    public partial class SubmissionResponse
    {
        [JsonProperty("FilesStatusDetail")]
        public List<FilesStatusDetail> FilesStatusDetail { get; set; }

        [JsonProperty("OperationId")]
        public string OperationId { get; set; }

        [JsonProperty("CustomerCorrelationId")]
        public string CustomerCorrelationId { get; set; }

        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("ErrorInfo")]
        public ErrorInfo ErrorInfo { get; set; }

        [JsonProperty("CertificateThumbprint")]
        public object CertificateThumbprint { get; set; }
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

    public partial class FilesStatusDetail
    {
        [JsonProperty("SourceHash")]
        public string SourceHash { get; set; }

        [JsonProperty("HashType")]
        public string HashType { get; set; }

        [JsonProperty("DestinationHash")]
        public string DestinationHash { get; set; }
    }
}
