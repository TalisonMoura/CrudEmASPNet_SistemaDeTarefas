using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> FindAllUsers();
        Task<UsuarioModel> FindById(int id);
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
