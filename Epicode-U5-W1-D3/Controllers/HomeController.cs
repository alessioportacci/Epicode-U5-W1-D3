using Epicode_U5_W1_D3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Epicode_U5_W1_D3.Controllers
{
    public class HomeController : Controller
    {

        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDb"].ConnectionString.ToString());

        public ActionResult Index()
        {
            conn.Open();    
            List<ProdottoModel> list = new List<ProdottoModel>();

            SqlDataReader sqlDataReader = new SqlCommand("SELECT * FROM T_Prodotti", conn).ExecuteReader();
            while (sqlDataReader.Read())
                list.Add(new ProdottoModel 
                            { 
                                Nome = sqlDataReader["Nome"].ToString(),
                                Prezzo = Double.Parse(sqlDataReader["Prezzo"].ToString()),
                                Descrizione = sqlDataReader["Descrizione"].ToString(),
                                Img1 = sqlDataReader["Img1"].ToString(),
                                Img2 = sqlDataReader["Img2"].ToString(),
                                Img3 = sqlDataReader["Img3"].ToString(), 
                                Visibile = Boolean.Parse(sqlDataReader["Visibile"].ToString())
                            });

            conn.Close();
            return View(list);
        }


        [HttpGet]
        public ActionResult AggiungiProdotto() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiProdotto(ProdottoModel prodotto)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO T_Prodotti VALUES(@Nome, @Prezzo, @Descrizione, @Img1, @Img2, @Img3, @Visibile)";

            cmd.Parameters.AddWithValue("Nome", prodotto.Nome);
            cmd.Parameters.AddWithValue("Prezzo", prodotto.Prezzo);
            cmd.Parameters.AddWithValue("Descrizione", prodotto.Nome);
            cmd.Parameters.AddWithValue("Img1", prodotto.Nome);
            cmd.Parameters.AddWithValue("Img2", prodotto.Nome);
            cmd.Parameters.AddWithValue("Img3", prodotto.Nome);
            cmd.Parameters.AddWithValue("Visibile", prodotto.Visibile);

            cmd.ExecuteNonQuery();
            conn.Close();

            return View();
        }


    }
}