## Microsoft.Azure.Management.Reservations release notes

### Changes in 1.1.0-preview

**Notes**

- Patch Reservations takes in optional parameter InstanceFlexibility.
- Support for InstanceFlexibility.
- Support for ReservedResourceType (VirtualMachines, SqlDatabases, SuseLinux).
- Upgrade to rest api version 2018-06-01.

**Breaking change**

- Catalogs API takes in a required parameter ReservedResourceType and optional parameter Location.


### Changes in 1.0.0-preview

- Initial release with rest api version 2017-11-01.