// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects
{
    using System.IO;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;

    public class ClusterProvisioningServerPayloadConverter
    {
        public T DeserializeChangeRequest<T>(string payload) where T : UserChangeRequest
        {
            T request;
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(payload);
                writer.Flush();
                stream.Flush();
                stream.Position = 0;
                request = (T)ser.ReadObject(stream);
            }
            return request;
        }

        public string SerailizeChangeRequestResponse(PassthroughResponse response)
        {
            string result;
            DataContractSerializer ser = new DataContractSerializer(typeof(PassthroughResponse));
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                ser.WriteObject(stream, response);
                stream.Flush();
                stream.Position = 0;
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
