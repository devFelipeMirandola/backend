using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using reposbackend.Business.Interface;

namespace reposbackend.Business.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IJWTService _jwtService;
        private readonly Context _context;

        public AutenticacaoService(IJWTService _jwtService
        , Context _context)
        {
            this._jwtService = _jwtService ?? throw new ArgumentNullException(nameof(_jwtService));
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<string> RecuperarToken(string login, string senha){
            try{
                var usuario = await _context.Usuario
                .Where(w => w.Login == login)
                .FirstOrDefaultAsync();

                if(usuario is null)
                { 
                    throw new Exception($"Usuário {login} não cadastrado.");
                }
                else {

                    if(!usuario.Ativo) { throw new Exception($"Usuário {login} possúi restrições de acesso."); }
                    
                    if(usuario.Senha == senha)
                    {
                        var dados = TokenService.GenerateToken(login);
                        return dados;
                    }
                    else{
                        var tentativas = usuario.Tentativas;
                        if(tentativas > 3)
                        {
                            usuario.Ativo = false;
                            await _context.SaveChangesAsync();
                            throw new Exception($"Tentativas excedidas - usuário {login} bloqueado.");
                        }
                        else{
                            throw new Exception($"Senha incorreta - Tentativa {tentativas} de 3");
                        }
                    }
                }
            }
            catch(Exception ex)
            { throw ex; }
        }

        public IEnumerable<Claim> GetClaimProfilePropertys(TokenValidatedContext tvc)
        {
            ClaimsIdentity secondIdentity = new();

            secondIdentity.AddClaim(new Claim("InternalUser", "InternalUser", ClaimValueTypes.String));

            return secondIdentity.Claims;
        }
    }
}