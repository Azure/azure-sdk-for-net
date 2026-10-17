import "./specification/storage/data-plane/BlobStorage/main.tsp";

using Azure.Mcp;

@@tool(
  Storage.Blob.Container.create,
  "f5088334-e630-4df0-a5be-ac87787acad0",
  "storage blob container create",
  "Create Storage Blob Container"
);
@@destructive(Storage.Blob.Container.create);
@@idempotent(Storage.Blob.Container.create, false);
@@readOnly(Storage.Blob.Container.create, false);
@@openWorld(Storage.Blob.Container.create, false);
