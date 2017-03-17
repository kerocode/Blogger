using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.repository
{
    public class AuthorRespository : BloggerBaseRespository<Author>, IAuthorRepository
    {
        public AuthorRespository(BloggingContext context)
            : base(context)
        { }
    }
}
