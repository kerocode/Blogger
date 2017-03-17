using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.repository
{
    public interface IPostRepository:IBloggerRepository<Post>
    {
    }
}
