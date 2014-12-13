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
namespace Microsoft.Hadoop.Avro.Schema
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a name of the schema. For details, please see <a href="http://avro.apache.org/docs/current/spec.html#Names">the specification</a>.
    /// </summary>
    internal sealed class SchemaName : IComparable<SchemaName>, IEquatable<SchemaName>
    {
        private static readonly Regex NamePattern = new Regex("^[A-Za-z_][A-Za-z0-9_]*$");
        private static readonly Regex NamespacePattern = new Regex("^([A-Za-z_][A-Za-z0-9_]*)?(?:\\.[A-Za-z_][A-Za-z0-9_]*)*$");

        private readonly string name;
        private readonly string @namespace;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SchemaName" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SchemaName(string name) : this(name, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaName" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="namespace">The namespace.</param>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="name"/> is empty or null.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when any argument is invalid.</exception>
        public SchemaName(string name, string @namespace)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Name is not allowed to be null or empty."), "name");
            }

            this.@namespace = @namespace ?? string.Empty;

            int lastDot = name.LastIndexOf('.');
            if (lastDot == name.Length - 1)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid name specified '{0}'.", name));
            }

            if (lastDot != -1)
            {
                this.name = name.Substring(lastDot + 1, name.Length - lastDot - 1);
                this.@namespace = name.Substring(0, lastDot);
            }
            else
            {
                this.name = name;
            }

            this.CheckNameAndNamespace();
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        ///     Gets the namespace.
        /// </summary>
        public string Namespace
        {
            get { return this.@namespace; }
        }

        /// <summary>
        ///     Gets the full name.
        /// </summary>
        public string FullName
        {
            get { return string.IsNullOrEmpty(this.@namespace) ? this.name : this.@namespace + "." + this.name; }
        }

        /// <summary>
        ///     Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     A 32-bit signed integer that indicates the relative order of the objects being compared.
        ///     The return value has the following meanings: Value Meaning Less than zero This object is less than the
        ///     <paramref
        ///         name="other" />
        ///     parameter.
        ///     Zero This object is equal to <paramref name="other" />.
        ///     Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(SchemaName other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(this.FullName, other.FullName, StringComparison.Ordinal);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     True if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(SchemaName other)
        {
            return this.CompareTo(other) == 0;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="System.Object" /> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.CompareTo(obj as SchemaName) == 0;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.FullName.GetHashCode();
        }

        private void CheckNameAndNamespace()
        {
            if (!NamePattern.IsMatch(this.name))
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Name '{0}' contains invalid characters.", this.name));
            }

            if (!NamespacePattern.IsMatch(this.@namespace))
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Namespace '{0}' contains invalid characters.", this.@namespace));
            }
        }
    }
}
