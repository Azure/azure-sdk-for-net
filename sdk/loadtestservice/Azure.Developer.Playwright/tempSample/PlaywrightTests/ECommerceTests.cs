// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using NUnit.Framework;

// namespace PlaywrightTests;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class ECommerceTests : PageTest
// {
//     [Test]
//     public async Task AmazonHomePage()
//     {
//         await Page.GotoAsync("https://amazon.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("Amazon"));
        
//         // Search for a product
//         await Page.FillAsync("#twotabsearchtextbox", "laptop");
//         await Page.ClickAsync("#nav-search-submit-button");
        
//         // Wait for search results
//         await Page.WaitForSelectorAsync("[data-component-type='s-search-result']");
//         await Task.Delay(2000); // Add some delay to consume more test time
//     }

//     [Test]
//     public async Task EbayHomePage()
//     {
//         await Page.GotoAsync("https://ebay.com");
//         await Expect(Page).ToHaveTitleAsync(new Regex("eBay"));
        
//         // Search for a product
//         await Page.FillAsync("#gh-ac", "smartphone");
//         await Page.ClickAsync("#gh-btn");
        
//         // Wait for results
//         await Page.WaitForSelectorAsync(".s-item");
//         await Task.Delay(2000);
//     }

//     [Test]
//     public async Task ShopifyDemo()
//     {
//         await Page.GotoAsync("https://hydrogen-preview.myshopify.com");
//         await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
//         // Browse products
//         await Page.ClickAsync("text=Products");
//         await Page.WaitForSelectorAsync("[data-test='product-item']");
//         await Task.Delay(3000); // Longer delay for more test time
//     }
// }
