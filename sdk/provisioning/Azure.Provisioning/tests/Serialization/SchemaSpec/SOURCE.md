# Schema Source

These TypeSpec files define the Azure Provisioning serialization AST schema.

- **Repository**: `Azure/js-provisioning-lib`
- **Branch**: `main`
- **Original pull request**: `473` (merged)
- **SHA**: 62801dbbc6405055ce69ba57bb76dfd2073f8ce0
- **Verified**: 2026-09-29

To update, resolve the latest `main` commit and download the `.tsp` files from
the `typespec/` directory at that SHA, then update this record.
All five files are unchanged from the previously downloaded snapshot.

## Compatibility coverage

The serialization tests validate required fields and nested model, union, record,
array, and scalar shapes against these files. Type annotations and signed 64-bit
integer literals are preserved when reading JSON; decorator numbers must fit the
TypeSpec `safeint` range.

Loops (`for-expression`) remain unsupported. Nested resource access, null
suppression, standalone decorators, and decorators absent from `DecoratorsNode`
have no representation in this schema and are rejected when writing JSON.
Their existing Bicep serialization is unaffected.