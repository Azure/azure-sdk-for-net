Below is a summary of the changes in the most recent release of Microsoft.Azure.Management.Redis.

## v2.0.0-Preview
We have changed underlying mechanism of generating code for .NET. There are breaking changes in this preview. 
We have flattened all properties so they can be accessed as first class properties. This was done to be consistent with other services.
Following is a summary of the high-level changes. 

* "CreateOrUpdate" operation will return type "RedisResourceWithAccessKey" instead of "RedisCreateOrUpdateResponse".
* "Get" operation will have return type "RedisResource" instead of "RedisGetResponse".
* "List" with parameter resourceGroupName is new operation named as "ListByResourceGroup".
* "List" and "ListByResourceGroup" will have return type "IPage<RedisResource>" instead of "RedisListResponse".
* "RedisListKeysResponse" is now named as "RedisListKeysResult".
* "RegenerateKey" and "ListKeys" operations will return type "RedisListKeysResult".
* All the properties are first class citizen e.g. Sku, Port, HostName etc are accessed as "obj.Port" instead of "obj.Properties.Port" (here "obj" is object of type "RedisResourceWithAccessKey" or "RedisResource")