namespace EYCD05092024ConJWT.Endpoints
{
    //Declara una clase esstatica llamada TestEndpoint".
    public static class TestEndpoint
    {
        //Crea una lista estatica llamada 'data' para
        // almacenar objetos de forma persistente en la aplicacion.
        static List<object> data = new List<object>();

        //Define un metodo publico y estatico llamado 
        //"AddTestEndPoint" que extiende la clase "WebAplication".
        
        public static void AddTestEndPoint (this WebApplication app)
        {
            //Mapea una ruta GET "/test".
            app.MapGet("/test", () =>
            {
                //Devuelve los datos almacenados en la lista 
                // 'data' como respuesta a una solicitud GET 
                return data;
            }).AllowAnonymous();  //Peermite el acceso sin requerir autenticacion para esta ruta

            //Mapea una ruta POST "/test" que acepte dos parametros: "name" y "lastName".
            app.MapPost("/test", (string name, string lastName) =>
            {
                //Agrega un nuevo objeto anonimo con 'name' y 'lastName' 
                //a la lista 'data' en respuesta a una solicitud POST.
                data.Add(new { name, lastName });

                //Devuelve una respuesta HTTP exitosa (200) Ok 
                // para indicar que la operacion se ha completado con exito.
                return Results.Ok();
            }).AllowAnonymous(); //permite el acceso sin requerir autenticacion par esta ruta

            //mapea la ruta DELETE "/test"
            app.MapDelete("/test", () =>
            {
                //Elimina todos los datos en la lista 'data' 
                // en respuesta a una solicitud DELETE (solo si el usuario esta autenticado).
                data = new List<object>();

                //Devuelve una respuesta HTTP exitosa (200 Ok)
                //para indicar que la operacion se ha completado con exito
                return Results.Ok();
            }).RequireAuthorization(); //requiere que el usuario este autenticado
                                      //para acceder a esta ruta, ya que es una operacion sensible.
            
        }
    }
}
