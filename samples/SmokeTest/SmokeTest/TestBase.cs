using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTest
{
    abstract class TestBase
    {
        protected async Task<bool> ExcecuteTest(Func<Task> testAction)
        {
            try
            {
                await testAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAILED.");
                Console.WriteLine(ex);
                return false;
            }

            Console.WriteLine("DONE.");
            return true;
        }
    }
}
