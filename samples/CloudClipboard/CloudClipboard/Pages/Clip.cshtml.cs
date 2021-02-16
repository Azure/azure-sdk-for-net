using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CloudClipboard.Pages
{
    public class ClipModel : PageModel
    {
        public BlobServiceClient ClipService { get; }
        public string Clip { get; set; }

        public ClipModel(BlobServiceClient clipService)
        {
            ClipService = clipService;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string clipId)
        {
            BlobClient clip = ClipService.GetBlobContainerClient(userId).GetBlobClient(clipId);
            try
            {
                BlobDownloadInfo download = await clip.DownloadAsync();
                using MemoryStream data = new MemoryStream();
                await download.Content.CopyToAsync(data);
                Clip = Encoding.UTF8.GetString(data.ToArray());
                return Page();
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }
    }
}
