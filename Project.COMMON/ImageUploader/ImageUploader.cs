using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.ImageUploader
{
    public static class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file!=null)
            {
                Guid uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                string[] fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                string newfileName = $"{uniqueName}.{extension}";
                if (extension=="jpg"||extension=="gif"||extension=="jpeg"||extension=="png")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+newfileName)))
                    {
                        return "File is already exists.";
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + newfileName);
                        file.SaveAs(filePath);
                        return serverPath + newfileName;
                    }
                }
                else
                {
                    return "Chosen File is not a Picture";
                }
            }
            else
            {
                return "File is Empty";
            }
        }
    }
}
