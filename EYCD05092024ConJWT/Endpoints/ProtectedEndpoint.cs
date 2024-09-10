namespace EYCD05092024ConJWT.Endpoints
{
    //Declara una clase estatica llamada "ProtectedEndpoint"
    public static class ProtectedEndpoint
    {
        //Crea una lista estatica llamada 'data' para almacemar objetos
        //de forma persistente en la aplicacion
        static List<object> data = new List<object>();

        //Define un metodo publico y estatico llamado ""AddProtectedEndpoints"
        //que extiende la clase "WebAplication"
        public static void AddProtectedEndpoints(this WebApplication app)
        {
            //Mapea una ruta GET "/protected".
            app.MapGet("/protected", () =>
            {
                //Devuelve los datos almacenados en la lita 'data' como
                // respuesta a una solicitud GET 
                return data;
            }).RequireAuthorization(); //requiere que el usuario este autenticado para acceder a esta ruta 

            //Mapea una ruta POST "/protected" que acepta dos parametros "name" y "lastName"
            app.MapPost("/protected", (string name, string lastNmae) =>
            {
                //Agrega un nuevo objeto anonimo con 'name' y 'lastName' a la 
                //lista 'data' en respusta a una solicitud POST 
                data.Add(new { name, lastNmae });

                //Devuelve una respuesta HTTP exitosa (200 Ok) para indicar que 
                //la operacion se ha completado con exito.
            }).RequireAuthorization(); //requiere que el usario este autenticado para acceder a esta ruta.
        }
    }
}
