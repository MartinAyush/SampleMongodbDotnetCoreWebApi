using MongoDB.Bson;
using MongoDB.Driver;
using SampleMongodbConnection.API.DTO;
using SampleMongodbConnection.API.Models;

namespace SampleMongodbConnection.API.Repositories
{
    public class MongoConnection : IMongoConnection
    {
        private readonly MongoClient _mongoClient;
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<Student> _studentCollection;
        public MongoConnection(IConfiguration configuration)
        {
            this._configuration = configuration;

            var connectionString = _configuration.GetConnectionString("Mongodb");
            var dbName = "CrudOperations";
            var collectionName = "StudentsCollection";

            _mongoClient = new MongoClient(connectionString);
            var mongoDatabase = _mongoClient.GetDatabase(dbName);
            _studentCollection = mongoDatabase.GetCollection<Student>(collectionName);
        }
        public bool CreateOne(CrudRequest crudRequest)
        {
            var student = new Student()
            {
                Id = crudRequest.Id,
                Name = crudRequest.Name,
                Address = crudRequest.Address,
                CreatedDate = DateTime.Now.ToString(),
                UpdatedDate = string.Empty,
                Email = crudRequest.Email,
                PhoneNumber = crudRequest.PhoneNumber
            };

            try
            {
                _studentCollection.InsertOne(student);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public CrudResponse GetAll()
        {
            var filter = new BsonDocument
            {
            };
            var result = _studentCollection.Find(filter).ToList();

            var response = new CrudResponse
            {
                students = result,
                ResponseCode = "200",
                ResponseMessage = "Successful"
            };

            return response;
        }

        public CrudResponse GetById(CrudRequest crudRequest)
        {
            var newStudent = new Student();
            var crudresp = new CrudResponse();
            var student = _studentCollection.Find(x => x.Id == crudRequest.Id).SingleOrDefault();
            if(student != null)
            {
                crudresp.ResponseCode = "200";
                crudresp.ResponseMessage = "Successfull";
                crudresp.student = student;
            }
            else
            {
                crudresp.ResponseCode = "201";
                crudresp.ResponseMessage = "Something went wrong!";
            }
            return crudresp;
        }
    }
}
