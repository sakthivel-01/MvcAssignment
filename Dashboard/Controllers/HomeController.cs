using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection _connection;

        public HomeController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }
        public ActionResult Index()
        {
            List<Products> products = new List<Products>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_ProductDetail", _connection);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products
                    {
                        Id = (int)reader["Id"],
                        ProductName = reader["Product_Name"].ToString(),
                        Amount = (int)reader["Amount"],
                        PurchaseDate = (DateTime)reader["Purchase_Date"],
                        Customer = reader["Customer_Name"].ToString(),
                        Place= reader["Place"].ToString(),
                        PaidStatus= reader["Paid_Status"].ToString()
                    });
                }
                return View(products);
            }
            catch (Exception)
            {
                return View(products);
            }
            finally { _connection.Close(); }
        }

        public ActionResult Statistics()
        {
            Statistics statistics = new Statistics();
            try
            {
                _connection.Open();
                //Geting count for day
                SqlCommand cmdDay = new SqlCommand(" SELECT COUNT(Id) FROM tbl_ProductDetail " +
                    "WHERE CAST(Purchase_Date AS DATE) = CAST(getdate() AS DATE )", _connection);
                statistics.Today = (int)cmdDay.ExecuteScalar();

                SqlCommand cmdMonth = new SqlCommand("  SELECT COUNT(Id) from tbl_ProductDetail" +
                    " where DATEPART(MONTH,Purchase_Date) = DATEPART(MONTH, GETDATE());", _connection);
                statistics.ThisMonth = (int)cmdMonth.ExecuteScalar();

                SqlCommand cmdYear = new SqlCommand(" SELECT COUNT(Id) from tbl_ProductDetail " +
                    "WHERE DATEPART(YEAR,Purchase_Date) = DATEPART(YEAR, GETDATE())", _connection);
                statistics.ThisYear = (int)cmdYear.ExecuteScalar();


                return View(statistics);

            }
            catch (Exception)
            {
                return View(statistics);
            }
            finally { _connection.Close(); }
        }

        public ActionResult DaySale()
        {
            List<Products> products = new List<Products>();
            try
            {
                SqlCommand cmd = new SqlCommand("  select * from tbl_ProductDetail " +
                    "where Cast(Purchase_Date as date) = cast(getdate() as date)", _connection);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products
                    {
                        Id = (int)reader["Id"],
                        ProductName = reader["Product_Name"].ToString(),
                        Amount = (int)reader["Amount"],
                        PurchaseDate = (DateTime)reader["Purchase_Date"],
                          Customer = reader["Customer_Name"].ToString(),
                        Place = reader["Place"].ToString(),
                        PaidStatus = reader["Paid_Status"].ToString()
                    });
                }
                return View(products);
            }
            catch (Exception)
            {
                return View(products);
            }
            finally { _connection.Close(); }
        }

        public ActionResult MonthSale()
        {
            List<Products> products = new List<Products>();
            try
            {
                SqlCommand cmd = new SqlCommand("  SELECT * from tbl_ProductDetail " +
                    "where DATEPART(MONTH,Purchase_Date) = DATEPART(MONTH, GETDATE())", _connection);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products
                    {
                        Id = (int)reader["Id"],
                        ProductName = reader["Product_Name"].ToString(),
                        Amount = (int)reader["Amount"],
                        PurchaseDate = (DateTime)reader["Purchase_Date"],
                        Customer = reader["Customer_Name"].ToString(),
                        Place = reader["Place"].ToString(),
                        PaidStatus = reader["Paid_Status"].ToString()
                    });
                }
                return View(products);
            }
            catch (Exception)
            {
                return View(products);
            }
            finally { _connection.Close(); }
        }

        public ActionResult YearSale()
        {
            List<Products> products = new List<Products>();
            try
            {
                SqlCommand cmd = new SqlCommand("  SELECT * from tbl_ProductDetail" +
                    " WHERE DATEPART(YEAR,Purchase_Date) = DATEPART(YEAR, GETDATE())", _connection);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products
                    {
                        Id = (int)reader["Id"],
                        ProductName = reader["Product_Name"].ToString(),
                        Amount = (int)reader["Amount"],
                        PurchaseDate = (DateTime)reader["Purchase_Date"],
                        Customer = reader["Customer_Name"].ToString(),
                        Place = reader["Place"].ToString(),
                        PaidStatus = reader["Paid_Status"].ToString()
                    });
                }
                return View(products);
            }
            catch (Exception)
            {
                return View(products);
            }
            finally { _connection.Close(); }

        }
    }
}