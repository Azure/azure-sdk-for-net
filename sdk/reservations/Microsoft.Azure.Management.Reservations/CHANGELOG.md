## Microsoft.Azure.Management.Reservations release notes

### Changes in 1.16.0-preview
**Notes**

* Updated Reservations APIs version to 2022-03-01.
* Support for new reserved resource types: AVS, DataFactory, NetAppStorage, AzureFiles, SqlEdge VirtualMachineSoftware.

### Changes in 1.15.0-preview
**Notes**

* Add quota GA APIs.
* Removed AutoQuotaIncrease APIs from GA version. It's available in preview version -1.14.0-preview.

### Changes in 1.14.0-preview
**Notes**

* Add quota APIs.
* Add AutoQuotaIncrease APIs.

### Changes in 1.9.0-preview

**Notes**

* Add CosmosDb type in ReservedResourceType enum.
* Add name property in PatchProperties.

### Changes in 1.1.0-preview

**Notes**

* Updated Reservations Patch API.
    - Added optional InstanceFlexibility parameter.
* Added properties to Reservation object.
* Support for InstanceFlexibility.
* Support for ReservedResourceType (VirtualMachines, SqlDatabases, SuseLinux).
* Upgrade to rest api version 2018-06-01.

**Breaking change**

* Updated Catalogs API
    - Added required parameter ReservedResourceType and optional parameter Location.
    - Removed Size and Tier from Catalog object.

### Changes in 1.0.0-preview

* Initial release with rest api version 2017-11-01.