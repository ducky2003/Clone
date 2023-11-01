using elFinder.NetCore;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {
            return View();
        }

        IWebHostEnvironment _env;
        public FileManagerController(IWebHostEnvironment env) => _env = env;

        // Url để client-side kết nối đến backend
        // /el-finder-file-system/connector
        [Route("Admin/connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            return await connector.ProcessAsync(Request);
        }

        // Địa chỉ để truy vấn thumbnail
        // /el-finder-file-system/thumb
        [Route("Admin/thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = GetConnector();
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            // uploads 
            string pathroot = "uploads";
            string requestUrl = "files";
            string DVFolder = string.Empty;// "\\2022\\sub1";
            string DVFolder1 = string.Empty;//"2022/sub1/";

            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            // uploads
            //string rootDirectory = Path.Combine(_env.ContentRootPath, pathroot) + DVFolder;
            string rootDirectory = Path.Combine(_env.ContentRootPath, pathroot);

            //string url = $"{uri.Scheme}://{uri.Authority}/{requestUrl}/";
            //string url = $"/{requestUrl}/{DVFolder1}";
            string url = $"/{requestUrl}/";
            string urlthumb = $"{uri.Scheme}://{uri.Authority}/Admin/thumb/";
            //string urlthumb = $"/{requestUrl}/";

            var root = new RootVolume(rootDirectory, url, urlthumb)
            {
                //IsReadOnly = !User.IsInRole("Administrators")
                IsReadOnly = false, // Can be readonly according to user's membership permission
                IsLocked = false, // If locked, files and directories cannot be deleted, renamed or moved
                Alias = "Files", // Beautiful name given to the root/home folder
                //MaxUploadSizeInKb = 2048, // Limit imposed to user uploaded file <= 2048 KB
                //LockedFolders = new List<string>(new string[] { "sss" }),
                ThumbnailSize = 100,
                //AccessControlAttributes = new HashSet<NamedAccessControlAttributeSet>()
                //{
                //    new NamedAccessControlAttributeSet(PathHelper.MapPath("~/files/2022/sub1"))
                //    {
                //        Read = true,
                //        Write = true,
                //        Locked = false
                //    },
                //},
            };


            driver.AddRoot(root);

            return new Connector(driver)
            {
                // This allows support for the "onlyMimes" option on the client.
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }
}
