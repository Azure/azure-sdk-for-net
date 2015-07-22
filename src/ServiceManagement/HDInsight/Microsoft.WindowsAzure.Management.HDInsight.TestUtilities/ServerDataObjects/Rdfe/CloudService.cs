﻿// Copyright (c) Microsoft Corporation
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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ServerDataObjects.Rdfe
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CloudService : IExtensibleDataObject
    {
        // Properties
        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string GeoRegion { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string Label { get; set; }

        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Needed for serialization. [tgs]")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", 
            Justification = "Part of the contract. [tgs]")]
        [DataMember(Order = 5, EmitDefaultValue = false)]
        public ResourceList Resources { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}