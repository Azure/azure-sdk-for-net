// -----------------------------------------------------------------------------------------
// <copyright file="IgnoreEntity.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.Entities
{
    public class IgnoreEntity : TableEntity
    {
        public const int NumberOfNonNullProperties = 26;

        public IgnoreEntity()
            : base()
        {
        }

        public IgnoreEntity(string pk, string rk)
            : base(pk, rk)
        {
        }

        private DateTimeOffset? dateTimeOffsetNull = null;
        [IgnorePropertyAttribute]
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
        [IgnorePropertyAttribute]
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
        [IgnorePropertyAttribute]
        public Boolean Bool
        {
            get { return boolObj; }
            set { boolObj = value; }
        }

        private bool? boolPrimitiveNull = null;
        [IgnorePropertyAttribute]
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
    }
}
