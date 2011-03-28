using System.Collections.Generic;

namespace PATestApp.Entities {
    public class Book {
        public Book(){
            Authors = new List<string>();
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public decimal Price { get; set; }
        public int PublishedYear { get; set; }
    }
}
