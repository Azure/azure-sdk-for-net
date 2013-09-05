//-----------------------------------------------------------------------
// <copyright file="ShapeEntity.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Storage.Table.Entities
{
    public class ShapeEntity
    {
        public ShapeEntity()
        {
        }

        public ShapeEntity(string partitionKey, string rowKey, string name, int length, int breadth)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
            this.Name = name;
            this.Length = length;
            this.Breadth = breadth;
        }

        public string PartitionKey;
        public string RowKey;
        public string Name { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
    }
}
