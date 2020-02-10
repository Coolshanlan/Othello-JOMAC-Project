using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace 失智預警系統
{
    class sqlclass
    {
        MySqlConnection sqlcon = new MySqlConnection(@"datasource=localhost;username=root;password=");
        public void Wrong_Insert(string Chess_ID , string Wrong_ID )
        {
            sqlcon.Open();
            MySqlCommand sqlcom = new MySqlCommand("INSERT INTO lar_lan.wrong(`Chess_ID`, `Wrong_ID`, `DateTime`) VALUES ('"+Chess_ID+"','"+Wrong_ID+"','NULL')", sqlcon);
            sqlcom.Connection = sqlcon;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        public DataTable CheckPlayer(string Player_ID , string Caregiver_ID)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("select * from lar_lan.player where ID = '"+Player_ID+ "' and Caregiver_ID = '" + Caregiver_ID+"'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public DataTable Player_search(string Caregiver_ID)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("select * from lar_lan.player where Caregiver_ID = '" + Caregiver_ID + "'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public DataTable CheckCaregiver(string account, string password)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("SELECT * from lar_lan.caregiver where `Account` = '" + account + "' and `Password` = '" + password + "'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public void Done_Game(string User_ID, int win, int time, int wrong, string date, int ai_mode, int done, int remember)
        {
            sqlcon.Open();
            MySqlCommand sqlcom = new MySqlCommand("INSERT INTO lar_lan.chess(`Player_ID`, `Win`, `Time`, `Wrong`, `Date`, `AI_Mode`, `Done`, `Remember`) VALUES ('" + User_ID + "','" + win + "','" + time + "','" + wrong + "','" + date + "','" + ai_mode + "','" + done + "','" + remember + "')", sqlcon);
            sqlcom.Connection = sqlcon;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        public DataTable ToTable(string Comment)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter(Comment, sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public DataTable Next_Game(int Player_ID, string Date, string period)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("UPDATE  lar_lan.reservation SET `Next_Date`='" + Date + "',`Period`='" + period + "' WHERE `Player_ID` = '" + Player_ID + "'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public DataTable chess_search(string ID)
        { 
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("select * from lar_lan.chess where `Player_ID` = '"+ID+"'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
        public DataTable wrong_search(string Chess_ID)
        {
            sqlcon.Open();
            MySqlDataAdapter sqla = new MySqlDataAdapter("select * from lar_lan.wrong where `Chess_ID` = '" + Chess_ID + "'", sqlcon);
            DataTable dt = new DataTable();
            sqla.Fill(dt);
            sqlcon.Close();
            return dt;
        }
    }
}
