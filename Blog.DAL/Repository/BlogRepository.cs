using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public void AddPost(Post post)
        {
            if (post.Author == null)
                throw new ArgumentException("Author");
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
