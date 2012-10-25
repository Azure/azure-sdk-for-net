// -----------------------------------------------------------------------------------------
// <copyright file="UnionEnitity.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace Microsoft.WindowsAzure.Storage.Table.DataServices.Entities
{
    class UnionEnitity : TableServiceEntity
    {
        public UnionEnitity()
            : base()
        {
        }

        public UnionEnitity(string pk, string rk)
            : base(pk, rk)
        {
        }

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }

        public void Randomize()
        {
            A = Guid.NewGuid().ToString();
            B = Guid.NewGuid().ToString();
            C = Guid.NewGuid().ToString();
            D = Guid.NewGuid().ToString();
            E = Guid.NewGuid().ToString();
            F = Guid.NewGuid().ToString();
        }
    }
}
