using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhateverProject.Contracts;
using WhateverProject.Contracts.V1.Requests;
using WhateverProject.Contracts.V1.Responses;
using WhateverProject.Domain;
using WhateverProject.Services;

namespace WhateverProject.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid postId)
        {
            var res = _postService.GetPostById(postId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postReq)
        {
            var post = new Post { Id = postReq.Id };

            if (Guid.Empty == post.Id)
            {
                post.Id = Guid.NewGuid();
            }
            _postService.GetPosts().Add(post);
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/";
            var location = baseUrl + ApiRoutes.Posts.Get.Replace("{postId}",post.Id.ToString());

            var res = new PostResponse { Id = postReq.Id };
            return Created(location, res);
        }
    }
}
