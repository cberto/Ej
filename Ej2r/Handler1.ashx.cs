using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


namespace Ej2r
{
    /// <summary>
    /// Descripción breve de Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
     
        public void ProcessRequest(HttpContext context)
        {
            string jsonDevolucion;
            try
            {
             /*   string nombre = context.Request["parametro1"].ToString();
                string apellido = context.Request["parametro2"].ToString();
                string saludo = "Hola " + nombre + " " + apellido + "!!!";

                context.Response.ContentType = "text/plain";
                context.Response.Write(saludo);
               */

                string jsonRecibido = context.Request["jsonData"].ToString();
                var serializer = new JavaScriptSerializer();
                dynamic result = serializer.DeserializeObject(jsonRecibido);

                string nombre = result["nombre"];													
                int edad = int.Parse(result["edad"]);
                int dni = int.Parse(result["dni"]);
                string email = result["email"];	

                jsonDevolucion = "{";
                jsonDevolucion += "\"nombre\" : \"" + nombre + "\", ";
                jsonDevolucion += "\"nombre\" : \"" + edad + "\", ";
                jsonDevolucion += "\"dni\" : \"" + dni + "\", ";
                jsonDevolucion += "\"email\" : \"" + email + "\", ";
	            

                if (edad > 18)
                    jsonDevolucion +="\"mensajeEdad\" : \"La edad es correcta\", ";

                else
                    jsonDevolucion += "\"mensajeEdad\" : \"La edad es menor a 19\", ";

                if(dni <= 9999999 && dni >= 10000000){
                  Console.WriteLine ("'DNI correcto,");
                }else
                    Console.WriteLine("'DNI correcto',");

                jsonDevolucion += "}";
                //context.Response.Write(jsonDevolucion);

                
              if(email.Contains("@gmail.com") || email.Contains("@hotmail.com"))
                  Console.WriteLine ("'Email correcto',");
              else 
                  Console.WriteLine("'Email incorrecto',");
            }
             

            catch (Exception ex)
            {
                jsonDevolucion = "{ 'mensajeRespuesta' : 'Ocurrio un error inesperado.' }";
            }
            jsonDevolucion = jsonDevolucion.Replace("'", "\""); //Cambiamos las comillas simples ' por comillas dobles " | Formato final: { "nombre" : "Carlos", "edad" : "18" }
            context.Response.Write(jsonDevolucion);				//Devolvemos el JSON al JS.
        }
    



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
  
}