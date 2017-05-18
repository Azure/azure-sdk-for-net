## Microsoft.Azure.Management.DataLake.Store release notes

### Changes in 2.1.1-preview
- Update underlying AutoRest framework to the latest. This cleans up a lot of the generated code, making it easier to read.
- Filesystem client updates to further bring the client in line with WebHDFS standards:
    - When calling `CheckAccess` the fsaction parameter is now required.
    - The `Mkdirs` and `Create` methods now optionally accept a permission parameter to change the permissions on the created folder or file
    - For `ListFileStatus`, `GetFileStatus` and `GetAclStatus` an optional tooId parameter has been added. This allows the caller to try and get a friendly name for users and groups back from the server instead of object ID.
    - There was a slight change in how `GetAclStatus` returns ACL entries. The un-named entries are no longer returned as specific ACL entries. Instead they are part of the `permission` property.
    - Add optional parameters to file read/write methods (`Create`, `Open` and `Append`): leaseId and fileSessionId. When used properly, these can increase the performance of reads and writes within a single session.
    - The aclBit boolean value is now populated when calling `GetAclStatus`

### Changes in 2.0.1-preview
- Integrate DataLake.StoreUploader functionality into this package.
    - As of this release, the DataLake.StoreUploader package is deprecated and should not be used.
    - This introduces four new top level methods for convenience and to help with logging:
        - UploadFile
        - UploadFolder
        - DownloadFile
        - DownloadFolder
    - Added logic for smarter default values for thread count as the defaults. If the user does not pass in anything for PerFileThreadCount or ConcurrentFileCount they will be computed and, in most cases, give comparable performance to specifying the values.
    - Added Patch support for firewall rules and trusted identity providers
    - Added support for allowing/blocking Azure originating IP addresses through the firewall.
    - Fixed a bug in GetContentSummary that was preventing it from returning results
    - Minor documentation updates and corrections for methods and objects.

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
