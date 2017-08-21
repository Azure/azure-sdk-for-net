using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Management.EventGrid.Models;
using Xunit;

namespace EventGrid.Tests
{
	public class OperationScenarioTests
	{
		[Fact]
		public void ListOperations()
		{
			using (TestContext context = new TestContext(this))
			{
				EventGridManagementClient client = context.GetClient<EventGridManagementClient>();

				// List operations
				IEnumerable<Operation> operations = client.Operations.List();
				Assert.NotNull(operations);
				Assert.True(operations.Any());
				foreach(Operation op in operations)
				{
					Assert.NotNull(op.Name);
					Assert.NotNull(op.Display);
					Assert.NotNull(op.Display.Provider);
					Assert.NotNull(op.Display.Resource);
					Assert.NotNull(op.Display.Operation);
					Assert.NotNull(op.Display.Description);
				}
			}
		}
	}
}
