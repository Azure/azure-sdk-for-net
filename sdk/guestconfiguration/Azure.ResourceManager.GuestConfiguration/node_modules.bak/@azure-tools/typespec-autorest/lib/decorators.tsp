using Reflection;

namespace Autorest;

/**
 * `@example` - attaches example files to an operation. Multiple examples can be specified.
 *
 * `@example` can be specified on Operations.
 *
 * @param pathOrUri - path or Uri to the example file.
 * @param title - name or description of the example file.
 */
extern dec example(target: Operation, pathOrUri: valueof string, title: valueof string);

/**
 * `@useRef` - is used to replace the TypeSpec model type in emitter output with a pre-existing named OpenAPI schema such as Azure Resource Manager common types.
 *
 * `@useRef` can be specified on Models and ModelProperty.
 *
 * @param jsonRef - path or Uri to an OpenAPI schema.
 */
extern dec useRef(entity: Model | ModelProperty, jsonRef: valueof string);
