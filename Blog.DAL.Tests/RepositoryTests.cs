﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            context.Posts.ToList().ForEach(x => context.Posts.Remove(x));

            context.Posts.Add(new Post

            {

                Author = "test",

                Content = "test, test, test..."

            });

            context.SaveChanges();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }
    }
}
