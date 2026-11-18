# The plugin to set experimental attributes

This plugin visits the classes and properties, detects `@extension` decorator, containing `x-ms-foundry-meta` key and marks classes and properties as experimrntal.

The plugin also preserves `At` on date and time model properties (for example, `createdAt` becomes `CreatedAt`, not `CreatedOn`). It leaves wire names, published property names, and names affected by a collision with the model name unchanged.
