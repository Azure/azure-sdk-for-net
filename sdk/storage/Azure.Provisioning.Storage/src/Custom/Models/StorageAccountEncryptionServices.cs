// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountEncryptionServices
{
    private StorageEncryptionService _blob;
    private StorageEncryptionService _file;
    private StorageEncryptionService _table;
    private StorageEncryptionService _queue;

    /// <summary> Gets or sets the blob encryption service. </summary>
    [CodeGenMember("Blob")]
    public StorageEncryptionService Blob
    {
        get { Initialize(); return _blob; }
        set { Initialize(); AssignOrReplace(ref _blob, value); }
    }

    /// <summary> Gets or sets the file encryption service. </summary>
    [CodeGenMember("File")]
    public StorageEncryptionService File
    {
        get { Initialize(); return _file; }
        set { Initialize(); AssignOrReplace(ref _file, value); }
    }

    /// <summary> Gets or sets the table encryption service. </summary>
    [CodeGenMember("Table")]
    public StorageEncryptionService Table
    {
        get { Initialize(); return _table; }
        set { Initialize(); AssignOrReplace(ref _table, value); }
    }

    /// <summary> Gets or sets the queue encryption service. </summary>
    [CodeGenMember("Queue")]
    public StorageEncryptionService Queue
    {
        get { Initialize(); return _queue; }
        set { Initialize(); AssignOrReplace(ref _queue, value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _blob = DefineModelProperty<StorageEncryptionService>(nameof(Blob), new string[] { "blob" });
        _file = DefineModelProperty<StorageEncryptionService>(nameof(File), new string[] { "file" });
        _table = DefineModelProperty<StorageEncryptionService>(nameof(Table), new string[] { "table" });
        _queue = DefineModelProperty<StorageEncryptionService>(nameof(Queue), new string[] { "queue" });
    }
}
