//-----------------------------------------------------------------------
// <copyright file="TableServiceTable.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
//    Contains code for the TableServiceTable class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Data.Services.Common;

    /// <summary>
    /// Internal table service entity for creating tables.
    /// </summary>
    [DataServiceKey("TableName")]
    internal class TableServiceTable
    {
        /// <summary>
        /// Stores the table name.
        /// </summary>
        private string tableName;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceTable"/> class.
        /// </summary>
        public TableServiceTable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceTable"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the table.</param>
        public TableServiceTable(string name)
        {
            CommonUtils.CheckStringParameter(name, false, "name", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);
            this.TableName = name;
        }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName
        {
            get
            {
                return this.tableName;
            }

            set
            {
                CommonUtils.CheckStringParameter(value, false, "TableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);
                this.tableName = value;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TableServiceTable rhs = obj as TableServiceTable;

            if (rhs == null)
            {
                return false;
            }

            return this.TableName.Equals(rhs.TableName, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.TableName.GetHashCode();
        }
    }
}
