# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-03-05)

### Features Added

- Azure.Core.Expressions.DataFactory is now generally available.

### Other Changes

- `DataFactorySecretBaseDefinition` has been renamed to `DataFactorySecret`.
- `DataFactoryKeyVaultSecretReference` has been renamed to `DataFactoryKeyVaultSecret`.
- `DataFactoryLinkedServiceReferenceType` has been renamed to `DataFactoryLinkedServiceReferenceKind`.
- `DataFactoryModelFactory` has been removed.
- The `keyVaultSecretReference` parameter of the `DataFactoryElement<T>.FromKeyVaultSecretReference` method  has been renamed to `secretReference`.

## 1.0.0-beta.6 (2023-11-02)

### Bugs Fixed

- Fixed deserialization of `DataFactoryElement<BinaryData>` properties where the underlying data
  is not a JSON object.

## 1.0.0-beta.5 (2023-08-15)

### Bugs Fixed

- Added serialization support for `DataFactoryElement<BinaryData>` where the underlying
  `BinaryData` is a JSON object.

## 1.0.0-beta.4 (2023-07-13)

### Other Changes

- Added `PropertyReferenceTypeAttribute` to Data Factory types to support code generation.
- Added `DataFactoryModelFactory` to support mocking.

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
