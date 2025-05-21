# TypeSpec Migration Candidates

This document identifies candidates for migration from Swagger to TypeSpec based on the library inventory.

## Current Repository State

Based on the inventory scan, we found:
- Total libraries: 424
- Management Plane (Swagger): 206
- Data Plane (Swagger): 151
- No libraries were detected as currently using TypeSpec in production code
- 67 libraries with unknown generator type

This indicates that the migration to TypeSpec is still in early stages and represents a significant effort ahead.

## Migration Priority

Based on the issue requirements, the following priorities are established:

1. **High Priority**: Data plane libraries currently using Swagger
2. **Medium Priority**: Management plane libraries using Swagger
3. **Low Priority**: Libraries with unknown generators

## Data Plane Libraries (Swagger → TypeSpec Migration Candidates)

Data plane libraries currently using Swagger are the highest priority for migration to TypeSpec. These libraries can be migrated as soon as the TypeSpec definitions are ready.

Note: The inventory identified 151 data plane libraries currently using Swagger.

### Key Data Plane Libraries to Consider for Initial Migration

When prioritizing which libraries to migrate first, consider:
1. Usage and popularity of the service
2. Simplicity of the API (simpler APIs are easier to migrate)
3. Availability of TypeSpec definitions

Some of the data plane libraries that might be good candidates for initial migration:
- Azure.AI libraries (AI services tend to have newer APIs)
- Azure.Data.* libraries
- Azure.Security.* libraries

### How to Approach the Migration

For each data plane library using Swagger:

1. Check if a TypeSpec definition is available for the service
2. Create a proof of concept branch to test the TypeSpec generator
3. Compare the generated code with the current Swagger-generated code
4. Update necessary customizations
5. Run tests to ensure compatibility
6. Submit a pull request for review

### Running a Test Migration

To test the migration of a data plane library from Swagger to TypeSpec:

```bash
# 1. Create a branch for the migration
git checkout -b feature/migrate-[service]-to-tsp

# 2. Update the autorest.md file to use TypeSpec
# Example:
# - Remove input-file pointing to Swagger files
# - Add typespec configuration

# 3. Run code generation
cd sdk/[service]/[library]
dotnet msbuild /t:GenerateCode

# 4. Build the library
dotnet build

# 5. Run tests
dotnet test
```

## Management Plane Libraries

Management plane libraries should be migrated after data plane libraries, as they often require more complex considerations for the ARM model. The inventory found 206 management plane libraries using Swagger.

## Next Steps

1. **TypeSpec Readiness**: Determine which services have TypeSpec definitions available
2. **Prioritization**: Identify which data plane libraries to migrate first based on:
   - Usage/popularity
   - Complexity
   - Availability of TypeSpec definitions
3. **Pilot Migration**: Select 2-3 data plane libraries for initial migration
4. **Planning**: Create a migration schedule with target dates
5. **Documentation**: Update relevant contribution guides to prefer TypeSpec for new libraries

## References

- [Library Inventory](./Library_Inventory.md)
- [Library Inventory Guide](./Library_Inventory_Guide.md)