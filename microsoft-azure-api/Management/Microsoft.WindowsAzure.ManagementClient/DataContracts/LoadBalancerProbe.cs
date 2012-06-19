//-----------------------------------------------------------------------
// <copyright file="InputEndpoint.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the InputEndpoint class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "LoadBalancerProbe", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class LoadBalancerProbe : AzureDataContractBase
    {
        private LoadBalancerProbe() { }

        public LoadBalancerProbe(Protocol protocol)
            :this(protocol, null, null)
        {
        }

        public LoadBalancerProbe(Protocol protocol, int port)
            :this(protocol, null, port)
        {
        }

        public LoadBalancerProbe(Protocol protocol, string path)
            :this(protocol, path, null)
        {
        }

        public LoadBalancerProbe(Protocol protocol, string path, int? port)
        {
            //TODO: Validate params
            this.Protocol = protocol;
            this.Path = path;
            this.Port = port;
        }

        [DataMember(Order=0, IsRequired=false, EmitDefaultValue=false)]
        public string Path { get; private set; }

        [DataMember(Order=1, IsRequired=false, EmitDefaultValue=false)]
        public int? Port { get; private set; }

        [DataMember(Order=2, IsRequired=false, EmitDefaultValue=false)]
        public Protocol Protocol { get; private set; }
    }
}
