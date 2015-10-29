using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using SPA_MVC_EmployeeInfo.Photo;

namespace SPA_MVC_EmployeeInfo.Controllers
{

    public class FileUploadController : ApiController
    {
        public async Task<List<string>> PostAsync()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/uploads");

                StreamProvider streamProvider = new StreamProvider(uploadPath);

                await Request.Content.ReadAsMultipartAsync(streamProvider);
                
                List<string> messages = new List<string>();
                foreach(var file in streamProvider.FileData)
                {
                    FileInfo fi = new FileInfo(file.LocalFileName);
                    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
                }
                
                return messages;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Request!");
                throw new HttpResponseException(response);
            }
        }

        public async Task<IHttpActionResult> Delete(string fileName)
        {
            IPhotoManager photoManager = new LocalPhotoManager(HttpRuntime.AppDomainAppPath + @"\uploads");
            if (!photoManager.FileExists(fileName))
            {
                return NotFound();
            }

            var result = await photoManager.Delete(fileName);

            if (result.Successful)
            {
                return Ok(new { message = result.Message });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

    }
}