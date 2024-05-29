using Newtonsoft.Json;

namespace LibraryManagement.Entity
{
    public class Book
    {
        // Unique identifier for the book
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        // Title of the book
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        // Author of the book
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        // Date when the book was published
        [JsonProperty(PropertyName = "publishedDate")]
        public DateTime PublishedDate { get; set; }


        // International Standard Book Number (ISBN) of the book
        [JsonProperty(PropertyName = "isbn")]
        public string ISBN { get; set; }

        // Indicates whether the book is currently issued or not
        [JsonProperty(PropertyName = "isIssued")]
        public bool IsIssued { get; set; }

    }
}
