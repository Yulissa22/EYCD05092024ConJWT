namespace EYCD05092024ConJWT.Auth
{
    //Interfaz para un servicio de autenticacion JWT
    public interface IJwtAuthenticationService
    {
        //Metodo para aumentar al usuario y generar un token JWT
        string Authenticate(string userNmae); 
    }
}
