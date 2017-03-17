using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.repository
{
    public class PostRepository : BloggerBaseRespository<Post>, IPostRepository
    {
        public PostRepository(BloggingContext context)
        : base(context)
        { }
    }
}
