import "../../dist/src/commontypes.private.decorators.js";

namespace Azure.ResourceManager.CommonTypes.Private;

using Reflection;

/**
 * Describes the shape of model literals accepted by the `version` parameter of
 * the `armCommonDefinition` and `armCommonParameter` decorators.
 */
alias ArmCommonTypeVersionSpec = {
  version: string | EnumMember;
  isDefault: boolean;
};

/**
 * @param definitionName Definition name
 * @param version Azure Resource Manager Version
 * @param referenceFile Reference file
 */
extern dec armCommonDefinition(
  target: Model | Enum | Union,
  definitionName?: valueof string,
  version?: valueof EnumMember | ArmCommonTypeVersionSpec | string,
  referenceFile?: valueof string
);

/**
 * @param definitionName Definition name
 * @param version Azure Resource Manager Version
 * @param referenceFile Reference file
 */
extern dec armCommonParameter(
  target: ModelProperty,
  definitionName?: valueof string,
  version?: valueof EnumMember | ArmCommonTypeVersionSpec | string,
  referenceFile?: valueof string
);

/**
 * Marks an enum as representing the valid `common-types` versions.
 */
extern dec armCommonTypesVersions(target: Enum);

/**
 * Signifies that a property can be treated as an inline type in emitters
 */
extern dec inlineAzureType(target: ModelProperty);
