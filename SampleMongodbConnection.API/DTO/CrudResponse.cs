using SampleMongodbConnection.API.Models;

namespace SampleMongodbConnection.API.DTO
{
    public class CrudResponse
    {
        public string? ResponseMessage { get; set; }
        public string? ResponseCode { get; set; }

        public List<Student>? students { get; set; }
        public Student? student { get; set; }
    }
}
