Below is a summary of the the main features/bug fixes in the most recent releases of Microsoft.Azure.Management.Redis.

## v2.0.0-Preview
We have change underlying mechanism of generating code for .NET, So there are breaking changes related to that. We have also flatten all properties directly as first class citizen to be consistent with other services. 

* "CreateOrUpdate" operation will return type "RedisResourceWithAccessKey" instead of "RedisCreateOrUpdateResponse".
* "Get" operation will have return type "RedisResource" instead of "RedisGetResponse".
* "List" with parameter resourceGroupName is new operation named as "ListByResourceGroup".
* "List" and "ListByResourceGroup" will have return type "IPage<RedisResource>" instead of "RedisListResponse".
* "RedisListKeysResponse" is now named as "RedisListKeysResult".
* "RegenerateKey" and "ListKeys" operations will return type "RedisListKeysResult".
* All the properties are first class citizen e.g. Sku, Port, HostName etc are accessed as "obj.Port" instead of "obj.Properties.Port" (here "obj" is object of type "RedisResourceWithAccessKey" or "RedisResource")
