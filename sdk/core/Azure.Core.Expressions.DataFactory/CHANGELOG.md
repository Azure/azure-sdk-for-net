# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2023-06-27)

### Features Added

- Added `DataFactoryKeyVaultSecretReference`, `DataFactoryLinkedServiceReference`, `DataFactorySecretString`, and `DataFactorySecretBaseDefinition` types.

### Breaking Changes

- Renamed `DataFactoryMaskedString` to `DataFactorySecretString`.

### Bugs Fixed

- Fixed serialization of Key Vault References.

## 1.0.0-beta.2 (2023-04-10)

### Features Added

- Added the ability to create a `DataFactoryElement` from a Key Vault Reference or a Masked String.

### Breaking Changes

- The `DataFactoryExpression<T>` type has been renamed to `DataFactoryElement<T>`.
- The `HasLiteral` property was removed in favor of the `Kind` property.

## 1.0.0-beta.1 (2022-12-07)

### Features Added

- Initial release containing a new `DataFactoryExpression<T>` type for supporting both literal values and expression values for properties.
