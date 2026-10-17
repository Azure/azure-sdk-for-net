# Pinned service input

The five files in `storage/data-plane/BlobStorage` are unchanged copies from
[Azure/azure-rest-api-specs at ae348cc71f54a61f5d17472052cfef279a23db6b](https://github.com/Azure/azure-rest-api-specs/tree/ae348cc71f54a61f5d17472052cfef279a23db6b/specification/storage/data-plane/BlobStorage).
They are the complete relative import closure of `main.tsp`, including its
client customizations. Their Microsoft MIT copyright/license notices are
preserved.

These are existing service definitions, not MCP configuration or a new service
projection. The small `../storage.tsp` overlay selects the real
`Storage.Blob.Container.create` operation. Do not modify these files to make
the MCP emitter accept an unsupported operation. Update the pinned source and
its provenance together when intentionally changing the service contract.

The local fixture uses this package's pinned TypeSpec libraries, not the
upstream monorepo's Node/pnpm installation. This does not claim that the
published Blob Storage .NET SDK was generated from this TypeSpec; that SDK
currently uses Swagger/AutoRest.
