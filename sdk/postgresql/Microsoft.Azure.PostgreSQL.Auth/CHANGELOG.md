# Release History

## 1.0.0-beta.1 (2026-04-09)

### Features Added

- Entra ID authentication extension for Npgsql PostgreSQL driver
- Synchronous and asynchronous `UseEntraAuthentication` extension methods for `NpgsqlDataSourceBuilder`
- Automatic username extraction from JWT token claims (`upn`, `xms_mirid`, `preferred_username`, `unique_name`)
- Password provider integration with Npgsql data source builder for token-based authentication
