using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcTest.Controllers
{
    public class HolaController : Controller
    {
        //
        // GET: /Hola/

        public ActionResult Index()
        {
           return View();
           // return Content("Holi mdfk!!!!");
        }
        [HttpPost]
        public JsonResult setData(Form form)
        {
            try
            {
                string strcxn = ConfigurationManager.ConnectionStrings["BibliotecaConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(strcxn);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertBook";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection;
                cmd.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = form.Nombre.ToString();
                cmd.Parameters.Add("@autor", SqlDbType.NVarChar).Value = form.Autor.ToString();
                cmd.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = form.ISBN.ToString();
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = form.Comentarios.ToString();
                sqlConnection.Open();
                cmd.ExecuteScalar();
                sqlConnection.Close();
                JsonResult jsonr = new JsonResult { Data = "true", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return jsonr;
            }
            catch (Exception ex) {
                JsonResult jsonr = new JsonResult { Data = ex.ToString(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return jsonr;     
            }
        }

    }
    public class Form {
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Comentarios { get; set; }
    
    }
}
