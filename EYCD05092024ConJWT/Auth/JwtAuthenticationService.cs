//Directiva para trabajar con tokens y su validacion en JSON Tokens (JWT)
using Microsoft.IdentityModel.Tokens;

//Directiva para manejar la creacion y manipulacion de tokens JWT
using System.IdentityModel.Tokens.Jwt;

//Directiva para definir y trabajar con reclamaciones de identidad del usuario 
using System.Security.Claims;

//Directiva para trabajr con codificacion de texto y bytes
using System.Text;

namespace EYCD05092024ConJWT.Auth
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string _key;
        public JwtAuthenticationService(string key) 
        {
            _key = key;
        }

        //Metodo para autenticar al usuario y generar un token JWT 
        public string Authenticate (string username)
        {
            //Crear un manejador de tokens JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            //Convertir la clave en bytes utilizando codificacion ASCII
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            //Configurar la informacion del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Definir la identidad del token con el nombre del usuario 
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                //Establecer la fecha de vencimiento (8 horas desde ahora)
                Expires = DateTime.UtcNow.AddHours(8),

                //Configurar la clave de firma y el algoritmo de firma 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };

            //Crear el token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Escribir el token como una cadena y devolverlo
            return tokenHandler.WriteToken(token);
        }
    }
}
