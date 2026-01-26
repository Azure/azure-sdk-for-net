import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Foundations;
using Azure.ClientGenerator.Core;
using Azure.Core;

namespace MgmtTypeSpec;

#suppress "@azure-tools/typespec-azure-core/no-openapi" "Required to avoid breaking SDK change"
alias ParentResourceParameters = {
  /**
   * The parent resource provider namespace.
   */
  @path
  @segment("providers")
  @maxLength(63)
  @pattern("^[a-zA-Z0-9][a-zA-Z0-9-_.]{2,62}$")
  parentProviderNamespace: string;

  /**
   * The parent resource type.
   */
  @path
  @maxLength(63)
  @pattern("^[a-zA-Z0-9][a-zA-Z0-9-_.]{2,62}$")
  parentResourceType: string;

  /**
   * The parent resource name.
   */
  @path
  @maxLength(63)
  @pattern("^[a-zA-Z0-9][a-zA-Z0-9-_.]{2,62}$")
  parentResourceName: string;
};

/**
 * Model that represents a Target resource.
 */
model Target is Azure.ResourceManager.ProxyResource<Record<unknown>, false> {
  ...ResourceNameParameter<
    Resource = Target,
    KeyName = "targetName",
    SegmentName = "targets",
    NamePattern = "^[a-zA-Z0-9_\\-\\.]+$"
  >;

  /**
   * Azure resource location.
   */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property" "Required to avoid SDK breaking change."
  location?: azureLocation;
}

alias TargetParentResourceParameters = BaseParameters<Target> &
  ParentResourceParameters;

/**
 * Model that represents a list of Target resources and a link for pagination.
 */
model TargetListResult is Azure.Core.Page<Target>;

@armResourceOperations
interface Targets {
  /**
   * Get a Target resource that extends a tracked regional resource.
   */
  get is ArmResourceRead<Target, TargetParentResourceParameters>;

  /**
   * Create or update a Target resource that extends a tracked regional resource.
   */
  createOrUpdate is ArmResourceCreateOrReplaceSync<
    Target,
    TargetParentResourceParameters
  >;

  /**
   * Delete a Target resource that extends a tracked regional resource.
   */
  delete is ArmResourceDeleteSync<Target, TargetParentResourceParameters>;

  /**
   * Get a list of Target resources that extend a tracked regional resource.
   */
  list is ArmResourceListByParent<
    Target,
    {
      ...TargetParentResourceParameters;

      /**
       * String that sets the continuation token.
       */
      @query("continuationToken")
      continuationToken?: string;
    },
    Response = TargetListResult
  >;
}

@@doc(Target.name, "String that represents a Target resource name.");
@@doc(Target.properties, "The properties of the target resource.");
@@doc(Targets.createOrUpdate::parameters.resource,
  "Target resource to be created or updated."
);

/**
 * Model that represents a Experiment resource.
 */
#suppress "@azure-tools/typespec-azure-core/no-private-usage" "Required implementation to avoid breaking .NET SDK changes"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Required implementation to avoid breaking .NET SDK changes"
@Azure.ResourceManager.Private.armResourceInternal(ExperimentProperties)
@Http.Private.includeInapplicableMetadataInPayload(false)
model Experiment extends Azure.ResourceManager.Foundations.TrackedResource {
  ...ResourceNameParameter<
    Resource = Experiment,
    KeyName = "experimentName",
    SegmentName = "experiments",
    NamePattern = "^[^<>%&:?#/\\\\]+$"
  >;
  ...Azure.ResourceManager.ManagedServiceIdentityProperty;

  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property" "Required implementation to avoid breaking .NET SDK changes"
  @doc("The resource-specific properties for this resource.")
  @Azure.ResourceManager.Private.armResourcePropertiesOptionality(false)
  properties?: ExperimentProperties;
}

/**
 * Model that represents the Experiment properties model.
 */
model ExperimentProperties {
  /**
   * Most recent provisioning state for the given experiment resource.
   */
  @visibility(Lifecycle.Read)
  provisioningState?: string;
}

/**
 * Model that represents a list of Experiment resources and a link for pagination.
 */
model ExperimentListResult is Azure.Core.Page<Experiment>;

@armResourceOperations
interface Experiments {
  /**
   * Get a Experiment resource.
   */
  get is ArmResourceRead<Experiment>;

  /**
   * Create or update a Experiment resource.
   */
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Experiment>;

  /**
   * Get a list of Experiment resources in a resource group.
   */
  list is ArmResourceListByParent<
    Experiment,
    Parameters = {
      /**
       * Optional value that indicates whether to filter results based on if the Experiment is currently running. If null, then the results will not be filtered.
       */
      @query("running")
      running?: boolean;

      /**
       * String that sets the continuation token.
       */
      @query("continuationToken")
      continuationToken?: string;
    },
    Response = ExperimentListResult
  >;

  /**
   * Get a list of Experiment resources in a subscription.
   */
  getExperiments is ArmListBySubscription<
    Experiment,
    Parameters = {
      /**
       * Optional value that indicates whether to filter results based on if the Experiment is currently running. If null, then the results will not be filtered.
       */
      @query("running")
      running?: boolean;

      /**
       * String that sets the continuation token.
       */
      @query("continuationToken")
      continuationToken?: string;
    },
    Response = ExperimentListResult
  >;
}