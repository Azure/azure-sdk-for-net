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
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.Dynamic;
    using System.Globalization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Represents an Avro generic record. It can be considered as a set of name-value pairs.
    /// Please, use the <see cref="Microsoft.Hadoop.Avro.AvroSerializer.CreateGeneric"/> method to create the corresponding <see cref="Microsoft.Hadoop.Avro.IAvroSerializer{T}"/>.
    /// </summary>
    public sealed class AvroRecord : DynamicObject
    {
        private readonly object[] values;
        private readonly RecordSchema schema;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvroRecord"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public AvroRecord(Schema.Schema schema)
        {
            this.schema = schema as RecordSchema;
            if (this.schema == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Expected record schema."), "schema");
            }
            this.values = new object[this.schema.Fields.Count];
        }

        /// <summary>
        /// Gets the schema of the record.
        /// </summary>
        public RecordSchema Schema
        {
            get { return this.schema; }
        }

        /// <summary>
        /// Gets or sets the field value with the specified name.
        /// </summary>
        /// <value>
        /// The field value.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns>Field value.</returns>
        /// <exception cref="System.ArgumentException">Thrown when field value is invalid.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when field value is out of range.</exception>
        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Value cannot be null or empty");
                }

                RecordField field = this.GetField(name);
                if (field == null)
                {
                    throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Field with name '{0}' cannot be found.", name));
                }

                return this.values[field.Position];
            }

            set
            {
                RecordField field = this.GetField(name);
                if (field == null)
                {
                    throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Field with name '{0}' cannot be found.", name));
                }

                this.values[field.Position] = value;
            }
        }

        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <typeparam name="T">The type of field.</typeparam>
        /// <param name="name">The name of field.</param>
        /// <returns>Field value.</returns>
        public T GetField<T>(string name)
        {
            object result = this[name];
            return (T)result;
        }

        /// <summary>
        /// Gets or sets the field value with the specified position.
        /// </summary>
        /// <value>
        /// The field value.
        /// </value>
        /// <param name="position">The position.</param>
        /// <returns>Field value.</returns>
        public object this[int position]
        {
            get
            {
                return this.values[position];
            }

            set
            {
                this.values[position] = value;
            }
        }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
        /// <returns>
        /// True if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.).
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="binder"/> is null.</exception>
        public override bool TryGetMember(
            GetMemberBinder binder,
            out object result)
        {
            if (binder == null)
            {
                throw new ArgumentNullException("binder");
            }

            result = null;

            RecordField field = this.GetField(binder.Name);
            if (field == null)
            {
                return false;
            }
            result = this.values[field.Position];
            return true;
        }

        /// <summary>
        /// Provides the implementation for operations that set member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as setting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member to which the value is being assigned. For example, for the statement sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="value">The value to set to the member. For example, for sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, the <paramref name="value" /> is "Test".</param>
        /// <returns>
        /// True if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.).
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="binder"/> is null.</exception>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder == null)
            {
                throw new ArgumentNullException("binder");
            }

            RecordField field = this.GetField(binder.Name);
            if (field == null)
            {
                return false;
            }
            this.values[field.Position] = value;
            return true;
        }

        /// <summary>
        /// Gets the record field.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>Record field.</returns>
        private RecordField GetField(string fieldName)
        {
            RecordField field;
            return this.schema.TryGetField(fieldName, out field)
                ? field
                : null;
        }
    }
}
