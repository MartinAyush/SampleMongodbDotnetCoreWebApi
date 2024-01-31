using SampleMongodbConnection.API.DTO;
using SampleMongodbConnection.API.Repositories;

namespace SampleMongodbConnection.API.Services
{
    public class CrudApiService : ICrudApiService
    {
        private readonly IMongoConnection _mongoConnection;

        public CrudApiService(IMongoConnection mongoConnection)
        {
            this._mongoConnection = mongoConnection;
        }

        public CrudResponse CreateOne(CrudRequest crudRequest)
        {
            var result = new CrudResponse();
            var response = _mongoConnection.CreateOne(crudRequest);
            if (response)
            {
                result.ResponseCode = "200";
                result.ResponseMessage = "Student created successfully";
            }
            else
            {
                result.ResponseCode = "500";
                result.ResponseMessage = "Something went wrong";
            }
            return result;
        }

        public CrudResponse GetAll()
        {
            var response = _mongoConnection.GetAll();
            return response;
        }

        public CrudResponse GetById(CrudRequest crudRequest)
        {
            var response = _mongoConnection.GetById(crudRequest);
            return response;
        }
    }
}
