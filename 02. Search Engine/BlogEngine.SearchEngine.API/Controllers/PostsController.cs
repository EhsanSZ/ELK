using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogEngine.SearchEngine.API.Controllers
{
    public class PostSearchEngine
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
    }

    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PostSearchEngine> Get(string value)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
              .DefaultIndex("posts");

            var client = new ElasticClient(settings);
           



            var searchResponse = client.Search<PostSearchEngine>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                     .MultiMatch(m => m
                        .Fields(
                            f => f.Field($"title^10")
                                   .Field($"shortDescription^5")
                                   .Field($"body")
                        )
                        .Query(value)
                     )
                )
            );

            var posts = searchResponse.Documents;
            return posts;
        }


    }
}
