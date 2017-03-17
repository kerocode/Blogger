using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.repository
{
    public class PublisherRepository : BloggerBaseRespository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BloggingContext context)
        : base(context)
        { }
    }
}
