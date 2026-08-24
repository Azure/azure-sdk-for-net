// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Storage;

// TypeSpec does not generate provisioning role helpers. Preserve the shipped role identifiers
// and value semantics used by StorageAccount.CreateRoleAssignment.
/// <summary>
/// Built-in Storage roles that can be assigned to principals.
/// </summary>
/// <param name="value">The role definition identifier.</param>
public readonly struct StorageBuiltInRole(string value) : IEquatable<StorageBuiltInRole>
{
    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> Storage Account Backup Contributor. </summary>
    public static StorageBuiltInRole StorageAccountBackupContributor { get; } = new(StorageAccountBackupContributorValue);
    internal const string StorageAccountBackupContributorValue = "e5e2a7ff-d759-4cd2-bb51-3152d37e2eb1";

    /// <summary> Storage Account Contributor. </summary>
    public static StorageBuiltInRole StorageAccountContributor { get; } = new(StorageAccountContributorValue);
    internal const string StorageAccountContributorValue = "17d1049b-9a84-46fb-8f53-869881c3d3ab";

    /// <summary> Storage Account Key Operator Service Role. </summary>
    public static StorageBuiltInRole StorageAccountKeyOperatorServiceRole { get; } = new(StorageAccountKeyOperatorServiceRoleValue);
    internal const string StorageAccountKeyOperatorServiceRoleValue = "81a9662b-bebf-436f-a333-f67b29880f12";

    /// <summary> Storage Blob Data Contributor. </summary>
    public static StorageBuiltInRole StorageBlobDataContributor { get; } = new(StorageBlobDataContributorValue);
    internal const string StorageBlobDataContributorValue = "ba92f5b4-2d11-453d-a403-e96b0029c9fe";

    /// <summary> Storage Blob Data Owner. </summary>
    public static StorageBuiltInRole StorageBlobDataOwner { get; } = new(StorageBlobDataOwnerValue);
    internal const string StorageBlobDataOwnerValue = "b7e6dc6d-f1e8-4753-8033-0f276bb0955b";

    /// <summary> Storage Blob Data Reader. </summary>
    public static StorageBuiltInRole StorageBlobDataReader { get; } = new(StorageBlobDataReaderValue);
    internal const string StorageBlobDataReaderValue = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1";

    /// <summary> Storage Blob Delegator. </summary>
    public static StorageBuiltInRole StorageBlobDelegator { get; } = new(StorageBlobDelegatorValue);
    internal const string StorageBlobDelegatorValue = "db58b8e5-c6ad-4a2a-8342-4190687cbf4a";

    /// <summary> Storage File Data Privileged Contributor. </summary>
    public static StorageBuiltInRole StorageFileDataPrivilegedContributor { get; } = new(StorageFileDataPrivilegedContributorValue);
    internal const string StorageFileDataPrivilegedContributorValue = "69566ab7-960f-475b-8e7c-b3118f30c6bd";

    /// <summary> Storage File Data Privileged Reader. </summary>
    public static StorageBuiltInRole StorageFileDataPrivilegedReader { get; } = new(StorageFileDataPrivilegedReaderValue);
    internal const string StorageFileDataPrivilegedReaderValue = "b8eda974-7b85-4f76-af95-65846b26df6d";

    /// <summary> Storage File Data SMB Share Contributor. </summary>
    public static StorageBuiltInRole StorageFileDataSmbShareContributor { get; } = new(StorageFileDataSmbShareContributorValue);
    internal const string StorageFileDataSmbShareContributorValue = "0c867c2a-1d8c-454a-a3db-ab2ea1bdc8bb";

    /// <summary> Storage File Data SMB Share Elevated Contributor. </summary>
    public static StorageBuiltInRole StorageFileDataSmbShareElevatedContributor { get; } = new(StorageFileDataSmbShareElevatedContributorValue);
    internal const string StorageFileDataSmbShareElevatedContributorValue = "a7264617-510b-434b-a828-9731dc254ea7";

    /// <summary> Storage File Data SMB Share Reader. </summary>
    public static StorageBuiltInRole StorageFileDataSmbShareReader { get; } = new(StorageFileDataSmbShareReaderValue);
    internal const string StorageFileDataSmbShareReaderValue = "aba4ae5f-2193-4029-9191-0cb91df5e314";

    /// <summary> Storage Queue Data Contributor. </summary>
    public static StorageBuiltInRole StorageQueueDataContributor { get; } = new(StorageQueueDataContributorValue);
    internal const string StorageQueueDataContributorValue = "974c5e8b-45b9-4653-ba55-5f855dd0fb88";

    /// <summary> Storage Queue Data Message Processor. </summary>
    public static StorageBuiltInRole StorageQueueDataMessageProcessor { get; } = new(StorageQueueDataMessageProcessorValue);
    internal const string StorageQueueDataMessageProcessorValue = "8a0f0c08-91a1-4084-bc3d-661d67233fed";

    /// <summary> Storage Queue Data Message Sender. </summary>
    public static StorageBuiltInRole StorageQueueDataMessageSender { get; } = new(StorageQueueDataMessageSenderValue);
    internal const string StorageQueueDataMessageSenderValue = "c6a89b2d-59bc-44d0-9896-0f6e12d7b80a";

    /// <summary> Storage Queue Data Reader. </summary>
    public static StorageBuiltInRole StorageQueueDataReader { get; } = new(StorageQueueDataReaderValue);
    internal const string StorageQueueDataReaderValue = "19e7f393-937e-4f77-808e-94535e297925";

    /// <summary> Storage Table Data Contributor. </summary>
    public static StorageBuiltInRole StorageTableDataContributor { get; } = new(StorageTableDataContributorValue);
    internal const string StorageTableDataContributorValue = "0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3";

    /// <summary> Storage Table Data Reader. </summary>
    public static StorageBuiltInRole StorageTableDataReader { get; } = new(StorageTableDataReaderValue);
    internal const string StorageTableDataReaderValue = "76199698-9eea-4c19-bc75-cec21354c6b6";

    /// <summary> Classic Storage Account Contributor. </summary>
    public static StorageBuiltInRole ClassicStorageAccountContributor { get; } = new(ClassicStorageAccountContributorValue);
    internal const string ClassicStorageAccountContributorValue = "86e8f5dc-a6e9-4c67-9d15-de283e8eac25";

    /// <summary> Classic Storage Account Key Operator Service Role. </summary>
    public static StorageBuiltInRole ClassicStorageAccountKeyOperatorServiceRole { get; } = new(ClassicStorageAccountKeyOperatorServiceRoleValue);
    internal const string ClassicStorageAccountKeyOperatorServiceRoleValue = "985d6b00-f706-48f5-a6fe-d0ca12fb668d";

    /// <summary> Gets the built-in role name for a known role identifier. </summary>
    /// <param name="value">The role value.</param>
    /// <returns>The built-in role name, or the identifier if unknown.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string GetBuiltInRoleName(StorageBuiltInRole value) =>
        value._value switch
        {
            StorageAccountBackupContributorValue => nameof(StorageAccountBackupContributor),
            StorageAccountContributorValue => nameof(StorageAccountContributor),
            StorageAccountKeyOperatorServiceRoleValue => nameof(StorageAccountKeyOperatorServiceRole),
            StorageBlobDataContributorValue => nameof(StorageBlobDataContributor),
            StorageBlobDataOwnerValue => nameof(StorageBlobDataOwner),
            StorageBlobDataReaderValue => nameof(StorageBlobDataReader),
            StorageBlobDelegatorValue => nameof(StorageBlobDelegator),
            StorageFileDataPrivilegedContributorValue => nameof(StorageFileDataPrivilegedContributor),
            StorageFileDataPrivilegedReaderValue => nameof(StorageFileDataPrivilegedReader),
            StorageFileDataSmbShareContributorValue => nameof(StorageFileDataSmbShareContributor),
            StorageFileDataSmbShareElevatedContributorValue => nameof(StorageFileDataSmbShareElevatedContributor),
            StorageFileDataSmbShareReaderValue => nameof(StorageFileDataSmbShareReader),
            StorageQueueDataContributorValue => nameof(StorageQueueDataContributor),
            StorageQueueDataMessageProcessorValue => nameof(StorageQueueDataMessageProcessor),
            StorageQueueDataMessageSenderValue => nameof(StorageQueueDataMessageSender),
            StorageQueueDataReaderValue => nameof(StorageQueueDataReader),
            StorageTableDataContributorValue => nameof(StorageTableDataContributor),
            StorageTableDataReaderValue => nameof(StorageTableDataReader),
            ClassicStorageAccountContributorValue => nameof(ClassicStorageAccountContributor),
            ClassicStorageAccountKeyOperatorServiceRoleValue => nameof(ClassicStorageAccountKeyOperatorServiceRole),
            _ => value._value
        };

    /// <summary> Compares two role values for equality. </summary>
    public static bool operator ==(StorageBuiltInRole left, StorageBuiltInRole right) => left.Equals(right);

    /// <summary> Compares two role values for inequality. </summary>
    public static bool operator !=(StorageBuiltInRole left, StorageBuiltInRole right) => !left.Equals(right);

    /// <summary> Converts a string role identifier to a role value. </summary>
    public static implicit operator StorageBuiltInRole(string value) => new(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is StorageBuiltInRole other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(StorageBuiltInRole other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}
