using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Citas.Administrador.Modelos;

namespace WebApi.Citas.Administrador.DAL
{
    public class AsesoresDisponibilidadRepository
    {
        private readonly BDConexion _context;

        public AsesoresDisponibilidadRepository(BDConexion context)
        {
            _context = context;
        }

        // Get all records
        public async Task<List<AsesoresDisponibilidadModel>> GetAllAsync()
        {
            return await _context.AsesoresDisponibilidad.ToListAsync();
        }

        // Get a single record by ID
        public async Task<AsesoresDisponibilidadModel> GetByIdAsync(int id)
        {
            return await _context.AsesoresDisponibilidad.FindAsync(id);
        }

        // Add a new record
        public async Task<bool> AddAsync(AsesoresDisponibilidadModel disponibilidad)
        {
            try
            {
                await _context.AsesoresDisponibilidad.AddAsync(disponibilidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update an existing record
        public async Task<bool> UpdateAsync(AsesoresDisponibilidadModel disponibilidad)
        {
            try
            {
                _context.AsesoresDisponibilidad.Update(disponibilidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete a record by ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var disponibilidad = await _context.AsesoresDisponibilidad.FindAsync(id);
                if (disponibilidad == null)
                {
                    return false;
                }
                _context.AsesoresDisponibilidad.Remove(disponibilidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

