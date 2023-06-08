using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    { 
        private readonly SistemaDeTarefasDBContex _dbContext;
        public TarefaRepositorio(SistemaDeTarefasDBContex sistemaDeTarefasDBContex)
        {
            _dbContext = sistemaDeTarefasDBContex;
        }

        public async Task<List<TarefaModel>> FindAllTasks()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> FindById(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModel> Create(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Update(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaById = await FindById(id);
            if (tarefaById == null) 
            {
                throw new Exception($"Task for ID: {id} not found in Database");
            }
            tarefaById.Nome = tarefa.Nome;
            tarefaById.Descricao = tarefa.Descricao;
            tarefaById.Status = tarefa.Status;
            tarefaById.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaById);
            await _dbContext.SaveChangesAsync();

            return tarefaById;
        }

        public async Task<bool> Delete(int id)
        {
            TarefaModel tarefaById = await FindById(id);
            if (tarefaById == null)
            {
                throw new Exception($"User for ID: {id} not found in Database");
            }
            _dbContext.Tarefas.Remove(tarefaById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
