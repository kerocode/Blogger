using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.repository
{
    public class TopicRepository : BloggerBaseRespository<Topic>, ITopicRepository
    {
        public TopicRepository(BloggingContext context)
        : base(context)
        { }

    }
}
