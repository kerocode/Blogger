using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blogger.repository;
using Blogger.Models;
using System.IO;
using Blogger.Controllers.viewModal;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Blogger.Controllers
{
    [Route("api/post")]
    public class PostsController : Controller
    {
        private BloggingContext _context;
        //private IPostRepository _postRepository;
        //private IAuthorRepository _authorRepository;
        //private IPublisherRepository _publisherRepository;
        //private ITopicRepository _topicRepository;
        public PostsController(BloggingContext context)
        {
            _context = context;
            //    IPostRepository postRepository,
            //    ITopicRepository topicRepository,IAuthorRepository authorRepository,
            //  IPublisherRepository publisherRepository,
            //    _postRepository = postRepository;
            //    _authorRepository = authorRepository;
            //    _publisherRepository = publisherRepository;
            //    _topicRepository = topicRepository;
        }


        // GET api/values
        [HttpGet, Route("GetAllPosts")]
        public IActionResult GetAll()
        {
            List<Post> posts = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.PostTopics)
                  .ThenInclude(postTopic => postTopic.Topic)
                .Include(p => p.HeaderImage)
                .ToList();
            //IEnumerable<Post> posts = _postRepository
            //    .AllIncluding(p => p.Author, p => p.Publisher)
            //    .ToList();
            //foreach (var post in posts)
            //{
            //    post
            //}
            if (posts != null)
            {
                return Json(posts);
            }
            else
            {
                return NotFound();
            }

        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult Get(int id)
        {
            var post = _context.Posts
               .Single(p => p.Id == id);
            _context.Entry(post)
                    .Reference(b => b.Publisher)
                    .Load();
            _context.Entry(post)
                    .Reference(b => b.Author)
                    .Load();
            _context.Entry(post)
                    .Reference(b => b.HeaderImage)
                    .Load();
            _context.Entry(post)
                .Collection(p => p.PostTopics)
                .Query()
                .ToList();
            if (post != null)
            {
                return Json(post);
            }
            else
            {
                return NotFound();
            }

        }
        // GET api/values/5
        [HttpPost]
        public IActionResult Add([FromBody]Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return Ok();
            }
        
            else
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }


        }

        // POST api/values
        //[HttpPost]
        //public async Task<IActionResult> PostBlog([FromBody]PostViewModel model)
        //{
        //    if (model==null)
        //    {
        //        return BadRequest();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var post = new Post
        //        {
        //            Title = model.Title,
        //            Body = model.Body,
        //            Publisher=model.Publisher,
        //            Author=model.Author,
        //            PostTopics=model.PostTopics
        //        };
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await model.HeaderImage.ImageContent.CopyToAsync(memoryStream);
        //            post.HeaderImage.ImageContent = memoryStream.ToArray();
        //        }
        //        _postRepository.Add(post);
        //        _postRepository.Commit();
        //    }
        //    CreatedAtRouteResult result = CreatedAtRoute("GetPost", new { controller = "Post", id = model.Id }, model);
        //    return result;
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
