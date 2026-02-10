// Copyright (c) Microsoft Corporation
// Licensed under the MIT license.

import "../../dist/src/lib/tsp-index.js";

using TypeSpec.Reflection;

namespace TypeSpec;

/**
 * Sets the visibility modifiers that are active on a property, indicating that it is only considered to be present
 * (or "visible") in contexts that select for the given modifiers.
 *
 * A property without any visibility settings applied for any visibility class (e.g. `Lifecycle`) is considered to have
 * the default visibility settings for that class.
 *
 * If visibility for the property has already been set for a visibility class (for example, using `@invisible` or
 * `@removeVisibility`), this decorator will **add** the specified visibility modifiers to the property.
 *
 * See: [Visibility](https://typespec.io/docs/language-basics/visibility)
 *
 * The `@typespec/http` library uses `Lifecycle` visibility to determine which properties are included in the request or
 * response bodies of HTTP operations. By default, it uses the following visibility settings:
 *
 * - For the return type of operations, properties are included if they have `Lifecycle.Read` visibility.
 * - For POST operation parameters, properties are included if they have `Lifecycle.Create` visibility.
 * - For PUT operation parameters, properties are included if they have `Lifecycle.Create` or `Lifecycle.Update` visibility.
 * - For PATCH operation parameters, properties are included if they have `Lifecycle.Update` visibility.
 * - For DELETE operation parameters, properties are included if they have `Lifecycle.Delete` visibility.
 * - For GET or HEAD operation parameters, properties are included if they have `Lifecycle.Query` visibility.
 *
 * By default, properties have all five Lifecycle visibility modifiers enabled, so a property is visible in all contexts
 * by default.
 *
 * The default settings may be overridden using the `@returnTypeVisibility` and `@parameterVisibility` decorators.
 *
 * See also: [Automatic visibility](https://typespec.io/docs/libraries/http/operations#automatic-visibility)
 *
 * @param visibilities List of visibilities which apply to this property.
 *
 * @example
 *
 * ```typespec
 * model Dog {
 *   // The service will generate an ID, so you don't need to send it.
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   // The service will store this secret name, but won't ever return it.
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   // The regular name has all vi
 *   name: string;
 * }
 * ```
 */
extern dec visibility(target: ModelProperty, ...visibilities: valueof EnumMember[]);

/**
 * Indicates that a property is not visible in the given visibility class.
 *
 * This decorator removes all active visibility modifiers from the property within
 * the given visibility class, making it invisible to any context that selects for
 * visibility modifiers within that class.
 *
 * @param visibilityClass The visibility class to make the property invisible within.
 *
 * @example
 * ```typespec
 * model Example {
 *   @invisible(Lifecycle)
 *   hidden_property: string;
 * }
 * ```
 */
extern dec invisible(target: ModelProperty, visibilityClass: Enum);

/**
 * Removes visibility modifiers from a property.
 *
 * If the visibility modifiers for a visibility class have not been initialized,
 * this decorator will use the default visibility modifiers for the visibility
 * class as the default modifier set.
 *
 * @param target The property to remove visibility from.
 * @param visibilities The visibility modifiers to remove from the target property.
 *
 * @example
 * ```typespec
 * model Example {
 *   // This property will have all Lifecycle visibilities except the Read
 *   // visibility, since it is removed.
 *   @removeVisibility(Lifecycle.Read)
 *   secret_property: string;
 * }
 * ```
 */
extern dec removeVisibility(target: ModelProperty, ...visibilities: valueof EnumMember[]);

/**
 * Removes properties that do not have at least one of the given visibility modifiers
 * active.
 *
 * If no visibility modifiers are supplied, this decorator has no effect.
 *
 * See also: [Automatic visibility](https://typespec.io/docs/libraries/http/operations#automatic-visibility)
 *
 * When using an emitter that applies visibility automatically, it is generally
 * not necessary to use this decorator.
 *
 * @param visibilities List of visibilities that apply to this property.
 *
 * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   name: string;
 * }
 *
 * // The spread operator will copy all the properties of Dog into DogRead,
 * // and @withVisibility will then remove those that are not visible with
 * // create or update visibility.
 * //
 * // In this case, the id property is removed, and the name and secretName
 * // properties are kept.
 * @withVisibility(Lifecycle.Create, Lifecycle.Update)
 * model DogCreateOrUpdate {
 *   ...Dog;
 * }
 *
 * // In this case the id and name properties are kept and the secretName property
 * // is removed.
 * @withVisibility(Lifecycle.Read)
 * model DogRead {
 *   ...Dog;
 * }
 * ```
 */
extern dec withVisibility(target: Model, ...visibilities: valueof EnumMember[]);

/**
 * Set the visibility of key properties in a model if not already set.
 *
 * This will set the visibility modifiers of all key properties in the model if the visibility is not already _explicitly_ set,
 * but will not change the visibility of any properties that have visibility set _explicitly_, even if the visibility
 * is the same as the default visibility.
 *
 * Visibility may be set explicitly using any of the following decorators:
 *
 * - `@visibility`
 * - `@removeVisibility`
 * - `@invisible`
 *
 * @param visibility The desired default visibility value. If a key property already has visibility set, it will not be changed.
 */
extern dec withDefaultKeyVisibility(target: Model, visibility: valueof EnumMember);

/**
 * Declares the visibility constraint of the parameters of a given operation.
 *
 * A parameter or property nested within a parameter will be visible if it has _any_ of the visibilities
 * in the list.
 *
 * It is invalid to call this decorator with no visibility modifiers.
 *
 * @param visibilities List of visibility modifiers that apply to the parameters of this operation.
 */
extern dec parameterVisibility(target: Operation, ...visibilities: valueof EnumMember[]);

/**
 * Declares the visibility constraint of the return type of a given operation.
 *
 * A property within the return type of the operation will be visible if it has _any_ of the visibilities
 * in the list.
 *
 * It is invalid to call this decorator with no visibility modifiers.
 *
 * @param visibilities List of visibility modifiers that apply to the return type of this operation.
 */
extern dec returnTypeVisibility(target: Operation, ...visibilities: valueof EnumMember[]);

/**
 * Returns the model with non-updateable properties removed.
 */
extern dec withUpdateableProperties(target: Model);

/**
 * Declares the default visibility modifiers for a visibility class.
 *
 * The default modifiers are used when a property does not have any visibility decorators
 * applied to it.
 *
 * The modifiers passed to this decorator _MUST_ be members of the target Enum.
 *
 * @param visibilities the list of modifiers to use as the default visibility modifiers.
 */
extern dec defaultVisibility(target: Enum, ...visibilities: valueof EnumMember[]);

/**
 * A visibility class for resource lifecycle phases.
 *
 * These visibilities control whether a property is visible during the various phases of a resource's lifecycle.
 *
 * @example
 * ```typespec
 * model Dog {
 *  @visibility(Lifecycle.Read)
 *  id: int32;
 *
 *  @visibility(Lifecycle.Create, Lifecycle.Update)
 *  secretName: string;
 *
 *  name: string;
 * }
 * ```
 *
 * In this example, the `id` property is only visible during the read phase, and the `secretName` property is only visible
 * during the create and update phases. This means that the server will return the `id` property when returning a `Dog`,
 * but the client will not be able to set or update it. In contrast, the `secretName` property can be set when creating
 * or updating a `Dog`, but the server will never return it. The `name` property has no visibility modifiers and is
 * therefore visible in all phases.
 */
enum Lifecycle {
  /**
   * The property is visible when a resource is being created.
   */
  Create,

  /**
   * The property is visible when a resource is being read.
   */
  Read,

  /**
   * The property is visible when a resource is being updated.
   */
  Update,

  /**
   * The property is visible when a resource is being deleted.
   */
  Delete,

  /**
   * The property is visible when a resource is being queried.
   *
   * In HTTP APIs, this visibility applies to parameters of GET or HEAD operations.
   */
  Query,
}

/**
 * A visibility filter, used to specify which properties should be included when
 * using the `withVisibilityFilter` decorator.
 *
 * The filter matches any property with ALL of the following:
 * - If the `any` key is present, the property must have at least one of the specified visibilities.
 * - If the `all` key is present, the property must have all of the specified visibilities.
 * - If the `none` key is present, the property must have none of the specified visibilities.
 */
model VisibilityFilter {
  any?: EnumMember[];
  all?: EnumMember[];
  none?: EnumMember[];
}

/**
 * Applies the given visibility filter to the properties of the target model.
 *
 * This transformation is recursive, so it will also apply the filter to any nested
 * or referenced models that are the types of any properties in the `target`.
 *
 * If a `nameTemplate` is provided, newly-created type instances will be named according
 * to the template. See the `@friendlyName` decorator for more information on the template
 * syntax. The transformed type is provided as the argument to the template.
 *
 * @param target The model to apply the visibility filter to.
 * @param filter The visibility filter to apply to the properties of the target model.
 * @param nameTemplate The name template to use when renaming new model instances.
 *
 * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   name: string;
 * }
 *
 * @withVisibilityFilter(#{ all: #[Lifecycle.Read] })
 * model DogRead {
 *  ...Dog
 * }
 * ```
 */
extern dec withVisibilityFilter(
  target: Model,
  filter: valueof VisibilityFilter,
  nameTemplate?: valueof string
);

/**
 * Transforms the `target` model to include only properties that are visible during the
 * "Update" lifecycle phase.
 *
 * Any nested models of optional properties will be transformed into the "CreateOrUpdate"
 * lifecycle phase instead of the "Update" lifecycle phase, so that nested models may be
 * fully updated.
 *
 * If a `nameTemplate` is provided, newly-created type instances will be named according
 * to the template. See the `@friendlyName` decorator for more information on the template
 * syntax. The transformed type is provided as the argument to the template.
 *
 * @param target The model to apply the transformation to.
 * @param nameTemplate The name template to use when renaming new model instances.
 *
 * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   name: string;
 * }
 *
 * @withLifecycleUpdate
 * model DogUpdate {
 *   ...Dog
 * }
 * ```
 */
extern dec withLifecycleUpdate(target: Model, nameTemplate?: valueof string);

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Create" resource lifecycle phase.
 *
 * This transformation is recursive, and will include only properties that have the
 * `Lifecycle.Create` visibility modifier.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   name: string;
 * }
 *
 * // This model has only the `name` field.
 * model CreateDog is Create<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withVisibilityFilter(#{ all: #[Lifecycle.Create] }, NameTemplate)
model Create<T extends Reflection.Model, NameTemplate extends valueof string = "Create{name}"> {
  ...T;
}

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Read" resource lifecycle phase.
 *
 * The "Read" lifecycle phase is used for properties returned by operations that read data, like
 * HTTP GET operations.
 *
 * This transformation is recursive, and will include only properties that have the
 * `Lifecycle.Read` visibility modifier.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   name: string;
 * }
 *
 * // This model has the `id` and `name` fields, but not `secretName`.
 * model ReadDog is Read<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withVisibilityFilter(#{ all: #[Lifecycle.Read] }, NameTemplate)
model Read<T extends Reflection.Model, NameTemplate extends valueof string = "Read{name}"> {
  ...T;
}

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Update" resource lifecycle phase.
 *
 * The "Update" lifecycle phase is used for properties passed as parameters to operations
 * that update data, like HTTP PATCH operations.
 *
 * This transformation will include only the properties that have the `Lifecycle.Update`
 * visibility modifier, and the types of all properties will be replaced with the
 * equivalent `CreateOrUpdate` transformation.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   name: string;
 * }
 *
 * // This model will have the `secretName` and `name` fields, but not the `id` field.
 * model UpdateDog is Update<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withLifecycleUpdate(NameTemplate)
model Update<T extends Reflection.Model, NameTemplate extends valueof string = "Update{name}"> {
  ...T;
}

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Create" or "Update" resource lifecycle phases.
 *
 * The "CreateOrUpdate" lifecycle phase is used by default for properties passed as parameters to operations
 * that can create _or_ update data, like HTTP PUT operations.
 *
 * This transformation is recursive, and will include only properties that have the
 * `Lifecycle.Create` or `Lifecycle.Update` visibility modifier.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   @visibility(Lifecycle.Create)
 *   immutableSecret: string;
 *
 *   @visibility(Lifecycle.Create, Lifecycle.Update)
 *   secretName: string;
 *
 *   name: string;
 * }
 *
 * // This model will have the `immutableSecret`, `secretName`, and `name` fields, but not the `id` field.
 * model CreateOrUpdateDog is CreateOrUpdate<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withVisibilityFilter(#{ any: #[Lifecycle.Create, Lifecycle.Update] }, NameTemplate)
model CreateOrUpdate<
  T extends Reflection.Model,
  NameTemplate extends valueof string = "CreateOrUpdate{name}"
> {
  ...T;
}

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Delete" resource lifecycle phase.
 *
 * The "Delete" lifecycle phase is used for properties passed as parameters to operations
 * that delete data, like HTTP DELETE operations.
 *
 * This transformation is recursive, and will include only properties that have the
 * `Lifecycle.Delete` visibility modifier.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   // Set when the Dog is removed from our data store. This happens when the
 *   // Dog is re-homed to a new owner.
 *   @visibility(Lifecycle.Delete)
 *   nextOwner: string;
 *
 *   name: string;
 * }
 *
 * // This model will have the `nextOwner` and `name` fields, but not the `id` field.
 * model DeleteDog is Delete<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withVisibilityFilter(#{ all: #[Lifecycle.Delete] }, NameTemplate)
model Delete<T extends Reflection.Model, NameTemplate extends valueof string = "Delete{name}"> {
  ...T;
}

/**
 * A copy of the input model `T` with only the properties that are visible during the
 * "Query" resource lifecycle phase.
 *
 * The "Query" lifecycle phase is used for properties passed as parameters to operations
 * that read data, like HTTP GET or HEAD operations. This should not be confused for
 * the `@query` decorator, which specifies that the property is transmitted in the
 * query string of an HTTP request.
 *
 * This transformation is recursive, and will include only properties that have the
 * `Lifecycle.Query` visibility modifier.
 *
 * If a `NameTemplate` is provided, the new model will be named according to the template.
 * The template uses the same syntax as the `@friendlyName` decorator.
 *
 * @template T The model to transform.
 * @template NameTemplate The name template to use for the new model.
 *
 *  * @example
 * ```typespec
 * model Dog {
 *   @visibility(Lifecycle.Read)
 *   id: int32;
 *
 *   // When getting information for a Dog, you can set this field to true to include
 *   // some extra information about the Dog's pedigree that is normally not returned.
 *   // Alternatively, you could just use a separate option parameter to get this
 *   // information.
 *   @visibility(Lifecycle.Query)
 *   includePedigree?: boolean;
 *
 *   name: string;
 *
 *   // Only included if `includePedigree` is set to true in the request.
 *   @visibility(Lifecycle.Read)
 *   pedigree?: string;
 * }
 *
 * // This model will have the `includePedigree` and `name` fields, but not `id` or `pedigree`.
 * model QueryDog is Query<Dog>;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@withVisibilityFilter(#{ all: #[Lifecycle.Query] }, NameTemplate)
model Query<T extends Reflection.Model, NameTemplate extends valueof string = "Query{name}"> {
  ...T;
}
