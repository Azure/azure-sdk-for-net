// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace HttpRecorder.Tests.DelegatingHandlers
{
    using Microsoft.Azure.Test.HttpRecorder;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class BinaryDataDelegatingHandler : RecordedDelegatingHandler
    {
        public ContentMimeType ContentType { get; private set; }

        public BinaryDataDelegatingHandler() : base() { }

        public BinaryDataDelegatingHandler(HttpResponseMessage httpResponse) : base(httpResponse) { }


        public BinaryDataDelegatingHandler(ContentMimeType mimeType): base()
        {
            ContentType = mimeType;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken cancellationToken)
        {
            // Save request
            if (req.Content == null)
            {
                Request = string.Empty;
            }
            else
            {
                Request = await req.Content.ReadAsStringAsync();
            }

            RequestHeaders = req.Headers;
            if (req.Content != null)
            {
                ContentHeaders = req.Content.Headers;
            }
            Method = req.Method;
            Uri = req.RequestUri;


            if (IsPassThrough)
            {
                return await base.SendAsync(req, cancellationToken);
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(StatusCodeToReturn);
                HttpRequestMessage reqClone = new HttpRequestMessage(req.Method, req.RequestUri);
                response.RequestMessage = reqClone;

                req.Headers.ForEach(h => response.RequestMessage.Headers.Add(h.Key, h.Value));
                response.RequestMessage.Content = req.Content;
                
                switch (ContentType)
                {
                    case ContentMimeType.Audio:
                        {
                            response.Content = new ByteArrayContent(GetBinaryData(ContentType));
                            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
                            break;
                        }

                    case ContentMimeType.Image:
                        {
                            response.Content = new ByteArrayContent(GetBinaryData(ContentType));
                            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/png");
                            break;
                        }
                    case ContentMimeType.Null:
                        {
                            response.Content = new StringContent(@"");
                            response.Content.Headers.ContentType = null;
                            break;
                        }
                }

                return response;
            }
        }

        private byte[] GetBinaryData(ContentMimeType contentType)
        {
            string filePath = GetBinaryDataFile(contentType);
            byte[] binaryData = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                MemoryStream mem = new MemoryStream();
                fs.CopyTo(mem);
                binaryData = mem.ToArray();
            }

            return binaryData;
        }

        private string GetBinaryDataFile(ContentMimeType contentType)
        {
            string codeBasePath = this.GetType().GetTypeInfo().Assembly.CodeBase;
            var uri = new UriBuilder(codeBasePath);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            string binaryFilePath = string.Empty;
            if(Directory.Exists(path))
            {
                switch(contentType)
                {
                    case ContentMimeType.Audio:
                        {
                            var files = Directory.EnumerateFiles(path, "*.wav", SearchOption.AllDirectories);
                            if(files.Any())
                            {
                                binaryFilePath = files.First<string>();
                            }
                            break;
                        }
                    case ContentMimeType.Image:
                        {
                            var files = Directory.EnumerateFiles(path, "*.png", SearchOption.AllDirectories);
                            if (files.Any())
                            {
                                binaryFilePath = files.First<string>();
                            }
                            break;
                        }
                }
            }
            return binaryFilePath;
        }
    }



    public enum ContentMimeType
    {
        Audio,
        Video,
        Image,
        OctetStream,
        MultipartFormData,
        Null
    }
}
