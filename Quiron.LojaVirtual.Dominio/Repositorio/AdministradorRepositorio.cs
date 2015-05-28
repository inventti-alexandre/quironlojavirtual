using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class AdministradorRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public Administrador ObterAdministrador(Administrador administrador)
        {
            return _context.Administrador.FirstOrDefault(a => a.Login == administrador.Login);
        }
    }
}
