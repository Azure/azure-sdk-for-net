// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using NUnit.Framework;

// namespace PlaywrightTests;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class LongRunningTests : PageTest
// {
//     [Test]
//     public async Task FormSubmissionTest()
//     {
//         await Page.GotoAsync("https://httpbin.org/forms/post");
        
//         // Fill out the form slowly
//         await Page.FillAsync("input[name='custname']", "Test Customer");
//         await Task.Delay(1000);
        
//         await Page.FillAsync("input[name='custtel']", "123-456-7890");
//         await Task.Delay(1000);
        
//         await Page.FillAsync("input[name='custemail']", "test@example.com");
//         await Task.Delay(1000);
        
//         await Page.SelectOptionAsync("select[name='size']", "large");
//         await Task.Delay(1000);
        
//         await Page.CheckAsync("input[name='topping'][value='bacon']");
//         await Task.Delay(1000);
        
//         await Page.FillAsync("textarea[name='comments']", "This is a test order for playwright automation testing.");
//         await Task.Delay(2000);
        
//         await Page.ClickAsync("input[type='submit']");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(1000);
//     }

//     [Test]
//     public async Task FileUploadTest()
//     {
//         await Page.GotoAsync("https://httpbin.org/forms/post");
        
//         // Simulate file operations (longer test)
//         await Task.Delay(3000);
        
//         await Page.FillAsync("input[name='custname']", "File Upload Test");
//         await Task.Delay(2000);
        
//         await Page.FillAsync("textarea[name='comments']", "Testing file upload functionality with extended wait times");
//         await Task.Delay(3000);
        
//         await Page.ClickAsync("input[type='submit']");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
//         await Task.Delay(2000);
//     }

//     [Test]
//     public async Task MultiPageNavigationTest()
//     {
//         // Test that navigates through multiple pages
//         await Page.GotoAsync("https://example.com");
//         await Task.Delay(2000);
        
//         await Page.GotoAsync("https://httpbin.org");
//         await Task.Delay(2000);
        
//         await Page.GotoAsync("https://httpbin.org/html");
//         await Task.Delay(2000);
        
//         await Page.GotoAsync("https://httpbin.org/json");
//         await Task.Delay(2000);
        
//         await Page.GotoAsync("https://httpbin.org/xml");
//         await Task.Delay(2000);
        
//         // Go back through history
//         await Page.GoBackAsync();
//         await Task.Delay(1000);
        
//         await Page.GoBackAsync();
//         await Task.Delay(1000);
        
//         await Page.GoForwardAsync();
//         await Task.Delay(1000);
//     }
// }
