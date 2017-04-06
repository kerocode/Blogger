using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using System.Text.RegularExpressions;
using System.Net.Http;
using Blogger.Models;
using System.IO;
using Blogger.repository;
using System.Net;
using Blogger.Controllers.viewModal;

namespace Blogger.Controllers
{
    [Produces("application/json")]
    [Route("api/HeaderImage")]
    public class HeaderImageController : Controller
    {
        //private IHeaderImageRepository _headerImageRepository;
        private BloggingContext _context;
        public HeaderImageController(BloggingContext context)
        {
            //_headerImageRepository = headerImageRepository;
            _context = context;
        }

        [HttpPost, Route("addImage")]
        public async Task<IActionResult> AddImage(HeaderImageViewModel headerImageViewModel)
        {

            if (ModelState.IsValid)
            {
                var image = new HeaderImage
                {
                    ImageName = headerImageViewModel.ImageName
                };

                using (var memoryStream = new MemoryStream())
                {
                    await headerImageViewModel.ImageContent.CopyToAsync(memoryStream);
                    image.ImageContent = memoryStream.ToArray();
                }


            }

        }
    }
}