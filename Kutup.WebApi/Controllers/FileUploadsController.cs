using Kutup.Core.Application.Interfaces.Services;
using Kutup.Services.Services;
using Kutup.Core.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kutup.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly IBookMapService _bookMapService;

        public FileUploadsController(IWebHostEnvironment webHostEnvironment, IBookMapService bookMapService)
        {
            _webHostEnvironment = webHostEnvironment;
            _bookMapService = bookMapService;
        }

        [HttpPost]
        public string Post([FromForm]FileUpload objectFile)
        {
            try
            {
                if (objectFile.files.Length > 0)
                {
                    string path = _webHostEnvironment.ContentRootPath + @"\uploads\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
                    {
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded";
                    }
                }
                else
                {
                    return "File not uploaded";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }    
        }

        [HttpGet]
        public List<string> GetNodes()
        {
            string path = _webHostEnvironment.ContentRootPath + @"\uploads\" + "sanalpazar.xml";
            List<string> xmlNodes;
            xmlNodes = _bookMapService.XmlGetNodes(path);
            return xmlNodes;
        }
    }
}
