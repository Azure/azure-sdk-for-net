namespace MgmtTypeSpec;

model CloudError {
  /**
   * Gets or sets additional error info.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/missing-x-ms-identifiers" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @visibility(Lifecycle.Read)
  additionalInfo?: AdditionalErrorInfo[];

  /**
   * Error code.
   */
  code?: string;

  /**
   * Gets or sets details for the error.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/missing-x-ms-identifiers" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @visibility(Lifecycle.Read)
  details?: CloudError[];

  /**
   * The error message parsed from the body of the http error response.
   */
  message?: string;

  /**
   * Gets or sets the target of the error.
   */
  target?: string;
}

/**
 * This class represents additional info which Resource Providers pass when an error occurs.
 */
model AdditionalErrorInfo {
  /**
   * Additional information of the type of error.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  info?: Record<unknown>;

  /**
   * Type of error (e.g. CustomerIntervention, PolicyViolation, SecurityViolation).
   */
  type?: string;
}