using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Blogger.Controllers.viewModal
{
    public class HeaderImageViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageContent { get; set; }
    }
}
