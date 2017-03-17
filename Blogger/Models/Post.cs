using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blogger.Models
{
    public class Post:IEntity
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int HeaderImageId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        [ForeignKey("HeaderImageId")]
        public HeaderImage HeaderImage { get; set; }
       public List<PostTopic> PostTopics { get; set; }

    }
}
