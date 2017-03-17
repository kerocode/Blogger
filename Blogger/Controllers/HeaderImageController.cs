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

namespace Blogger.Controllers
{
    [Produces("application/json")]
    [Route("api/HeaderImage")]
    public class HeaderImageController : Controller
    {
        private IHeaderImageRepository _headerImageRepository;

        public HeaderImageController(IHeaderImageRepository headerImageRepository)
        {
            _headerImageRepository = headerImageRepository;
        }

    }
}