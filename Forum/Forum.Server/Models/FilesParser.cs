using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Forum.ViewModels;
using Newtonsoft.Json;

namespace Forum.Server.Models
{
    public class FilesParser
    {
        private readonly string _path = HttpContext.Current.Server.MapPath("~/App_Data/Threads");

        public IEnumerable<string> AllFileNames()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            var res = Directory.GetFiles(_path);
            return res.Select(Path.GetFileNameWithoutExtension);
        }

        public ThreadViewModel GetThreadByName(string name, out ErrorMessage message)
        {
            var filePath = Path.Combine(_path, $"{name}.txt");
            if (!File.Exists(filePath))
            {
                message = new ErrorMessage
                {
                    IsOk = false,
                    Message = "File not found"
                };
                return null;
            }
            var fileContent = File.ReadAllText(filePath);
            try
            {
                var thread = JsonConvert.DeserializeObject<ThreadViewModel>(fileContent);
                message = new ErrorMessage();
                return thread;
            }
            catch (Exception e)
            {
                message = new ErrorMessage
                {
                    IsOk = false,
                    Message = e.Message
                };
                return null;
            }
            
            
        }
    }
}