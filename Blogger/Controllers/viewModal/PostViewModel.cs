using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Controllers.viewModal
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int HeaderImageId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Author Author { get; set; }
    
        public Publisher Publisher { get; set; }
        public HeaderImageViewModel HeaderImage { get; set; }
        public ICollection<PostTopic> PostTopics { get; set; }
    }
}
