// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.Tables.Models
{
    /// <summary> Error codes returned by the service. </summary>
    public readonly partial struct TableErrorCode : IEquatable<TableErrorCode>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="TableErrorCode"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TableErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AuthorizationResourceTypeMismatchValue = "AuthorizationResourceTypeMismatch";
        private const string AuthorizationPermissionMismatchValue = "AuthorizationPermissionMismatch";
        private const string XMethodNotUsingPostValue = "XMethodNotUsingPost";
        private const string XMethodIncorrectValueValue = "XMethodIncorrectValue";
        private const string XMethodIncorrectCountValue = "XMethodIncorrectCount";
        private const string TableHasNoPropertiesValue = "TableHasNoProperties";
        private const string DuplicatePropertiesSpecifiedValue = "DuplicatePropertiesSpecified";
        private const string TableHasNoSuchPropertyValue = "TableHasNoSuchProperty";
        private const string DuplicateKeyPropertySpecifiedValue = "DuplicateKeyPropertySpecified";
        private const string TableAlreadyExistsValue = "TableAlreadyExists";
        private const string TableNotFoundValue = "TableNotFound";
        private const string ResourceNotFoundValue = "ResourceNotFound";
        private const string EntityNotFoundValue = "EntityNotFound";
        private const string EntityAlreadyExistsValue = "EntityAlreadyExists";
        private const string PartitionKeyNotSpecifiedValue = "PartitionKeyNotSpecified";
        private const string OperatorInvalidValue = "OperatorInvalid";
        private const string UpdateConditionNotSatisfiedValue = "UpdateConditionNotSatisfied";
        private const string PropertiesNeedValueValue = "PropertiesNeedValue";
        private const string PartitionKeyPropertyCannotBeUpdatedValue = "PartitionKeyPropertyCannotBeUpdated";
        private const string TooManyPropertiesValue = "TooManyProperties";
        private const string EntityTooLargeValue = "EntityTooLarge";
        private const string PropertyValueTooLargeValue = "PropertyValueTooLarge";
        private const string KeyValueTooLargeValue = "KeyValueTooLarge";
        private const string InvalidValueTypeValue = "InvalidValueType";
        private const string TableBeingDeletedValue = "TableBeingDeleted";
        private const string PrimaryKeyPropertyIsInvalidTypeValue = "PrimaryKeyPropertyIsInvalidType";
        private const string PropertyNameTooLongValue = "PropertyNameTooLong";
        private const string PropertyNameInvalidValue = "PropertyNameInvalid";
        private const string InvalidDuplicateRowValue = "InvalidDuplicateRow";
        private const string CommandsInBatchActOnDifferentPartitionsValue = "CommandsInBatchActOnDifferentPartitions";
        private const string JsonFormatNotSupportedValue = "JsonFormatNotSupported";
        private const string AtomFormatNotSupportedValue = "AtomFormatNotSupported";
        private const string JsonVerboseFormatNotSupportedValue = "JsonVerboseFormatNotSupported";
        private const string MediaTypeNotSupportedValue = "MediaTypeNotSupported";
        private const string MethodNotAllowedValue = "MethodNotAllowed";
        private const string ContentLengthExceededValue = "ContentLengthExceeded";
        private const string AccountIopsLimitExceededValue = "AccountIOPSLimitExceeded";
        private const string CannotCreateTableWithIopsGreaterThanMaxAllowedPerTableValue = "CannotCreateTableWithIOPSGreaterThanMaxAllowedPerTable";
        private const string PerTableIopsIncrementLimitReachedValue = "PerTableIOPSIncrementLimitReached";
        private const string PerTableIopsDecrementLimitReachedValue = "PerTableIOPSDecrementLimitReached";
        private const string SettingIopsForATableInProvisioningNotAllowedValue = "SettingIOPSForATableInProvisioningNotAllowed";
        private const string PartitionKeyEqualityComparisonExpectedValue = "PartitionKeyEqualityComparisonExpected";
        private const string PartitionKeySpecifiedMoreThanOnceValue = "PartitionKeySpecifiedMoreThanOnce";
        private const string InvalidInputValue = "InvalidInput";
        private const string NotImplementedValue = "NotImplemented";
        private const string OperationTimedOutValue = "OperationTimedOut";
        private const string OutOfRangeInputValue = "OutOfRangeInput";
        private const string ForbiddenValue = "Forbidden";

        /// <summary> AuthorizationResourceTypeMismatch. </summary>
        public static TableErrorCode AuthorizationResourceTypeMismatch { get; } = new TableErrorCode(AuthorizationResourceTypeMismatchValue);

        /// <summary> XMethodNotUsingPost. </summary>
        public static TableErrorCode XMethodNotUsingPost { get; } = new TableErrorCode(XMethodNotUsingPostValue);

        /// <summary> XMethodIncorrectValue. </summary>
        public static TableErrorCode XMethodIncorrectValue { get; } = new TableErrorCode(XMethodIncorrectValueValue);

        /// <summary> XMethodIncorrectCount. </summary>
        public static TableErrorCode XMethodIncorrectCount { get; } = new TableErrorCode(XMethodIncorrectCountValue);

        /// <summary> TableHasNoProperties. </summary>
        public static TableErrorCode TableHasNoProperties { get; } = new TableErrorCode(TableHasNoPropertiesValue);

        /// <summary> DuplicatePropertiesSpecified. </summary>
        public static TableErrorCode DuplicatePropertiesSpecified { get; } = new TableErrorCode(DuplicatePropertiesSpecifiedValue);

        /// <summary> TableHasNoSuchProperty. </summary>
        public static TableErrorCode TableHasNoSuchProperty { get; } = new TableErrorCode(TableHasNoSuchPropertyValue);

        /// <summary> DuplicateKeyPropertySpecified. </summary>
        public static TableErrorCode DuplicateKeyPropertySpecified { get; } = new TableErrorCode(DuplicateKeyPropertySpecifiedValue);

        /// <summary> TableAlreadyExists. </summary>
        public static TableErrorCode TableAlreadyExists { get; } = new TableErrorCode(TableAlreadyExistsValue);

        /// <summary> TableNotFound.</summary>
        public static TableErrorCode TableNotFound { get; } = new TableErrorCode(TableNotFoundValue);

        /// <summary> ResourceNotFound. </summary>
        public static TableErrorCode ResourceNotFound { get; } = new TableErrorCode(ResourceNotFoundValue);

        /// <summary> EntityNotFound. </summary>
        public static TableErrorCode EntityNotFound { get; } = new TableErrorCode(EntityNotFoundValue);

        /// <summary> EntityAlreadyExists. </summary>
        public static TableErrorCode EntityAlreadyExists { get; } = new TableErrorCode(EntityAlreadyExistsValue);

        /// <summary> PartitionKeyNotSpecified. </summary>
        public static TableErrorCode PartitionKeyNotSpecified { get; } = new TableErrorCode(PartitionKeyNotSpecifiedValue);

        /// <summary> OperatorInvalid. </summary>
        public static TableErrorCode OperatorInvalid { get; } = new TableErrorCode(OperatorInvalidValue);

        /// <summary> UpdateConditionNotSatisfied. </summary>
        public static TableErrorCode UpdateConditionNotSatisfied { get; } = new TableErrorCode(UpdateConditionNotSatisfiedValue);

        /// <summary> PropertiesNeedValue. </summary>
        public static TableErrorCode PropertiesNeedValue { get; } = new TableErrorCode(PropertiesNeedValueValue);

        /// <summary> PartitionKeyPropertyCannotBeUpdated. </summary>
        public static TableErrorCode PartitionKeyPropertyCannotBeUpdated { get; } = new TableErrorCode(PartitionKeyPropertyCannotBeUpdatedValue);

        /// <summary> TooManyProperties. </summary>
        public static TableErrorCode TooManyProperties { get; } = new TableErrorCode(TooManyPropertiesValue);

        /// <summary> EntityTooLarge. </summary>
        public static TableErrorCode EntityTooLarge { get; } = new TableErrorCode(EntityTooLargeValue);

        /// <summary> PropertyValueTooLarge. </summary>
        public static TableErrorCode PropertyValueTooLarge { get; } = new TableErrorCode(PropertyValueTooLargeValue);

        /// <summary> KeyValueTooLarge. </summary>
        public static TableErrorCode KeyValueTooLarge { get; } = new TableErrorCode(KeyValueTooLargeValue);

        /// <summary> InvalidValueType. </summary>
        public static TableErrorCode InvalidValueType { get; } = new TableErrorCode(InvalidValueTypeValue);

        /// <summary> TableBeingDeleted. </summary>
        public static TableErrorCode TableBeingDeleted { get; } = new TableErrorCode(TableBeingDeletedValue);

        /// <summary> PrimaryKeyPropertyIsInvalidType. </summary>
        public static TableErrorCode PrimaryKeyPropertyIsInvalidType { get; } = new TableErrorCode(PrimaryKeyPropertyIsInvalidTypeValue);

        /// <summary> PropertyNameTooLong. </summary>
        public static TableErrorCode PropertyNameTooLong { get; } = new TableErrorCode(PropertyNameTooLongValue);

        /// <summary> PropertyNameInvalid. </summary>
        public static TableErrorCode PropertyNameInvalid { get; } = new TableErrorCode(PropertyNameInvalidValue);

        /// <summary> InvalidDuplicateRow. </summary>
        public static TableErrorCode InvalidDuplicateRow { get; } = new TableErrorCode(InvalidDuplicateRowValue);

        /// <summary> CommandsInBatchActOnDifferentPartitions. </summary>
        public static TableErrorCode CommandsInBatchActOnDifferentPartitions { get; } = new TableErrorCode(CommandsInBatchActOnDifferentPartitionsValue);

        /// <summary> JsonFormatNotSupported. </summary>
        public static TableErrorCode JsonFormatNotSupported { get; } = new TableErrorCode(JsonFormatNotSupportedValue);

        /// <summary> AtomFormatNotSupported. </summary>
        public static TableErrorCode AtomFormatNotSupported { get; } = new TableErrorCode(AtomFormatNotSupportedValue);

        /// <summary> JsonVerboseFormatNotSupported. </summary>
        public static TableErrorCode JsonVerboseFormatNotSupported { get; } = new TableErrorCode(JsonVerboseFormatNotSupportedValue);

        /// <summary> MediaTypeNotSupported. </summary>
        public static TableErrorCode MediaTypeNotSupported { get; } = new TableErrorCode(MediaTypeNotSupportedValue);

        /// <summary> MethodNotAllowed. </summary>
        public static TableErrorCode MethodNotAllowed { get; } = new TableErrorCode(MethodNotAllowedValue);

        /// <summary> ContentLengthExceeded. </summary>
        public static TableErrorCode ContentLengthExceeded { get; } = new TableErrorCode(ContentLengthExceededValue);

        /// <summary> AccountIOPSLimitExceeded. </summary>
        public static TableErrorCode AccountIOPSLimitExceeded { get; } = new TableErrorCode(AccountIopsLimitExceededValue);

        /// <summary> CannotCreateTableWithIOPSGreaterThanMaxAllowedPerTable. </summary>
        public static TableErrorCode CannotCreateTableWithIOPSGreaterThanMaxAllowedPerTable { get; } = new TableErrorCode(CannotCreateTableWithIopsGreaterThanMaxAllowedPerTableValue);

        /// <summary> PerTableIOPSIncrementLimitReached. </summary>
        public static TableErrorCode PerTableIOPSIncrementLimitReached { get; } = new TableErrorCode(PerTableIopsIncrementLimitReachedValue);

        /// <summary> PerTableIOPSDecrementLimitReached. </summary>
        public static TableErrorCode PerTableIOPSDecrementLimitReached { get; } = new TableErrorCode(PerTableIopsDecrementLimitReachedValue);

        /// <summary> SettingIOPSForATableInProvisioningNotAllowed. </summary>
        public static TableErrorCode SettingIOPSForATableInProvisioningNotAllowed { get; } = new TableErrorCode(SettingIopsForATableInProvisioningNotAllowedValue);

        /// <summary> PartitionKeyEqualityComparisonExpected. </summary>
        public static TableErrorCode PartitionKeyEqualityComparisonExpected { get; } = new TableErrorCode(PartitionKeyEqualityComparisonExpectedValue);

        /// <summary> PartitionKeySpecifiedMoreThanOnce. </summary>
        public static TableErrorCode PartitionKeySpecifiedMoreThanOnce { get; } = new TableErrorCode(PartitionKeySpecifiedMoreThanOnceValue);

        /// <summary> InvalidInput. </summary>
        public static TableErrorCode InvalidInput { get; } = new TableErrorCode(InvalidInputValue);

        /// <summary> NotImplemented. </summary>
        public static TableErrorCode NotImplemented { get; } = new TableErrorCode(NotImplementedValue);

        /// <summary> OperationTimedOut. </summary>
        public static TableErrorCode OperationTimedOut { get; } = new TableErrorCode(OperationTimedOutValue);

        /// <summary> OutOfRangeInput. </summary>
        public static TableErrorCode OutOfRangeInput { get; } = new TableErrorCode(OutOfRangeInputValue);

        /// <summary> Forbidden. </summary>
        public static TableErrorCode Forbidden { get; } = new TableErrorCode(ForbiddenValue);

        /// <summary> AuthorizationPermissionMismatch. </summary>
        public static TableErrorCode AuthorizationPermissionMismatch { get; } = new TableErrorCode(AuthorizationPermissionMismatchValue);

        /// <summary> Determines if two <see cref="TableErrorCode"/> values are the same. </summary>
        public static bool operator ==(TableErrorCode left, TableErrorCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TableErrorCode"/> values are not the same. </summary>
        public static bool operator !=(TableErrorCode left, TableErrorCode right) => !left.Equals(right);

        /// <summary> Determines if a <see cref="TableErrorCode"/> and a string are equal. </summary>
        public static bool operator ==(TableErrorCode code, string value) => value != null && code.Equals(value);

        /// <summary> Determines if a <see cref="TableErrorCode"/> and a string are not equal. </summary>
        public static bool operator !=(TableErrorCode code, string value) => !(code == value);

        /// <summary> Determines if a string and a <see cref="TableErrorCode"/> are equal. </summary>
        public static bool operator ==(string value, TableErrorCode code) => code == value;

        /// <summary> Determines if a string and a <see cref="TableErrorCode"/> are not equal. </summary>
        public static bool operator !=(string value, TableErrorCode code) => !(value == code);

        /// <summary> Converts a string to a <see cref="TableErrorCode"/>. </summary>
        public static implicit operator TableErrorCode(string value) => new TableErrorCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TableErrorCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TableErrorCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
