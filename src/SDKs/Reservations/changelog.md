## Microsoft.Azure.Management.Reservations release notes

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