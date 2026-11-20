# The plugin to set experimental attributes

This plugin visits the classes and properties, detects `@extension` decorator, containing `x-ms-foundry-meta` key and marks classes and properties as experimrntal.

After the generator applies its [date and time naming conventions](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/generator/docs/naming-conventions.md#date-and-time-names), the plugin replaces only the final `On` with `At` on date/time model properties and operation method parameters. For example, `startTime` becomes `StartsOn` before the plugin changes it to `StartsAt` (`startsAt` in a method signature). The plugin leaves wire names, explicit names, published names, and names that would collide unchanged.
