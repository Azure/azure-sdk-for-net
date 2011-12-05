//-----------------------------------------------------------------------
// <copyright file="TableErrorCodeStrings.cs" company="Microsoft">
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
//    Contains code for the TableErrorCodeStrings class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Provides error code strings that are specific to the Windows Azure Table service.
    /// </summary>
    public static class TableErrorCodeStrings
    {
        /// <summary>
        /// The request uses X-HTTP-Method with an HTTP verb other than POST.
        /// </summary>
        public const string XMethodNotUsingPost = "XMethodNotUsingPost";

        /// <summary>
        /// The specified X-HTTP-Method is invalid.
        /// </summary>
        public const string XMethodIncorrectValue = "XMethodIncorrectValue";

        /// <summary>
        /// More than one X-HTTP-Method is specified.
        /// </summary>
        public const string XMethodIncorrectCount = "XMethodIncorrectCount";

        /// <summary>
        /// The specified table has no properties.
        /// </summary>
        public const string TableHasNoProperties = "TableHasNoProperties";

        /// <summary>
        /// A property is specified more than once.
        /// </summary>
        public const string DuplicatePropertiesSpecified = "DuplicatePropertiesSpecified";

        /// <summary>
        /// The specified table has no such property.
        /// </summary>
        public const string TableHasNoSuchProperty = "TableHasNoSuchProperty";

        /// <summary>
        /// A duplicate key property was specified.
        /// </summary>
        public const string DuplicateKeyPropertySpecified = "DuplicateKeyPropertySpecified";

        /// <summary>
        /// The specified table already exists.
        /// </summary>
        public const string TableAlreadyExists = "TableAlreadyExists";

        /// <summary>
        /// The specified table was not found.
        /// </summary>
        public const string TableNotFound = "TableNotFound";

        /// <summary>
        /// The specified entity was not found.
        /// </summary>
        public const string EntityNotFound = "EntityNotFound";

        /// <summary>
        /// The specified entity already exists.
        /// </summary>
        public const string EntityAlreadyExists = "EntityAlreadyExists";

        /// <summary>
        /// The partition key was not specified.
        /// </summary>
        public const string PartitionKeyNotSpecified = "PartitionKeyNotSpecified";

        /// <summary>
        /// One or more specified operators are invalid.
        /// </summary>
        public const string OperatorInvalid = "OperatorInvalid";

        /// <summary>
        /// The specified update condition was not satsified.
        /// </summary>
        public const string UpdateConditionNotSatisfied = "UpdateConditionNotSatisfied";

        /// <summary>
        /// All properties must have values.
        /// </summary>
        public const string PropertiesNeedValue = "PropertiesNeedValue";

        /// <summary>
        /// The partition key property cannot be updated.
        /// </summary>
        public const string PartitionKeyPropertyCannotBeUpdated = "PartitionKeyPropertyCannotBeUpdated";

        /// <summary>
        /// The entity contains more properties than allowed.
        /// </summary>
        public const string TooManyProperties = "TooManyProperties";

        /// <summary>
        /// The entity is larger than the maximum size permitted.
        /// </summary>
        public const string EntityTooLarge = "EntityTooLarge";

        /// <summary>
        /// The property value is larger than the maximum size permitted.
        /// </summary>
        public const string PropertyValueTooLarge = "PropertyValueTooLarge";

        /// <summary>
        /// One or more value types are invalid.
        /// </summary>
        public const string InvalidValueType = "InvalidValueType";

        /// <summary>
        /// The specified table is being deleted.
        /// </summary>
        public const string TableBeingDeleted = "TableBeingDeleted";

        /// <summary>
        /// The Table service server is out of memory.
        /// </summary>
        public const string TableServerOutOfMemory = "TableServerOutOfMemory";

        /// <summary>
        /// The type of the primary key property is invalid.
        /// </summary>
        public const string PrimaryKeyPropertyIsInvalidType = "PrimaryKeyPropertyIsInvalidType";

        /// <summary>
        /// The property name exceeds the maximum allowed length.
        /// </summary>
        public const string PropertyNameTooLong = "PropertyNameTooLong";

        /// <summary>
        /// The property name is invalid.
        /// </summary>
        public const string PropertyNameInvalid = "PropertyNameInvalid";

        /// <summary>
        /// Batch operations are not supported for this operation type.
        /// </summary>
        public const string BatchOperationNotSupported = "BatchOperationNotSupported";

        /// <summary>
        /// JSON format is not supported.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1704:IdentifiersShouldBeSpelledCorrectly",
            MessageId = "Json",
            Justification = "The casing matches the storage constant the identifier represents.")]
        public const string JsonFormatNotSupported = "JsonFormatNotSupported";

        /// <summary>
        /// The specified method is not allowed.
        /// </summary>
        public const string MethodNotAllowed = "MethodNotAllowed";

        /// <summary>
        /// The specified operation is not yet implemented.
        /// </summary>
        public const string NotImplemented = "NotImplemented";
    }
}