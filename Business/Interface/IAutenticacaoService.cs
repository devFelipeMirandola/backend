using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reposbackend.Business.Interface
{
    public interface IAutenticacaoService
    {
        Task<string> RecuperarToken(string login, string senha);
    }
}