// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SignRequest : EsrpServiceModelBase<SignRequest>
    {
        #region Properties
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

        [JsonProperty("SignBatches")]
        public List<SignBatch> SignBatches { get; set; }
        #endregion

        public SignRequest()
        {
            Version = "1.0.0";
            ContextData = new ContextData();
            SignBatches = new List<SignBatch>();
            DriEmail = new List<string>() { "abhishah@microsoft.com" };
        }

        public SignRequest(string signBuildName) : this()
        {
            ContextData.SignBuildName = signBuildName;
        }


        private SignRequest CreateSampleRequest()
        {
            SignRequest signReq = new SignRequest();

            signReq.Version = "1.0.0";
            signReq.ContextData = new ContextData("");
            signReq.DriEmail = new List<string>() { "abhishah@microsoft.com" };
            signReq.SignBatches = new List<SignBatch>();

            SignBatch sbatch = new SignBatch();
            sbatch.SourceLocationType = "UNC";
            sbatch.SourceRootDirectory = @"C:\signFiles\Input";
            sbatch.DestinationLocationType = "UNC";
            sbatch.DestinationRootDirectory = @"C:\signFiles\Output";

            SignRequestFile srf = new SignRequestFile();
            srf.Name = "ClientRuntime.dll";
            srf.SourceLocation = @"InputFile\ClientRuntime.dll";
            srf.DestinationLocation = @"OutputFile\ClientRuntime.dll";
            srf.HashType = null;
            srf.SizeInBytes = 0;

            sbatch.SignRequestFiles.Add(srf);

            Operation op = new Operation();
            op.KeyCode = "CodeSignTestCertSha2TestRoot";
            op.OperationCode = "Authenticode_SignTool6.2.9304_NPH";

            sbatch.SigningInfo.Operations.Add(op);

            signReq.SignBatches.Add(sbatch);

            return signReq;
        }
    }

    public partial class ContextData
    {
        [JsonProperty("signbuildname")]
        public string SignBuildName { get; set; }

        [JsonProperty("myKey2")]
        public string MyKey2 { get; set; }

        public ContextData(string buildName)
        {
            SignBuildName = buildName;
        }

        public ContextData() { }
    }

    public partial class SignBatch
    {
        private string _sourceLocationType;
        private string _destinationLocationType;

        const string DEFAULT_LOCATION_TYPE = "UNC";


        [JsonProperty("SourceLocationType")]
        public string SourceLocationType
        {
            get
            {
                if(string.IsNullOrEmpty(_sourceLocationType))
                {
                    _sourceLocationType = DEFAULT_LOCATION_TYPE;
                }

                return _sourceLocationType;
            }
                set { _sourceLocationType = value; }
        }

        [JsonProperty("SourceRootDirectory")]
        public string SourceRootDirectory { get; set; }

        [JsonProperty("DestinationLocationType")]
        public string DestinationLocationType
        {
            get
            {
                if(string.IsNullOrEmpty(_destinationLocationType))
                {
                    _destinationLocationType = DEFAULT_LOCATION_TYPE;
                }

                return _destinationLocationType;
            }
                 set { _destinationLocationType = value; }
        }

        [JsonProperty("DestinationRootDirectory")]
        public string DestinationRootDirectory { get; set; }

        [JsonProperty("SignRequestFiles")]
        public List<SignRequestFile> SignRequestFiles { get; set; }

        [JsonProperty("SigningInfo")]
        public SigningInfo SigningInfo { get; set; }

        public SignBatch()
        {
            SignRequestFiles = new List<SignRequestFile>();

            SigningInfo = new SigningInfo();
        }
    }

    public partial class SignRequestFile
    {
        [JsonProperty("CustomerCorrelationId")]
        public string CustomerCorrelationId { get; set; }

        [JsonProperty("SourceLocation")]
        public string SourceLocation { get; set; }

        [JsonProperty("SourceHash")]
        public string SourceHash { get; set; }

        [JsonProperty("HashType")]
        public object HashType { get; set; }

        [JsonProperty("SizeInBytes")]
        public long SizeInBytes { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DestinationLocation")]
        public string DestinationLocation { get; set; }
    }

    public partial class SigningInfo
    {
        [JsonProperty("Operations")]
        public List<Operation> Operations { get; set; }

        public SigningInfo()
        {
            Operations = new List<Operation>();
        }
    }

    public partial class Operation
    {
        [JsonProperty("KeyCode")]
        public string KeyCode { get; set; }

        [JsonProperty("OperationCode")]
        public string OperationCode { get; set; }

        [JsonProperty("Parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("ToolName")]
        public string ToolName { get; set; }

        [JsonProperty("ToolVersion")]
        public string ToolVersion { get; set; }
    }

    public partial class Parameters
    {
    }
}
