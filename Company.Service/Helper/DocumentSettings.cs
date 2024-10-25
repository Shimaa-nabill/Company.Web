using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFiles(IFormFile file, string foldername)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",foldername);


            var filename =$"{Guid.NewGuid()}-{file.FileName}";

            var filepath = Path.Combine(folderpath,filename);
            using var filestream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(filestream);
            return filename;
         }
    }
}
