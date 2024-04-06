using System.Collections.Generic;

namespace BlogEngine.PostManagement.Models.Posts.Commands
{
    public class AddNewPost
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public List<string> Keywords { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
