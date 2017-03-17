using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.repository
{
    public class HeaderImageRepository : BloggerBaseRespository<HeaderImage>, IHeaderImageRepository
    {
        public HeaderImageRepository(BloggingContext context)
        : base(context)
        { }
    }


}
