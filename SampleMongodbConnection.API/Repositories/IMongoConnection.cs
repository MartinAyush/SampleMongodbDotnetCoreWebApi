using SampleMongodbConnection.API.DTO;

namespace SampleMongodbConnection.API.Repositories
{
    public interface IMongoConnection
    {
        public bool CreateOne(CrudRequest crudRequest);
        public CrudResponse GetAll();
        public CrudResponse GetById(CrudRequest crudRequest);
    }
}
