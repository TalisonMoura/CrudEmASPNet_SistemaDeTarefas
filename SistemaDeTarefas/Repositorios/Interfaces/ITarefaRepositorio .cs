using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> FindAllTasks();
        Task<TarefaModel> FindById(int id);
        Task<TarefaModel> Create(TarefaModel tarefa);
        Task<TarefaModel> Update(TarefaModel tarefa, int id);
        Task<bool> Delete(int id);
    }
}
