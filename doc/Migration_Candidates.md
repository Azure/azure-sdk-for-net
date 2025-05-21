# TypeSpec Migration Candidates

This document identifies candidates for migration from Swagger to TypeSpec based on the library inventory.

## Migration Priority

Based on the issue requirements, the following priorities are established:

1. **High Priority**: Data plane libraries currently using Swagger
2. **Medium Priority**: Management plane libraries using Swagger
3. **Low Priority**: Libraries with unknown generators

## Data Plane Libraries (Swagger → TypeSpec Migration Candidates)

Data plane libraries currently using Swagger are the highest priority for migration to TypeSpec. These libraries can be migrated as soon as the TypeSpec definitions are ready.

Note: The inventory identified 150 data plane libraries currently using Swagger.

### How to Approach the Migration

For each data plane library using Swagger:

1. Check if a TypeSpec definition is available for the service
2. Create a proof of concept branch to test the TypeSpec generator
3. Compare the generated code with the current Swagger-generated code
4. Update necessary customizations
5. Run tests to ensure compatibility
6. Submit a pull request for review

## Management Plane Libraries

Management plane libraries should be migrated after data plane libraries, as they often require more complex considerations for the ARM model.

## Next Steps

1. **Validation**: Validate the inventory classification for the most important services
2. **Prioritization**: Identify which data plane libraries to migrate first based on:
   - Usage/popularity
   - Complexity
   - Availability of TypeSpec definitions
3. **Planning**: Create a migration schedule with target dates
4. **Documentation**: Update relevant contribution guides to prefer TypeSpec for new libraries

## References

- [Library Inventory](./Library_Inventory.md)
- [Library Inventory Guide](./Library_Inventory_Guide.md)