// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> Azure Data Factory secure string definition. The string value will be masked with asterisks '*' during Get or List API calls. </summary>
    [PropertyReferenceType(new string[0], new[]{ nameof(SecretBaseType)})]
    public partial class DataFactorySecretString : DataFactorySecret
    {
        /// <summary> Initializes a new instance of DataFactorySecretString. </summary>
        internal DataFactorySecretString()
        {
        }
        /// <summary> Initializes a new instance of DataFactorySecretString. </summary>
        /// <param name="value"> Value of secure string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        [InitializationConstructor]
        public DataFactorySecretString(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
            SecretBaseType = "SecureString";
        }

        /// <summary> Initializes a new instance of DataFactorySecretString. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        /// <param name="value"> Value of secure string. </param>
        [SerializationConstructor]
        internal DataFactorySecretString(string? secretBaseType, string? value) : base(secretBaseType)
        {
            Value = value;
            SecretBaseType = secretBaseType ?? "SecureString";
        }

        /// <summary> Value of secure string. </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactorySecretString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>

        public static implicit operator DataFactorySecretString(string literal) => new DataFactorySecretString(literal);
    }
}
