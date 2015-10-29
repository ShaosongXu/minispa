using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.IO;

namespace SPA_MVC_EmployeeInfo.Photo
{
    public class LocalPhotoManager : IPhotoManager
    {

        private string workingFolder { get; set; }

        public LocalPhotoManager()
        {

        }

        public LocalPhotoManager(string workingFolder)
        {
            this.workingFolder = workingFolder;
            CheckTargetDirectory();
        }

        public async Task<PhotoActionResult> Delete(string fileName)
        {                         
            try
            {
                var filePath = Directory.GetFiles(this.workingFolder, fileName)
                                .FirstOrDefault();

                await Task.Factory.StartNew(() =>
                {
                    File.Delete(filePath);
                });

                return new PhotoActionResult { Successful = true, Message = fileName + "deleted successfully" };
            }
            catch (Exception ex)
            {
                return new PhotoActionResult { Successful = false, Message = "error deleting fileName " + ex.GetBaseException().Message};
            }            
        }

        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(this.workingFolder, fileName)
                                .FirstOrDefault();

            return file != null;
        }

        private void CheckTargetDirectory()
        {            
            if (!Directory.Exists(this.workingFolder))
            {
                throw new ArgumentException("the destination path " + this.workingFolder + " could not be found");
            }
        }
    }
}