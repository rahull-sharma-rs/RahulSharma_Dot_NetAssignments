using Newtonsoft.Json;

namespace LibraryManagement.Entity
{
    public class Issue
    {
        // Unique identifier for the issue
        [JsonProperty(PropertyName = "id")]
         public string Id { get; set; }


        // Identifier of the book being issued
        [JsonProperty(PropertyName = "bookId")]
        public string BookId { get; set; }


        // Identifier of the member who is issuing the book
        [JsonProperty(PropertyName = "memberId")]
         public string MemberId { get; set; }


        // Date when the book is issued
        [JsonProperty(PropertyName = "issueDate")]
         public DateTime IssueDate { get; set; }


        // Date when the book is expected to be returned
        [JsonProperty(PropertyName = "returnDate")]
         public DateTime? ReturnDate { get; set; }


        // Indicates whether the book has been returned or not
        [JsonProperty(PropertyName = "isReturned")]
         public bool IsReturned { get; set; }
    }
}
