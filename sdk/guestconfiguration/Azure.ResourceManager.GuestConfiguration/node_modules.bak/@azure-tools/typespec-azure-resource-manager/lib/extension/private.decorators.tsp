using Reflection;

namespace Azure.ResourceManager.Extension.Private;

/**
 * `@builtInResource` marks a model as built-in to Azure ResourceManager at the tenant level
 *
 * @param target - The model that is marked as built-in.
 */
extern dec builtInResource(target: Model);

/**
 * `@builtInSubscriptionResource` marks a model as built-in to Azure ResourceManager at the Subscription level
 *
 * @param target - The model that is marked as built-in.
 */
extern dec builtInSubscriptionResource(target: Model);

/**
 * `@builtInResourceGroupResource` marks a model as built-in to Azure ResourceManager at the ResourceGroup level
 *
 * @param target - The model that is marked as built-in.
 */
extern dec builtInResourceGroupResource(target: Model);
