<h1>Mapping from ADLS Gen1 API -> ADLS Gen2 API</h1>
<table style="background:white">
<thead>
<tr>
<th>ADLS Gen1 API</th>
<th>Note for Gen1 API</th>
<th>ADLS Gen2 API</th>
<th>Note for API Mapping</th>
</tr>
</thead>
<tbody>
<tr>
<td>Bulk Download</td>
<td>Download directory or file from remote server to local. Transfers the contents under source directory under the destination directory.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Bulk Upload</td>
<td>Upload directory or file from local to remote. Transfers the contents under source directory under the destination directory.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Change ACL</td>
<td>Change Acl (Modify, set, and remove) recursively on a directory tree.</td>
<td>DirectoryClient, FileClient, or PathClient.SetAccessControlList()</td>
<td></td>
</tr>
<tr>
<td>Check Access</td>
<td>Checks if the user/group has specified access of the given path.</td>
<td>DirectoryClient, FileClient, or PathClient.GetAccessControls()</td>
<td>In the response, check if the user/group is the Owner/Group, or has an entry in the ACL.</td>
</tr>
<tr>
<td>Check Exists</td>
<td>Checks whether file or directory exists.</td>
<td>DirectoryClient, FileClient, or PathClient.GetProperties()</td>
<td>An exception will be throw if the File or Directory doesn't exist.</td>
</tr>
<tr>
<td>Concatenate Files</td>
<td>API to concatenate source files to a destination file</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Concurrent Append</td>
<td>API to perform concurrent append at server. The offset at which append will occur is determined by server.</td>
<td>FileClient.Append()</td>
<td>Pass in an offset equal to the current file length, then call Flush() with an offset of the previous file length + the length of the new content.  Also note that Gen 2 does not handle concurrency, so in multi-writer scenarios, the customer application needs to coordinate writes to an individial file.</td>
</tr>
<tr>
<td>Create Directory</td>
<td>API to create a directory.</td>
<td>DirectoryClient.Create()</td>
<td></td>
</tr>
<tr>
<td>Create File</td>
<td>API that creates a file and returns the stream to write data to that file in ADLS.</td>
<td>FileClient.Create()</td>
<td></td>
</tr>
<tr>
<td>Delete</td>
<td>API to delete a file or directory.</td>
<td>DirectoryClient, FileClient, or PathClient.Delete()</td>
<td></td>
</tr>
<tr>
<td>Delete Recursive</td>
<td>API to delete a file or directory recursively.</td>
<td>DirectoryClient, FileClient, or PathClient.Delete()</td>
<td></td>
</tr>
<tr>
<td>Enumerate Deleted Items</td>
<td>Search trash under a account with hint and a starting point.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Enumerate Directory</td>
<td>Returns a enumerable that enumerates the sub-directories or files contained in a directory.</td>
<td>FileSystemClient.ListPaths()</td>
<td></td>
</tr>
<tr>
<td>Get ACL Status</td>
<td>Gets the ACL entry list, owner ID, group ID, octal permission and sticky bit (only for a directory) of the file/directory.</td>
<td>DirectoryClient, FileClient, or PathClient.GetAccessControlList()</td>
<td>Owner, Group, Permissions, and Access Control List are returned in the response</td>
</tr>
<tr>
<td>Get Append Stream</td>
<td>API that returns the stream to write data to a file in ADLS.</td>
<td>FileClient.Append()</td>
<td></td>
</tr>
<tr>
<td>Get Content Summary</td>
<td>Gets content summary of a file or directory.</td>
<td>DirectoryClient, FileClient, or PathClient.GetProperties()</td>
<td></td>
</tr>
<tr>
<td>Get Directory Entry</td>
<td>Gets data like full path, type (file or directory), group, user, permission, length, last Access Time, last Modified Time, expiry time, acl Bit, replication Factor</td>
<td>DirectoryClient.GetProperties() and .GetAccessControlList()</td>
<td></td>
</tr>
<tr>
<td>Get File Properties</td>
<td>Recursively dumps file property of alldirectories or/and files under the given path to a local or adl file.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Get Read Stream</td>
<td>API that returns the stream to read data from file in ADLS.</td>
<td>FileClient.Read()</td>
<td></td>
</tr>
<tr>
<td>Modify ACL Entries</td>
<td>Modifies acl entries of a file or directory with given ACL list.</td>
<td>DirectoryClient, FileClient, or PathClient.SetAccessControlList()</td>
<td></td>
</tr>
<tr>
<td>Remove ACL Entries</td>
<td>Removes specified Acl Entries for a file or directory.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Remove Default ACLs</td>
<td>Removes all Acl Entries of AclScope default for a file or directory.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Rename</td>
<td>API to rename a file or directory.</td>
<td>DirectoryClient, FileClient, or PathClient.Rename()</td>
<td></td>
</tr>
<tr>
<td>Restore Deleted Items</td>
<td>Restores trash entry Caution: Undeleting files is a best effort operation.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Set ACL</td>
<td>Sets Acl Entries for a file or directory.</td>
<td>DirectoryClient, FileClient, or PathClient.SetAccessControlList()</td>
<td></td>
</tr>
<tr>
<td>Set Expiry Time</td>
<td>Sets the expiry time.</td>
<td>N/A</td>
<td></td>
</tr>
<tr>
<td>Set Owner</td>
<td>Sets the owner or/and group of the path.</td>
<td>DirectoryClient, FileClient, or PathClient.SetAccessControlList()</td>
<td>Set the Owner and/or Group parameter</td>
</tr>
<tr>
<td>Set Permission</td>
<td>Sets the permission of the specified path.</td>
<td>DirectoryClient, FileClient, or PathClient.SetPermissions()</td>
<td></td>
</tr>
</tbody>
</table>
