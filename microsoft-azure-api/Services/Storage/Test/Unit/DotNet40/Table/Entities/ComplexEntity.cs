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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.WindowsAzure.Storage.Table.Entities
{
    public class ComplexEntity : TableEntity
    {
        public const int NumberOfNonNullProperties = 26;
        
        public ComplexEntity()
            : base()
        {
        }

        public ComplexEntity(string pk, string rk)
            : base(pk, rk)
        {
        }

        private DateTimeOffset? dateTimeOffsetNull = null;
        public DateTimeOffset? DateTimeOffsetNull
        {
            get { return dateTimeOffsetNull; }
            set { dateTimeOffsetNull = value; }
        }

        private DateTimeOffset? dateTimeOffsetN = DateTimeOffset.Now;
        public DateTimeOffset? DateTimeOffsetN
        {
            get { return dateTimeOffsetN; }
            set { dateTimeOffsetN = value; }
        }

        private DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
        public DateTimeOffset DateTimeOffset
        {
            get { return dateTimeOffset; }
            set { dateTimeOffset = value; }
        }

        private DateTime? dateTimeNull = null;
        public DateTime? DateTimeNull
        {
            get { return dateTimeNull; }
            set { dateTimeNull = value; }
        }

        private DateTime? dateTimeN = DateTime.UtcNow;
        public DateTime? DateTimeN
        {
            get { return dateTimeN; }
            set { dateTimeN = value; }
        }

        private DateTime dateTime = DateTime.UtcNow;
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private Boolean? boolObjNull = null;
        public Boolean? BoolNull
        {
            get { return boolObjNull; }
            set { boolObjNull = value; }
        }

        private Boolean? boolObjN = false;
        public Boolean? BoolN
        {
            get { return boolObjN; }
            set { boolObjN = value; }
        }

        private Boolean boolObj = false;
        public Boolean Bool
        {
            get { return boolObj; }
            set { boolObj = value; }
        }

        private bool? boolPrimitiveNull = null;
        public bool? BoolPrimitiveNull
        {
            get { return boolPrimitiveNull; }
            set { boolPrimitiveNull = value; }
        }

        private bool? boolPrimitiveN = false;
        public bool? BoolPrimitiveN
        {
            get { return boolPrimitiveN; }
            set { boolPrimitiveN = value; }
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

        private Byte[] binaryNull = null;
        public Byte[] BinaryNull
        {
            get { return binaryNull; }
            set { binaryNull = value; }
        }

        private byte[] binaryPrimitive = new byte[] { 1, 2, 3, 4 };
        public byte[] BinaryPrimitive
        {
            get { return binaryPrimitive; }
            set { binaryPrimitive = value; }
        }

        private double? doublePrimitiveNull = null;
        public double? DoublePrimitiveNull
        {
            get { return doublePrimitiveNull; }
            set { doublePrimitiveNull = value; }
        }

        private double? doublePrimitiveN = (double)1234.1234;
        public double? DoublePrimitiveN
        {
            get { return doublePrimitiveN; }
            set { doublePrimitiveN = value; }
        }

        private double doublePrimitive = (double)1234.1234;
        public double DoublePrimitive
        {
            get { return doublePrimitive; }
            set { doublePrimitive = value; }
        }

        private Double? doubleOBjNull = null;
        public Double? DoubleNull
        {
            get { return doubleOBjNull; }
            set { doubleOBjNull = value; }
        }

        private Double? doubleOBjN = (Double)1234.1234;
        public Double? DoubleN
        {
            get { return doubleOBjN; }
            set { doubleOBjN = value; }
        }

        private Double doubleOBj = (Double)1234.1234;
        public Double Double
        {
            get { return doubleOBj; }
            set { doubleOBj = value; }
        }

        private Guid? guidNull = null;
        public Guid? GuidNull
        {
            get { return guidNull; }
            set { guidNull = value; }
        }

        private Guid? guidN = Guid.NewGuid();
        public Guid? GuidN
        {
            get { return guidN; }
            set { guidN = value; }
        }

        private Guid guid = Guid.NewGuid();
        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        private int? integerPrimitiveNull = null;
        public int? IntegerPrimitiveNull
        {
            get { return integerPrimitiveNull; }
            set { integerPrimitiveNull = value; }
        }

        private int? integerPrimitiveN = 1234;
        public int? IntegerPrimitiveN
        {
            get { return integerPrimitiveN; }
            set { integerPrimitiveN = value; }
        }

        private int integerPrimitive = 1234;
        public int IntegerPrimitive
        {
            get { return integerPrimitive; }
            set { integerPrimitive = value; }
        }

        private Int32? int32Null = null;
        public Int32? Int32Null
        {
            get { return int32Null; }
            set { int32Null = value; }
        }

        private Int32? int32N = 1234;
        public Int32? Int32N
        {
            get { return int32N; }
            set { int32N = value; }
        }

        private Int32 int32 = 1234;
        public Int32 Int32
        {
            get { return int32; }
            set { int32 = value; }
        }

        private long? longPrimitiveNull = null;
        public long? LongPrimitiveNull
        {
            get { return longPrimitiveNull; }
            set { longPrimitiveNull = value; }
        }

        private long? longPrimitiveN = 123456789012;
        public long? LongPrimitiveN
        {
            get { return longPrimitiveN; }
            set { longPrimitiveN = value; }
        }

        private long longPrimitive = 123456789012;
        public long LongPrimitive
        {
            get { return longPrimitive; }
            set { longPrimitive = value; }
        }

        private Int64? int64Null = null;
        public Int64? Int64Null
        {
            get { return int64Null; }
            set { int64Null = value; }
        }

        private Int64? int64N = 123456789012;
        public Int64? Int64N
        {
            get { return int64N; }
            set { int64N = value; }
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
    }
}
