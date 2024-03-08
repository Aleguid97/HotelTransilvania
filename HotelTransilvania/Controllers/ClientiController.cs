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
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Clienti (CodFisc, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodFisc, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Output di debug per verificare i dati inseriti

                            command.Parameters.AddWithValue("@CodFisc", clienti.CodFisc);
                            command.Parameters.AddWithValue("@Cognome", clienti.Cognome);
                            command.Parameters.AddWithValue("@Nome", clienti.Nome);
                            command.Parameters.AddWithValue("@Citta", clienti.Citta);
                            command.Parameters.AddWithValue("@Provincia", clienti.Provincia);
                            command.Parameters.AddWithValue("@Email", clienti.Email);
                            command.Parameters.AddWithValue("@Telefono", clienti.Telefono);
                            command.Parameters.AddWithValue("@Cellulare", clienti.Cellulare);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                        }
                    }

                    return RedirectToAction("Create", "Clienti");
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore SQL: {ex.Message}");
                    return View(ex.Message); // Puoi creare una vista specifica per gli errori
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Errore generale: {ex.Message}");
                    return View("Error");

                }


            }
            else
            {
                return View("Create", clienti);
            }

        }

        [HttpGet]
        public ActionResult ListaClienti()
        {
            List<Clienti> clienti = new List<Clienti>();

            string connectionString = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clienti";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Clienti cliente = new Clienti();
                            cliente.IdCliente = reader.GetInt32(0);
                            cliente.CodFisc = reader.GetString(1);
                            cliente.Cognome = reader.GetString(2);
                            cliente.Nome = reader.GetString(3);
                            cliente.Citta = reader.GetString(4);
                            cliente.Provincia = reader.GetString(5);
                            cliente.Email = reader.GetString(6);
                            cliente.Telefono = reader.GetString(7);
                            cliente.Cellulare = reader.GetString(8);
                            clienti.Add(cliente);
                        }
                    }
                }
            }

            return View(clienti);
        }
        
        
        [HttpGet]
        public ActionResult Dettagli(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Clienti");
            }

            List<Clienti> cliente = new List<Clienti>();
            string connectionString = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Clienti WHERE IdCiente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdCliente", id.Value);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Clienti d = new Clienti();
                        d.IdCliente = Convert.ToInt16(reader["IdCliente"]);
                        d.Nome = reader["Nome"].ToString();
                        d.Cognome = reader["Cognome"].ToString();
                        d.CodFisc = reader["CodFisc"].ToString();
                        d.Citta = reader["Citta"].ToString();
                        d.Provincia = reader["Provincia"].ToString();
                        d.Email = reader["Email"].ToString();
                        d.Telefono = reader["Telefono"].ToString();
                        d.Cellulare = reader["Cellulare"].ToString();

                        cliente.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Errore: " + ex.Message);
                    return View("Error");
                }
                finally
                {
                    conn.Close();
                }
            }

            return View(cliente);
        }
    }
}