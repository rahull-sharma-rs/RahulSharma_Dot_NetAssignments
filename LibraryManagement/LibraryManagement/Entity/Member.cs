using Newtonsoft.Json;

namespace LibraryManagement.Entity
{
    public class Member

    {    // Unique identifier for the member
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        // Name of the member
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        // Date of birth of the member
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }


        // Email address of the member
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

    }
}
