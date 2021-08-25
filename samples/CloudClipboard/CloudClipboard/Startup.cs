using System;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region v11 usings
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Services.AppAuthentication;
#endregion

namespace CloudClipboard
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Add v11 CloudBlobClient
            /*
            AzureServiceTokenProvider tokenProvider = new AzureServiceTokenProvider();
            string token = tokenProvider.GetAccessTokenAsync("https://storage.azure.com/").GetAwaiter().GetResult();
            TokenCredential tokenCredential = new TokenCredential(token);
            StorageCredentials storageCredentials = new StorageCredentials(tokenCredential);
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(Configuration["BlobServiceUri"]), storageCredentials);
            services.AddSingleton(blobClient);
            /**/
            #endregion

            #region Add v12 BlobServiceClient

            services.AddAzureClients(builder => builder.AddBlobServiceClient(new Uri(Configuration["BlobServiceUri"])));

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.Use(EnsureUserIdAndContainer);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private RequestDelegate EnsureUserIdAndContainer(RequestDelegate next)
        {
            return async ctx =>
            {
                // Get the UserId from our Cookies or create it and save it for this request
                if (!ctx.Request.Cookies.TryGetValue("UserId", out string userId))
                {
                    userId = Guid.NewGuid().ToString();
                }
                ctx.Items["UserId"] = userId;
                ctx.Response.Cookies.Append("UserId", userId);

                // Create a container for the user if it doesn't already exist
                BlobServiceClient serviceClient = ctx.RequestServices.GetService<BlobServiceClient>();
                await serviceClient.GetBlobContainerClient(userId).CreateIfNotExistsAsync();
                
                // Continue processing
                await next(ctx);
            };
        }
    }
}
