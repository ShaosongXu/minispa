using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SPA_MVC_EmployeeInfo.Photo

{
    public interface IPhotoManager
    {
        Task<PhotoActionResult> Delete(string fileName);
        bool FileExists(string fileName);
    }
}
