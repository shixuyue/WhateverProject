using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhateverProject.Domain;

namespace WhateverProject.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPostById(Guid postId);
    }
}
