// -----------------------------------------------------------------------------------------
// <copyright file="ComplexEntity.cs" company="Microsoft">
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace Microsoft.WindowsAzure.Storage.Table.DataServices.Entities
{
    public class ComplexEntity : TableServiceEntity
    {
        public ComplexEntity()
            : base()
        {
        }

        public ComplexEntity(string pk, string rk)
            : base(pk, rk)
        {
        }

        private DateTime dateTime = DateTime.Now;
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private Boolean boolObj = false;
        public Boolean Bool
        {
            get { return boolObj; }
            set { boolObj = value; }
        }

        private bool boolPrimitive = false;
        public bool BoolPrimitive
        {
            get { return boolPrimitive; }
            set { boolPrimitive = value; }
        }

        private Byte[] binary = new Byte[] { 1, 2, 3, 4 };
        public Byte[] Binary
        {
            get { return binary; }
            set { binary = value; }
        }

        private byte[] binaryPrimitive = new byte[] { 1, 2, 3, 4 };
        public byte[] BinaryPrimitive
        {
            get { return binaryPrimitive; }
            set { binaryPrimitive = value; }
        }

        private double doublePrimitive = (double)1234.1234;
        public double DoublePrimitive
        {
            get { return doublePrimitive; }
            set { doublePrimitive = value; }
        }

        private Double doubleOBj = (Double)1234.1234;
        public Double Double
        {
            get { return doubleOBj; }
            set { doubleOBj = value; }
        }

        private Guid guid = Guid.NewGuid();
        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        private int integerPrimitive = 1234;
        public int IntegerPrimitive
        {
            get { return integerPrimitive; }
            set { integerPrimitive = value; }
        }

        private Int32 int32 = 1234;
        public Int32 Int32
        {
            get { return int32; }
            set { int32 = value; }
        }

        private long longPrimitive = 123456789012;
        public long LongPrimitive
        {
            get { return longPrimitive; }
            set { longPrimitive = value; }
        }

        private Int64 int64 = 123456789012;
        public Int64 Int64
        {
            get { return int64; }
            set { int64 = value; }
        }

        private string stringObj = "test";
        public string String
        {
            get { return stringObj; }
            set { stringObj = value; }
        }

        public static void AssertEquality(ComplexEntity a, ComplexEntity b)
        {
            Assert.AreEqual(a.String, b.String);
            Assert.AreEqual(a.Int64, b.Int64);
            Assert.AreEqual(a.LongPrimitive, b.LongPrimitive);
            Assert.AreEqual(a.Int32, b.Int32);
            Assert.AreEqual(a.IntegerPrimitive, b.IntegerPrimitive);
            Assert.AreEqual(a.Guid, b.Guid);
            Assert.AreEqual(a.Double, b.Double);
            Assert.AreEqual(a.DoublePrimitive, b.DoublePrimitive);
            Assert.AreEqual(a.BinaryPrimitive, b.BinaryPrimitive);
            Assert.AreEqual(a.Binary, b.Binary);
            Assert.AreEqual(a.BoolPrimitive, b.BoolPrimitive);
            Assert.AreEqual(a.Bool, b.Bool);
            Assert.AreEqual(a.DateTime, b.DateTime);

            Assert.AreEqual(a.PartitionKey, b.PartitionKey);
            Assert.AreEqual(a.RowKey, b.RowKey);
        }
    }
}
