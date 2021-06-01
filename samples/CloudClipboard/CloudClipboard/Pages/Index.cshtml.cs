using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region v11 usings
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
#endregion

namespace CloudClipboard.Pages
{
    public class IndexModel : PageModel
    {
        public string UserId => (string)HttpContext.Items["UserId"];

        public BlobServiceClient ClipsBlobService { get; }

        public IndexModel(BlobServiceClient clipService)
        {
            ClipsBlobService = clipService;
        }

        public List<string> ClipIds { get; set; } = new List<string>();

        public async Task OnGetAsync()
        {
            #region v11 ListBlobsSegmentedAsync
            /*
            CloudBlobClient blobService = (CloudBlobClient)HttpContext.RequestServices.GetService(typeof(CloudBlobClient));
            CloudBlobContainer userContainerReference = blobService.GetContainerReference(UserId);
            BlobContinuationToken continuation = null;
            do
            {
                BlobResultSegment segment = await userContainerReference.ListBlobsSegmentedAsync(null, continuation);
                continuation = segment.ContinuationToken;
                foreach (IListBlobItem clipBlobItem in segment.Results)
                {
                    ClipIds.Add(new BlobUriBuilder(clipBlobItem.Uri).BlobName);
                }
            } while (continuation != null);
            /**/
            #endregion

            #region v12 GetBlobsAsync
            BlobContainerClient userContainer = ClipsBlobService.GetBlobContainerClient(UserId);
            await foreach (BlobItem clipBlob in userContainer.GetBlobsAsync())
            {
                ClipIds.Add(clipBlob.Name);
            }
            #endregion
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Upload the new clip as a blob
            string name = Guid.NewGuid().ToString();

            #region v11 UploadFromStreamAsync
            /*
            CloudBlockBlob blob = ClipsBlobService.GetContainerReference(UserId).GetBlockBlobReference(name);
            using (var stream = GetNewClipAsStream())
            {
                await blob.UploadFromStreamAsync(stream);
            }
            /**/
            #endregion

            #region v12 UploadAsync
            BlobClient blob = ClipsBlobService.GetBlobContainerClient(UserId).GetBlobClient(name);
            using (var stream = GetNewClipAsStream())
            {
                await blob.UploadAsync(stream);
            }
            #endregion

            // Navigate to that page
            return RedirectToPage("Clip", new { userId = this.UserId, clipId = name });
        }

        [BindProperty]
        [Required]
        public string NewClip { get; set; }

        private Stream GetNewClipAsStream()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(NewClip));
        }
    }
}
