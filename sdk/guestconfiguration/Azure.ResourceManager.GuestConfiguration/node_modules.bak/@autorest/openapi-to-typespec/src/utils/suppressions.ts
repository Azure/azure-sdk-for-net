import { TypespecTemplateModel, WithSuppressDirective } from "../interfaces";
import { NamesOfResponseTemplate } from "./type-mapping";

export enum SuppressionCode {
  NoEnum = "@azure-tools/typespec-azure-core/no-enum",
  ArmPutOperationResponseCodes = "@azure-tools/typespec-azure-resource-manager/arm-put-operation-response-codes",
  DocumentRequired = "@azure-tools/typespec-azure-core/documentation-required",
  NoResponseBody = "@azure-tools/typespec-azure-resource-manager/no-response-body",
  LroLocationHeader = "@azure-tools/typespec-azure-resource-manager/lro-location-header",
  ArmDeleteOperationResponseCodes = "@azure-tools/typespec-azure-resource-manager/arm-delete-operation-response-codes",
  ArmResourceInvalidEnvelopeProperty = "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property",
  ArmNoRecord = "@azure-tools/typespec-azure-resource-manager/arm-no-record",
  ArmResourceInterfaceRequiresDecorator = "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator",
}

export function checkArmPutOperationResponseCodes(
  responses: TypespecTemplateModel[],
  asyncNames: NamesOfResponseTemplate,
  syncNames: NamesOfResponseTemplate,
): WithSuppressDirective | undefined {
  if (
    (responses.length === 2 &&
      responses.find((r) => r.name === asyncNames._200Name) !== undefined &&
      responses.find((r) => r.name === asyncNames._201Name) !== undefined) ||
    (responses.find((r) => r.name === syncNames._201Name) !== undefined &&
      responses.find((r) => r.name === syncNames._200Name) !== undefined)
  )
    return undefined;
  return getSuppressionWithCode(SuppressionCode.ArmPutOperationResponseCodes);
}

export function checkNoResponseBody(
  responses: TypespecTemplateModel[],
  asyncNames: NamesOfResponseTemplate,
  syncNames: NamesOfResponseTemplate,
): WithSuppressDirective | undefined {
  // 202 and 204 templates don't accept body, therefore if they have a body, it must be like `& {@body _ : T}`
  function hasBody(response: TypespecTemplateModel): boolean {
    return (
      response.additionalProperties !== undefined &&
      response.additionalProperties.find(
        (p) => p.decorators?.find((d) => d.name === "bodyRoot" || d.name === "body") !== undefined,
      ) !== undefined
    );
  }

  if (
    responses.find(
      (r) =>
        ((r.name === asyncNames._202Name || r.name === syncNames._202Name) && hasBody(r)) ||
        ((r.name === asyncNames._204Name || r.name === syncNames._204Name) && hasBody(r)),
    )
  ) {
    return getSuppressionWithCode(SuppressionCode.NoResponseBody);
  } else return undefined;
}

export function checkArmDeleteOperationResponseCodes(
  responses: TypespecTemplateModel[],
  asyncNames: NamesOfResponseTemplate,
  syncNames: NamesOfResponseTemplate,
): WithSuppressDirective | undefined {
  if (
    (responses.length === 2 &&
      responses.find((r) => r.name === asyncNames._200Name) !== undefined &&
      responses.find((r) => r.name === asyncNames._204Name) !== undefined) ||
    (responses.find((r) => r.name === syncNames._204Name) !== undefined &&
      responses.find((r) => r.name === syncNames._200Name) !== undefined)
  )
    return undefined;
  else return getSuppressionWithCode(SuppressionCode.ArmDeleteOperationResponseCodes);
}

export function generateSuppressionForNoEnum(): string {
  return `#suppress "@azure-tools/typespec-azure-core/no-enum" "For backward compatibility"`;
}

export function generateSuppressions(suppressions: WithSuppressDirective[]): string[] {
  const definitions: string[] = [];
  for (const suppression of suppressions) {
    definitions.push(`#suppress "${suppression.suppressionCode}" "${suppression.suppressionMessage}"`);
  }
  return definitions;
}

export function getSuppressionWithCode(suppressionCode: SuppressionCode): WithSuppressDirective {
  return {
    suppressionCode,
    suppressionMessage: "For backward compatibility",
  };
}

export function getSuppressionsForModelExtension(): WithSuppressDirective[] {
  return [
    {
      suppressionCode: "@azure-tools/typespec-azure-core/composition-over-inheritance",
      suppressionMessage: "For backward compatibility",
    },
  ];
}

export function getSuppressionsForProvisioningState(): WithSuppressDirective[] {
  return [
    {
      suppressionCode: "@azure-tools/typespec-azure-resource-manager/arm-resource-provisioning-state",
      suppressionMessage: "For backward compatibility",
    },
  ];
}
