//Importar el espacio de nombres ""AutenticacionJWTMinimalAPI.Auth"
// para poder usar sus clases y tipos
using EYCD05092024ConJWT.Auth;

namespace EYCD05092024ConJWT.Endpoints
{
    public static class AccountEndpoint
    {
        //Declara una clase estatica llamada "AccountEndpoint"
        //"AddAccountEndpoints" que extiende la clase "WebAplication".

        public static void AddAccountEndpoints(this WebApplication app)
        {
            //Asosia una ruta "/acount/login" en el metodo POST con una funcion llamada que
            //toma tres parametros: "login", "password" y authService".
            //este es un ejemplo de como utilizar el servicio de autenticacion (authService) inyectado.
            //puedes usar authService para realizar operaciones relacionadas con la autenticacion.
            //por ejemplo, autenticar al usuario y generar un token JWT.
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {
                //comprueba si las credenciales de inicio de sesion 
                //son validas (en este caso, si el usuario es "admin" y la credencial es "12345")
                if (login == "admin" && password == "12345")
                {
                    //Si las credenciales son validas, autentica al usuario 
                    //utilizando el servicio de autenticacion JWT y obtiene un token.
                    var token = authService.Authenticate(login);

                    //Devuelve una respuesta HTTP OK (200) con el token JWT como resultado.
                    return Results.Ok(token);
                }
                else
                {
                    //si las credenciales no son validas, 
                    //devuelve una respuesta HTTP Unauthorized (401).
                    return Results.Unauthorized();
                }
            });
        }
    }
}
