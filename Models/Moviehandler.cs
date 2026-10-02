using movie_booking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
{
    public class Moviehandler
    {
        public SqlConnection con;

        public SqlConnection Connection()
        {
            string conn = ConfigurationManager.ConnectionStrings["movie"].ConnectionString;
            return new SqlConnection(conn);
        }

        // ADD CATEGORY
        public bool Add_Movie_category(Movie_Category mc)
        {
            con = Connection();

            SqlCommand cmd = new SqlCommand("Add_Movie_category", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Cat_Type", mc.Cat_Type);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // DISPLAY CATEGORY
        public List<Movie_Category> Get_Movie_Category()
        {
            List<Movie_Category> list = new List<Movie_Category>();

            con = Connection();

            SqlCommand cmd = new SqlCommand("Get_Movie_Category", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Movie_Category mc = new Movie_Category();

                mc.Cat_ID = Convert.ToInt32(dr["Cat_ID"]);
                mc.Cat_Type = dr["Cat_Type"].ToString();

                list.Add(mc);
            }

            con.Close();

            return list;
        }

        // ADD MOVIE
        public bool Add_Movie(Movie m)
        {
            con = Connection();

            SqlCommand cmd = new SqlCommand("Add_Movie", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Movie_name", m.Movie_name);
            cmd.Parameters.AddWithValue("@Release_Date", m.Release_Date);
            cmd.Parameters.AddWithValue("@Cat_ID", m.Cat_ID);
            cmd.Parameters.AddWithValue("@rate", m.rate);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // DISPLAY ALL MOVIES
        public List<Movie> Get_All_Movies()
        {
            List<Movie> list = new List<Movie>();

            con = Connection();

            SqlCommand cmd = new SqlCommand("Get_All_Movies", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Movie m = new Movie();

                m.Movie_ID = Convert.ToInt32(dr["Movie_ID"]);
                m.Movie_name = dr["Movie_name"].ToString();
                m.Release_Date = dr["Release_Date"].ToString();
                m.Cat_ID = Convert.ToInt32(dr["Cat_ID"]);
                m.Cat_Type = dr["Cat_Type"].ToString();
                m.rate = Convert.ToInt32(dr["rate"]);

                list.Add(m);
            }

            con.Close();

            return list;
        }

        // DISPLAY MOVIES BY CATEGORY
        public List<Movie> Get_Movies_By_Category(int Cat_ID)
        {
            List<Movie> list = new List<Movie>();

            con = Connection();

            SqlCommand cmd = new SqlCommand("Get_Movies_By_Category", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Cat_ID", Cat_ID);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Movie m = new Movie();

                m.Movie_ID = Convert.ToInt32(dr["Movie_ID"]);
                m.Movie_name = dr["Movie_name"].ToString();
                m.Release_Date = dr["Release_Date"].ToString();
                m.Cat_ID = Convert.ToInt32(dr["Cat_ID"]);
                m.Cat_Type = dr["Cat_Type"].ToString();
                m.rate = Convert.ToInt32(dr["rate"]);

                list.Add(m);
            }

            con.Close();

            return list;
        }
        public bool Add_Booking(booking b)
        {
            con = Connection();

            SqlCommand cmd =
                new SqlCommand("Add_Booking", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@User_ID",
                b.User_ID
            );

            cmd.Parameters.AddWithValue(
                "@Cat_ID",
                b.Cat_ID
            );

            cmd.Parameters.AddWithValue(
                "@Movie_ID",
                b.Movie_ID
            );

            cmd.Parameters.AddWithValue(
                "@no_tickets",
                b.no_tickets
            );

            cmd.Parameters.AddWithValue(
                "@amount",
                b.amount
            );

            con.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<booking> Get_All_Bookings()
        {
            List<booking> list = new List<booking>();

            con = Connection();

            SqlCommand cmd = new SqlCommand(
                "Get_All_Bookings",
                con
            );

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                booking b = new booking();

                b.booking_id = Convert.ToInt32(dr["booking_id"]);

                b.User_ID = Convert.ToInt32(dr["User_ID"]);

                b.Cat_ID = Convert.ToInt32(dr["Cat_ID"]);

                b.Movie_ID = Convert.ToInt32(dr["Movie_ID"]);

                b.Movie_name = dr["Movie_name"].ToString();

                b.Cat_Type = dr["Cat_Type"].ToString();

                b.no_tickets = Convert.ToInt32(dr["no_tickets"]);

                b.amount = Convert.ToInt32(dr["amount"]);

                list.Add(b);
            }

            con.Close();

            return list;
        }
        // USER LOGIN
        public User User_Login(User user)
        {
            User loggedUser = null;

            con = Connection();

            SqlCommand cmd = new SqlCommand(
                "User_Login",
                con
            );

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@User_Name",
                user.User_Name
            );

            cmd.Parameters.AddWithValue(
                "@User_password",
                user.User_password
            );

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                loggedUser = new User();

                loggedUser.User_ID =
                    Convert.ToInt32(dr["User_ID"]);

                loggedUser.User_Name =
                    dr["User_Name"].ToString();

                loggedUser.Email_ID =
                    dr["Email_ID"].ToString();

                loggedUser.City =
                    dr["City"].ToString();

                loggedUser.PhoneNo =
                    Convert.ToInt32(dr["PhoneNo"]);
            }

            con.Close();

            return loggedUser;
        }
    }
}