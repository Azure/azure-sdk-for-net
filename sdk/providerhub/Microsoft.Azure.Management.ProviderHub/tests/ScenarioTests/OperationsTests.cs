
using Microsoft.Azure.Management.ProviderHub.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.ProviderHub.Tests
{
    public class OperationsTests
    {
        [Fact]
        public void OperationsCRUDTests()
        {
            using (var context = MockContext.Start(GetType()))
            {

                string providerNamespace = "Microsoft.Contoso";
                var content = new List<OperationsDefinition>
                {
                    new OperationsDefinition
                    {
                        Name = "Microsoft.Contoso/Operations/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "Microsoft.Contoso",
                            Resource = "Operations",
                            Operation = "Operations_read",
                            Description = "read Operations"
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "Microsoft.Contoso/locations/operationstatuses/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "Microsoft.Contoso",
                            Resource = "locations/operationstatuses",
                            Operation = "operationstatuses_read",
                            Description = "read operationstatuses"
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "Microsoft.Contoso/locations/operationstatuses/write",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "Microsoft.Contoso",
                            Resource = "locations/operationstatuses",
                            Operation = "operationstatuses_write",
                            Description = "write operationstatuses"
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/nestedResourceType/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "Microsoft.Contoso/",
                            Resource = "employees/nestedResourceType",
                            Operation = "NestedResourceType_Get",
                            Description = "Returns nested resources for a given employee name"
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/nestedResourceType/write",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees/nestedResourceType",
                            Operation = "NestedResourceType_CreateAndUpdate",
                            Description = "Create or update nested resource type."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/nestedResourceType/write",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees/nestedResourceType",
                            Operation = "NestedResourceType_Update",
                            Description = "Update nested resource type details."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/nestedResourceType/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees/nestedResourceType",
                            Operation = "NestedResourceType_List",
                            Description = "Returns nested resources for a given employee name"
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employee_ListBySubscription",
                            Description = "Returns list of employees."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employee_List",
                            Description = "Returns list of employees."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/read",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employee_Get",
                            Description = "Returns employee resource for a given name."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/write",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employee_CreateAndUpdate",
                            Description = "Create or update employee resource."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/delete",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employee_Delete",
                            Description = "Deletes employee resource for a given name."
                        }
                    },
                    new OperationsDefinition
                    {
                        Name = "microsoft.contoso/employees/write",
                        IsDataAction = false,
                        Display = new OperationsDefinitionDisplay
                        {
                            Provider = "microsoft.contoso/",
                            Resource = "employees",
                            Operation = "Employees_Update",
                            Description = "Update employee details."
                        }
                    }
                };

                var resourceProviderOperations = CreateResourceProviderOperations(context, providerNamespace, content);
                Assert.NotNull(resourceProviderOperations);

                var operationsListByProviderRegistration = ListOperationsByProviderRegistration(context, providerNamespace);
                Assert.NotNull(operationsListByProviderRegistration);
            }
        }

        private OperationsContent CreateResourceProviderOperations(MockContext context, string providerNamespace, List<OperationsDefinition> content)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.Operations.CreateOrUpdate(providerNamespace, content);
        }

        private IPage<OperationsDefinition> ListOperations(MockContext context)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.Operations.List();
        }

        private IList<OperationsDefinition> ListOperationsByProviderRegistration(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            return client.Operations.ListByProviderRegistration(providerNamespace);
        }

        private void DeleteResourceProviderOperations(MockContext context, string providerNamespace)
        {
            ProviderHubClient client = GetProviderHubManagementClient(context);
            client.Operations.Delete(providerNamespace);
        }

        private ProviderHubClient GetProviderHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<ProviderHubClient>();
        }
    }
}
