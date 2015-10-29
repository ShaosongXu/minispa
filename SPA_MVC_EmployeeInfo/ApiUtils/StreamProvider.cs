using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SPA_MVC_EmployeeInfo.Photo
{

    public class StreamProvider : MultipartFormDataStreamProvider
    {
        public StreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = headers.ContentDisposition.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Guid.NewGuid().ToString() + ".data";
            }
            return fileName.Replace("\"", string.Empty);
        }
    }
}