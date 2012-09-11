using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KartingApp.Domain.Abstract;
using KartingApp.Domain.Entities;
using KartingApp.Domain.Concrete;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace TestApp.WebUI.Controllers
{
    public class DriverController : Controller
    {
        private IDriverRepository repository;

        public DriverController()
        {
            repository = new EFDriverRepository();
        }

        public ViewResult List()
        {
            return View(repository.Drivers);
        }

        public ViewResult Test()
        {
            MySqlConnection conn;
            conn = null;
            string myConnectionString;

            myConnectionString = "server=58012422-1aa5-46aa-9e2e-a0bd00f552e2.mysql.sequelizer.com;database=db580124221aa546aa9e2ea0bd00f552e2;uid=oisfyfzfrlktdouh;pwd=5o8Wpvry3BozmVvjwyTrTys2GqRKxLJ4tHSxcT2mctsD6Ca3fpxSVDEE5gp7MNbp";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                ViewBag.Response = "OK";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                ViewBag.Response = ex.Message;
            }

            MySqlCommand sql = new MySqlCommand("select DriverID from Drivers order by DriverID desc", conn);
            ViewBag.Response = sql.ExecuteScalar();

            conn.Close();

            return View(repository.Drivers);
        }
    }
}
