

using BaseLibrary.Responses;

namespace ClienteLibreria.Services.Contracts
{
    public interface IGenericServiceInterface<T>
    {
        Task<List<T>> GetAll(string url);
        Task<T> GetById(int id, string url);
        Task<GeneralResponse> Insert(T item, string url);
        Task<GeneralResponse> Update(T item, string url);
        Task<GeneralResponse> DeleteById(int id, string url);
    }
}
