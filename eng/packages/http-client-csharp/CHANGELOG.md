# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Added support for TCGC `@lroStatusMetadata`. By default this adds no public API: convenience methods keep returning `Operation<T>` or `Operation` and, at runtime, return an internal `{Method}Operation` subclass with one nullable property per selected status-monitor field. Values come from the latest status-monitor response, refresh on every poll (including failed and canceled polls), and are not stored in the rehydration token. A library can opt in to a public type by adding a partial class that renames the operation with `[CodeGenType]` and declares it public; the convenience methods then return that type.
