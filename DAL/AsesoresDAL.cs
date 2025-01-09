using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Citas.Administrador.Modelos;

namespace WebApi.Citas.Administrador.DAL
{
    public class AsesoresDAL
    {
        private readonly BDConexion _context;

        public AsesoresDAL(BDConexion context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsesoresModel>> GetAllAsync()
        {
            return await _context.Asesores.ToListAsync();
        }

        // Aquí cambiamos el tipo de retorno a 'AsesoresModel?' para permitir nulos
        public async Task<AsesoresModel?> GetByIdAsync(long id)
        {
            return await _context.Asesores.FindAsync(id);
        }

        public async Task AddAsync(AsesoresModel asesor)
        {
            await _context.Asesores.AddAsync(asesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AsesoresModel asesor)
        {
            _context.Asesores.Update(asesor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var asesor = await _context.Asesores.FindAsync(id);
            if (asesor != null)
            {
                _context.Asesores.Remove(asesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
