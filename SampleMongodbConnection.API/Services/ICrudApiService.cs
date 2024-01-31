using Microsoft.AspNetCore.Mvc;
using SampleMongodbConnection.API.DTO;

namespace SampleMongodbConnection.API.Services
{
    public interface ICrudApiService
    {
        public CrudResponse CreateOne(CrudRequest crudRequest);
        public CrudResponse GetAll();
        public CrudResponse GetById(CrudRequest crudRequest);

    }
}
