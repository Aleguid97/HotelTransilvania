using HotelTransilvania.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelTransilvania.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class PrenotazioneController : Controller
    {
        // GET: Prenotazione
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Prenotazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prenotazione(Prenotazione prenotazioni)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Prenotazione (DataPrenotazione, DataCheckIn, DataCheckOut, Anticipo, Nome, Cognome, IdTipoPrenotazione, IdCliente, IdCamera, IdServizio, Descrizione, Prezzo) VALUES (@DataPrenotazione, @DataCheckIn, @DataCheckOut, @Anticipo, @Nome, @Cognome, @IdTipoPrenotazione, @IdCliente, @IdCamera, @IdServizio, @Descrizione, @Prezzo)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DataPrenotazione", prenotazioni.DataPrenotazione);
                            command.Parameters.AddWithValue("@DataCheckIn", prenotazioni.DataCheckIn);
                            command.Parameters.AddWithValue("@DataCheckOut", prenotazioni.DataCheckOut);
                            command.Parameters.AddWithValue("@Anticipo", prenotazioni.Anticipo);
                            command.Parameters.AddWithValue("@Nome", prenotazioni.Nome);
                            command.Parameters.AddWithValue("@Cognome", prenotazioni.Cognome);
                            command.Parameters.AddWithValue("@IdTipoPrenotazione", prenotazioni.IdTipoPrenotazione);
                            command.Parameters.AddWithValue("@IdCliente", prenotazioni.IdCliente);
                            command.Parameters.AddWithValue("@IdCamera", prenotazioni.IdCamera);
                            command.Parameters.AddWithValue("@IdServizio", prenotazioni.IdServizio);
                            command.Parameters.AddWithValue("@Descrizione", prenotazioni.Descrizione);
                            command.Parameters.AddWithValue("@Prezzo", prenotazioni.Prezzo);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    return RedirectToAction("Prenotazione", "Prenotazione");
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore SQL: {ex.Message}");
                    return View(ex.Message);
                }

            }
            else
            {
                return View("Create", prenotazioni);
            }
        }

        public ActionResult ListaPrenotazioni()
        {
            List<Prenotazione> prenotazioni = new List<Prenotazione>();

            string connectionString = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Prenotazione";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prenotazione prenotazione = new Prenotazione
                            {
                                IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]),
                                DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]),
                                DataCheckIn = Convert.ToDateTime(reader["DataCheckIn"]),
                                DataCheckOut = Convert.ToDateTime(reader["DataCheckOut"]),
                                Anticipo = Convert.ToDecimal(reader["Anticipo"]),
                                Nome = reader["Nome"].ToString(),
                                Cognome = reader["Cognome"].ToString(),
                                IdTipoPrenotazione = Convert.ToInt32(reader["IdTipoPrenotazione"]),
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                IdCamera = Convert.ToInt32(reader["IdCamera"]),
                                IdServizio = Convert.ToInt32(reader["IdServizio"]),
                                Descrizione = reader["Descrizione"].ToString(),
                                Prezzo = Convert.ToInt16(reader["Prezzo"])
                            };

                            prenotazioni.Add(prenotazione);
                        }
                    }
                }
            }

            return View(prenotazioni);
        }
    }
}