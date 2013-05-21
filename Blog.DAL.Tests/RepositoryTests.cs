using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Yaml;
using TDD.DbTestHelpers.Core;

namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            //var context = new BlogContext();
            //context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            //context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
            //context.Posts.Add(new Post { Author = "test", Content = "test, test, test..." });
            //context.SaveChanges();

            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void AddPost_OnePostInDb_ReturnCorrectNumberOfPosts()
        {
            var repository = new BlogRepository();

            var post = new Post { Author = "aaa", Content = "xyz" };
            repository.AddPost(post);
            var result = repository.GetAllPosts();

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPost_WithoutRequiredData_ThrowsException()
        {
            var repository = new BlogRepository();
            var post = new Post { Author = null, Content = "xyz" };
            repository.AddPost(post);
        }
    }

    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("posts.yml");
        }
    }

    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }
    }

}