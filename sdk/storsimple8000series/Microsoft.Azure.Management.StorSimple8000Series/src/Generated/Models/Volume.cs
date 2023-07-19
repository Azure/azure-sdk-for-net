
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The volume.
    /// </summary>
    [JsonTransformation]
    public partial class Volume : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Volume class.
        /// </summary>
        public Volume() { }

        /// <summary>
        /// Initializes a new instance of the Volume class.
        /// </summary>
        /// <param name="sizeInBytes">The size of the volume in bytes.</param>
        /// <param name="volumeType">The type of the volume. Possible values
        /// include: 'Tiered', 'Archival', 'LocallyPinned'</param>
        /// <param name="accessControlRecordIds">The IDs of the access control
        /// records, associated with the volume.</param>
        /// <param name="volumeStatus">The volume status. Possible values
        /// include: 'Online', 'Offline'</param>
        /// <param name="monitoringStatus">The monitoring status of the volume.
        /// Possible values include: 'Enabled', 'Disabled'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="volumeContainerId">The ID of the volume container, in
        /// which this volume is created.</param>
        /// <param name="operationStatus">The operation status on the volume.
        /// Possible values include: 'None', 'Updating', 'Deleting',
        /// 'Restoring'</param>
        /// <param name="backupStatus">The backup status of the volume.
        /// Possible values include: 'Enabled', 'Disabled'</param>
        /// <param name="backupPolicyIds">The IDs of the backup policies, in
        /// which this volume is part of.</param>
        public Volume(long sizeInBytes, VolumeType volumeType, IList<string> accessControlRecordIds, VolumeStatus volumeStatus, MonitoringStatus monitoringStatus, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), string volumeContainerId = default(string), OperationStatus? operationStatus = default(OperationStatus?), BackupStatus? backupStatus = default(BackupStatus?), IList<string> backupPolicyIds = default(IList<string>))
            : base(id, name, type, kind)
        {
            SizeInBytes = sizeInBytes;
            VolumeType = volumeType;
            VolumeContainerId = volumeContainerId;
            AccessControlRecordIds = accessControlRecordIds;
            VolumeStatus = volumeStatus;
            OperationStatus = operationStatus;
            BackupStatus = backupStatus;
            MonitoringStatus = monitoringStatus;
            BackupPolicyIds = backupPolicyIds;
        }

        /// <summary>
        /// Gets or sets the size of the volume in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sizeInBytes")]
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the type of the volume. Possible values include:
        /// 'Tiered', 'Archival', 'LocallyPinned'
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeType")]
        public VolumeType VolumeType { get; set; }

        /// <summary>
        /// Gets the ID of the volume container, in which this volume is
        /// created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeContainerId")]
        public string VolumeContainerId { get; protected set; }

        /// <summary>
        /// Gets or sets the IDs of the access control records, associated with
        /// the volume.
        /// </summary>
        [JsonProperty(PropertyName = "properties.accessControlRecordIds")]
        public IList<string> AccessControlRecordIds { get; set; }

        /// <summary>
        /// Gets or sets the volume status. Possible values include: 'Online',
        /// 'Offline'
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeStatus")]
        public VolumeStatus VolumeStatus { get; set; }

        /// <summary>
        /// Gets the operation status on the volume. Possible values include:
        /// 'None', 'Updating', 'Deleting', 'Restoring'
        /// </summary>
        [JsonProperty(PropertyName = "properties.operationStatus")]
        public OperationStatus? OperationStatus { get; protected set; }

        /// <summary>
        /// Gets the backup status of the volume. Possible values include:
        /// 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupStatus")]
        public BackupStatus? BackupStatus { get; protected set; }

        /// <summary>
        /// Gets or sets the monitoring status of the volume. Possible values
        /// include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.monitoringStatus")]
        public MonitoringStatus MonitoringStatus { get; set; }

        /// <summary>
        /// Gets the IDs of the backup policies, in which this volume is part
        /// of.
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupPolicyIds")]
        public IList<string> BackupPolicyIds { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AccessControlRecordIds == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AccessControlRecordIds");
            }
        }
    }
}

