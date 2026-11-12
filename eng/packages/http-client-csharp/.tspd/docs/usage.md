### Prerequisite

- Install [Node.js](https://nodejs.org/download/) 20 or above. (Verify by running `node --version`)
- Install [**.NET 10.0 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) for your specific platform. (or a higher version within the 10.0.* band)

### Customizing Generated Code

For detailed instructions on how to customize the generated C# code, see the [Customization Guide](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md).

### Long-running operation metadata

Select auxiliary status-monitor properties with TCGC `@lroStatusMetadata` to generate a named operation with a strongly typed `Metadata` property. The metadata view reads the latest monitor response, including the initial monitor body and failed or canceled responses, rather than the final resource response. Missing or null fields return null; an absent field in a later response does not retain its previous value. Generated property names, wire names, inherited properties, models, collections, and serialization formats follow the normal model conventions.

Select the polling operation's ID path parameter or a monitor-body property with `@lroOperationId` to expose it as `operation.Id`. A body ID takes precedence once present; a selected URI ID is available before polling and after rehydration. An unavailable ID is `NOT_SET`. Polling always uses the complete polling URL, including its query string, not the extracted ID.

Use the generated operation's `FromRehydrationToken(client.Pipeline, token)` method to resume it without an immediate network request. URI IDs remain available, but monitor-body metadata and IDs are repopulated by the next status update. For example, the metadata Spector client's generated `MetadataClientAnalyzeJobOperation` exposes `operation.Metadata.Statistics?.Succeeded` and `operation.Metadata.LastUpdatedOn`. A saved metadata view continues to reflect subsequent polls.

Only annotated LROs receive these operation types. Existing unannotated operations retain their APIs. These annotations do not define custom terminal states, result projection, or paged LRO results.
