using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaLogin.DAL;

namespace SistemaLogin.BLL
{
    public class buscaCpfBo
    {
        montarGridDao _montaGridDao = new montarGridDao();
        public DataTable MontaGridUser(string cpf) { return _montaGridDao.MontaGridUser(cpf); }
    }
}
