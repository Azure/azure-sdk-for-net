## Microsoft.Azure.Management.DataLake.Store release notes

### Changes in 1.0.3
- As the first official stable release of the `Microsoft.Azure.Management.DataLake.Store` package, changes between this version and the preview version are enumerated below. 
	- All nested properties have been flattened down into their containing objects. For example: `myAccount.Properties.DefaultGroup` is now: `myAccount.DefaultGroup`
    - Reorganized account management operations into three distinct operation groups: `Account`, `FirewallRules` and `TrustedIdProviders`. This results in changes to how certain operations are reached. For example, to get firewall rules previously this would be called: `myClient.Account.GetFirewallRules()`. Now: `myClient.FirewallRules.Get()`.
	- All object properties have been updated to reflect whether they are required, optional or read-only (un-settable). This more explicitly helps the caller understand what they need to pass in and what they cannot pass in. As a result, there are some read-only properties that previously were not, and will need to be removed from object initialization.
	- Updates to include default values for some optional properties for objects. Please see class documentation for details on these defaults.
	- Added encryption support to account creation
	- Added billing support for account creation and updates
	- Added SyncFlag support for Create, Append and ConcurrentAppend calls in the filesystem. This allows granular control of when the stream on the server side is flushed and metadata about the stream is updated.
	- Added support for removal of full and default ACLs on files and folders, respectively. This does not remove system computed ACL entries (such as mask).
	- Added support for setting the expiration time for a file, as well as retrieving the expiration time when getting a file.
	- Added some new `AdlsErrorException` class types for exceptions thrown by the filesystem (which can be accessed under `myCaughException.Body.RemoteException`):
		- AdlsIllegalArgumentException
		- AdlsUnsupportedOperationException
		- AdlsSecurityException
		- AdlsIOException
		- AdlsFileNotFoundException
		- AdlsFileAlreadyExistsException
		- AdlsBadOffsetException
		- AdlsRuntimeException
		- AdlsAccessControlException
		- AdlsRemoteException
        - AdlsThrottledException
