// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

import "../../dist/src/experimental/tsp-index.js";

namespace Azure.Core.Experimental;

using Reflection;

// #region Mutative Decorators

/**
 * Changes the type of a model property to a new type.
 *
 * This can be used in situations where an existing model property type needs to be changed because it cannot be redefined.
 *
 * WARNING: This decorator mutates the model property in place and should be used with EXTREME caution.
 *
 * @param target The model property to change.
 * @param newType The new type to assign to the model property.
 */
extern dec changePropertyType(target: ModelProperty, newType: Model | Union | Scalar | Enum);

/**
 * Copies the properties of `source` that do not already exist on `target` into `target`.
 *
 * This can be used to add a group of properties to an existing model in cases where the model cannot be redefined.
 *
 * WARNING: This decorator mutates the target model in place and should be used with EXTREME caution.
 *
 * @param target The model to copy properties to.
 * @param sourceModel The model to copy properties from.
 */
extern dec copyProperties(target: Model, sourceModel: Model);

/**
 * Copies the variants of `sourceUnion` that do not already exist on `target` into `target`.
 *
 * This can be used to add a group of variants to an existing union in cases where the union cannot be redefined.
 *
 * WARNING: This decorator mutates the target union in place and should be used with EXTREME caution.
 *
 * @param target The union to copy variants to.
 * @param sourceUnion The union to copy variants from.
 */
extern dec copyVariants(target: Union, sourceUnion: Union);

// #endregion
