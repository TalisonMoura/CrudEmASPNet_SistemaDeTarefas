using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDBContex _dbContext;
        public UsuarioRepositorio(SistemaDeTarefasDBContex sistemaDeTarefasDBContex)
        {
            _dbContext = sistemaDeTarefasDBContex;
        }

        public async Task<List<UsuarioModel>> FindAllUsers()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> FindById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel userById = await FindById(id);
            if (userById == null) 
            {
                throw new Exception($"User for ID: {id} not found in Database");
            }
            userById.Nome = usuario.Nome;
            userById.Email = usuario.Email;
            _dbContext.Usuarios.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel userById = await FindById(id);
            if (userById == null)
            {
                throw new Exception($"User for ID: {id} not found in Database");
            }
            _dbContext.Usuarios.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
