using LibraryManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace LibraryManagement.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class LibraryManagementController : ControllerBase {
        // URI for connecting to the Cosmos DB Emulator
        public string URI = "https://localhost:8081";

        // Primary key for authenticating access to the Cosmos DB Emulator
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        // Name of the database in Cosmos DB
        public string DatabaseName = "LibraryManagementSystem";

        // Containers for storing different types of entities
        public Container BookContainer;
        public Container MemberContainer;
        public Container IssueContainer;

        // Constructor to initialize containers
        public LibraryManagementController()
        {
            BookContainer = GetContainer("Book");
            MemberContainer = GetContainer("Member");
            IssueContainer = GetContainer("Issue");
        }

        // Method to get a container by name
        private Container GetContainer(String ContainerName)
        {
            // Initialize Cosmos Client with URI and Primary Key
            CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);

            // Get the specified database
            Database database = cosmosClient.GetDatabase(DatabaseName);

            // Get the specified container within the database
            Container container = database.GetContainer(ContainerName);

            return container;
        }


        //FOR BOOK


        // API method to add a book to the database
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            // Check if the book object is null
            if (book == null)
            {
                return BadRequest("Book cannot be null.");
            }
            // Ensure the book has a unique ID
            if (string.IsNullOrEmpty(book.Id))
            {
                book.Id = Guid.NewGuid().ToString(); // Ensure the book has a unique ID
            }
            // Create the book item in the Book container
            await BookContainer.CreateItemAsync(book);

            return Ok(book);
        }

        // API method to retrieve a book by its ID
        [HttpGet]
        public async Task<Book> GetBookById(string id)
        {
            // Retrieve the book from the Book container by ID
            var book = BookContainer.GetItemLinqQueryable<Book>(true).Where(q => q.Id == id).FirstOrDefault();
            return book;
        }

        // API method to retrieve all books
        [HttpGet]
        public async Task<List<Book>> GetAllBook()
        {
            // Retrieve all books from the Book container
            var book = BookContainer.GetItemLinqQueryable<Book>(true).ToList();
          
            return book;

        }


        // API method to retrieve all available books (not issued)
        [HttpGet]
        public async Task<List<Book>> GetAvailableBooks()
        {
            // Retrieve all available books (not issued) from the Book container
            var availableBooks = BookContainer.GetItemLinqQueryable<Book>(true)
                                               .Where(b => !b.IsIssued)
                                               .ToList();

            return availableBooks;

        }


        // API method to retrieve all issued books
        [HttpGet]
        public async Task<List<Book>> GetIssuedBooks()
        {
            // Retrieve all issued books from the Book container
            var availableBooks = BookContainer.GetItemLinqQueryable<Book>(true)
                                                .Where(b => b.IsIssued)
                                                .ToList();

            return availableBooks;

        }

        // API method to retrieve a book by its name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Book>> GetBookByName(string name)
        {
            // Retrieve the book from the Book container by name
            var book = BookContainer.GetItemLinqQueryable<Book>(true)
                                      .Where(q => q.Title == name)
                                      .AsEnumerable()
                                      .FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // API method to update a book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] Book updatedBook)
        {
            // Check if the updated book object or ID is null
            if (updatedBook == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid book data or ID.");
            }
            // Retrieve the existing book from the Book container by ID
            var book = BookContainer.GetItemLinqQueryable<Book>(true)
                                     .Where(q => q.Id == id)
                                     .AsEnumerable()
                                     .FirstOrDefault();
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            // Update book properties with the new values
            book.Author = updatedBook.Author;
            book.Title = updatedBook.Title;
            book.IsIssued = updatedBook.IsIssued;
            // Update other properties as needed
            // Replace the existing book item in the Book container
            await BookContainer.ReplaceItemAsync(book, book.Id);

            return Ok(book);
        }

        // API method to delete a book by its ID which i have added extra
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(string id)
        {
            try
            {
                // Retrieve the book from the Book container by ID
                var book = BookContainer.GetItemLinqQueryable<Book>(true)
                                          .Where(q => q.Id == id)
                                          .AsEnumerable()
                                          .FirstOrDefault();
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }
                // Delete the book item from the Book container
                await BookContainer.DeleteItemAsync<Book>(id, new PartitionKey(id));
                return NoContent();
            }
            catch (CosmosException ex)
            {
                // Handle Cosmos DB exceptions
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception)
            {
                // Handle unexpected exceptions
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }






        // FOR MEMBER

        // API method to add a member to the database
        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            // Check if the member object is null
            if (member == null)
            {
                return BadRequest("Member cannot be null.");
            }
            // Ensure the member has a unique ID
            if (string.IsNullOrEmpty(member.Id))
            {
                member.Id = Guid.NewGuid().ToString(); // Ensure the member has a unique ID
            }
            // Create the member item in the Member container
            await MemberContainer.CreateItemAsync(member);

            return Ok(member);
        }

        // API method to get all member from database
        [HttpGet]
        public async Task<List<Member>> GetAllMember()
        {
            // Retrieve all member items from the Member container
            var member = BookContainer.GetItemLinqQueryable<Member>(true).ToList();

            return member;

        }

        // API method to get a member by ID from the database
        [HttpGet]
        public async Task<Member> GetMemberById(string id)
        {
            // Retrieve a member item by ID from the Member container
            var member = MemberContainer.GetItemLinqQueryable<Member>(true).Where(q => q.Id == id).FirstOrDefault();
            return member;
        }


        // API method to update a member in the database
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(string id, [FromBody] Member updatedMember)
        {
            // Check if the updatedMember object is null or if ID is empty
            if (updatedMember == null || string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid Member data or ID.");
            }
            // Retrieve the existing member by ID from the Member container
            var member = MemberContainer.GetItemLinqQueryable<Member>(true)
                                     .Where(q => q.Id == id)
                                     .AsEnumerable()
                                     .FirstOrDefault();
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            // Update member properties with the values from updatedMember
            member.Name = updatedMember.Name;
            member.DateOfBirth = updatedMember.DateOfBirth;
            member.Email = updatedMember.Email;
            // Update other properties as needed
            // Replace the existing member item with the updated member item in the Member container
            await MemberContainer.ReplaceItemAsync(member, member.Id);

            return Ok(member);
        }






        //FOR ISSUE

        // API method to issue a book to a member
        [HttpPost("issue")]
        public async Task<IActionResult> IssueBook([FromBody] Issue issue)
        {
            // Check if the issue object is null
            if (issue == null)
            {
                return BadRequest("Issue cannot be null.");
            }

            // Validate that the BookId exists
            var book = BookContainer.GetItemLinqQueryable<Book>(true)
                                     .Where(b => b.Id == issue.BookId)
                                     .AsEnumerable()
                                     .FirstOrDefault();
            if (book == null)
            {
                return BadRequest("BookId does not exist.");
            }

            // Validate that the MemberId exists
            var member = MemberContainer.GetItemLinqQueryable<Member>(true)
                                         .Where(m => m.Id == issue.MemberId)
                                         .AsEnumerable()
                                         .FirstOrDefault();
            if (member == null)
            {
                return BadRequest("MemberId does not exist.");
            }
            // Generate a unique ID for the issue
            issue.Id = Guid.NewGuid().ToString();
            // Set the issue date to the current UTC date and time
            issue.IssueDate = DateTime.UtcNow;
            // Set the IsReturned flag to false as the book is issued
            issue.IsReturned = false;

            // Create the issue item in the Issue container
            await IssueContainer.CreateItemAsync(issue);

            return Ok(issue);
        }

        // API method to get an issue by its unique ID
        [HttpGet("issue/{uid}")]
        public async Task<ActionResult<Issue>> GetIssueById(string uid)
        {
            // Retrieve the issue item by its unique ID from the Issue container
            var issue = IssueContainer.GetItemLinqQueryable<Issue>(true)
                                       .Where(i => i.Id == uid)
                                       .AsEnumerable()
                                       .FirstOrDefault();
            if (issue == null)
            {
                return NotFound();
            }
            return issue;
        }

        // API method to update an existing issue
        [HttpPut("issue/{uid}")]
        public async Task<IActionResult> UpdateIssue(string uid, [FromBody] Issue updatedIssue)
        {
            // Check if the updatedIssue object is null
            if (updatedIssue == null)
            {
                return BadRequest("Issue cannot be null.");
            }
            // Retrieve the existing issue by its unique ID from the Issue container
            var issue = IssueContainer.GetItemLinqQueryable<Issue>(true)
                                       .Where(i => i.Id == uid)
                                       .AsEnumerable()
                                       .FirstOrDefault();
            if (issue == null)
            {
                return NotFound();
            }
            // Update issue properties with the values from updatedIssue
            issue.BookId = updatedIssue.BookId;
            issue.MemberId = updatedIssue.MemberId;
            issue.IssueDate = updatedIssue.IssueDate;
            issue.ReturnDate = updatedIssue.ReturnDate;
            issue.IsReturned = updatedIssue.IsReturned;

            // Replace the existing issue item with the updated issue item in the Issue container
            await IssueContainer.ReplaceItemAsync(issue, uid);

            return Ok(issue);
        }


    }


}
