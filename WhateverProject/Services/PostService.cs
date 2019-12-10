using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhateverProject.Domain;

namespace WhateverProject.Services
{
    public class PostService : IPostService
    {
        private List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }

        public Post GetPostById(Guid postId)
        {
            var res = _posts.Where(x => x.Id == postId).FirstOrDefault();

            return res;
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }
    }
}
