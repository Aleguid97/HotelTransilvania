using HotelTransilvania.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace HotelTransilvania.Controllers
{
    public class DettagliController : Controller
    {
        // GET: Dettagli
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dettagli()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dettagli(int id)
        {
            List<Dettagli> dettagli = new List<Dettagli>();
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Clienti.Nome AS NomeCliente,
                            Clienti.Cognome AS CognomeCliente,
                            Camere.Descrizione AS DescrizioneCamera,
                            Servizio.Descrizione AS DescrizioneServizio,
                            SUM(Servizio.Prezzo) AS TotalePrezzoServizi
                        FROM
                            Prenotazioni
                        INNERJOIN
                            Clienti ON Prenotazioni.IdCliente = Clienti.IdCliente
                        INNERJOIN
                            Camere ON Prenotazioni.IdCamera = Camere.IdCamera
                        JOIN
                            Servizio ON Prenotazioni.IdServizio = Servizio.IdServizio
                        GROUP BY
                            Clienti.Nome, Clienti.Cognome, Camere.Descrizione, Servizio.Descrizione;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Dettagli d = new Dettagli();
                        d.Nome = reader["NomeCliente"].ToString();
                        d.Cognome = reader["CognomeCliente"].ToString();
                        d.DescrizioneCamera = reader["DescrizioneCamera"].ToString();
                        d.DescrizioneServizio = reader["DescrizioneServizio"].ToString();
                        d.TotalePrezzoServizi = Convert.ToDecimal(reader["TotalePrezzoServizi"]);

                        dettagli.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Errore: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return View(dettagli);
        }
    }
}
